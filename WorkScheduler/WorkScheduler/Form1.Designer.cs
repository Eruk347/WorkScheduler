namespace WorkScheduler
{
    partial class Form1
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
            this.teamName = new System.Windows.Forms.TextBox();
            this.springFallGetDate = new System.Windows.Forms.Button();
            this.dateList = new System.Windows.Forms.ListBox();
            this.addTeam = new System.Windows.Forms.Button();
            this.main13Start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.main13End = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.second3Start = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.second3End = new System.Windows.Forms.DateTimePicker();
            this.teamList = new System.Windows.Forms.ListBox();
            this.createListButton = new System.Windows.Forms.Button();
            this.numberOfShifts = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.loadTeamList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfShifts)).BeginInit();
            this.SuspendLayout();
            // 
            // teamName
            // 
            this.teamName.Location = new System.Drawing.Point(12, 150);
            this.teamName.Name = "teamName";
            this.teamName.Size = new System.Drawing.Size(120, 20);
            this.teamName.TabIndex = 0;
            this.teamName.TextChanged += new System.EventHandler(this.teamName_TextChanged);
            // 
            // springFallGetDate
            // 
            this.springFallGetDate.Location = new System.Drawing.Point(12, 121);
            this.springFallGetDate.Name = "springFallGetDate";
            this.springFallGetDate.Size = new System.Drawing.Size(75, 23);
            this.springFallGetDate.TabIndex = 2;
            this.springFallGetDate.Text = "Get dates";
            this.springFallGetDate.UseVisualStyleBackColor = true;
            this.springFallGetDate.Click += new System.EventHandler(this.springFallGetDate_Click);
            // 
            // dateList
            // 
            this.dateList.FormattingEnabled = true;
            this.dateList.Location = new System.Drawing.Point(138, 150);
            this.dateList.Name = "dateList";
            this.dateList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.dateList.Size = new System.Drawing.Size(120, 407);
            this.dateList.TabIndex = 3;
            // 
            // addTeam
            // 
            this.addTeam.Location = new System.Drawing.Point(264, 150);
            this.addTeam.Name = "addTeam";
            this.addTeam.Size = new System.Drawing.Size(75, 23);
            this.addTeam.TabIndex = 4;
            this.addTeam.Text = "Add team";
            this.addTeam.UseVisualStyleBackColor = true;
            this.addTeam.Click += new System.EventHandler(this.addTeam_Click);
            // 
            // main13Start
            // 
            this.main13Start.Location = new System.Drawing.Point(122, 12);
            this.main13Start.Name = "main13Start";
            this.main13Start.Size = new System.Drawing.Size(136, 20);
            this.main13Start.TabIndex = 5;
            this.main13Start.Value = new System.DateTime(2016, 9, 9, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select 13 week start";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select 13 week end";
            // 
            // main13End
            // 
            this.main13End.Location = new System.Drawing.Point(122, 38);
            this.main13End.Name = "main13End";
            this.main13End.Size = new System.Drawing.Size(136, 20);
            this.main13End.TabIndex = 7;
            this.main13End.Value = new System.DateTime(2016, 12, 2, 0, 0, 0, 0);
            this.main13End.ValueChanged += new System.EventHandler(this.main13End_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Select 3 week start";
            // 
            // second3Start
            // 
            this.second3Start.Location = new System.Drawing.Point(122, 64);
            this.second3Start.Name = "second3Start";
            this.second3Start.Size = new System.Drawing.Size(136, 20);
            this.second3Start.TabIndex = 9;
            this.second3Start.Value = new System.DateTime(2017, 1, 2, 0, 0, 0, 0);
            this.second3Start.ValueChanged += new System.EventHandler(this.second3Start_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Select 3 week end";
            // 
            // second3End
            // 
            this.second3End.Location = new System.Drawing.Point(122, 90);
            this.second3End.Name = "second3End";
            this.second3End.Size = new System.Drawing.Size(136, 20);
            this.second3End.TabIndex = 11;
            this.second3End.Value = new System.DateTime(2017, 1, 20, 0, 0, 0, 0);
            // 
            // teamList
            // 
            this.teamList.FormattingEnabled = true;
            this.teamList.Location = new System.Drawing.Point(345, 150);
            this.teamList.Name = "teamList";
            this.teamList.Size = new System.Drawing.Size(120, 407);
            this.teamList.TabIndex = 13;
            this.teamList.SelectedIndexChanged += new System.EventHandler(this.teamList_SelectedIndexChanged);
            // 
            // createListButton
            // 
            this.createListButton.Location = new System.Drawing.Point(472, 150);
            this.createListButton.Name = "createListButton";
            this.createListButton.Size = new System.Drawing.Size(75, 23);
            this.createListButton.TabIndex = 14;
            this.createListButton.Text = "Create list";
            this.createListButton.UseVisualStyleBackColor = true;
            this.createListButton.Click += new System.EventHandler(this.createListButton_Click);
            // 
            // numberOfShifts
            // 
            this.numberOfShifts.Location = new System.Drawing.Point(472, 180);
            this.numberOfShifts.Name = "numberOfShifts";
            this.numberOfShifts.Size = new System.Drawing.Size(38, 20);
            this.numberOfShifts.TabIndex = 15;
            this.numberOfShifts.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(517, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "How many shifts/team?";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(648, 150);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(199, 407);
            this.listBox1.TabIndex = 17;
            // 
            // loadTeamList
            // 
            this.loadTeamList.Location = new System.Drawing.Point(264, 121);
            this.loadTeamList.Name = "loadTeamList";
            this.loadTeamList.Size = new System.Drawing.Size(75, 23);
            this.loadTeamList.TabIndex = 18;
            this.loadTeamList.Text = "Load team list";
            this.loadTeamList.UseVisualStyleBackColor = true;
            this.loadTeamList.Click += new System.EventHandler(this.loadTeamList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 561);
            this.Controls.Add(this.loadTeamList);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numberOfShifts);
            this.Controls.Add(this.createListButton);
            this.Controls.Add(this.teamList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.second3End);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.second3Start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.main13End);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.main13Start);
            this.Controls.Add(this.addTeam);
            this.Controls.Add(this.dateList);
            this.Controls.Add(this.springFallGetDate);
            this.Controls.Add(this.teamName);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfShifts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox teamName;
        private System.Windows.Forms.Button springFallGetDate;
        private System.Windows.Forms.ListBox dateList;
        private System.Windows.Forms.Button addTeam;
        private System.Windows.Forms.DateTimePicker main13Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker main13End;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker second3Start;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker second3End;
        private System.Windows.Forms.ListBox teamList;
        private System.Windows.Forms.Button createListButton;
        private System.Windows.Forms.NumericUpDown numberOfShifts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button loadTeamList;
    }
}

