using System;
using System.Configuration;
using System.IO;
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
            textBoxSourceFolder.Text = sourceFolder;

            var backupRootFolder = Path.Combine(sourceFolder, "Backups");
            if (!Directory.Exists(backupRootFolder))
            {
                MessageBox.Show($@"Backups folder {backupRootFolder} not exist.");
                return;
            }

            var topNode = treeViewBackups.Nodes.Add("Backups");
            
            //get all month folders under backups
            var folders = Directory.GetDirectories(backupRootFolder);
            foreach (var folder in folders)
            {
                var folderName = Path.GetFileName(folder);
                var node = topNode.Nodes.Add(folderName);
                var subFolders = Directory.GetDirectories(folder);
                foreach (var subFolder in subFolders)
                {
                    var subFolderName = Path.GetFileName(subFolder);
                    var tempNode = node.Nodes.Add(subFolderName);
                    tempNode.Tag = subFolder;
                }
            }
            treeViewBackups.ExpandAll();
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            try
            {
                var node = treeViewBackups.SelectedNode;
                if (node == null)
                {
                    MessageBox.Show(@"Please select a node to restore first");
                    return;
                }

                var sourceFolder = GetSourceFolder();

                var restoreFolder = node.Tag.ToString();
                var files = Directory.GetFiles(restoreFolder);
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    var targetFileName = Path.Combine(sourceFolder, fileName);
                    File.Copy(file, targetFileName, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
