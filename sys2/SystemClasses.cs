using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; // для строк

namespace SystemClasses
{
    public enum State 
    {
        
        Init = 0, // инициализировать модуль
        Finish = 1, // принять сообщение  о завершении его работы
        SendData = 2,  // послать данные  в БД
        RetrievePatientData = 3, // извлеч данные из БД
        CheckData = 4, // проверить данные на корректность в БД
        UpdateDataFromDB = 5, // обновить сетку из БД
        Wait = 6,
        RetrieveCustomData =7,
        MakeaWindow = 8,
        QuickSave=9,
        QuickLoad=12,
        TextChanged=10,
        WaitForAction = 11
    }

    enum Message 
    {
        
    }

    enum Role
    {
        Administrator=0,
        Doctor=1,
        Registrator=2,
        Undefined =404,
        SuperAdmin = 1000
    }

    enum DMYCheck 
    {
        equal=0,
        more=1,
        less=2
    }

    public class CStateBox 
    {
        public State state;
        public CPatient patient;
        public CStudy study;
        public CProtocol protocol;
        public DateTime date;
        public object locker;
        public CStateBox() { }
    }

    class User 
    {
        public string login;
        public Role role;
        public int id;

        public User() 
        {
            login = null;
            role = Role.Undefined;
        }

        public void ActionAddPatient()  // void !!!
        {
            switch(role)
            {
                case(Role.Administrator):{break;}
                case(Role.Doctor):{break;}
                case(Role.Registrator):{break;}
                default: break;
            }
        }
        public void ActionDeletePatient()
        {
            switch(role)
            {
                case Role.Administrator:
                    {
                        //return false;
                        break;
                    }
                case Role.Doctor :{break;}
                case Role.Registrator :{break;}
            }
        }
        public void ActionAddProtocol()
        {
            switch(role)
            {
                case(Role.Administrator):{break;}
                case(Role.Doctor):{break;}
                case(Role.Registrator):
                    {
                        //return false;
                        break;
                    }
            }
        }
        public void DeleteProtocol()
        {
            switch(role)
            {
                case(Role.Administrator):{break;}
                case(Role.Doctor):{break;}
                case(Role.Registrator):
                    {
                        //return false;   
                        break;
                    }
            }
        }

    }

    public class CInitials
    {
        public string surname; //second name
	    public string firstname;
	    public string middlename;
	    public CInitials()
        {
            surname = null; // secondname
            firstname = null;
            middlename = null;
        }
	}

    public class CBirthDate
    {
        public int day;
	    public int month;
	    public int year;
        public string date;
	    public CBirthDate(){}
    }

    public class CStudy
    {
        public int pid;
        public int sid;
        public string modality;
        public string is_hospital;
        public string department;
        public string body;
        public int role_id;
        public DateTime study_date; 
        public CStudy() { }

        //---- а нужны ли эти свойства у исследования ?--
        public CInitials doctor;//doctor's initials
        public bool amb_st; //ambulatory(0) or stationary(1)?
        public string diagnosis;//diagnosis
        
        //------
    }
	    

    public class CProtocol
    {
        public int prid;
        public int sid;
        public string text; // ????
        public CProtocol(){}
	}


    class CEmergency 
    {
        public CInitials initials; //key
        public string amb_card; //key
        public CBirthDate birth_date; //key
        public string sex; //key
        public string is_child; //key

        public string patient_id; 
	    public string is_hospital;
	    public ulong hist_card;
        public bool have_child;
	    public int study_ctr;
	    public CEmergency(){}
    }

   public class CPatient
   {    
        public CInitials initials; //key
        public string amb_card; //key
        public CBirthDate birth_date; //key
        
        public string sex; //key
        public string is_child; //key
        public int pid; // RIS patient id key

	    public string hist_card;   // ?????????????????????
	    public int study_ctr;
        public CPatient(){}
    }

};
