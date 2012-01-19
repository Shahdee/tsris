using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using System.IO;


namespace sys2
{ 
    public partial class TestConnectionForm : Form
    {
        private DataSet ds;
        private DataTable dt;
        private StreamWriter sw;
        private string path2;

        /*Парсер файла в котором хранится connectionstring*/
        public void TextParser(string conn)
        {
            bool first=true;
            string prm = "";
            int j=0;
            int ctr = 0;

            for (int i = 0; i < conn.Length; i++) 
            {
                if ((conn[i] != '=') && first)
                        continue;
                first = false;
                if ((conn[i] != ';')&&(conn[i] != '='))
                {
                    prm += conn[i];
                    continue;
                }
                if(conn[i] == ';')
                {
                    switch (ctr) 
                    {
                        case 0: 
                            {
                                tbHost.Text = prm;
                                break;
                            }
                        case 1: 
                            {
                                tbPort.Text = prm;
                                break;
                            }
                        case 2: 
                            {
                                tbUser.Text = prm;
                                break;
                            }
                        case 3: 
                            {
                                tbPass.Text = prm;
                                break;
                            }
                        case 4: 
                            {
                                tbDataBaseName.Text = prm;
                                break;
                            }
                    }
                    prm = "";
                    first = true;
                    j = 0;
                    ctr++;
                }
            }
        }

        public TestConnectionForm(string connectionstring, string path)
        {
            InitializeComponent();
            TextParser(connectionstring);
            path2 = path;

        }

        private void savetoconnstr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sw = new StreamWriter(path2);
            sw.WriteLine("Server="+tbHost.Text+";");
            sw.WriteLine("Port="+tbPort.Text+";");
            sw.WriteLine("User Id="+tbUser.Text+";");
            sw.WriteLine("Password="+tbPass.Text+";");
            sw.WriteLine("DataBase="+tbDataBaseName.Text+";");
            sw.Dispose();
            sw.Close();
        }     
    }
}
