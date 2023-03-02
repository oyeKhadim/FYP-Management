namespace ProjectA.Forms
{
    partial class AddStudent
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
            this.components = new System.ComponentModel.Container();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblRegNo = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDoB = new System.Windows.Forms.Label();
            this.dateTimePickerDoB = new System.Windows.Forms.DateTimePicker();
            this.textBoxContact = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblContct = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.checkBoxisDoBApplicable = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.textBoxRegNo = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(40, 44);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(118, 23);
            this.lblFirstName.TabIndex = 19;
            this.lblFirstName.Text = "First Name :";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegNo
            // 
            this.lblRegNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegNo.Location = new System.Drawing.Point(40, 79);
            this.lblRegNo.Name = "lblRegNo";
            this.lblRegNo.Size = new System.Drawing.Size(118, 27);
            this.lblRegNo.TabIndex = 18;
            this.lblRegNo.Text = "Registration No :";
            this.lblRegNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(40, 107);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(118, 34);
            this.lblEmail.TabIndex = 23;
            this.lblEmail.Text = "Email :";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDoB
            // 
            this.lblDoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoB.Location = new System.Drawing.Point(40, 142);
            this.lblDoB.Name = "lblDoB";
            this.lblDoB.Size = new System.Drawing.Size(98, 30);
            this.lblDoB.TabIndex = 20;
            this.lblDoB.Text = "Date of Birth :";
            this.lblDoB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerDoB
            // 
            this.dateTimePickerDoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDoB.Location = new System.Drawing.Point(159, 148);
            this.dateTimePickerDoB.Name = "dateTimePickerDoB";
            this.dateTimePickerDoB.Size = new System.Drawing.Size(249, 23);
            this.dateTimePickerDoB.TabIndex = 6;
            this.dateTimePickerDoB.ValueChanged += new System.EventHandler(this.dateTimePickerDoB_ValueChanged);
            // 
            // textBoxContact
            // 
            this.textBoxContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxContact.Location = new System.Drawing.Point(459, 111);
            this.textBoxContact.Name = "textBoxContact";
            this.textBoxContact.Size = new System.Drawing.Size(191, 26);
            this.textBoxContact.TabIndex = 5;
            this.textBoxContact.Leave += new System.EventHandler(this.textBoxContact_Leave);
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLastName.Location = new System.Drawing.Point(459, 44);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(191, 26);
            this.textBoxLastName.TabIndex = 1;
     
            // 
            // lblLastName
            // 
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(367, 44);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(107, 23);
            this.lblLastName.TabIndex = 21;
            this.lblLastName.Text = "Last Name :";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContct
            // 
            this.lblContct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContct.Location = new System.Drawing.Point(367, 111);
            this.lblContct.Name = "lblContct";
            this.lblContct.Size = new System.Drawing.Size(107, 27);
            this.lblContct.TabIndex = 22;
            this.lblContct.Text = "Contact  :";
            this.lblContct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGender
            // 
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(371, 68);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(86, 34);
            this.lblGender.TabIndex = 24;
            this.lblGender.Text = "Gender :";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(159, 110);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(184, 26);
            this.textBoxEmail.TabIndex = 4;
            this.textBoxEmail.Leave += new System.EventHandler(this.textBoxEmail_Leave);
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFirstName.Location = new System.Drawing.Point(159, 44);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(184, 26);
            this.textBoxFirstName.TabIndex = 0;
            this.textBoxFirstName.Leave += new System.EventHandler(this.textBoxFirstName_Leave);
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxGender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "NULL"});
            this.comboBoxGender.Location = new System.Drawing.Point(459, 76);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(191, 28);
            this.comboBoxGender.TabIndex = 3;
       
            // 
            // checkBoxisDoBApplicable
            // 
            this.checkBoxisDoBApplicable.AutoSize = true;
            this.checkBoxisDoBApplicable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxisDoBApplicable.Location = new System.Drawing.Point(437, 150);
            this.checkBoxisDoBApplicable.Name = "checkBoxisDoBApplicable";
            this.checkBoxisDoBApplicable.Size = new System.Drawing.Size(121, 22);
            this.checkBoxisDoBApplicable.TabIndex = 7;
            this.checkBoxisDoBApplicable.Text = "Not Applicable";
            this.checkBoxisDoBApplicable.UseVisualStyleBackColor = true;
            this.checkBoxisDoBApplicable.CheckStateChanged += new System.EventHandler(this.checkBoxisDoBApplicable_CheckStateChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(504, 182);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 28);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(579, 182);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 28);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.Black;
            this.lblHeading.Location = new System.Drawing.Point(258, 4);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(194, 24);
            this.lblHeading.TabIndex = 35;
            this.lblHeading.Text = "Add Details of Student";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxRegNo
            // 
            this.textBoxRegNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRegNo.Location = new System.Drawing.Point(159, 76);
            this.textBoxRegNo.Name = "textBoxRegNo";
            this.textBoxRegNo.Size = new System.Drawing.Size(184, 26);
            this.textBoxRegNo.TabIndex = 2;
            this.textBoxRegNo.Leave += new System.EventHandler(this.textBoxRegNo_Leave);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // AddStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(228)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(683, 229);
            this.Controls.Add(this.textBoxRegNo);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblRegNo);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblDoB);
            this.Controls.Add(this.dateTimePickerDoB);
            this.Controls.Add(this.textBoxContact);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblContct);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.comboBoxGender);
            this.Controls.Add(this.checkBoxisDoBApplicable);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddStudent";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddStudent";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddStudent_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblRegNo;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDoB;
        private System.Windows.Forms.DateTimePicker dateTimePickerDoB;
        private System.Windows.Forms.TextBox textBoxContact;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblContct;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.CheckBox checkBoxisDoBApplicable;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.TextBox textBoxRegNo;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}