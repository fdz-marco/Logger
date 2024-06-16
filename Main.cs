using glitcher.core;

namespace LoggerTester
{
    /// <summary>
    /// **Logger Tester**
    /// This application is to test a simple log class (static) for bigger projects.
    /// </summary>
    /// <remarks>
    /// Author: Marco Fernandez (marcofdz.com / glitcher.dev)<br/>
    /// Last modified: 2024.06.15 - June 15, 2024
    /// </remarks>
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // Init combo
            combo_SeverityLevel.Items.Clear();
            combo_SeverityLevel.DataSource = Enum.GetValues(typeof(LogLevel));
            combo_SeverityLevel.SelectedIndex = combo_SeverityLevel.Items.IndexOf(LogLevel.OnlyDebug);
        }

        private void btn_ShowLogger_Click(object sender, EventArgs e)
        {
            try
            {
                LogViewer.GetInstance().Show();
            }
            catch (Exception ex)
            {

                Logger.Add(LogLevel.Error, "Sys Tray", $"Error opening LogViewer: {ex.Message}.");
            }
        }

        private void btn_Add_SameThread_Click(object sender, EventArgs e)
        {
            LogLevel level = (LogLevel)combo_SeverityLevel.SelectedIndex;
            string group = txt_Group.Text.Trim();
            string message = txt_Message.Text.Trim();
            string whisper = txt_Whiper.Text.Trim();
            Logger.Add(level, group, message, whisper);
        }

        private async void btn_Add_AsyncThread_Click(object sender, EventArgs e)
        {
            LogLevel level = (LogLevel)combo_SeverityLevel.SelectedIndex;
            string group = txt_Group.Text.Trim();
            string message = txt_Message.Text.Trim();
            string whisper = txt_Whiper.Text.Trim();
            await Task.Run(() =>
            {
                Logger.Add(level, group, message, whisper);
            });
        }

        private void btn_TestAll_SameThread_Click(object sender, EventArgs e)
        {
            string group = txt_Group.Text.Trim();
            string message = txt_Message.Text.Trim();
            string whisper = txt_Whiper.Text.Trim();
            Logger.Add(LogLevel.Info, group, message, whisper);
            Logger.Add(LogLevel.Warning, group, message, whisper);
            Logger.Add(LogLevel.Error, group, message, whisper);
            Logger.Add(LogLevel.Fatal, group, message, whisper);
            Logger.Add(LogLevel.OnlyDebug, group, message, whisper);
            Logger.Add(LogLevel.None, group, message, whisper);
            Logger.Add(LogLevel.Success, group, message, whisper);
        }

        private async void btn_TestAll_AsyncThread_Click(object sender, EventArgs e)
        {
            string group = txt_Group.Text.Trim();
            string message = txt_Message.Text.Trim();
            string whisper = txt_Whiper.Text.Trim();
            await Task.Run(() =>
            {
                Logger.Add(LogLevel.Info, group, message, whisper);
                Logger.Add(LogLevel.Warning, group, message, whisper);
                Logger.Add(LogLevel.Error, group, message, whisper);
                Logger.Add(LogLevel.Fatal, group, message, whisper);
                Logger.Add(LogLevel.OnlyDebug, group, message, whisper);
                Logger.Add(LogLevel.None, group, message, whisper);
                Logger.Add(LogLevel.Success, group, message, whisper);
            });
        }
    }
}