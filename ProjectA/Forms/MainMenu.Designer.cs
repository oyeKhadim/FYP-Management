﻿namespace ProjectA.Forms
{
    partial class MainMenu
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
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.lblTopBar = new System.Windows.Forms.Label();
            this.paneltopLeft = new System.Windows.Forms.Panel();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.panelSideBar = new System.Windows.Forms.Panel();
            this.buttonManageGroups = new System.Windows.Forms.Button();
            this.buttonManageProjects = new System.Windows.Forms.Button();
            this.buttonManageAdvisors = new System.Windows.Forms.Button();
            this.buttonManageStudents = new System.Windows.Forms.Button();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panelTopBar.SuspendLayout();
            this.paneltopLeft.SuspendLayout();
            this.panelSideBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.panelTopBar.Controls.Add(this.btnCloseChildForm);
            this.panelTopBar.Controls.Add(this.lblTopBar);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(182, 0);
            this.panelTopBar.Margin = new System.Windows.Forms.Padding(0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(802, 41);
            this.panelTopBar.TabIndex = 1;
            this.panelTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseDown);
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseChildForm.Location = new System.Drawing.Point(9, 6);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(28, 29);
            this.btnCloseChildForm.TabIndex = 0;
            this.btnCloseChildForm.Text = "X";
            this.btnCloseChildForm.UseVisualStyleBackColor = true;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // lblTopBar
            // 
            this.lblTopBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTopBar.AutoSize = true;
            this.lblTopBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopBar.Location = new System.Drawing.Point(338, 3);
            this.lblTopBar.Name = "lblTopBar";
            this.lblTopBar.Size = new System.Drawing.Size(95, 31);
            this.lblTopBar.TabIndex = 0;
            this.lblTopBar.Text = "HOME";
            // 
            // paneltopLeft
            // 
            this.paneltopLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.paneltopLeft.Controls.Add(this.lblProjectName);
            this.paneltopLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltopLeft.Location = new System.Drawing.Point(0, 0);
            this.paneltopLeft.Name = "paneltopLeft";
            this.paneltopLeft.Size = new System.Drawing.Size(182, 41);
            this.paneltopLeft.TabIndex = 1;
            // 
            // lblProjectName
            // 
            this.lblProjectName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.Location = new System.Drawing.Point(3, 9);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(170, 25);
            this.lblProjectName.TabIndex = 1;
            this.lblProjectName.Text = "FYP Management";
            this.lblProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSideBar
            // 
            this.panelSideBar.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panelSideBar.Controls.Add(this.buttonManageGroups);
            this.panelSideBar.Controls.Add(this.buttonManageProjects);
            this.panelSideBar.Controls.Add(this.buttonManageAdvisors);
            this.panelSideBar.Controls.Add(this.buttonManageStudents);
            this.panelSideBar.Controls.Add(this.paneltopLeft);
            this.panelSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideBar.ForeColor = System.Drawing.Color.Black;
            this.panelSideBar.Location = new System.Drawing.Point(0, 0);
            this.panelSideBar.Margin = new System.Windows.Forms.Padding(0);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(182, 511);
            this.panelSideBar.TabIndex = 1;
            // 
            // buttonManageGroups
            // 
            this.buttonManageGroups.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonManageGroups.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonManageGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonManageGroups.FlatAppearance.BorderSize = 0;
            this.buttonManageGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManageGroups.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManageGroups.ForeColor = System.Drawing.Color.White;
            this.buttonManageGroups.Location = new System.Drawing.Point(0, 158);
            this.buttonManageGroups.Name = "buttonManageGroups";
            this.buttonManageGroups.Size = new System.Drawing.Size(182, 39);
            this.buttonManageGroups.TabIndex = 5;
            this.buttonManageGroups.Text = "Manage Groups";
            this.buttonManageGroups.UseVisualStyleBackColor = false;
            this.buttonManageGroups.Click += new System.EventHandler(this.buttonManageGroups_Click);
            // 
            // buttonManageProjects
            // 
            this.buttonManageProjects.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonManageProjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonManageProjects.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonManageProjects.FlatAppearance.BorderSize = 0;
            this.buttonManageProjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManageProjects.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManageProjects.ForeColor = System.Drawing.Color.White;
            this.buttonManageProjects.Location = new System.Drawing.Point(0, 119);
            this.buttonManageProjects.Name = "buttonManageProjects";
            this.buttonManageProjects.Size = new System.Drawing.Size(182, 39);
            this.buttonManageProjects.TabIndex = 4;
            this.buttonManageProjects.Text = "Manage Projects";
            this.buttonManageProjects.UseVisualStyleBackColor = false;
            this.buttonManageProjects.Click += new System.EventHandler(this.buttonManageProjects_Click);
            // 
            // buttonManageAdvisors
            // 
            this.buttonManageAdvisors.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonManageAdvisors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonManageAdvisors.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonManageAdvisors.FlatAppearance.BorderSize = 0;
            this.buttonManageAdvisors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManageAdvisors.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManageAdvisors.ForeColor = System.Drawing.Color.White;
            this.buttonManageAdvisors.Location = new System.Drawing.Point(0, 80);
            this.buttonManageAdvisors.Name = "buttonManageAdvisors";
            this.buttonManageAdvisors.Size = new System.Drawing.Size(182, 39);
            this.buttonManageAdvisors.TabIndex = 3;
            this.buttonManageAdvisors.Text = "Manage Advisors";
            this.buttonManageAdvisors.UseVisualStyleBackColor = false;
            this.buttonManageAdvisors.Click += new System.EventHandler(this.buttonManageAdvisors_Click);
            // 
            // buttonManageStudents
            // 
            this.buttonManageStudents.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonManageStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonManageStudents.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonManageStudents.FlatAppearance.BorderSize = 0;
            this.buttonManageStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManageStudents.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManageStudents.ForeColor = System.Drawing.Color.White;
            this.buttonManageStudents.Location = new System.Drawing.Point(0, 41);
            this.buttonManageStudents.Name = "buttonManageStudents";
            this.buttonManageStudents.Size = new System.Drawing.Size(182, 39);
            this.buttonManageStudents.TabIndex = 2;
            this.buttonManageStudents.Text = "Manage Students";
            this.buttonManageStudents.UseVisualStyleBackColor = false;
            this.buttonManageStudents.Click += new System.EventHandler(this.buttonManageStudents_Click);
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.SystemColors.Control;
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(182, 41);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(802, 470);
            this.panelChildForm.TabIndex = 2;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(984, 511);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelTopBar);
            this.Controls.Add(this.panelSideBar);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "MainMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.panelTopBar.ResumeLayout(false);
            this.panelTopBar.PerformLayout();
            this.paneltopLeft.ResumeLayout(false);
            this.paneltopLeft.PerformLayout();
            this.panelSideBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Panel paneltopLeft;
        private System.Windows.Forms.Panel panelSideBar;
        private System.Windows.Forms.Button buttonManageGroups;
        private System.Windows.Forms.Button buttonManageProjects;
        private System.Windows.Forms.Button buttonManageAdvisors;
        private System.Windows.Forms.Button buttonManageStudents;
        private System.Windows.Forms.Label lblTopBar;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Button btnCloseChildForm;
        private System.Windows.Forms.Panel panelChildForm;
    }
}