using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SystemClasses;


 
namespace sys2
{
   

    public class CShadowService // инициализация сервиса
    {
        public SQLDaemon sql;

        public CScheduler sch;

        public CRegistration reg;

        public CStateBox box;

        public MakeaWindowPrm win;

        private string query;

        public AutoResetEvent autoEvent;




        public CShadowService()    // Attention!
        {
           //sql = new SQLDaemon(1);
           //reg = new CRegistration();
           //sch = new CScheduler();
           //win = new MakeaWindowPrm();
           //box = new CStateBox();  
        }   

        /*Запуск методов для работы с базой данных*/   
        /*
        public void WorkWithDB(object o)
        {
            
            //State state = (State)o;  // ????
            CStateBox obj = (CStateBox)o;

            while (true)
            {
                switch (obj.state)
                {
                    case State.UpdateDataFromDB:
                        {
                            //sql.CheckDB(obj);  // ????
                            autoEvent.WaitOne(); 
                            break;
                        }
                    case State.SendData:
                        {
                            //sql.AddPatientObj();
                            autoEvent.WaitOne();
                            break;
                        }
                    case State.RetrievePatientData:
                        {
                            
                            autoEvent.WaitOne();
                            break;
                        }
                    case State.RetrieveCustomData: 
                        {
                            autoEvent.WaitOne();
                            break;
                        }
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    case State.QuickSave: 
                        {
                            sql.UpdateProtocol(obj);
                            autoEvent.WaitOne();
                            break;
                        }
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    case State.Finish:
                        {
                            autoEvent.WaitOne();
                            break;
                        }

                }
            }
        }
         * */


        /*
        public void SetState(); // устанавливает состояние для модуля
        TransferData(); // передача данных от одного модуля, другому
        SendMessage(); // отправляет сообщение модулю  
        */
        public void WorkWithWindows(object o) 
        {
            CStateBox obj = (CStateBox)o;
            

            while (true)
            {
                switch(win.pw.box.state)
                {
                    case State.MakeaWindow:
                        {
                            break;
                        }
                    /*
                    case State.QuickLoad: 
                        {
                            sql.RetrieveProtocol(obj);
                            win.pw.box.state = State.WaitForAction;
                            break;
                        }
                    */
                    case State.QuickSave:
                        {
                            sql.UpdateProtocol(obj);
                            win.pw.box.state = State.WaitForAction;
                            
                            break;
                        }
                   
                    case State.Finish:
                        {
                            box.state = State.Finish;
                            return;
                        }
                    /* в протоколе исследования произошло изменения*/
                    case State.TextChanged: 
                        {
                            win.SetBoxText(obj);
                            win.pw.box.state = State.QuickSave;
                            break;
                        }

                    case State.WaitForAction: { break; }

                }
            }
        }
    }
}
