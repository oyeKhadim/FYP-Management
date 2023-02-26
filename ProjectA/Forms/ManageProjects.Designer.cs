namespace ProjectA.Forms
{
    partial class ManageProjects
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
            this.guna2VProgressBar1 = new Guna.UI2.WinForms.Guna2VProgressBar();
            this.SuspendLayout();
            // 
            // guna2VProgressBar1
            // 
            this.guna2VProgressBar1.Location = new System.Drawing.Point(347, 74);
            this.guna2VProgressBar1.Name = "guna2VProgressBar1";
            this.guna2VProgressBar1.Size = new System.Drawing.Size(30, 300);
            this.guna2VProgressBar1.TabIndex = 0;
            this.guna2VProgressBar1.Text = "guna2VProgressBar1";
            this.guna2VProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // ManageProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 431);
            this.Controls.Add(this.guna2VProgressBar1);
            this.Name = "ManageProjects";
            this.Text = "Manage Projects";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2VProgressBar guna2VProgressBar1;
    }
}