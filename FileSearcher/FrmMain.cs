using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FileSearcher
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private string searchStatus = "notstarted";
        private string currentFileName = string.Empty;
        private int filesCounter = 0;
        private readonly Stopwatch stopwatch = new Stopwatch();
        private Thread thread;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            TbSearchDirectory.Text = Properties.Settings.Default.SearchDirectory;
            CbUserSubdirectories.Checked = Properties.Settings.Default.UserSubdirectories;
            TbTemplateFileNames.Text = Properties.Settings.Default.TemplateFileName;
            TbSymbolsInFile.Text = Properties.Settings.Default.TbSymbolsInFile;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (searchStatus == "started" || searchStatus == "paused")
            {
                DialogResult dialogResult = MessageBox.Show("Закрыть программу?", "Поиск", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    thread.Abort();

                    stopwatch.Stop();

                    searchStatus = "notstarted";
                }
            }
        }

        private void BtnSelectSearchDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog
            {
                SelectedPath = TbSearchDirectory.Text
            };
            if (folderBrowser.ShowDialog(this) == DialogResult.OK)
            {
                Properties.Settings.Default.SearchDirectory = folderBrowser.SelectedPath;
                Properties.Settings.Default.Save();

                TbSearchDirectory.Text = folderBrowser.SelectedPath;
            }
            folderBrowser.Dispose();
        }

        private void CbUserSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UserSubdirectories = CbUserSubdirectories.Checked;
            Properties.Settings.Default.Save();
        }

        private void TbTemplateFileName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TemplateFileName = TbTemplateFileNames.Text;
            Properties.Settings.Default.Save();
        }

        private void TbSymbolsInFile_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TbSymbolsInFile = TbSymbolsInFile.Text;
            Properties.Settings.Default.Save();
        }

        private void BtnStopSearch_Click(object sender, EventArgs e)
        {
            if (searchStatus == "started" || searchStatus == "paused")
            {
                DialogResult dialogResult = MessageBox.Show("Закрыть программу?", "Поиск", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    if (thread.ThreadState == System.Threading.ThreadState.Suspended)
                    {
                        thread.Resume();
                    }

                    thread.Abort();

                    stopwatch.Stop();

                    searchStatus = "notstarted";
                }
            }
        }

        private void BtnStartPauseSearch_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(TbSearchDirectory.Text))
            {
                if (!string.IsNullOrWhiteSpace(TbTemplateFileNames.Text))
                {
                    if (searchStatus == "notstarted")
                    {
                        searchStatus = "started";

                        TvResult.Nodes.Clear();

                        currentFileName = string.Empty;
                        filesCounter = 0;

                        thread = new Thread(FileSearcher);
                        thread.Start();
                    }
                    else if (searchStatus == "started")
                    {
                        searchStatus = "paused";

                        stopwatch.Stop();

                        thread.Suspend();
                    }
                    else if (searchStatus == "paused")
                    {
                        searchStatus = "started";

                        stopwatch.Start();

                        thread.Resume();
                    }
                }
                else
                {
                    MessageBox.Show("Укажите шаблон", "Поиск");
                }
            }
            else
            {
                MessageBox.Show("Папка не найдена", "Поиск");
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (TvResult.SelectedNode != null)
            {
                Process.Start(TvResult.SelectedNode.Tag.ToString());
            }
        }

        private void TmTimer_Tick(object sender, EventArgs e)
        {
            LbCurrentFileName.Text = currentFileName;
            LbFinishedFilesCounter.Text = filesCounter.ToString();

            TimeSpan timeSpan = stopwatch.Elapsed;
            LbTimerCounter.Text = timeSpan.ToString(@"hh\:mm\:ss");

            if (searchStatus == "notstarted")
            {
                BtnStopSearch.Enabled = false;
                BtnStartPauseSearch.Text = "Искать";
            }
            else if (searchStatus == "started")
            {
                BtnStopSearch.Enabled = true;
                BtnStartPauseSearch.Text = "Пауза";
            }
            else if (searchStatus == "paused")
            {
                BtnStopSearch.Enabled = true;
                BtnStartPauseSearch.Text = "Продолжить";
            }

            if (TvResult.SelectedNode != null)
            {
                BtnOpen.Enabled = true;
            }
            else
            {
                BtnOpen.Enabled = false;
            }
        }

        private void FileSearcher()
        {
            stopwatch.Restart();

            DirectoryInfo directoryInfo = new DirectoryInfo(TbSearchDirectory.Text);
            TreeNode treeNode = (TreeNode)TvResult.Invoke(new Func<string, TreeNode>((s) => TvResult.Nodes.Add(s)), directoryInfo.Name);
            treeNode.Tag = directoryInfo.FullName;

            if (CbUserSubdirectories.Checked)
            {
                LoadSubDirectories(TbSearchDirectory.Text, treeNode);
            }

            LoadFiles(TbSearchDirectory.Text, treeNode);

            stopwatch.Stop();

            searchStatus = "notstarted";
        }

        private void LoadSubDirectories(string searchDirectory, TreeNode treeNode)
        {
            try
            {
                string[] subdirectories = Directory.GetDirectories(searchDirectory);
                foreach (string subdirectory in subdirectories)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(subdirectory);
                    TreeNode treeNode1 = (TreeNode)TvResult.Invoke(new Func<string, TreeNode>((s) => treeNode.Nodes.Add(s)), directoryInfo.Name);
                    treeNode1.Tag = directoryInfo.FullName;

                    LoadSubDirectories(subdirectory, treeNode1);
                    LoadFiles(subdirectory, treeNode1);

                    if (treeNode1.Nodes.Count == 0)
                    {
                        TvResult.Invoke(new Action<TreeNode>((s) => treeNode.Nodes.Remove(s)), treeNode1);

                        Thread.Sleep(25);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {

            }
        }

        private void LoadFiles(string searchDirectory, TreeNode treeNode)
        {
            try
            {
                string[] files = Directory.GetFiles(searchDirectory, TbTemplateFileNames.Text);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    currentFileName = fileInfo.Name;

                    Thread.Sleep(50);

                    if (!string.IsNullOrEmpty(TbSymbolsInFile.Text))
                    {
                        char[] symbols = TbSymbolsInFile.Text.ToCharArray();

                        try
                        {
                            FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.Open);
                            StreamReader streamReader = new StreamReader(fileStream);
                            string fileText = streamReader.ReadToEnd();

                            foreach (char symbol in symbols)
                            {
                                if (fileText.Contains(symbol.ToString()))
                                {
                                    treeNode = (TreeNode)TvResult.Invoke(new Func<string, TreeNode>((s) => treeNode.Nodes.Add(s)), fileInfo.Name);
                                    treeNode.Tag = fileInfo.FullName;

                                    break;
                                }
                            }

                            streamReader.Close();
                        }
                        catch (IOException)
                        {

                        }
                    }
                    else
                    {
                        treeNode = (TreeNode)TvResult.Invoke(new Func<string, TreeNode>((s) => treeNode.Nodes.Add(s)), fileInfo.Name);
                        treeNode.Tag = fileInfo.FullName;
                    }

                    filesCounter++;

                    currentFileName = string.Empty;
                }
            }
            catch (UnauthorizedAccessException)
            {
                filesCounter++;
            }
        }

        private void LbSearchDirectory_Click(object sender, EventArgs e)
        {

        }
    }
}