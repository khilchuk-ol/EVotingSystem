namespace EVoting
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGovernmentId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerBirthDate = new System.Windows.Forms.DateTimePicker();
            this.listBoxCandidates = new System.Windows.Forms.ListBox();
            this.buttonVote = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Government ID";
            // 
            // textBoxGovernmentId
            // 
            this.textBoxGovernmentId.Location = new System.Drawing.Point(12, 32);
            this.textBoxGovernmentId.Name = "textBoxGovernmentId";
            this.textBoxGovernmentId.Size = new System.Drawing.Size(250, 27);
            this.textBoxGovernmentId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Surname";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(12, 85);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(250, 27);
            this.textBoxSurname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 138);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(250, 27);
            this.textBoxName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Birth Date";
            // 
            // dateTimePickerBirthDate
            // 
            this.dateTimePickerBirthDate.Location = new System.Drawing.Point(12, 191);
            this.dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            this.dateTimePickerBirthDate.Size = new System.Drawing.Size(250, 27);
            this.dateTimePickerBirthDate.TabIndex = 7;
            // 
            // listBoxCandidates
            // 
            this.listBoxCandidates.FormattingEnabled = true;
            this.listBoxCandidates.ItemHeight = 20;
            this.listBoxCandidates.Location = new System.Drawing.Point(12, 224);
            this.listBoxCandidates.Name = "listBoxCandidates";
            this.listBoxCandidates.Size = new System.Drawing.Size(250, 184);
            this.listBoxCandidates.TabIndex = 8;
            // 
            // buttonVote
            // 
            this.buttonVote.Location = new System.Drawing.Point(12, 409);
            this.buttonVote.Name = "buttonVote";
            this.buttonVote.Size = new System.Drawing.Size(250, 29);
            this.buttonVote.TabIndex = 9;
            this.buttonVote.Text = "Vote";
            this.buttonVote.UseVisualStyleBackColor = true;
            this.buttonVote.Click += new System.EventHandler(this.buttonVote_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 450);
            this.Controls.Add(this.buttonVote);
            this.Controls.Add(this.listBoxCandidates);
            this.Controls.Add(this.dateTimePickerBirthDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxGovernmentId);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "EVoting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBoxGovernmentId;
        private Label label2;
        private TextBox textBoxSurname;
        private Label label3;
        private TextBox textBoxName;
        private Label label4;
        private DateTimePicker dateTimePickerBirthDate;
        private ListBox listBoxCandidates;
        private Button buttonVote;
    }
}