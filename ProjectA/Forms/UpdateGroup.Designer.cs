namespace ProjectA.Forms
{
    partial class UpdateGroup
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelChoosedStudents = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.dgvChoosedStudents = new System.Windows.Forms.DataGridView();
            this.dgvAllStudents = new System.Windows.Forms.DataGridView();
            this.lblHeading = new System.Windows.Forms.Label();
            this.btnUpdateGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoosedStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(575, 381);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(72, 29);
            this.buttonCancel.TabIndex = 21;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelChoosedStudents
            // 
            this.labelChoosedStudents.AutoSize = true;
            this.labelChoosedStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChoosedStudents.Location = new System.Drawing.Point(451, 18);
            this.labelChoosedStudents.Name = "labelChoosedStudents";
            this.labelChoosedStudents.Size = new System.Drawing.Size(142, 20);
            this.labelChoosedStudents.TabIndex = 20;
            this.labelChoosedStudents.Text = "Choosed Student :";
            this.labelChoosedStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(366, 195);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(78, 29);
            this.buttonRemove.TabIndex = 19;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStudent.Location = new System.Drawing.Point(374, 153);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(59, 29);
            this.btnAddStudent.TabIndex = 18;
            this.btnAddStudent.Text = "Add";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // dgvChoosedStudents
            // 
            this.dgvChoosedStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChoosedStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChoosedStudents.Location = new System.Drawing.Point(455, 53);
            this.dgvChoosedStudents.MultiSelect = false;
            this.dgvChoosedStudents.Name = "dgvChoosedStudents";
            this.dgvChoosedStudents.ReadOnly = true;
            this.dgvChoosedStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChoosedStudents.Size = new System.Drawing.Size(319, 284);
            this.dgvChoosedStudents.TabIndex = 17;
            // 
            // dgvAllStudents
            // 
            this.dgvAllStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllStudents.Location = new System.Drawing.Point(30, 53);
            this.dgvAllStudents.MultiSelect = false;
            this.dgvAllStudents.Name = "dgvAllStudents";
            this.dgvAllStudents.ReadOnly = true;
            this.dgvAllStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllStudents.Size = new System.Drawing.Size(319, 284);
            this.dgvAllStudents.TabIndex = 16;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(26, 18);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(133, 20);
            this.lblHeading.TabIndex = 15;
            this.lblHeading.Text = "Choose Student :";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpdateGroup
            // 
            this.btnUpdateGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateGroup.Location = new System.Drawing.Point(662, 381);
            this.btnUpdateGroup.Name = "btnUpdateGroup";
            this.btnUpdateGroup.Size = new System.Drawing.Size(112, 29);
            this.btnUpdateGroup.TabIndex = 14;
            this.btnUpdateGroup.Text = "Update Group";
            this.btnUpdateGroup.UseVisualStyleBackColor = true;
            this.btnUpdateGroup.Click += new System.EventHandler(this.btnUpdateGroup_Click);
            // 
            // UpdateGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(228)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(800, 428);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelChoosedStudents);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.dgvChoosedStudents);
            this.Controls.Add(this.dgvAllStudents);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.btnUpdateGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateGroup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateGroup";
            this.Load += new System.EventHandler(this.UpdateGroup_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpdateGroup_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoosedStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelChoosedStudents;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.DataGridView dgvChoosedStudents;
        private System.Windows.Forms.DataGridView dgvAllStudents;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Button btnUpdateGroup;
    }
}