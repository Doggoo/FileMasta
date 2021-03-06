﻿using FileMasta.Controls;
using FileMasta.Extensions;
using FileMasta.Files;
using FileMasta.GitHub;
using FileMasta.Models;
using FileMasta.Utilities;
using FileMasta.Windows;
using FileMasta.Worker;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System;

namespace FileMasta
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// This is only instance of the main form, set after InitializeComponent()
        /// </summary>
        public static MainForm Form { get; set; } = null;

        /// <summary>
        /// Splash Screen (one instance)
        /// </summary>
        public static SplashScreen FrmSplashScreen { get; } = new SplashScreen();

        /// <summary>
        /// About Dialog (one instance)
        /// </summary>
        public static AboutWindow FormAboutDialog { get; } = new AboutWindow();

        /// <summary>
        /// Keyboard Shortcuts Window (one instance)
        /// </summary>
        public static ShortcutsWindow FrmKeyboardShortcuts { get; } = new ShortcutsWindow();

        /// <summary>
        /// File Details Window (one instance, set when first shown)
        /// </summary>
        public static FileDetailsWindow FrmFileDetails { get; set; } = null;

        /// <summary>
        /// WebClient instance
        /// </summary>
        public static WebClient _webClient { get; set; } = new WebClient();

        /// <summary>
        /// Proxy Connection Settings
        /// </summary>
        public static bool UseWebProxyCustom { get; set; } = Properties.Settings.Default.proxyUseCustom;

        public MainForm()
        {
            Program.log.Info("Initializing");

            // Adds all file types to one list
            Types.All.AddRange(Types.Image); Types.All.AddRange(Types.Video); Types.All.AddRange(Types.Audio); Types.All.AddRange(Types.Book); Types.All.AddRange(Types.Subtitle); Types.All.AddRange(Types.Torrent); Types.All.AddRange(Types.Software); Types.All.AddRange(Types.Other);

            // Initialize
            InitializeComponent();

            // Set this instance
            Form = this;
            
            // Show Splash Screen
            Controls.Add(FrmSplashScreen);
            FrmSplashScreen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            FrmSplashScreen.Location = new Point(0, 0);
            FrmSplashScreen.Size = Form.ClientSize;
            FrmSplashScreen.BringToFront();
            FrmSplashScreen.Show();

            comboBoxType.SelectedIndex = 0;
            comboBoxSort.SelectedIndex = 0;
            comboBoxHost.SelectedIndex = 0;

            // Set this version on Change Log in Menu Strip
            menuHelpChangeLog.Text = String.Format(menuHelpChangeLog.Text, Application.ProductVersion);

            Program.log.Info("Initialized");
        }

        /*************************************************************************/
        /* Share on Social Media                                                 */
        /*************************************************************************/

        public string shareMessage = "Hey guys, I found a brilliant way to find direct download links for anything.";

        private void ImageShareTwitter_Click(object sender, EventArgs e)
        {
            Process.Start($"https://twitter.com/intent/tweet?hashtags=FileMasta&original_referer=https%3A%2F%2Fgithub.com/HerbL27/FileMasta%2F&ref_src=twsrc%5Etfw&text={shareMessage}&tw_p=tweetbutton&url=https%3A%2F%2Fgithub.com/HerbL27/FileMasta");
        }

        private void ImageShareFacebook_Click(object sender, EventArgs e)
        {
            Process.Start("https://facebook.com/sharer/sharer.php?app_id=248335808680372&kid_directed_site=0&sdk=joey&u=http%3A%2F%2Fgithub.com/HerbL27/FileMasta%2F&display=popup&ref=plugin&src=share_button");
        }

        /*************************************************************************/
        /* Form / Startup Events                                                 */
        /*************************************************************************/

        private void MainForm_Load(object sender, EventArgs e)
        {
            Program.log.Info("Starting load events");

            Directory.CreateDirectory(LocalExtensions.pathRoot);
            Directory.CreateDirectory(LocalExtensions.pathData);

            if (LocalExtensions.IsConnectionEnabled())
            {
                Updates.CheckForUpdate();
                LoadTopSearches();
                BackGroundWorker.RunWorkAsync(() => Database.UpdateLocalDatabase(), InitializeFinished);
            }
            else
            {
                Controls.Remove(FrmSplashScreen);
                MessageBox.Show(this, "No Internet connection found. You need to be connected to the Internet to use FileMasta. Please check your connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Program.log.Info("Completed all load events");
        }

        private void InitializeFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            SetDatabaseInfo();
            Controls.Remove(FrmSplashScreen);
            Program.log.Info("All startup tasks completed");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing | e.CloseReason == CloseReason.ApplicationExitCall)
                if (Properties.Settings.Default.clearDataOnClose)
                    if (Directory.Exists(LocalExtensions.pathData))
                        Directory.Delete(LocalExtensions.pathData, true);

            Program.log.Info("Closing application");
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        /// <summary>
        /// Fix paint form
        /// </summary>
        protected override void OnPaint(PaintEventArgs e) { }

        /// <summary>
        /// Declare new lists to store database info in variables
        /// </summary>
        public static List<WebFile> DbOpenFiles { get; set; } = new List<WebFile>();
        public static List<string> DbOpenServers { get; set; } = new List<string>();
        public static string DatabaseInfo { get; set; }

        /*************************************************************************/
        /* Menu Strip                                                            */
        /*************************************************************************/

        // File
        private void menuFileBookmarks_Click(object sender, EventArgs e)
        {
            var bookmarks = new BookmarksWindow();
            bookmarks.ShowDialog(this);
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Tools
        private void menuToolsWebServerList_Click(object sender, EventArgs e)
        {
            var servers = new ServersWindow();
            servers.ShowDialog(this);
        }

        private void menuToolsSubmitWebsite_Click(object sender, EventArgs e)
        {
            var submit = new SubmitWindow();
            submit.ShowDialog(this);
        }

        // Options
        private void menuStripToolsOptions_Click(object sender, EventArgs e)
        {
            var optionsDialog = new OptionsWindow();
            optionsDialog.ShowDialog(this);
        }

        // Help
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAboutDialog.ShowDialog(this);
        }

        private void reportIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start($"{OpenLink.urlGitHub}issues/new");
        }

        private void keyboardShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKeyboardShortcuts.ShowDialog(this);
        }

        private void changeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlExtensions.ShowDataWindow(((ToolStripMenuItem)sender).Text, Resources.UrlChangeLog);
        }

        private void termsOfUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlExtensions.ShowDataWindow(((ToolStripMenuItem)sender).Text, Resources.UrlTermsOfUse);
        }

        private void privacyPolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlExtensions.ShowDataWindow(((ToolStripMenuItem)sender).Text, Resources.UrlPrivacyPolicy);
        }

        /// <summary>
        /// Set database to UI
        /// </summary>
        public void SetDatabaseInfo()
        {
            toolStripDatabaseInfo.Text = string.Format(toolStripDatabaseInfo.Text,
                StringExtensions.FormatNumber(DbOpenFiles.Count.ToString()),
                StringExtensions.BytesToPrefix(Database.TotalFilesSize()),
                StringExtensions.FormatNumber(DbOpenServers.Count.ToString()),
                Database.LastUpdate().ToShortDateString());               
        }

        /// <summary>
        /// Powered by the HackerTarget API to get Top Searches from FileChef.com
        /// </summary>
        delegate void LoadTopSearchesCallBack();
        private void LoadTopSearches()
        {
            try
            {
                Program.log.Info("Getting most searches");

                BackGroundWorker.RunWorkAsync<List<string>>(() => GetTopSearches(), (data) =>
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new LoadTopSearchesCallBack(LoadTopSearches), new object[] { });
                    }
                    else
                    {
                        int count = 0;
                        foreach (var tag in data)
                            if (count <= 100)
                            {
                                flowPanelMostSearches.Controls.Add(ControlExtensions.GetMostSearchTag(tag, count));
                                count++;
                            }

                        Program.log.Info("Most searches returned successfully");
                    }
                });
            }
            catch (Exception ex) { labelMostSearches.Visible = false; flowPanelMostSearches.Visible = false; Program.log.Error("Error getting top searches", ex); } /* Error occurred, so hide controls/skip... */
        }

        /// <summary>
        /// Get Top Searches from web database
        /// </summary>
        /// <returns></returns>
        private List<string> GetTopSearches()
        {
            List<string> listTopSearches = new List<string>();
            using (var client = _webClient)
            using (var stream = client.OpenRead(Database.dbTopSearches))
            using (var reader = new StreamReader(stream))
            {
                stream.ReadTimeout = 60000;
                string line;
                while ((line = reader.ReadLine()) != null)
                    listTopSearches.Add(line);
            }
            return listTopSearches;
        }

        /*************************************************************************/
        /* Search Files                                                           */
        /*************************************************************************/

        /// <summary>
        /// User Preference: Files Type
        /// </summary>
        public List<string> SelectedFilesType { get; set; } = Types.All;

        /// <summary>
        /// User Preference: Sort Files By
        /// </summary>
        public Query.SortBy SelectedFilesSort { get; set; } = Query.SortBy.Name;

        /// <summary>
        /// User Preference: Files Host
        /// </summary>
        public string SelectedFilesHost { get; set; } = "";

        private void buttonSearchFiles_Click(object sender, EventArgs e)
        {
            SearchFiles();
        }

        private void textBoxSearchQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (textBoxSearchQuery.Text.Length > 2)
                    SearchFiles();
                else SetStatus("Minimum 3 characters."); 
        }

        public void SearchFiles()
        {
            SetStatus("Searching files..");

            if (Uri.TryCreate(textBoxSearchQuery.Text, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps) && uriResult != null)
            {
                if (WebFileExtensions.URLExists(uriResult.ToString()))
                {
                    try
                    {
                        ShowFileDetails(Database.WebFile(textBoxSearchQuery.Text), dataGridFiles);
                        textBoxSearchQuery.Text = null;
                    }
                    catch (Exception ex) { MessageBox.Show("There was an issue requesting this file. Make sure it exists on the server you're trying to access.\n\n" + ex.Message); }
                }
                else
                    MessageBox.Show(this, "There was an issue requesting this file. Make sure it exists on the server you're trying to access.");
            }
            else
                ShowFiles();
        }

        // Files dataGridView row click, will get the last (hidden) column (URL) in the selected row and use to get WebFile properties
        private void dataGridFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var URL = dataGridFiles.CurrentRow.Cells[5].Value.ToString();

                if (dataGridFiles.CurrentRow.Cells[4].Value.ToString() == "Local")
                    ShowFileDetails(new WebFile(Path.GetExtension(URL).Replace(".", "").ToUpper(), Path.GetFileNameWithoutExtension(new Uri(URL).LocalPath), new FileInfo(URL).Length, File.GetCreationTime(URL), URL, URL), dataGridFiles, true);
                else
                    ShowFileDetails(Database.WebFile(URL), dataGridFiles);
            }
        }

        private void dataGridFiles_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        delegate void ShowFilesCallBack();
        public void ShowFiles()
        {
            EnableSearchControls(false);
            var stopWatch = new Stopwatch();
            Program.log.InfoFormat("Starting query. Preferences - Sort: {0}, Type: {1}, Host: {2}", SelectedFilesSort.ToString(), SelectedFilesType.ToList(), SelectedFilesHost);
            BackGroundWorker.RunWorkAsync<List<WebFile>>(() => Query.Search(DbOpenFiles, textBoxSearchQuery.Text, SelectedFilesSort), (data) =>
            {
                if (this.InvokeRequired)
                {
                    var b = new ShowFilesCallBack(ShowFiles);
                    Invoke(b, new object[] { });
                }
                else
                {
                    dataGridFiles.Rows.Clear();
                    comboBoxHost.Items.Clear(); comboBoxHost.Items.Add("Any");
                    stopWatch.Start();
                    foreach (var jsonData in data)
                        if (SelectedFilesType.Contains(jsonData.Type) && jsonData.Host.Contains(SelectedFilesHost))
                        {
                            dataGridFiles.Rows.Add(jsonData.Type, jsonData.Name, StringExtensions.BytesToPrefix(jsonData.Size), StringExtensions.TimeSpanAge(jsonData.DateUploaded), jsonData.Host, jsonData.URL);
                            if (!(comboBoxHost.Items.Contains(jsonData.Host)))
                                comboBoxHost.Items.Add(jsonData.Host);
                        }

                    stopWatch.Stop();
                    SetStatus(string.Format("Successfully returned search results - {0} Results ({2} seconds)", StringExtensions.FormatNumber(dataGridFiles.Rows.Count.ToString()), StringExtensions.FormatNumber(DbOpenFiles.Count.ToString()), String.Format("{0:0.000}", stopWatch.Elapsed.TotalSeconds)));
                    stopWatch.Reset();
                    
                    if (dataGridFiles.Rows.Count == 0) labelNoResultsFound.Visible = true;
                    else labelNoResultsFound.Visible = false;

                    Program.log.Info(toolStripStatus.Text);

                    EnableSearchControls(true);

                    // Sets selected item to host
                    if (SelectedFilesHost == "") comboBoxHost.SelectedIndex = 0;
                    else comboBoxHost.SelectedItem = SelectedFilesHost;
                }
            });
        }

        // Context Menu Items
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var URL = dataGridFiles.CurrentRow.Cells[5].Value.ToString();
            Process.Start(URL);
        }

        private void viewFileDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var URL = dataGridFiles.CurrentRow.Cells[5].Value.ToString();
            ShowFileDetails(Database.WebFile(URL), dataGridFiles);
        }

        private void viewWebPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var URL = new Uri(dataGridFiles.CurrentRow.Cells[5].Value.ToString());
            Process.Start(URL.AbsoluteUri.Remove(URL.AbsoluteUri.Length - URL.Segments.Last().Length));
        }

        private void fileURLClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var URL = dataGridFiles.CurrentRow.Cells[5].Value.ToString();
            Clipboard.SetText(URL);
            MessageBox.Show("Clipboard set to : " + URL);
        }

        /// <summary>
        /// Enable/Disable search controls, to prevent another search process which causes a crash
        /// </summary>
        /// <param name="isEnabled">Enable/Disable Controls</param>
        private void EnableSearchControls(bool isEnabled)
        {
            textBoxSearchQuery.Enabled = isEnabled;
            buttonSearchFiles.Enabled = isEnabled;

            comboBoxSort.Enabled = isEnabled;
            comboBoxHost.Enabled = isEnabled;
            comboBoxType.Enabled = isEnabled;

            foreach (var ctrl in flowPanelMostSearches.Controls)
                if (ctrl is Label)
                    ((Label)ctrl).Enabled = isEnabled;
        }

        /// <summary>
        /// Show details/info for a WebFile
        /// </summary>
        /// <param name="File">WebFile object</param>
        /// <param name="createNewInstance">Whether to create a new instance</param>
        public void ShowFileDetails(WebFile File, DataGridView parentDataGrid, bool isLocal = false, bool createNewInstance = true)
        {
            Program.log.Info("Showing file details dialog : " + File.URL);

            if (createNewInstance)
                FrmFileDetails = new FileDetailsWindow();

            FrmFileDetails.IsLocalFile = isLocal;
            FrmFileDetails.ParentDataGrid = parentDataGrid;
            FrmFileDetails.CurrentFile = File;

            FrmFileDetails.LabelFileName.Text = File.Name;
            FrmFileDetails.LabelValueName.Text = File.Name;
            FrmFileDetails.LabelValueRefferer.Text = File.Host;
            FrmFileDetails.LabelValueType.Text = File.Type;
            FrmFileDetails.InfoFileURL.Text = Uri.UnescapeDataString(File.URL);

            // Builds parts of the URL into a better presented string, simply replaces '/' with '>' and no filename
            var url = new Uri(File.URL);
            var directories = new StringBuilder();
            if (!File.URL.StartsWith(@"C:\")) { directories.Append(File.Host); } else { FrmFileDetails.LabelValueRefferer.Text = "Local"; } // Appends the Host at the start if not Local, else it will be named 'Local'
                foreach (string path in url.LocalPath.Split('/', '\\'))
                if (!Path.HasExtension(path))
                    directories.Append(path + "> ");
            FrmFileDetails.LabelValueDirectory.Text = directories.ToString();

            FrmFileDetails.LabelValueSize.Text = StringExtensions.BytesToPrefix(File.Size);
            FrmFileDetails.LabelValueAge.Text = StringExtensions.TimeSpanAge(File.DateUploaded);

            if (!createNewInstance) FrmFileDetails.CheckFileEvents();
            else FrmFileDetails.ShowDialog(this);

            Program.log.Info("Successfully loaded file details dialog");
        }
        
        // Files Type
        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == -1) SelectedFilesType = Types.All;
            else if (comboBoxType.SelectedIndex == 0) SelectedFilesType = Types.All;
            else if (comboBoxType.SelectedIndex == 1) SelectedFilesType = Types.Video;
            else if (comboBoxType.SelectedIndex == 2) SelectedFilesType = Types.Audio;
            else if (comboBoxType.SelectedIndex == 3) SelectedFilesType = Types.Image;
            else if (comboBoxType.SelectedIndex == 4) SelectedFilesType = Types.Book;
            else if (comboBoxType.SelectedIndex == 5) SelectedFilesType = Types.Subtitle;
            else if (comboBoxType.SelectedIndex == 6) SelectedFilesType = Types.Torrent;
            else if (comboBoxType.SelectedIndex == 7) SelectedFilesType = Types.Software;
            else if (comboBoxType.SelectedIndex == 8) SelectedFilesType = Types.Other;
        }

        // Sort Files
        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSort.SelectedIndex == 0) SelectedFilesSort = Query.SortBy.Name;
            else if (comboBoxSort.SelectedIndex == 1) SelectedFilesSort = Query.SortBy.Size;
            else if (comboBoxSort.SelectedIndex == 2) SelectedFilesSort = Query.SortBy.Date;
        }

        // Host
        private void comboBoxHost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHost.SelectedIndex == 0) SelectedFilesHost = "";
            else SelectedFilesHost = comboBoxHost.SelectedItem.ToString();
        }

        /// <summary>
        /// Set Status Text of ToolStrip
        /// </summary>
        /// <param name="message">Message to be displayed, duh</param>
        public static void SetStatus(string message)
        {
            Form.toolStripStatus.Text = message;
        }

        /*************************************************************************/
        /* Keyboard Shortcuts                                                    */
        /*************************************************************************/

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                // Focus on Search Box
                case Keys.Control | Keys.F:
                    textBoxSearchQuery.Focus();
                    return true;
                // Show Shortcuts Window
                case Keys.Control | Keys.OemQuestion:
                    FrmKeyboardShortcuts.ShowDialog(this);
                    return true;
                // Close File Details if open, and close web explorer tab if open
                case Keys.Escape:
                    if (FrmFileDetails != null)
                        FrmFileDetails.Dispose();
                    return true;
                // Close application
                case Keys.Control | Keys.W:
                    Application.Exit();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}