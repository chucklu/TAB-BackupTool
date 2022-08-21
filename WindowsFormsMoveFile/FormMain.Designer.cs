
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
            this.SuspendLayout();
            // 
            // buttonMoveFile
            // 
            this.buttonMoveFile.Location = new System.Drawing.Point(465, 164);
            this.buttonMoveFile.Name = "buttonMoveFile";
            this.buttonMoveFile.Size = new System.Drawing.Size(111, 53);
            this.buttonMoveFile.TabIndex = 0;
            this.buttonMoveFile.Text = "MoveFile";
            this.buttonMoveFile.UseVisualStyleBackColor = true;
            this.buttonMoveFile.Click += new System.EventHandler(this.buttonMoveFile_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonMoveFile);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMoveFile;
    }
}

