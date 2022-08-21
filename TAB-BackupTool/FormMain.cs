using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace TABBackupTool
{
    public partial class FormMain : Form
    {
        private string _sourceFolder = string.Empty;
        private string _sourceFolderKey = "SourceFolder";

        public FormMain()
        {
            InitializeComponent();
        }

        private void SaveSourceFolder()
        {
            var inputFolder = textBoxSourceFolder.Text;
            if (inputFolder.Equals(_sourceFolder))
            {
                return;
            }

            if (!Directory.Exists(inputFolder))
            {
                throw new Exception($"Folder {inputFolder} not exist.");
            }

            AddOrUpdateAppSettings(_sourceFolderKey, inputFolder);
            _sourceFolder = inputFolder;
        }

        //https://stackoverflow.com/a/26778377
        public static void AddOrUpdateAppSettings(string key, string value)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            try
            {
                //SaveSourceFolder();

                var backupRootFolder = Path.Combine(_sourceFolder, "Backups");
                CreateFolder(backupRootFolder);

                var monthFolder = Path.Combine(backupRootFolder, DateTime.Now.ToString("yyyyMM"));
                CreateFolder(monthFolder);

                var backupFolder = Path.Combine(monthFolder, DateTime.Now.ToString("yyyy-MM-dd HHmmss"));
                CreateFolder(backupFolder);

                var files = Directory.GetFiles(_sourceFolder);
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
            var sourceFolder = ConfigurationManager.AppSettings[_sourceFolderKey];
            if (string.IsNullOrWhiteSpace(sourceFolder))
            {
                throw new Exception("Can not find source folder in app setting.");
            }

            if (!Directory.Exists(sourceFolder))
            {
                throw new Exception("Source folder not exist.");
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
            try
            {
                _sourceFolder = GetSourceFolder();
                textBoxSourceFolder.Text = _sourceFolder;

                LoadBackups();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadBackups()
        {
            var backupRootFolder = Path.Combine(_sourceFolder, "Backups");
            CreateFolder(backupRootFolder);

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
                    MessageBox.Show(@"Please select a node to restore first.");
                    return;
                }

                if (node.Tag == null)
                {
                    MessageBox.Show(@"Please select correct node.");
                    return;
                }

                var restoreFolder = node.Tag.ToString();
                var files = Directory.GetFiles(restoreFolder);
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    var targetFileName = Path.Combine(_sourceFolder, fileName);
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
