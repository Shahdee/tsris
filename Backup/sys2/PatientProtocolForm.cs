using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SystemClasses;
using SystemFunctions;

using System.Xml;

namespace sys2
{
    public partial class PatientProtocolForm : Form
    {


       public CStateBox box; 
       private bool text_was_changed;
        
        /*
        public PatientProtocolForm(CStateBox box)
        {

            InitializeComponent();
          
            dt2 = box.date;
            
            protocol2 = new CProtocol();
            protocol2 = box.protocol;
            protocol2.sid = box.patient.pid;   // теперь мы можем найти по исследованию id пациента

            initials2.Text = box.patient.initials.surname;
            sex2.Text = box.patient.sex;
            birthdate2.Text = box.patient.birth_date.date;
            ambcard2.Text = box.patient.amb_card;
            child2.Text = box.patient.is_child;
            modality2.Text = box.study.modality;

            shadow.sql.RetrieveProtocol(protocol2, dt2);
            //protocol2.sid = 0;  // для корректности
            pr_box.Text = protocol2.text;

        }    
         * */
        
        
        public PatientProtocolForm(CStateBox box) 
        {

            InitializeComponent();

            this.box = new CStateBox();
            this.box.patient = new CPatient();
            this.box.study = new CStudy();
            this.box.protocol = new CProtocol();
            this.box.locker = new object();

            this.box.patient = box.patient;
            this.box.study = box.study;
            this.box.protocol = box.protocol;
            this.box.date = box.date;
            this.box.locker = box.locker;
            
            this.box.state = State.WaitForAction;
            this.box.protocol.sid = box.patient.pid;  // !!!

            text_was_changed = false;
            
            initials2.Text = box.patient.initials.surname;
            sex2.Text = box.patient.sex;
            birthdate2.Text = box.patient.birth_date.date;
            ambcard2.Text = box.patient.amb_card;
            child2.Text = box.patient.is_child;
            modality2.Text = box.study.modality;

            //box.protocol.sid = 0;  // для корректности
            pr_box.Text = this.box.protocol.text;

        }    

        private void fontsize_TextChanged(object sender, EventArgs e) 
        {

            this.pr_box.Font = new Font(this.pr_box.Font.FontFamily,Convert.ToInt32(fontsize.Text.ToString()), this.pr_box.Font.Style);
        }

        private void pr_box_KeyPress(object sender, EventArgs e) 
        {
            text_was_changed = true;

        }


        private void pr_box_TextChanged(object sender, EventArgs e) 
        {
            if (text_was_changed) 
            {
                lock (this.box.locker)
                {
                    this.box.protocol.text = pr_box.Text;
                }
                    this.box.state = State.TextChanged;
                    text_was_changed = false;
                
            }
        }

        private void PatientProtocolForm_FormClosed(object sender, EventArgs e) 
        {
            this.box.state = State.Finish;
        }

    }
}
