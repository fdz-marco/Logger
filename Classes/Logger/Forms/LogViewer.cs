﻿using glitcher.core.Utils;

namespace glitcher.core.Logger
{
    /// <summary>(Form) Log Viewer</summary>
    /// <remarks>
    /// Author: Marco Fernandez (marcofdz.com / glitcher.dev)<br/>
    /// Last modified: 2024.06.15 - June 15, 2024
    /// </remarks>
    public partial class LogViewer : Form
    {
        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        #region Properties (Private / Public / Getters|Setters / Events)

        private static LogViewer? _instance = null;

        #endregion

        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        #region Constructor / Settings / Initialization Tasks

        /// <summary>Class constructor.</summary>
        public LogViewer()
        {
            InitializeComponent();
            InitListView();
            Logger.ChangeOccurred += Logger_ChangeOccurred; // Subscribe to changes on Logger
        }

        /// <summary>Get Instance of Static Clase.</summary>
        /// <returns>(Form) The instance of Form/Window</returns>
        public static LogViewer GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LogViewer();
                _instance.FormClosed += delegate { _instance = null; };
            }
            return _instance;
        }

        /// <summary>Initialization of the List View.</summary>
        /// <returns>(void)</returns>
        private void InitListView()
        {
            // ListView
            lv_Log.BorderStyle = BorderStyle.FixedSingle;
            lv_Log.View = View.Details;
            lv_Log.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lv_Log.GridLines = true;

            //  Column Headers
            ColumnHeader header1 = new ColumnHeader();
            header1.Text = "DateTime";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 180;

            ColumnHeader header2 = new ColumnHeader();
            header2.Text = "Level";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 120;

            ColumnHeader header3 = new ColumnHeader();
            header3.Text = "Group";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 100;

            ColumnHeader header4 = new ColumnHeader();
            header4.Text = "Message";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 450;

            ColumnHeader header5 = new ColumnHeader();
            header5.Text = "Whisper";
            header5.TextAlign = HorizontalAlignment.Left;
            header5.Width = 200;

            ColumnHeader header6 = new ColumnHeader();
            header6.Text = "Caller";
            header6.TextAlign = HorizontalAlignment.Left;
            header6.Width = 330;

            lv_Log.Columns.Add(header1);
            lv_Log.Columns.Add(header2);
            lv_Log.Columns.Add(header3);
            lv_Log.Columns.Add(header4);
            lv_Log.Columns.Add(header5);
            lv_Log.Columns.Add(header6);

            // Datagrid
            RefreshContentListView();
        }

        #endregion

        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        #region Methods (Update List View)

        /// <summary>Update List View with Log Items.</summary>
        /// <returns>(void)</returns>
        public void RefreshContentListView()
        {
            lv_Log.CallMethod((ctrl) => ctrl.Items.Clear()); // SafeThread Call
            List<Log> reversed = Logger.logList;
            reversed.Reverse();
            foreach (Log item in reversed)
            {
                ListViewItem logItem = CreateListViewItemFromLog(item);
                lv_Log.CallMethod((ctrl, value) => ctrl.Items.Add(value), logItem); // SafeThread Call
            }
            lv_Log.CallMethod((ctrl) => ctrl.Update()); // SafeThread Call
        }

        /// <summary>Create a List View Item From a Log Item.</summary>
        /// <param name="item">Log (Entry)</param>
        /// <returns>(ListViewItem) List View Item that represent a Log Entry</returns>
        private ListViewItem CreateListViewItemFromLog(Log item)
        {
            // Create ListView Item
            ListViewItem logItem = new ListViewItem();
            logItem.Text = item.DateTime.ToString("yyyy-MM-dd HH:mm:ss:fff");
            logItem.SubItems.Add(item.LogLevel.ToString());
            logItem.SubItems.Add(item.Group);
            logItem.SubItems.Add(item.Message);
            logItem.SubItems.Add(item.Whisper);
            logItem.SubItems.Add(item.Caller);

            // Custom Color
            if (item.LogLevel == LogLevel.Fatal) logItem.SubItems[1].BackColor = Color.Red;
            if (item.LogLevel == LogLevel.Error) logItem.SubItems[1].BackColor = Color.Tomato;
            if (item.LogLevel == LogLevel.Warning) logItem.SubItems[1].BackColor = Color.Khaki;
            if (item.LogLevel == LogLevel.Info) logItem.SubItems[1].BackColor = Color.SkyBlue;
            if (item.LogLevel == LogLevel.OnlyDebug) logItem.SubItems[1].BackColor = Color.Gray;
            if (item.LogLevel == LogLevel.None) logItem.SubItems[1].BackColor = Color.HotPink;
            if (item.LogLevel == LogLevel.Success) logItem.SubItems[1].BackColor = Color.LimeGreen;
            logItem.SubItems[1].ForeColor = Color.White;
            logItem.UseItemStyleForSubItems = false;

            return logItem;
        }

        /// <summary>In case the Logger Notify a change ocurred, execute some actions on Form/Window.</summary>
        /// <returns>(void)</returns>
        private void Logger_ChangeOccurred(object? sender, LogEvent e)
        {
            if (e.eventType == "clear")
            {
                lv_Log.Items.Clear();
            }
            else if (e.eventType == "add")
            {
                if (e.varValue != null)
                {
                    Log item = (Log)e.varValue;
                    ListViewItem logItem = CreateListViewItemFromLog(item);
                    //lv_Log.Items.Insert(0, logItem); // Add at Top
                    //lvLog.Items.Add(logitem); // Add at Bottom
                    //lv_Log.Update();
                    lv_Log.CallMethod((ctrl, value) => ctrl.Items.Insert(0, value), logItem); // SafeThread Call
                    lv_Log.CallMethod((ctrl) => ctrl.Update()); // SafeThread Call
                }
            }
        }

        #endregion

        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        #region Methods (UI Action)

        /// <summary>UI Action: Click on Clear All (Log).</summary>
        /// <returns>(void)</returns>
        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            Logger.ClearAll();
        }

        /// <summary>UI Action: Click on Copy (to Clipboard).</summary>
        /// <returns>(void)</returns>
        private void btn_Copy_Click(object sender, EventArgs e)
        {
            String text = "";
            foreach (ListViewItem item in lv_Log.Items)
            {
                text += item.SubItems[0].Text + "\t";
                text += item.SubItems[1].Text + "\t";
                text += item.SubItems[2].Text + "\t";
                text += item.SubItems[3].Text + "\t";
                text += item.SubItems[4].Text + "\t";
                text += item.SubItems[5].Text + Environment.NewLine;
            }
            Clipboard.SetText(text);
        }

        #endregion

        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~
    }
}