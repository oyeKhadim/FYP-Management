namespace ProjectA.Forms
{
    partial class AddEvaluation
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
            this.textBoxTotalMarks = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTotalMarks = new System.Windows.Forms.Label();
            this.lblWeightage = new System.Windows.Forms.Label();
            this.textBoxWeightage = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTotalMarks
            // 
            this.textBoxTotalMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalMarks.Location = new System.Drawing.Point(215, 76);
            this.textBoxTotalMarks.Name = "textBoxTotalMarks";
            this.textBoxTotalMarks.Size = new System.Drawing.Size(225, 26);
            this.textBoxTotalMarks.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(24, 47);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(156, 23);
            this.lblName.TabIndex = 44;
            this.lblName.Text = "Name of Evaluation :";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalMarks
            // 
            this.lblTotalMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMarks.Location = new System.Drawing.Point(24, 77);
            this.lblTotalMarks.Name = "lblTotalMarks";
            this.lblTotalMarks.Size = new System.Drawing.Size(118, 27);
            this.lblTotalMarks.TabIndex = 43;
            this.lblTotalMarks.Text = "Total Marks :";
            this.lblTotalMarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWeightage
            // 
            this.lblWeightage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeightage.Location = new System.Drawing.Point(24, 107);
            this.lblWeightage.Name = "lblWeightage";
            this.lblWeightage.Size = new System.Drawing.Size(156, 34);
            this.lblWeightage.TabIndex = 45;
            this.lblWeightage.Text = "Total Weightage :";
            this.lblWeightage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxWeightage
            // 
            this.textBoxWeightage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWeightage.Location = new System.Drawing.Point(215, 110);
            this.textBoxWeightage.Name = "textBoxWeightage";
            this.textBoxWeightage.Size = new System.Drawing.Size(225, 26);
            this.textBoxWeightage.TabIndex = 2;
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(215, 44);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(225, 26);
            this.textBoxName.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(317, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(392, 144);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 28);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.Black;
            this.lblHeading.Location = new System.Drawing.Point(141, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(217, 24);
            this.lblHeading.TabIndex = 66;
            this.lblHeading.Text = "Add Details of Evaluation";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // AddEvaluation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(228)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(503, 203);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.textBoxTotalMarks);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTotalMarks);
            this.Controls.Add(this.lblWeightage);
            this.Controls.Add(this.textBoxWeightage);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddEvaluation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddEvaluation";
            this.Load += new System.EventHandler(this.AddEvaluation_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddEvaluation_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTotalMarks;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTotalMarks;
        private System.Windows.Forms.Label lblWeightage;
        private System.Windows.Forms.TextBox textBoxWeightage;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}