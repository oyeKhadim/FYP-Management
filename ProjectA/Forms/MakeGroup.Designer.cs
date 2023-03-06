namespace ProjectA.Forms
{
    partial class MakeGroup
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
            this.dgvAllStudents = new System.Windows.Forms.DataGridView();
            this.lblHeading = new System.Windows.Forms.Label();
            this.btnMakeGroup = new System.Windows.Forms.Button();
            this.dgvChoosedStudents = new System.Windows.Forms.DataGridView();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.labelChoosedStudents = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoosedStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAllStudents
            // 
            this.dgvAllStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllStudents.Location = new System.Drawing.Point(27, 44);
            this.dgvAllStudents.MultiSelect = false;
            this.dgvAllStudents.Name = "dgvAllStudents";
            this.dgvAllStudents.ReadOnly = true;
            this.dgvAllStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllStudents.Size = new System.Drawing.Size(319, 284);
            this.dgvAllStudents.TabIndex = 8;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(23, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(133, 20);
            this.lblHeading.TabIndex = 7;
            this.lblHeading.Text = "Choose Student :";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMakeGroup
            // 
            this.btnMakeGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeGroup.Location = new System.Drawing.Point(659, 372);
            this.btnMakeGroup.Name = "btnMakeGroup";
            this.btnMakeGroup.Size = new System.Drawing.Size(112, 29);
            this.btnMakeGroup.TabIndex = 6;
            this.btnMakeGroup.Text = "Make Group";
            this.btnMakeGroup.UseVisualStyleBackColor = true;
            this.btnMakeGroup.Click += new System.EventHandler(this.btnMakeGroup_Click);
            // 
            // dgvChoosedStudents
            // 
            this.dgvChoosedStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChoosedStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChoosedStudents.Location = new System.Drawing.Point(452, 44);
            this.dgvChoosedStudents.MultiSelect = false;
            this.dgvChoosedStudents.Name = "dgvChoosedStudents";
            this.dgvChoosedStudents.ReadOnly = true;
            this.dgvChoosedStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChoosedStudents.Size = new System.Drawing.Size(319, 284);
            this.dgvChoosedStudents.TabIndex = 9;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStudent.Location = new System.Drawing.Point(371, 144);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(59, 29);
            this.btnAddStudent.TabIndex = 10;
            this.btnAddStudent.Text = "Add";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(363, 186);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(78, 29);
            this.buttonRemove.TabIndex = 11;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // labelChoosedStudents
            // 
            this.labelChoosedStudents.AutoSize = true;
            this.labelChoosedStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChoosedStudents.Location = new System.Drawing.Point(448, 9);
            this.labelChoosedStudents.Name = "labelChoosedStudents";
            this.labelChoosedStudents.Size = new System.Drawing.Size(142, 20);
            this.labelChoosedStudents.TabIndex = 12;
            this.labelChoosedStudents.Text = "Choosed Student :";
            this.labelChoosedStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(572, 372);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(72, 29);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // MakeGroup
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
            this.Controls.Add(this.btnMakeGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MakeGroup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MakeGroup";
            this.Load += new System.EventHandler(this.MakeGroup_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MakeGroup_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoosedStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllStudents;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Button btnMakeGroup;
        private System.Windows.Forms.DataGridView dgvChoosedStudents;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Label labelChoosedStudents;
        private System.Windows.Forms.Button buttonCancel;
    }
}