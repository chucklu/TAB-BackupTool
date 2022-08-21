
namespace WindowsFormsMoveFile
{
    partial class FormMain
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
            this.buttonBackup = new System.Windows.Forms.Button();
            this.treeViewBackups = new System.Windows.Forms.TreeView();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.textBoxSourceFolder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(356, 11);
            this.buttonBackup.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(83, 43);
            this.buttonBackup.TabIndex = 0;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // treeViewBackups
            // 
            this.treeViewBackups.Location = new System.Drawing.Point(12, 66);
            this.treeViewBackups.Name = "treeViewBackups";
            this.treeViewBackups.Size = new System.Drawing.Size(332, 277);
            this.treeViewBackups.TabIndex = 1;
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(356, 66);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(83, 43);
            this.buttonRestore.TabIndex = 2;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // textBoxSourceFolder
            // 
            this.textBoxSourceFolder.Location = new System.Drawing.Point(12, 23);
            this.textBoxSourceFolder.Name = "textBoxSourceFolder";
            this.textBoxSourceFolder.ReadOnly = true;
            this.textBoxSourceFolder.Size = new System.Drawing.Size(332, 20);
            this.textBoxSourceFolder.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.textBoxSourceFolder);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.treeViewBackups);
            this.Controls.Add(this.buttonBackup);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "Backup tool for 《They Are Billions》（亿万僵尸）";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.TreeView treeViewBackups;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.TextBox textBoxSourceFolder;
    }
}

