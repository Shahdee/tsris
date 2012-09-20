namespace sys2
{
    partial class PatientProtocolForm
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
            this.pr_box = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.modality2 = new System.Windows.Forms.Label();
            this.child2 = new System.Windows.Forms.Label();
            this.ambcard2 = new System.Windows.Forms.Label();
            this.sex2 = new System.Windows.Forms.Label();
            this.birthdate2 = new System.Windows.Forms.Label();
            this.initials2 = new System.Windows.Forms.Label();
            this.fontsize = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // pr_box
            // 
            this.pr_box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pr_box.Location = new System.Drawing.Point(194, 14);
            this.pr_box.Margin = new System.Windows.Forms.Padding(4);
            this.pr_box.Multiline = true;
            this.pr_box.Name = "pr_box";
            this.pr_box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pr_box.Size = new System.Drawing.Size(600, 704);
            this.pr_box.TabIndex = 0;

            this.pr_box.TextChanged += new System.EventHandler(this.pr_box_TextChanged);
            this.pr_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(pr_box_KeyPress);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.Image = global::sys2.Properties.Resources.right;
            this.button5.Location = new System.Drawing.Point(825, 339);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(71, 177);
            this.button5.TabIndex = 54;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button7.Image = global::sys2.Properties.Resources.left;
            this.button7.Location = new System.Drawing.Point(79, 339);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(71, 177);
            this.button7.TabIndex = 57;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // modality2
            // 
            this.modality2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modality2.AutoSize = true;
            this.modality2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.modality2.Location = new System.Drawing.Point(24, 190);
            this.modality2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.modality2.Name = "modality2";
            this.modality2.Size = new System.Drawing.Size(95, 16);
            this.modality2.TabIndex = 71;
            this.modality2.Text = "Модальность";
            // 
            // child2
            // 
            this.child2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.child2.AutoSize = true;
            this.child2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.child2.Location = new System.Drawing.Point(24, 164);
            this.child2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.child2.Name = "child2";
            this.child2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.child2.Size = new System.Drawing.Size(71, 16);
            this.child2.TabIndex = 70;
            this.child2.Text = "Ребёнок?";
            // 
            // ambcard2
            // 
            this.ambcard2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ambcard2.AutoSize = true;
            this.ambcard2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ambcard2.Location = new System.Drawing.Point(24, 135);
            this.ambcard2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ambcard2.Name = "ambcard2";
            this.ambcard2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ambcard2.Size = new System.Drawing.Size(92, 16);
            this.ambcard2.TabIndex = 69;
            this.ambcard2.Text = "№ амб карты";
            // 
            // sex2
            // 
            this.sex2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sex2.AutoSize = true;
            this.sex2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sex2.Location = new System.Drawing.Point(24, 110);
            this.sex2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sex2.Name = "sex2";
            this.sex2.Size = new System.Drawing.Size(34, 16);
            this.sex2.TabIndex = 68;
            this.sex2.Text = "Пол";
            // 
            // birthdate2
            // 
            this.birthdate2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.birthdate2.AutoSize = true;
            this.birthdate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.birthdate2.Location = new System.Drawing.Point(22, 86);
            this.birthdate2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.birthdate2.Name = "birthdate2";
            this.birthdate2.Size = new System.Drawing.Size(107, 16);
            this.birthdate2.TabIndex = 67;
            this.birthdate2.Text = "Дата рождения";
            // 
            // initials2
            // 
            this.initials2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.initials2.AutoSize = true;
            this.initials2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.initials2.Location = new System.Drawing.Point(22, 62);
            this.initials2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.initials2.Name = "initials2";
            this.initials2.Size = new System.Drawing.Size(39, 16);
            this.initials2.TabIndex = 66;
            this.initials2.Text = "ФИО";
            // 
            // fontsize
            // 
            this.fontsize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fontsize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontsize.FormattingEnabled = true;
            this.fontsize.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.fontsize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.fontsize.Location = new System.Drawing.Point(834, 54);
            this.fontsize.Name = "fontsize";
            this.fontsize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fontsize.Size = new System.Drawing.Size(46, 24);
            this.fontsize.TabIndex = 72;
            this.fontsize.TextChanged += new System.EventHandler(this.fontsize_TextChanged);
            // 
            // PatientProtocolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 733);
            this.Controls.Add(this.fontsize);
            this.Controls.Add(this.modality2);
            this.Controls.Add(this.child2);
            this.Controls.Add(this.ambcard2);
            this.Controls.Add(this.sex2);
            this.Controls.Add(this.birthdate2);
            this.Controls.Add(this.initials2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.pr_box);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "PatientProtocolForm";
            this.Text = "Протокол пациента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pr_box;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label modality2;
        private System.Windows.Forms.Label child2;
        private System.Windows.Forms.Label ambcard2;
        private System.Windows.Forms.Label sex2;
        private System.Windows.Forms.Label birthdate2;
        private System.Windows.Forms.Label initials2;
        private System.Windows.Forms.ComboBox fontsize;

        

    }
}