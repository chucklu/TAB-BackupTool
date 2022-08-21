
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
            this.buttonMoveFile = new System.Windows.Forms.Button();
            this.treeViewBackups = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // buttonMoveFile
            // 
            this.buttonMoveFile.Location = new System.Drawing.Point(356, 11);
            this.buttonMoveFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonMoveFile.Name = "buttonMoveFile";
            this.buttonMoveFile.Size = new System.Drawing.Size(83, 43);
            this.buttonMoveFile.TabIndex = 0;
            this.buttonMoveFile.Text = "MoveFile";
            this.buttonMoveFile.UseVisualStyleBackColor = true;
            this.buttonMoveFile.Click += new System.EventHandler(this.buttonMoveFile_Click);
            // 
            // treeViewBackups
            // 
            this.treeViewBackups.Location = new System.Drawing.Point(12, 66);
            this.treeViewBackups.Name = "treeViewBackups";
            this.treeViewBackups.Size = new System.Drawing.Size(332, 277);
            this.treeViewBackups.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.treeViewBackups);
            this.Controls.Add(this.buttonMoveFile);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMoveFile;
        private System.Windows.Forms.TreeView treeViewBackups;
    }
}

