using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMoveFile
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonMoveFile_Click(object sender, EventArgs e)
        {
            try
            {
                var sourceFolder = GetSourceFolder();

                var backupRootFolder = Path.Combine(sourceFolder, "Backups");
                CreateFolder(backupRootFolder);

                var monthFolder = Path.Combine(backupRootFolder, DateTime.Now.ToString("yyyyMM"));
                CreateFolder(monthFolder);

                var backupFolder = Path.Combine(monthFolder, DateTime.Now.ToString("yyyy-MM-dd HHmmss"));
                CreateFolder(backupFolder);

                var files = Directory.GetFiles(sourceFolder);
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    var targetFileName = Path.Combine(backupFolder, fileName);
                    File.Copy(file, targetFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string GetSourceFolder()
        {
            var sourceFolder = ConfigurationManager.AppSettings["SourceFolder"];
            if (string.IsNullOrWhiteSpace(sourceFolder))
            {
                throw new Exception("Can not find source folder in app setting.");
            }

            if (!Directory.Exists(sourceFolder))
            {
                throw new Exception("Source folder not exist");
            }

            return sourceFolder;
        }

        private void CreateFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var sourceFolder = GetSourceFolder();

            var backupRootFolder = Path.Combine(sourceFolder, "Backups");
            if (!Directory.Exists(backupRootFolder))
            {
                MessageBox.Show($@"Backups folder {backupRootFolder} not exist.");
                return;
            }

            var folders = Directory.GetDirectories(backupRootFolder);//month folder here
            foreach (var folder in folders)
            {
                var node = treeViewBackups.Nodes.Add(folder);
                var subFolders = Directory.GetDirectories(folder);
                foreach (var subFolder in subFolders)
                {
                    node.Nodes.Add(subFolder);
                }
            }
        }
    }
}
