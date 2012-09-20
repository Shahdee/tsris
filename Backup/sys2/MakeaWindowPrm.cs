using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SystemClasses;

namespace sys2
{
    public class MakeaWindowPrm
    {
        public TestConnectionForm test;
        public PatientProtocolForm pw;

        private Object syn = new object();


        public void CreateProtocolWindow(CStateBox box) 
        {

            pw = new PatientProtocolForm(box);
            pw.Show();
            

        } 
        

        public void CreateTestConnectionForm(string s1, string s2) 
        {
            test = new TestConnectionForm(s1,s2);
            test.Show();
        }


        public void ChangeStateToSend(State state) 
        {
            state = State.QuickSave;
        }



        public void SetBoxText(CStateBox obj)
        {
            lock (obj.locker)
            {
                if (obj.protocol != null && obj.protocol.text != null && pw.box.protocol != null && pw.box.protocol.text != null && pw.box != null)
                    obj.protocol.text = pw.box.protocol.text;
            }
        }

        
    }
}
