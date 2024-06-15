namespace LoggerTester
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            combo_SeverityLevel = new ComboBox();
            lbl_SeverityLevel = new Label();
            btn_Add_SameThread = new Button();
            txt_Group = new TextBox();
            btn_ShowLogger = new Button();
            lbl_Group = new Label();
            lbl_Message = new Label();
            lbl_Whisper = new Label();
            txt_Message = new TextBox();
            txt_Whiper = new TextBox();
            btn_Add_AsyncThread = new Button();
            btn_TestAll_AsyncThread = new Button();
            btn_TestAll_SameThread = new Button();
            SuspendLayout();
            // 
            // combo_SeverityLevel
            // 
            combo_SeverityLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_SeverityLevel.FormattingEnabled = true;
            combo_SeverityLevel.Location = new Point(96, 8);
            combo_SeverityLevel.Name = "combo_SeverityLevel";
            combo_SeverityLevel.Size = new Size(370, 28);
            combo_SeverityLevel.TabIndex = 0;
            // 
            // lbl_SeverityLevel
            // 
            lbl_SeverityLevel.AutoSize = true;
            lbl_SeverityLevel.Location = new Point(47, 11);
            lbl_SeverityLevel.Name = "lbl_SeverityLevel";
            lbl_SeverityLevel.Size = new Size(43, 20);
            lbl_SeverityLevel.TabIndex = 1;
            lbl_SeverityLevel.Text = "Level";
            lbl_SeverityLevel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn_Add_SameThread
            // 
            btn_Add_SameThread.Location = new Point(23, 169);
            btn_Add_SameThread.Name = "btn_Add_SameThread";
            btn_Add_SameThread.Size = new Size(216, 29);
            btn_Add_SameThread.TabIndex = 2;
            btn_Add_SameThread.Text = "Add (Same Thread)";
            btn_Add_SameThread.UseVisualStyleBackColor = true;
            btn_Add_SameThread.Click += btn_Add_SameThread_Click;
            // 
            // txt_Group
            // 
            txt_Group.Location = new Point(96, 46);
            txt_Group.Name = "txt_Group";
            txt_Group.Size = new Size(370, 27);
            txt_Group.TabIndex = 3;
            txt_Group.Text = "Sample Class";
            // 
            // btn_ShowLogger
            // 
            btn_ShowLogger.Location = new Point(23, 248);
            btn_ShowLogger.Name = "btn_ShowLogger";
            btn_ShowLogger.Size = new Size(443, 68);
            btn_ShowLogger.TabIndex = 4;
            btn_ShowLogger.Text = "Show Logger";
            btn_ShowLogger.UseVisualStyleBackColor = true;
            btn_ShowLogger.Click += btn_ShowLogger_Click;
            // 
            // lbl_Group
            // 
            lbl_Group.AutoSize = true;
            lbl_Group.Location = new Point(40, 49);
            lbl_Group.Name = "lbl_Group";
            lbl_Group.Size = new Size(50, 20);
            lbl_Group.TabIndex = 5;
            lbl_Group.Text = "Group";
            lbl_Group.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Message
            // 
            lbl_Message.AutoSize = true;
            lbl_Message.Location = new Point(23, 86);
            lbl_Message.Name = "lbl_Message";
            lbl_Message.Size = new Size(67, 20);
            lbl_Message.TabIndex = 6;
            lbl_Message.Text = "Message";
            lbl_Message.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Whisper
            // 
            lbl_Whisper.AutoSize = true;
            lbl_Whisper.Location = new Point(27, 126);
            lbl_Whisper.Name = "lbl_Whisper";
            lbl_Whisper.Size = new Size(63, 20);
            lbl_Whisper.TabIndex = 7;
            lbl_Whisper.Text = "Whisper";
            lbl_Whisper.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txt_Message
            // 
            txt_Message.Location = new Point(96, 83);
            txt_Message.Name = "txt_Message";
            txt_Message.Size = new Size(370, 27);
            txt_Message.TabIndex = 8;
            txt_Message.Text = "No error, just testing log";
            // 
            // txt_Whiper
            // 
            txt_Whiper.Location = new Point(96, 119);
            txt_Whiper.Name = "txt_Whiper";
            txt_Whiper.Size = new Size(370, 27);
            txt_Whiper.TabIndex = 9;
            txt_Whiper.Text = "Secret";
            // 
            // btn_Add_AsyncThread
            // 
            btn_Add_AsyncThread.Location = new Point(250, 169);
            btn_Add_AsyncThread.Name = "btn_Add_AsyncThread";
            btn_Add_AsyncThread.Size = new Size(216, 29);
            btn_Add_AsyncThread.TabIndex = 10;
            btn_Add_AsyncThread.Text = "Add (Async Thread)";
            btn_Add_AsyncThread.UseVisualStyleBackColor = true;
            btn_Add_AsyncThread.Click += btn_Add_AsyncThread_Click;
            // 
            // btn_TestAll_AsyncThread
            // 
            btn_TestAll_AsyncThread.Location = new Point(250, 204);
            btn_TestAll_AsyncThread.Name = "btn_TestAll_AsyncThread";
            btn_TestAll_AsyncThread.Size = new Size(216, 29);
            btn_TestAll_AsyncThread.TabIndex = 12;
            btn_TestAll_AsyncThread.Text = "Test All (Async Thread)";
            btn_TestAll_AsyncThread.UseVisualStyleBackColor = true;
            btn_TestAll_AsyncThread.Click += btn_TestAll_AsyncThread_Click;
            // 
            // btn_TestAll_SameThread
            // 
            btn_TestAll_SameThread.Location = new Point(23, 204);
            btn_TestAll_SameThread.Name = "btn_TestAll_SameThread";
            btn_TestAll_SameThread.Size = new Size(216, 29);
            btn_TestAll_SameThread.TabIndex = 11;
            btn_TestAll_SameThread.Text = "Test All (Same Thread)";
            btn_TestAll_SameThread.UseVisualStyleBackColor = true;
            btn_TestAll_SameThread.Click += btn_TestAll_SameThread_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 339);
            Controls.Add(btn_TestAll_AsyncThread);
            Controls.Add(btn_TestAll_SameThread);
            Controls.Add(btn_Add_AsyncThread);
            Controls.Add(txt_Whiper);
            Controls.Add(txt_Message);
            Controls.Add(lbl_Whisper);
            Controls.Add(lbl_Message);
            Controls.Add(lbl_Group);
            Controls.Add(btn_ShowLogger);
            Controls.Add(txt_Group);
            Controls.Add(btn_Add_SameThread);
            Controls.Add(lbl_SeverityLevel);
            Controls.Add(combo_SeverityLevel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Main";
            Text = "Logger Tester";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox combo_SeverityLevel;
        private Label lbl_SeverityLevel;
        private Button btn_Add_SameThread;
        private TextBox txt_Group;
        private Button btn_ShowLogger;
        private Label lbl_Group;
        private Label lbl_Message;
        private Label lbl_Whisper;
        private TextBox txt_Message;
        private TextBox txt_Whiper;
        private Button btn_Add_AsyncThread;
        private Button btn_TestAll_AsyncThread;
        private Button btn_TestAll_SameThread;
    }
}