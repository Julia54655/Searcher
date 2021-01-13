using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;
namespace FileSearcher
{
    partial class FrmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LbSearchDirectory = new System.Windows.Forms.Label();
            this.TbSearchDirectory = new System.Windows.Forms.TextBox();
            this.BtnSelectSearchDirectory = new System.Windows.Forms.Button();
            this.CbUserSubdirectories = new System.Windows.Forms.CheckBox();
            this.BtnStartPauseSearch = new System.Windows.Forms.Button();
            this.LbTimer = new System.Windows.Forms.Label();
            this.LbTimerCounter = new System.Windows.Forms.Label();
            this.BtnStopSearch = new System.Windows.Forms.Button();
            this.LbTemplateFileNames = new System.Windows.Forms.Label();
            this.TbTemplateFileNames = new System.Windows.Forms.TextBox();
            this.TbSymbolsInFile = new System.Windows.Forms.TextBox();
            this.LbSymbolsInFile = new System.Windows.Forms.Label();
            this.LbFinishedFilesCounter = new System.Windows.Forms.Label();
            this.LbFinishedFiles = new System.Windows.Forms.Label();
            this.LbCurrentFile = new System.Windows.Forms.Label();
            this.LbCurrentFileName = new System.Windows.Forms.Label();
            this.TvResult = new System.Windows.Forms.TreeView();
            this.TmControlUpdater = new System.Windows.Forms.Timer(this.components);
            this.BtnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbSearchDirectory
            // 
            this.LbSearchDirectory.AutoSize = true;
            this.LbSearchDirectory.Location = new System.Drawing.Point(283, 30);
            this.LbSearchDirectory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbSearchDirectory.Name = "LbSearchDirectory";
            this.LbSearchDirectory.Size = new System.Drawing.Size(131, 20);
            this.LbSearchDirectory.TabIndex = 0;
            this.LbSearchDirectory.Text = "Выберете папку";
            this.LbSearchDirectory.Click += new System.EventHandler(this.LbSearchDirectory_Click);
            // 
            // TbSearchDirectory
            // 
            this.TbSearchDirectory.Location = new System.Drawing.Point(287, 67);
            this.TbSearchDirectory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbSearchDirectory.Name = "TbSearchDirectory";
            this.TbSearchDirectory.ReadOnly = true;
            this.TbSearchDirectory.Size = new System.Drawing.Size(237, 26);
            this.TbSearchDirectory.TabIndex = 1;
            // 
            // BtnSelectSearchDirectory
            // 
            this.BtnSelectSearchDirectory.Location = new System.Drawing.Point(540, 63);
            this.BtnSelectSearchDirectory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSelectSearchDirectory.Name = "BtnSelectSearchDirectory";
            this.BtnSelectSearchDirectory.Size = new System.Drawing.Size(60, 35);
            this.BtnSelectSearchDirectory.TabIndex = 2;
            this.BtnSelectSearchDirectory.Text = "...";
            this.BtnSelectSearchDirectory.UseVisualStyleBackColor = true;
            this.BtnSelectSearchDirectory.Click += new System.EventHandler(this.BtnSelectSearchDirectory_Click);
            // 
            // CbUserSubdirectories
            // 
            this.CbUserSubdirectories.AutoSize = true;
            this.CbUserSubdirectories.Checked = true;
            this.CbUserSubdirectories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbUserSubdirectories.Location = new System.Drawing.Point(287, 103);
            this.CbUserSubdirectories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbUserSubdirectories.Name = "CbUserSubdirectories";
            this.CbUserSubdirectories.Size = new System.Drawing.Size(184, 24);
            this.CbUserSubdirectories.TabIndex = 3;
            this.CbUserSubdirectories.Text = "искать в подпапках";
            this.CbUserSubdirectories.UseVisualStyleBackColor = true;
            this.CbUserSubdirectories.CheckedChanged += new System.EventHandler(this.CbUserSubdirectories_CheckedChanged);
            // 
            // BtnStartPauseSearch
            // 
            this.BtnStartPauseSearch.Location = new System.Drawing.Point(468, 317);
            this.BtnStartPauseSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnStartPauseSearch.Name = "BtnStartPauseSearch";
            this.BtnStartPauseSearch.Size = new System.Drawing.Size(132, 35);
            this.BtnStartPauseSearch.TabIndex = 9;
            this.BtnStartPauseSearch.Text = "Поиск";
            this.BtnStartPauseSearch.UseVisualStyleBackColor = true;
            this.BtnStartPauseSearch.Click += new System.EventHandler(this.BtnStartPauseSearch_Click);
            // 
            // LbTimer
            // 
            this.LbTimer.AutoSize = true;
            this.LbTimer.Location = new System.Drawing.Point(266, 535);
            this.LbTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbTimer.Name = "LbTimer";
            this.LbTimer.Size = new System.Drawing.Size(144, 20);
            this.LbTimer.TabIndex = 15;
            this.LbTimer.Text = "Прошло времени:";
            // 
            // LbTimerCounter
            // 
            this.LbTimerCounter.AutoSize = true;
            this.LbTimerCounter.Location = new System.Drawing.Point(418, 535);
            this.LbTimerCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbTimerCounter.Name = "LbTimerCounter";
            this.LbTimerCounter.Size = new System.Drawing.Size(71, 20);
            this.LbTimerCounter.TabIndex = 16;
            this.LbTimerCounter.Text = "00:00:00";
            // 
            // BtnStopSearch
            // 
            this.BtnStopSearch.Enabled = false;
            this.BtnStopSearch.Location = new System.Drawing.Point(287, 317);
            this.BtnStopSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnStopSearch.Name = "BtnStopSearch";
            this.BtnStopSearch.Size = new System.Drawing.Size(132, 35);
            this.BtnStopSearch.TabIndex = 8;
            this.BtnStopSearch.Text = "Отмена";
            this.BtnStopSearch.UseVisualStyleBackColor = true;
            this.BtnStopSearch.Click += new System.EventHandler(this.BtnStopSearch_Click);
            // 
            // LbTemplateFileNames
            // 
            this.LbTemplateFileNames.AutoSize = true;
            this.LbTemplateFileNames.Location = new System.Drawing.Point(283, 177);
            this.LbTemplateFileNames.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbTemplateFileNames.Name = "LbTemplateFileNames";
            this.LbTemplateFileNames.Size = new System.Drawing.Size(72, 20);
            this.LbTemplateFileNames.TabIndex = 4;
            this.LbTemplateFileNames.Text = "Шаблон:";
            // 
            // TbTemplateFileNames
            // 
            this.TbTemplateFileNames.Location = new System.Drawing.Point(363, 177);
            this.TbTemplateFileNames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbTemplateFileNames.Name = "TbTemplateFileNames";
            this.TbTemplateFileNames.Size = new System.Drawing.Size(161, 26);
            this.TbTemplateFileNames.TabIndex = 5;
            this.TbTemplateFileNames.Text = "*.*";
            this.TbTemplateFileNames.TextChanged += new System.EventHandler(this.TbTemplateFileName_TextChanged);
            // 
            // TbSymbolsInFile
            // 
            this.TbSymbolsInFile.Location = new System.Drawing.Point(391, 230);
            this.TbSymbolsInFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbSymbolsInFile.Name = "TbSymbolsInFile";
            this.TbSymbolsInFile.Size = new System.Drawing.Size(133, 26);
            this.TbSymbolsInFile.TabIndex = 7;
            this.TbSymbolsInFile.TextChanged += new System.EventHandler(this.TbSymbolsInFile_TextChanged);
            // 
            // LbSymbolsInFile
            // 
            this.LbSymbolsInFile.AutoSize = true;
            this.LbSymbolsInFile.Location = new System.Drawing.Point(283, 236);
            this.LbSymbolsInFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbSymbolsInFile.Name = "LbSymbolsInFile";
            this.LbSymbolsInFile.Size = new System.Drawing.Size(100, 20);
            this.LbSymbolsInFile.TabIndex = 6;
            this.LbSymbolsInFile.Text = "Имя файла:";
            // 
            // LbFinishedFilesCounter
            // 
            this.LbFinishedFilesCounter.AutoSize = true;
            this.LbFinishedFilesCounter.Location = new System.Drawing.Point(441, 488);
            this.LbFinishedFilesCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbFinishedFilesCounter.Name = "LbFinishedFilesCounter";
            this.LbFinishedFilesCounter.Size = new System.Drawing.Size(18, 20);
            this.LbFinishedFilesCounter.TabIndex = 14;
            this.LbFinishedFilesCounter.Text = "0";
            // 
            // LbFinishedFiles
            // 
            this.LbFinishedFiles.AutoSize = true;
            this.LbFinishedFiles.Location = new System.Drawing.Point(262, 488);
            this.LbFinishedFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbFinishedFiles.Name = "LbFinishedFiles";
            this.LbFinishedFiles.Size = new System.Drawing.Size(171, 20);
            this.LbFinishedFiles.TabIndex = 13;
            this.LbFinishedFiles.Text = "Обработано файлов:";
            // 
            // LbCurrentFile
            // 
            this.LbCurrentFile.AutoSize = true;
            this.LbCurrentFile.Location = new System.Drawing.Point(13, 618);
            this.LbCurrentFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbCurrentFile.Name = "LbCurrentFile";
            this.LbCurrentFile.Size = new System.Drawing.Size(124, 20);
            this.LbCurrentFile.TabIndex = 11;
            this.LbCurrentFile.Text = "Текущий файл:";
            // 
            // LbCurrentFileName
            // 
            this.LbCurrentFileName.AutoSize = true;
            this.LbCurrentFileName.Location = new System.Drawing.Point(153, 618);
            this.LbCurrentFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbCurrentFileName.Name = "LbCurrentFileName";
            this.LbCurrentFileName.Size = new System.Drawing.Size(0, 20);
            this.LbCurrentFileName.TabIndex = 12;
            // 
            // TvResult
            // 
            this.TvResult.Location = new System.Drawing.Point(13, 14);
            this.TvResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TvResult.Name = "TvResult";
            this.TvResult.Size = new System.Drawing.Size(230, 598);
            this.TvResult.TabIndex = 10;
            // 
            // TmControlUpdater
            // 
            this.TmControlUpdater.Enabled = true;
            this.TmControlUpdater.Interval = 50;
            this.TmControlUpdater.Tick += new System.EventHandler(this.TmTimer_Tick);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Enabled = false;
            this.BtnOpen.Location = new System.Drawing.Point(287, 392);
            this.BtnOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(132, 51);
            this.BtnOpen.TabIndex = 17;
            this.BtnOpen.Text = "Открыть";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 656);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.TvResult);
            this.Controls.Add(this.LbCurrentFileName);
            this.Controls.Add(this.LbCurrentFile);
            this.Controls.Add(this.LbFinishedFilesCounter);
            this.Controls.Add(this.LbFinishedFiles);
            this.Controls.Add(this.LbSymbolsInFile);
            this.Controls.Add(this.TbSymbolsInFile);
            this.Controls.Add(this.TbTemplateFileNames);
            this.Controls.Add(this.LbTemplateFileNames);
            this.Controls.Add(this.BtnStopSearch);
            this.Controls.Add(this.LbTimerCounter);
            this.Controls.Add(this.LbTimer);
            this.Controls.Add(this.BtnStartPauseSearch);
            this.Controls.Add(this.CbUserSubdirectories);
            this.Controls.Add(this.BtnSelectSearchDirectory);
            this.Controls.Add(this.TbSearchDirectory);
            this.Controls.Add(this.LbSearchDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbSearchDirectory;
        private System.Windows.Forms.TextBox TbSearchDirectory;
        private System.Windows.Forms.Button BtnSelectSearchDirectory;
        private System.Windows.Forms.CheckBox CbUserSubdirectories;
        private System.Windows.Forms.Button BtnStartPauseSearch;
        private System.Windows.Forms.Label LbTimer;
        private System.Windows.Forms.Label LbTimerCounter;
        private System.Windows.Forms.Button BtnStopSearch;
        private System.Windows.Forms.Label LbTemplateFileNames;
        private System.Windows.Forms.TextBox TbTemplateFileNames;
        private System.Windows.Forms.TextBox TbSymbolsInFile;
        private System.Windows.Forms.Label LbSymbolsInFile;
        private System.Windows.Forms.Label LbFinishedFilesCounter;
        private System.Windows.Forms.Label LbFinishedFiles;
        private System.Windows.Forms.Label LbCurrentFile;
        private System.Windows.Forms.Label LbCurrentFileName;
        private System.Windows.Forms.TreeView TvResult;
        private System.Windows.Forms.Timer TmControlUpdater;
        private System.Windows.Forms.Button BtnOpen;
    }
}

