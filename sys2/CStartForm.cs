using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.IO;   

/*these are my personal classes*/
using SystemClasses;
using SystemFunctions;
/*eof*/

using System.Threading;
using System.Security.Cryptography;


namespace sys2

{

    public partial class CStartForm : Form
    {
        protected CShadowService shadow;
        private Thread second; // ????
        private State state;
        private User user;
        private DateTime dt;
        private string path = "connectionstring2.txt";
        private CPatient patient;
        private CStudy study;
        private CProtocol protocol;
        
        public string FileReader(string path)
        {
            StreamReader ds = new StreamReader(path);
            string connectionstring = ds.ReadToEnd();
            ds.Dispose();
            ds.Close();
            return connectionstring;
        }

        /*Проверяет данные введенные пользователем на корректность ввода;
            не учитывает точки в дате;
            не учитывает значность даты;
        */
        bool CheckData(string initials, string birthdate, string sex, string ambnum, string baby)
        {
            char[] dest = { ' ', ' ', ' ', ' ' };
            string day;
            string month;
            string year;
            string prototype = "0123456789/.";
            bool correct;
            
            if ((initials != "") && (birthdate != null) &&(birthdate.Length ==10) && (sex != null) && (ambnum != null) && (baby != null))  // если все поля заполненны
            {
                for (int i = 0; i < ambnum.Length; i++)
                {
                    correct = false;
                    for (int j = 0; j < prototype.Length; j++)
                    {

                        if (ambnum[i] == prototype[j])
                        {
                            correct = true;   // если символ совпал с символом контрольной строки, то переходим к следующему символу строки_на_проверку  -------------------------------------------
                            break;    
                        }
                        else
                        {
                            correct = false;

                        }

                    }
                    if(!correct)
                    {
                        tAmbNum.BackColor = Color.Yellow;
                        return false;
                    }
                }
                birthdate.CopyTo(0, dest, 0, 2);
                day = Convert.ToString(dest[0]);
                day += Convert.ToString(dest[1]);
                if (Convert.ToInt32(day) > 0 && Convert.ToInt32(day) < 32)
                {
                    birthdate.CopyTo(3, dest, 0, 2);
                    month = Convert.ToString(dest[0]);
                    month += Convert.ToString(dest[1]);
                    if (Convert.ToInt32(month) > 0 && Convert.ToInt32(month) < 13)
                    {
                        // условие что год 4х значный ?
                        birthdate.CopyTo(6, dest, 0, 4);
                        year = Convert.ToString(dest[0]);
                        year += Convert.ToString(dest[1]);
                        year += Convert.ToString(dest[2]);
                        year += Convert.ToString(dest[3]);
                        if (Convert.ToInt32(year) > 1900 && Convert.ToInt32(year) < 3000)
                        {
                            return true;
                        }
                        tBirthDate.BackColor = Color.Yellow;
                        return false;


                    }
                    tBirthDate.BackColor = Color.Yellow;
                    return false;


                }
                tBirthDate.BackColor = Color.Yellow;
                return false;
            }
            return false;
        }

        /*Возвращает hash code введеднной строки (MD5)*/
        string CreateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                //sb.Append(hashBytes[i].ToString("X2"));
                // To force the hex string to lower-case letters instead of
                // upper-case, use he following line instead:
                sb.Append(hashBytes[i].ToString("x2")); 
            }
            return sb.ToString();
        }

        /*Проверяет символ кириллицы на соответ ему символ транслита*/
        string CheckSymbol(string sym)
        {
            switch (sym) 
            {
                case "А": { sym = "A"; break; }
                case "Б": { sym = "B"; break; }
                case "В": { sym = "V"; break; }
                case "Г": { sym = "G"; break; }
                case "Д": { sym = "D"; break; }
                case "Е": { sym = "E"; break; }
                case "Ё": { sym = "E"; break; }
                case "Ж": { sym = "J"; break; }
                case "З": { sym = "Z"; break; }
                case "И": { sym = "I"; break; }
                case "Й": { sym = "Y"; break; }   // ?
                case "К": { sym = "K"; break; }
                case "Л": { sym = "L"; break; }
                case "М": { sym = "M"; break; }
                case "Н": { sym = "N"; break; }
                case "О": { sym = "O"; break; }
                case "П": { sym = "P"; break; }
                case "Р": { sym = "R"; break; }
                case "С": { sym = "S"; break; }
                case "Т": { sym = "T"; break; }
                case "У": { sym = "U"; break; }
                case "Ф": { sym = "F"; break; }
                case "Х": { sym = "H"; break; }
                case "Ц": { sym = "C"; break; }
                case "Ч": { sym = "CH"; break; }
                case "Ш": { sym = "SH"; break; }
                case "Щ": { sym = "SCH"; break; }
                case "Ъ": { sym = "'"; break; } // ?
                case "Ы": { sym = "Y"; break; } // ?
                case "Э": { sym = "E"; break; }
                case "Ю": { sym = "YU"; break; }
                case "Я": { sym = "YA"; break; }
                 
            }
            return sym;
        }

        public string TranslateToEnglish(string oldword)
        {
            bool rus=false;
            string sym;
            string newword="";
            string prototypeUpDown="АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            for(int i=0; i<oldword.Length; i++)
            {
                rus=false;
                for (int j = 0; j < prototypeUpDown.Length; j++)
                {
                   
                    if (oldword[i] == prototypeUpDown[j])
                    {
                        sym = oldword[i].ToString();
                        newword += CheckSymbol(sym);
                        rus=true;
                    }
                }
                if(!rus)
                    newword+=oldword[i];
                    
            }

            return newword;
        }

        
        /*Переводит пол пациента в формат БД*/
        public string TranslateSex(string sex) 
        {
            if (sex == "Жен")
                return "F";
            else
                if (sex == "Муж")
                    return "M";
                else
                    return null;
        }

        /*Переводит данные о том явл ли пациент амбулаторным в формат БД*/
        public string TranslateHospital(string amb) 
        {
            {
                if (amb == "Да")
                    return "YES";
                else
                    return "NO";
            }

        }

        /*Переводит данные о том явл ли пациент ребенком в формат БД*/
        public string TranslateChild(string child) 
        {
            if (child == "Да")
                return "YES";
            else
                return "NO";
        }

        public CStartForm()
        {   

            InitializeComponent(); // system function

            tabed_window.SelectedTab = tabPage2;
            user = new User();
            shadow = new CShadowService();

            patient = new CPatient();
            study = new CStudy();
            protocol = new CProtocol();

            patient.initials = new CInitials();
            patient.birth_date = new CBirthDate();

            shadow.win = new MakeaWindowPrm();
            shadow.sql = new SQLDaemon(FileReader(path));
            shadow.box = new CStateBox();
            shadow.box.locker = new object();
            
  
        }

        string TranslateToRusDay(string day_of_week)
        {
            switch(day_of_week)
            {
                case "Sunday":
                {
                    return day_of_week="Воскресенье";
                }
                case "Monday":
                {
                    return day_of_week="Понедельник";
                }
                case "Tuesday":
                {
                    return day_of_week="Вторник";
                }
                case "Wednesday":
                {
                    return day_of_week="Среда";
                }
                case "Thursday":
                {
                    return day_of_week="Четверг";
                }
                case "Friday":
                {
                    return day_of_week="Пятница";
                }
                case "Saturday":
                {
                    return day_of_week="Суббота";
                }
                default:
                {
                    return "неопределенно";
                }
            }
        }

        string TranslateToMonth(int day) 
        {
            switch (day)
            {
                case 1: 
                    {
                        return "Январь";
                    }
                case 2:
                    {
                        return "Февраль";
                    }
                case 3:
                    {
                        return "март";
                    }
                case 4:
                    {
                        return "апрель";
                    }
                case 5:
                    {
                        return "май";
                    }
                case 6:
                    {
                        return "июнь";
                    }
                case 7:
                    {
                        return "июль";
                    }
                case 8:
                    {
                        return "август";
                    }
                case 9:
                    {
                        return "сентябрь";
                    }
                case 10:
                    {
                        return "октябрь";
                    }
                case 11:
                    {
                        return "ноябрь";
                    }
                case 12:
                    {
                        return "декабрь";
                    }
                default: 
                    {
                        return "неопределен";
                    }

            
            }
        }

        /*Открытие вкладки Расписание сопровождается запросом списка пациентов из БД во втором потоке*/
        void tabed_window_SelectedIndexChanged(object sender, System.EventArgs e)
        {
                dt = DateTime.Today;
                
                switch (tabed_window.SelectedTab.Text)
                {
                    case "Расписание":
                        {
                            if (user.login == null || user.role == Role.Undefined || user.role != Role.Administrator)
                            {
                                MessageBox.Show("У вас нет на это прав!");
                                break;

                            }
                            else
                            {

                                state = State.UpdateDataFromDB;
                                shadow.sql.CheckDB(dt);
                                //shadow.autoEvent.Set(); // поток получает билетик  //-------------------------------------------------------------------------------------------------------------
                                SchedulerData.DataSource = shadow.sql.dt;
                               
                                curr_date.Text = TranslateToRusDay(dt.DayOfWeek.ToString());
                                tDay.Text = dt.Day.ToString();
                                tMonth.Text = TranslateToMonth(dt.Month);
                                tYear.Text = dt.Year.ToString();
                                break;
                            }
                        }

                    case "Новый пациент": 
                        {
                            NewtDay.Hide();
                            NewtMonth.Hide();
                            NewtYear.Hide();
                            ntdayl.Hide();
                            ntmonthl.Hide();
                            ntyearl.Hide();

                            if (user.login == null || user.role == Role.Undefined || user.role != Role.Administrator)
                            {
                                MessageBox.Show("У вас нет на это прав!");
                                break;

                            }
                            else 
                            {
                                // Если пользователь администратор
                                if (user.role == Role.Administrator) 
                                {

                                    //То отображаем все поля, которые позволяют нам задать дату исследования
                                    NewtDay.Show();
                                    NewtMonth.Show();
                                    NewtYear.Show();
                                    ntdayl.Show();
                                    ntmonthl.Show();
                                    ntyearl.Show();

                                    NewtDay.Text = dt.Day.ToString();
                                    NewtMonth.Text = TranslateToMonth(dt.Month);
                                    NewtYear.Text = dt.Year.ToString();

                                }
                                break;

                            }
                        }

                }

        }

        void CheckDMY(int chck, int num, int num2) 
        {
            if ((num - num2) == 0) 
            {
                chck = 0;
            }
            if ((num - num2) >  0)
            {
                chck = 1;
            }
            if ((num - num2) <  0)
            {
                chck = -1;
            }
        }
                   
        private void tDay_TextChanged(object sender, EventArgs e)
        {
            /*
            int day2;
            int check=0;
            day2=Convert.ToInt32(tDay.Text.ToString());

            CheckDMY(check,dt.Day,day2);
            //
            if(check == 1)
            {
                dt.AddDays(-(dt.Day-day2));
            }
            if (check == -1)
            {
                dt.AddDays(+(day2-dt.Day ));
            }

             
            */
            if (user.login == null || user.role == Role.Undefined || user.role != Role.Administrator)
            {
                MessageBox.Show("У вас нет на это прав!");

            }
            else
            {
                /*Запрос пациентов на этот день*/
                state = State.UpdateDataFromDB;
                shadow.sql.CheckDB(dt);
                SchedulerData.DataSource = shadow.sql.dt;
            }
        }

        private void tomorrow_Click(object sender, EventArgs e)
        {
            if (user.login == null || user.role == Role.Undefined || user.role != Role.Administrator)
            {
                MessageBox.Show("У вас нет на это прав!");

            }
            else
            {
                dt = dt.AddDays(1);
                curr_date.Text = TranslateToRusDay(dt.DayOfWeek.ToString());
                tDay.Text = dt.Day.ToString();
                tMonth.Text = TranslateToMonth(dt.Month);
                tYear.Text = dt.Year.ToString();


                /*Запрос пациентов на этот день*/
                state = State.UpdateDataFromDB;
                shadow.sql.CheckDB(dt);
                SchedulerData.DataSource = shadow.sql.dt;
            }
        }

        private void yesterday_Click(object sender, EventArgs e)
        {
            if (user.login == null || user.role == Role.Undefined || user.role != Role.Administrator)
            {
                MessageBox.Show("У вас нет на это прав!");

            }
            else
            {
                dt = dt.AddDays(-1);
                curr_date.Text = TranslateToRusDay(dt.DayOfWeek.ToString());
                tDay.Text = dt.Day.ToString();
                tMonth.Text = TranslateToMonth(dt.Month);
                tYear.Text = dt.Year.ToString();

                /*Запрос пациентов на этот день*/
                state = State.UpdateDataFromDB;
                shadow.sql.CheckDB(dt);
                SchedulerData.DataSource = shadow.sql.dt;
            }
        }

        /*Реакция на нажатие кнопки Настройки*/
        private void link_settings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*
            // если у пользователя недостаточно прав на настройку программы
            if (user.login == null || user.role == Role.Undefined || user.role != Role.Administrator)
            {
                MessageBox.Show("У вас нет на это прав!");
            }
             * */
            //else 
            //{
            shadow.win.CreateTestConnectionForm(FileReader(path), path);
            //}
        
        }

        /*Реакция на нажатие кнопки далее при регистрации нового пациента
         * проверка всех введенных данных на корректность
         * передача данных в SQL Daemon
        * */
        private void button_next_Click(object sender, EventArgs e)
        {
            // если у пользователя недостаточно прав на регистрацию пациентов
            if (user.login == null || user.role == Role.Undefined || user.role != Role.Administrator)   // добавить мед персонал------------------------------------------------------------
            {
                MessageBox.Show("У вас нет на это прав!");

            }
            else
            {
               
                
                bool input_is_correct = false;


                if (input_is_correct = CheckData(tInitials.Text, tBirthDate.Text, tSex.Text, tAmbNum.Text, tBaby.Text))  // если все поля были правильно заполненны
                {
                    bool user_exist = false;

                    // переносим значения из textboxes в поля объекта patinet
                    patient.pid = 0;                  
                    patient.amb_card = tAmbNum.Text;

                    patient.initials.surname = TranslateToEnglish(tInitials.Text.ToUpper()); 
                    patient.birth_date.date = tBirthDate.Text;
                    patient.sex = TranslateSex(tSex.Text);
                    patient.is_child = TranslateChild(tBaby.Text);
                    patient.study_ctr = 1;

                    study.pid = 0;
                    study.sid = 0;
                    study.modality = tModality.Text;
                    study.is_hospital = TranslateHospital(tHospital.Text); ;  
                    study.department = tDepartment.Text;
                    study.body = tBody.Text;
                    study.role_id = user.id;     
                    study.study_date = DateTime.Today;

                    protocol.prid = 0;
                    protocol.sid = 0;
                    protocol.text = "..."; // ?????? 


                    if (user.role == Role.Administrator) 
                    {
                        // ---------------------------------------------------------------------------------------------------------Нужна дата для исследования
                    }



                    // Проверка существует ли пользователь
                    user_exist = shadow.sql.CheckUserExist(patient);

                    if (!user_exist)
                    {
                        // Если пользователь не существует, то в БД создается новый
                        shadow.sql.AddPatient(patient);
                        study.pid = patient.pid;
                    }
                    else 
                    {
                        // Дополняем данные существующего пациента
                        shadow.sql.FillPatient(patient);
                        study.pid = patient.pid;
                    }
                    // Заполняем соответствующую таблицу Study
                    shadow.sql.FillStudy(study);  //--------------------------------------------------------------------------------------------------------
                    protocol.sid = study.sid;
                    shadow.sql.FillProtocol(protocol);
              
                    /* то соединить с БД, проверить, есть ли такой пациент, если есть, просто назначить существующшему новую процедуру,
                    * иначе внести нового пациента в БД и присвоить ему уникальный PID */

                    // очистить поля всех textboxes
                    tAmbNum.Clear();
                    tInitials.Clear();
                    tBirthDate.Clear();
                    tInitials.BackColor = Color.White;
                    tBirthDate.BackColor = Color.White;
                    tAmbNum.BackColor = Color.White;
                    tabed_window.SelectedTab = tabPage1; // переключить страницу на Расписание
                    SchedulerData.DataSource = shadow.sql.dt; 
                }
                else
                {
                    /* иначе ничего не происходит либо неправильно заполненные поля выделяются желтым цветом*/
                    tInitials.BackColor = Color.Yellow;
                    tBirthDate.BackColor = Color.Yellow;
                    tAmbNum.BackColor = Color.Yellow;
                }
            }

            
        }

        private void Enter_system_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tUser.Text != null && tPassword.Text != null && tUser.Text != "" && tPassword.Text != "")  // если пользователь ввёл данные
            {
                string hash;
                hash = tPassword.Text;
                hash = CreateMD5Hash(hash);

                user.id = shadow.sql.CheckUserRole(tUser.Text, hash); 

                if(user.id!=0)
                {
                    user.login = tUser.Text;
                    if (user.id == 1)
                    {
                        user.role = Role.Administrator;
                        user.id = 0;
                        guest.Text = "Администратор";
                        guest.ForeColor = Color.Green;


                        /* отображаем все поля для поиска пациента*/
                        sSearch.Visible = true;
                        sInitials.Visible = true;
                        sSex.Visible = true;
                        sBirthDate.Visible = true;
                        sAmbNum.Visible = true;
                        sChild.Visible = true;

                        sIn.Visible = true;
                        sSe.Visible = true;
                        sBi.Visible = true;
                        sAm.Visible = true;
                        sCh.Visible = true;
                    }
                     
                    tUser.Clear();
                    tPassword.Clear();
                }
                else
                //иначе вывести сообщение об ошибке
                 //выделить поля желтым цветом
                {
                    tUser.BackColor = Color.Yellow;
                    tPassword.BackColor = Color.Yellow;
                }
                 
            }
        }

        private void LeaveSystem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            user.login = "";
            user.role = Role.Undefined;
            guest.Text = "Гость";
            guest.ForeColor = Color.OrangeRed;

            /* скрываем все поля для поиска пациента*/
            sSearch.Visible = false;
            sInitials.Visible = false;
            sSex.Visible = false;
            sBirthDate.Visible = false;
            sAmbNum.Visible = false;
            sChild.Visible = false;

            sIn.Visible = false;
            sSe.Visible = false;
            sBi.Visible = false;
            sAm.Visible = false;
            sCh.Visible = false;

        }

        /*Двойное нажатие на пациента в списке пациентов приводит к открытию его протокола*/
        private void SchedulerData_CellContentDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //throw new System.NotImplementedException();
            if (user.login == null || user.role == Role.Undefined && ( user.role != Role.Administrator || user.role != Role.Doctor )/*|| user.role != Role.Registrator || user.role != Role.SuperAdmin*/)
            {
                MessageBox.Show("У вас нет на это прав!");
                
            }
            else
            {
                patient.initials.surname = SchedulerData[0, e.RowIndex].Value.ToString();
                patient.sex = SchedulerData[1, e.RowIndex].Value.ToString();
                patient.birth_date.date = SchedulerData[2, e.RowIndex].Value.ToString();
                patient.amb_card = SchedulerData[3, e.RowIndex].Value.ToString();
                patient.is_child = SchedulerData[4, e.RowIndex].Value.ToString();
                study.modality =   SchedulerData[5, e.RowIndex].Value.ToString(); 
                patient.pid = Convert.ToInt32(SchedulerData[6, e.RowIndex].Value.ToString());

                shadow.box.patient = patient;
                shadow.box.study = study;
                shadow.box.protocol = protocol;
                shadow.box.date = dt;

                shadow.box.protocol.sid = shadow.box.patient.pid;
                
                shadow.sql.RetrieveProtocol(shadow.box);
                shadow.box.protocol.sid = 0;
                shadow.win.CreateProtocolWindow(shadow.box);  // запустили окно
                shadow.box.state = State.WaitForAction; // поставили состояние на ожидание
                second = new Thread(shadow.WorkWithWindows); // запустили метод в новом потоке
                second.Name = "QuickSave";  // дали потоку имя
                second.IsBackground = true;
                second.Start(shadow.box); // передали объект-коробку с необходимыми данными 
                

            }

        }


    }
}