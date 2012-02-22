using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


/*these are mine*/
using SystemClasses;
using SystemFunctions;

using NpgsqlTypes;


namespace sys2
{
    public class SQLDaemon
    {

        private int id;
        private DataSet ds;
        public DataTable dt { set; get; }
        private NpgsqlDataAdapter da;
        private string connstring;
        private NpgsqlConnection conn;
        private string query;

        public SQLDaemon(string connectionstring) 
        {

            this.id = id;
            this.query = "SELECT initials, sex, birth_date, child  FROM Patient";
            ds = new DataSet();
            dt = new DataTable();
            connstring = connectionstring;
            conn = new NpgsqlConnection(connstring);
            da = new NpgsqlDataAdapter(this.query, conn);

        }

        /*Проверяет логин и пароль пользователя на валидность*/
        public int CheckUserRole(string login_in, string hash_in)
        {
            conn.Open();
            int id;
            NpgsqlTransaction t = conn.BeginTransaction();

            /*
            try
            {
               
            }
            catch
            {
                MessageBox.Show("DB exeption");
            }
            finally 
            {
                MessageBox.Show("change your parametres");
            }
             * 
             */
            NpgsqlCommand comm = new NpgsqlCommand("\"CheckUserRole\"", conn);

            NpgsqlParameter login = new NpgsqlParameter("login", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter hash = new NpgsqlParameter("hash", NpgsqlTypes.NpgsqlDbType.Varchar);

            login.Direction = ParameterDirection.Input;
            hash.Direction = ParameterDirection.Input;

            comm.Parameters.Add(login);
            comm.Parameters.Add(hash);
            comm.Parameters[0].Value = login_in;
            comm.Parameters[1].Value = hash_in;

            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                var result = comm.ExecuteScalar();
                id = (int)result;

            }
            finally
            {
                t.Commit();
                conn.Close();
                
              
            }
            return id;
 
        }

        /* извлекает список пациентов за указанную дату, вызов хранимой процедуры*/
        public void SPCheckDB()
        {
            conn.Open();
            NpgsqlTransaction t = conn.BeginTransaction();
            NpgsqlCommand comm = new NpgsqlCommand("\\", conn);
            NpgsqlParameter prm = new NpgsqlParameter("pid", NpgsqlTypes.NpgsqlDbType.Integer);
            prm.Direction = ParameterDirection.Input;
            comm.Parameters.Add(prm);
            comm.Parameters[0].Value = 15;
            comm.CommandType = CommandType.StoredProcedure;
            int pid = 0;

            try
            {
                pid = (int)comm.ExecuteScalar();


            }
            finally
            {
                conn.Close();
            }
        }

        /*Извлекает список пациентов за указанную дату, прямой запрос*/ 
        public void CheckDB(DateTime date)
        {
            this.query = "SELECT Patient.initials, Patient.sex, Patient.birth_date, Patient.amb_card, Patient.child, Study.modality, Patient.patient_id FROM Patient INNER JOIN Study ON Study.patient_id=Patient.patient_id WHERE Study.study_date="+"'"+date.Date.ToString()+"'";
            da.SelectCommand.CommandText = this.query;
                try
                {
                    conn.Open();
                    ds.Reset();
                    da.Fill(ds);
                    dt = ds.Tables[0];   // add to DataGridView.DataSource
                }
                catch (Exception msg)
                {
                    throw;
                }

                finally
                {
                    conn.Close();
                }
        }

        public void AddPatient(CPatient patient)
        {

            conn.Open();
            
            NpgsqlTransaction t = conn.BeginTransaction();
            NpgsqlCommand comm = new NpgsqlCommand("\"CreateUser\"", conn);

            NpgsqlParameter ini = new NpgsqlParameter("ini", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter amb = new NpgsqlParameter("amb", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter sex = new NpgsqlParameter("sex", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter birth = new NpgsqlParameter("birth", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter child = new NpgsqlParameter("child", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter pid = new NpgsqlParameter("pid", NpgsqlTypes.NpgsqlDbType.Integer);
            
            ini.Direction = ParameterDirection.Input;
            amb.Direction = ParameterDirection.Input;
            sex.Direction = ParameterDirection.Input;
            birth.Direction = ParameterDirection.Input;
            child.Direction = ParameterDirection.Input;
            pid.Direction = ParameterDirection.Input;

            comm.Parameters.Add(ini);
            comm.Parameters.Add(amb);
            comm.Parameters.Add(sex);
            comm.Parameters.Add(birth);
            comm.Parameters.Add(child);
            comm.Parameters.Add(pid);
            
            comm.Parameters[0].Value = patient.initials.surname;
            comm.Parameters[1].Value = patient.amb_card;
            comm.Parameters[2].Value = patient.sex;
            comm.Parameters[3].Value = patient.birth_date.date;
            comm.Parameters[4].Value = patient.is_child;
            comm.Parameters[5].Value = patient.pid;

            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                var result = comm.ExecuteScalar();
                patient.pid = (int)result;
            
            }
            finally
            {
                t.Commit();
                conn.Close();
            }           

        }

        /*Запуск хранимой процедуры по проверке пользователя на существование в БД*/
        public bool CheckUserExist(CPatient patient)
        {
            
            conn.Open();
            bool init = false;
            NpgsqlTransaction t = conn.BeginTransaction();
            NpgsqlCommand comm = new NpgsqlCommand("\"CheckUser2\"", conn);

            NpgsqlParameter ini = new NpgsqlParameter("ini", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter amb = new NpgsqlParameter("amb", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter sex = new NpgsqlParameter("sex", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter birth = new NpgsqlParameter("birth", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter child = new NpgsqlParameter("child", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter pid = new NpgsqlParameter("pid", NpgsqlTypes.NpgsqlDbType.Integer);

            ini.Direction = ParameterDirection.Input;
            amb.Direction = ParameterDirection.Input;
            sex.Direction = ParameterDirection.Input;
            birth.Direction = ParameterDirection.Input;
            child.Direction = ParameterDirection.Input;
            pid.Direction = ParameterDirection.Input;

            comm.Parameters.Add(ini);
            comm.Parameters.Add(amb);
            comm.Parameters.Add(sex);
            comm.Parameters.Add(birth);
            comm.Parameters.Add(child);
            comm.Parameters.Add(pid);
            
            comm.Parameters[0].Value = patient.initials.surname;
            comm.Parameters[1].Value = patient.amb_card;
            comm.Parameters[2].Value = patient.sex;
            comm.Parameters[3].Value = patient.birth_date.date;
            comm.Parameters[4].Value = patient.is_child;
            comm.Parameters[5].Value = patient.pid;
            
            comm.CommandType = CommandType.StoredProcedure;
            
            try
            {
                var result = comm.ExecuteScalar();
                patient.pid = (int)result;

                if(patient.pid!=0)
                    init=true;
            }
            finally
            {
                t.Commit();
                conn.Close();
                
              
            }
            return init;
        }

        /* 2nd edition*/
        public void RetrieveProtocol(CStateBox box)
        {

            conn.Open();

            NpgsqlTransaction t = conn.BeginTransaction();
            NpgsqlCommand comm = new NpgsqlCommand("\"RetrieveProtocol2\"", conn);

            NpgsqlParameter pid = new NpgsqlParameter("pid", NpgsqlTypes.NpgsqlDbType.Integer);
            NpgsqlParameter dat = new NpgsqlParameter("dat", NpgsqlTypes.NpgsqlDbType.Date);
            NpgsqlParameter text = new NpgsqlParameter("text", NpgsqlTypes.NpgsqlDbType.Varchar);


            pid.Direction = ParameterDirection.Input;
            dat.Direction = ParameterDirection.Input;
            text.Direction = ParameterDirection.Input;


            comm.Parameters.Add(pid);
            comm.Parameters.Add(dat);
            comm.Parameters.Add(text);

            comm.Parameters[0].Value = box.protocol.sid;
            comm.Parameters[1].Value = box.date;
            comm.Parameters[2].Value = box.protocol.text;
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                var result = comm.ExecuteScalar();
                box.protocol.text = (string)result;

            }
            finally
            {
                t.Commit();
                conn.Close();


            }

            return;
        }

        /* 1nd edition*/
        public void RetrieveProtocol(CProtocol protocol, DateTime date) 
        {

            conn.Open();
            
            NpgsqlTransaction t = conn.BeginTransaction();
            NpgsqlCommand comm = new NpgsqlCommand("\"RetrieveProtocol2\"", conn);

            NpgsqlParameter pid = new NpgsqlParameter("pid", NpgsqlTypes.NpgsqlDbType.Integer);
            NpgsqlParameter dat = new NpgsqlParameter("dat", NpgsqlTypes.NpgsqlDbType.Date);
            NpgsqlParameter text = new NpgsqlParameter("text", NpgsqlTypes.NpgsqlDbType.Varchar);


            pid.Direction = ParameterDirection.Input;
            dat.Direction = ParameterDirection.Input;
            text.Direction = ParameterDirection.Input;


            comm.Parameters.Add(pid);
            comm.Parameters.Add(dat);
            comm.Parameters.Add(text);

            comm.Parameters[0].Value = protocol.sid;
            comm.Parameters[1].Value = date.Date;
            comm.Parameters[2].Value = protocol.text;
       
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                var result = comm.ExecuteScalar();
                protocol.text = (string)result;
               
            }
            finally
            {
                t.Commit();
                conn.Close();


            }
            return; 
        }


        /*параллельная версия*/
        public void UpdateProtocol(CStateBox box)
        {
         lock(box.locker){

            conn.Open();

            NpgsqlTransaction t = conn.BeginTransaction();
            NpgsqlCommand comm = new NpgsqlCommand("\"UpdateProtocol\"", conn);

            NpgsqlParameter pid = new NpgsqlParameter("pid", NpgsqlTypes.NpgsqlDbType.Integer);
            NpgsqlParameter dat = new NpgsqlParameter("dat", NpgsqlTypes.NpgsqlDbType.Date);
            NpgsqlParameter text = new NpgsqlParameter("text", NpgsqlTypes.NpgsqlDbType.Varchar);


            pid.Direction = ParameterDirection.Input;
            dat.Direction = ParameterDirection.Input;
            text.Direction = ParameterDirection.Input;


            comm.Parameters.Add(pid);
            comm.Parameters.Add(dat);
            comm.Parameters.Add(text);

            comm.Parameters[0].Value = box.protocol.sid;
            comm.Parameters[1].Value = box.date.Date;
            comm.Parameters[2].Value = box.protocol.text;

            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                var result = comm.ExecuteScalar();
                //box.protocol.text = (string)result;

            }
            finally
            {
                t.Commit();
                conn.Close();


            }
            return; 
         }
        
        }


        /* последовательная версия*/
        public void UpdateProtocol(CProtocol protocol, DateTime date) 
        {

            conn.Open();

            NpgsqlTransaction t = conn.BeginTransaction();
            NpgsqlCommand comm = new NpgsqlCommand("\"UpdateProtocol\"", conn);

            NpgsqlParameter pid = new NpgsqlParameter("pid", NpgsqlTypes.NpgsqlDbType.Integer);
            NpgsqlParameter dat = new NpgsqlParameter("dat", NpgsqlTypes.NpgsqlDbType.Date);
            NpgsqlParameter text = new NpgsqlParameter("text", NpgsqlTypes.NpgsqlDbType.Varchar);


            pid.Direction = ParameterDirection.Input;
            dat.Direction = ParameterDirection.Input;
            text.Direction = ParameterDirection.Input;


            comm.Parameters.Add(pid);
            comm.Parameters.Add(dat);
            comm.Parameters.Add(text);

            comm.Parameters[0].Value = protocol.sid;
            comm.Parameters[1].Value = date.Date;
            comm.Parameters[2].Value = protocol.text;

            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                var result = comm.ExecuteScalar();
                //protocol.text = (string)result;

            }
            finally
            {
                t.Commit();
                conn.Close();


            }
            return;  // ???
        
        }

        public void FillPatient(CPatient patient)
        {
            conn.Open();
            NpgsqlTransaction t = conn.BeginTransaction();
            NpgsqlCommand comm = new NpgsqlCommand("\"FillPatient2\"", conn);
            NpgsqlParameter pid = new NpgsqlParameter("pid", NpgsqlTypes.NpgsqlDbType.Integer);

            pid.Direction = ParameterDirection.Input;
            comm.Parameters.Add(pid);
            comm.Parameters[0].Value = patient.pid;
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                var result = comm.ExecuteScalar();
            }
            finally
            {
                t.Commit();
                conn.Close();
            }

        }

        /*Заполняет таблицу исследований для пришедшего пациента*/
        public void FillStudy(CStudy study) 
        {
            conn.Open();
            NpgsqlTransaction t = conn.BeginTransaction();
            NpgsqlCommand comm = new NpgsqlCommand("\"FillStudy2\"", conn);

            NpgsqlParameter pid = new NpgsqlParameter("pid", NpgsqlTypes.NpgsqlDbType.Integer);
            NpgsqlParameter sid = new NpgsqlParameter("sid", NpgsqlTypes.NpgsqlDbType.Integer);
            NpgsqlParameter mod = new NpgsqlParameter("mod", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter is_hosp = new NpgsqlParameter("is_hosp", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter dep = new NpgsqlParameter("dep", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter body = new NpgsqlParameter("body", NpgsqlTypes.NpgsqlDbType.Varchar);
            NpgsqlParameter role = new NpgsqlParameter("role", NpgsqlTypes.NpgsqlDbType.Integer);
            NpgsqlParameter date = new NpgsqlParameter("date", NpgsqlTypes.NpgsqlDbType.Date);

            pid.Direction = ParameterDirection.Input;
            sid.Direction = ParameterDirection.Input;
            mod.Direction = ParameterDirection.Input;
            is_hosp.Direction = ParameterDirection.Input;
            dep.Direction = ParameterDirection.Input;
            body.Direction = ParameterDirection.Input;
            role.Direction = ParameterDirection.Input;
            date.Direction = ParameterDirection.Input;

            comm.Parameters.Add(pid);
            comm.Parameters.Add(sid);
            comm.Parameters.Add(mod);
            comm.Parameters.Add(is_hosp);
            comm.Parameters.Add(dep);
            comm.Parameters.Add(body);
            comm.Parameters.Add(role);
            comm.Parameters.Add(date);

            comm.Parameters[0].Value = study.pid;   // first of all it must be in patient
            comm.Parameters[1].Value = study.sid;
            comm.Parameters[2].Value = study.modality;
            comm.Parameters[3].Value = study.is_hospital;
            comm.Parameters[4].Value = study.department;
            comm.Parameters[5].Value = study.body;
            comm.Parameters[6].Value = study.role_id;
            comm.Parameters[7].Value = study.study_date;

            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                var result = comm.ExecuteScalar();
                study.sid = (int)result;
            }
            finally
            {
                t.Commit();
                conn.Close();
            }
        }

        public void FillProtocol(CProtocol protocol) 
        {
            conn.Open();
            NpgsqlTransaction t = conn.BeginTransaction();
            NpgsqlCommand comm = new NpgsqlCommand("\"FillProtocol\"", conn);

            NpgsqlParameter prid = new NpgsqlParameter("prid", NpgsqlTypes.NpgsqlDbType.Integer);
            NpgsqlParameter sid = new NpgsqlParameter("sid", NpgsqlTypes.NpgsqlDbType.Integer);
            // NpgsqlParameter txt = new NpgsqlParameter("txt", NpgsqlTypes.NpgsqlDbType.Text);
         
            prid.Direction = ParameterDirection.Input;
            sid.Direction = ParameterDirection.Input;
            //txt.Direction = ParameterDirection.Input;
       
            comm.Parameters.Add(prid);
            comm.Parameters.Add(sid);
           // comm.Parameters.Add(txt);

            comm.Parameters[0].Value = protocol.prid;
            comm.Parameters[1].Value = protocol.sid;
         
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                var result = comm.ExecuteScalar();
                protocol.prid = (int)result;
            }
            finally
            {
                t.Commit();
                conn.Close();
            }
        }

        public void RetrievePatientFromDB() { } // извлчеь данные конктретного пациентаы
        public void RetrieveCustomDataFromDB() { } // запрос формируется динамически

        private void Parameters() 
        {
        
        }

        /*
        public void Test() 
        {
            conn.Open();
            NpgsqlTransaction t = conn.BeginTransaction();
            NpgsqlCommand comm = new NpgsqlCommand("test", conn);
            NpgsqlParameter prm = new NpgsqlParameter("pid", NpgsqlTypes.NpgsqlDbType.Integer);
            prm.Direction = ParameterDirection.Input;
            comm.Parameters.Add(prm);
            comm.Parameters[0].Value = 15;
            comm.CommandType = CommandType.StoredProcedure;
            int pid = 0;

            try
            {
                pid = (int)comm.ExecuteScalar();


            }
            finally
            {
                conn.Close();
            }
        }
         * */

    }
}

