namespace sys2
{
    partial class TestConnectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbHost = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbDataBaseName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.savetoconn = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(199, 135);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(100, 20);
            this.tbHost.TabIndex = 0;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(199, 174);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 20);
            this.tbPort.TabIndex = 1;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(199, 219);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(100, 20);
            this.tbUser.TabIndex = 2;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(199, 254);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(100, 20);
            this.tbPass.TabIndex = 3;
            // 
            // tbDataBaseName
            // 
            this.tbDataBaseName.Location = new System.Drawing.Point(199, 90);
            this.tbDataBaseName.Name = "tbDataBaseName";
            this.tbDataBaseName.Size = new System.Drawing.Size(100, 20);
            this.tbDataBaseName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Host";
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Location = new System.Drawing.Point(143, 181);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(26, 13);
            this.Port.TabIndex = 7;
            this.Port.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "db name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Login";
            // 
            // savetoconn
            // 
            this.savetoconn.AutoSize = true;
            this.savetoconn.LinkColor = System.Drawing.Color.Black;
            this.savetoconn.Location = new System.Drawing.Point(376, 169);
            this.savetoconn.Name = "savetoconn";
            this.savetoconn.Size = new System.Drawing.Size(128, 13);
            this.savetoconn.TabIndex = 13;
            this.savetoconn.TabStop = true;
            this.savetoconn.Text = "Save to connection string";
            this.savetoconn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.savetoconnstr_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "*reboot for changes";
            // 
            // TestConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(615, 389);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.savetoconn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDataBaseName);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbHost);
            this.MaximumSize = new System.Drawing.Size(631, 427);
            this.MinimumSize = new System.Drawing.Size(631, 427);
            this.Name = "TestConnectionForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbDataBaseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel savetoconn;
        private System.Windows.Forms.Label label5;
    }
}

