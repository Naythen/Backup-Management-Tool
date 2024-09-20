namespace Test3._7._2024
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            userLabel = new Label();
            passwordLabel = new Label();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            signInButton = new Button();
            updateButton = new Button();
            addNewButton = new Button();
            deleteButton = new Button();
            signOutButton = new Button();
            startDate = new DateTimePicker();
            endDate = new DateTimePicker();
            selectId = new ComboBox();
            searchByDate = new RadioButton();
            searchByID = new RadioButton();
            dateForAdvanced = new DateTimePicker();
            appsTextBox = new TextBox();
            dateLabel = new Label();
            startDateLabel = new Label();
            endDateLabel = new Label();
            appsLabel = new Label();
            logoPictureBox = new PictureBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            sqlCommand2 = new Microsoft.Data.SqlClient.SqlCommand();
            searchByApp = new RadioButton();
            appToBeSearched = new TextBox();
            userPictureBox = new PictureBox();
            usersNameLabel = new Label();
            aboutButton = new Button();
            helpButton = new Button();
            undoButton = new Button();
            redoButton = new Button();
            AppTitle = new Label();
            historyTextBox = new ListBox();
            toolTip = new ToolTip(components);
            inventoryId = new TextBox();
            inventarIdLabel = new Label();
            redCodeLabel = new Label();
            yellowCodeLabel = new Label();
            greenCodeLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userPictureBox).BeginInit();
            SuspendLayout();
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userLabel.Location = new Point(1097, 14);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(44, 21);
            userLabel.TabIndex = 0;
            userLabel.Text = "User";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordLabel.Location = new Point(1059, 44);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(82, 21);
            passwordLabel.TabIndex = 1;
            passwordLabel.Text = "Password";
            // 
            // textBoxUsername
            // 
            textBoxUsername.BackColor = SystemColors.ControlLightLight;
            textBoxUsername.Location = new Point(1147, 12);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(100, 23);
            textBoxUsername.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BackColor = SystemColors.ControlLightLight;
            textBoxPassword.Location = new Point(1147, 44);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(100, 23);
            textBoxPassword.TabIndex = 3;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // signInButton
            // 
            signInButton.BackColor = SystemColors.ControlLight;
            signInButton.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
            signInButton.FlatStyle = FlatStyle.Flat;
            signInButton.Location = new Point(1163, 73);
            signInButton.Name = "signInButton";
            signInButton.Size = new Size(75, 32);
            signInButton.TabIndex = 4;
            signInButton.Text = "Sign in";
            signInButton.UseVisualStyleBackColor = false;
            signInButton.Click += SignInButton_Click;
            // 
            // updateButton
            // 
            updateButton.BackColor = SystemColors.ControlLight;
            updateButton.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            updateButton.Location = new Point(104, 526);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(75, 34);
            updateButton.TabIndex = 6;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = false;
            updateButton.Visible = false;
            updateButton.Click += UpdateButton_Click;
            // 
            // addNewButton
            // 
            addNewButton.BackColor = SystemColors.ControlLight;
            addNewButton.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
            addNewButton.FlatStyle = FlatStyle.Flat;
            addNewButton.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            addNewButton.Location = new Point(12, 526);
            addNewButton.Name = "addNewButton";
            addNewButton.Size = new Size(75, 34);
            addNewButton.TabIndex = 7;
            addNewButton.Text = "Add new";
            addNewButton.UseVisualStyleBackColor = false;
            addNewButton.Visible = false;
            addNewButton.Click += AddNewButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = SystemColors.ControlLight;
            deleteButton.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            deleteButton.Location = new Point(199, 526);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 34);
            deleteButton.TabIndex = 8;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Visible = false;
            deleteButton.Click += DeleteButton_Click;
            // 
            // signOutButton
            // 
            signOutButton.BackColor = SystemColors.ControlLight;
            signOutButton.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
            signOutButton.FlatStyle = FlatStyle.Flat;
            signOutButton.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            signOutButton.Location = new Point(1138, 172);
            signOutButton.Name = "signOutButton";
            signOutButton.Size = new Size(75, 32);
            signOutButton.TabIndex = 9;
            signOutButton.Text = "Sign out";
            signOutButton.UseVisualStyleBackColor = false;
            signOutButton.Visible = false;
            signOutButton.Click += SignOutButton_Click;
            // 
            // startDate
            // 
            startDate.CalendarFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            startDate.CalendarMonthBackground = SystemColors.ControlLightLight;
            startDate.CustomFormat = "dd/mm/yyyy";
            startDate.Enabled = false;
            startDate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            startDate.Format = DateTimePickerFormat.Short;
            startDate.Location = new Point(110, 204);
            startDate.Name = "startDate";
            startDate.Size = new Size(121, 23);
            startDate.TabIndex = 10;
            startDate.Visible = false;
            startDate.ValueChanged += StartDate_ValueChanged;
            startDate.EnabledChanged += SelectId_EnabledChanged;
            // 
            // endDate
            // 
            endDate.CalendarFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            endDate.CalendarMonthBackground = SystemColors.ControlLightLight;
            endDate.CustomFormat = "dd/mm/yyyy";
            endDate.Enabled = false;
            endDate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            endDate.Format = DateTimePickerFormat.Short;
            endDate.Location = new Point(110, 233);
            endDate.Name = "endDate";
            endDate.Size = new Size(121, 23);
            endDate.TabIndex = 11;
            endDate.Visible = false;
            endDate.ValueChanged += EndDate_ValueChanged;
            // 
            // selectId
            // 
            selectId.BackColor = SystemColors.ControlLightLight;
            selectId.DropDownHeight = 100;
            selectId.Enabled = false;
            selectId.FormattingEnabled = true;
            selectId.IntegralHeight = false;
            selectId.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            selectId.Location = new Point(110, 137);
            selectId.Name = "selectId";
            selectId.Size = new Size(121, 23);
            selectId.TabIndex = 13;
            selectId.Visible = false;
            selectId.EnabledChanged += SelectId_EnabledChanged;
            selectId.TextChanged += SelectId_CursorChanged;
            // 
            // searchByDate
            // 
            searchByDate.Appearance = Appearance.Button;
            searchByDate.BackColor = SystemColors.GradientInactiveCaption;
            searchByDate.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
            searchByDate.FlatAppearance.CheckedBackColor = SystemColors.GradientActiveCaption;
            searchByDate.FlatStyle = FlatStyle.Flat;
            searchByDate.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            searchByDate.Location = new Point(12, 204);
            searchByDate.Name = "searchByDate";
            searchByDate.Size = new Size(262, 55);
            searchByDate.TabIndex = 14;
            searchByDate.TabStop = true;
            searchByDate.Text = "Search by date";
            searchByDate.UseVisualStyleBackColor = false;
            searchByDate.Visible = false;
            searchByDate.MouseMove += SearchByDate_MouseMove;
            // 
            // searchByID
            // 
            searchByID.Appearance = Appearance.Button;
            searchByID.BackColor = SystemColors.GradientInactiveCaption;
            searchByID.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
            searchByID.FlatAppearance.CheckedBackColor = SystemColors.GradientActiveCaption;
            searchByID.FlatStyle = FlatStyle.Flat;
            searchByID.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            searchByID.Location = new Point(12, 120);
            searchByID.Name = "searchByID";
            searchByID.Size = new Size(262, 55);
            searchByID.TabIndex = 15;
            searchByID.TabStop = true;
            searchByID.Text = "Search by Id";
            searchByID.UseVisualStyleBackColor = false;
            searchByID.Visible = false;
            searchByID.MouseMove += SearchByID_MouseMove;
            // 
            // dateForAdvanced
            // 
            dateForAdvanced.CalendarMonthBackground = SystemColors.ControlLightLight;
            dateForAdvanced.CustomFormat = "dd/mm/yyyy";
            dateForAdvanced.Format = DateTimePickerFormat.Short;
            dateForAdvanced.Location = new Point(167, 437);
            dateForAdvanced.Name = "dateForAdvanced";
            dateForAdvanced.Size = new Size(107, 23);
            dateForAdvanced.TabIndex = 16;
            dateForAdvanced.Visible = false;
            // 
            // appsTextBox
            // 
            appsTextBox.BackColor = SystemColors.ControlLightLight;
            appsTextBox.Location = new Point(12, 469);
            appsTextBox.Name = "appsTextBox";
            appsTextBox.Size = new Size(262, 23);
            appsTextBox.TabIndex = 17;
            appsTextBox.Visible = false;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dateLabel.Location = new Point(167, 419);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(92, 15);
            dateLabel.TabIndex = 18;
            dateLabel.Text = "Date of backup";
            dateLabel.Visible = false;
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            startDateLabel.Location = new Point(110, 189);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new Size(117, 15);
            startDateLabel.TabIndex = 19;
            startDateLabel.Text = "First date of backup";
            startDateLabel.Visible = false;
            // 
            // endDateLabel
            // 
            endDateLabel.AutoSize = true;
            endDateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            endDateLabel.Location = new Point(110, 257);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Size = new Size(115, 15);
            endDateLabel.TabIndex = 20;
            endDateLabel.Text = "Last date of backup";
            endDateLabel.Visible = false;
            // 
            // appsLabel
            // 
            appsLabel.AutoSize = true;
            appsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            appsLabel.Location = new Point(12, 495);
            appsLabel.Name = "appsLabel";
            appsLabel.Size = new Size(84, 15);
            appsLabel.TabIndex = 21;
            appsLabel.Text = "Installed Apps";
            appsLabel.Visible = false;
            // 
            // logoPictureBox
            // 
            logoPictureBox.BackgroundImage = Properties.Resources.PHIN_BIG_bbeeca58;
            logoPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            logoPictureBox.Location = new Point(12, 12);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(262, 53);
            logoPictureBox.TabIndex = 23;
            logoPictureBox.TabStop = false;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // sqlCommand2
            // 
            sqlCommand2.CommandTimeout = 30;
            sqlCommand2.EnableOptimizedParameterBinding = false;
            // 
            // searchByApp
            // 
            searchByApp.Appearance = Appearance.Button;
            searchByApp.BackColor = SystemColors.GradientInactiveCaption;
            searchByApp.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
            searchByApp.FlatAppearance.CheckedBackColor = SystemColors.GradientActiveCaption;
            searchByApp.FlatStyle = FlatStyle.Flat;
            searchByApp.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            searchByApp.Location = new Point(12, 288);
            searchByApp.Name = "searchByApp";
            searchByApp.Size = new Size(262, 55);
            searchByApp.TabIndex = 25;
            searchByApp.TabStop = true;
            searchByApp.Text = "Search by App";
            searchByApp.UseVisualStyleBackColor = false;
            searchByApp.Visible = false;
            searchByApp.MouseMove += SearchByApp_MouseMove;
            // 
            // appToBeSearched
            // 
            appToBeSearched.BackColor = SystemColors.ControlLightLight;
            appToBeSearched.Enabled = false;
            appToBeSearched.Location = new Point(110, 305);
            appToBeSearched.Name = "appToBeSearched";
            appToBeSearched.Size = new Size(121, 23);
            appToBeSearched.TabIndex = 26;
            appToBeSearched.Visible = false;
            appToBeSearched.EnabledChanged += SelectId_EnabledChanged;
            appToBeSearched.TextChanged += AppToBeSearched_TextChanged;
            // 
            // userPictureBox
            // 
            userPictureBox.BackgroundImage = (Image)resources.GetObject("userPictureBox.BackgroundImage");
            userPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            userPictureBox.Location = new Point(1118, 12);
            userPictureBox.Name = "userPictureBox";
            userPictureBox.Size = new Size(120, 123);
            userPictureBox.TabIndex = 27;
            userPictureBox.TabStop = false;
            userPictureBox.Visible = false;
            // 
            // usersNameLabel
            // 
            usersNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usersNameLabel.ForeColor = Color.DarkSlateGray;
            usersNameLabel.Location = new Point(1118, 129);
            usersNameLabel.Name = "usersNameLabel";
            usersNameLabel.Size = new Size(120, 31);
            usersNameLabel.TabIndex = 28;
            usersNameLabel.Text = "User";
            usersNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            usersNameLabel.Visible = false;
            // 
            // aboutButton
            // 
            aboutButton.BackColor = SystemColors.ControlLight;
            aboutButton.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
            aboutButton.FlatStyle = FlatStyle.Flat;
            aboutButton.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            aboutButton.Location = new Point(1138, 210);
            aboutButton.Name = "aboutButton";
            aboutButton.Size = new Size(75, 32);
            aboutButton.TabIndex = 29;
            aboutButton.Text = "About";
            aboutButton.UseVisualStyleBackColor = false;
            aboutButton.Visible = false;
            aboutButton.Click += AboutButton_Click;
            // 
            // helpButton
            // 
            helpButton.BackColor = SystemColors.ControlLight;
            helpButton.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
            helpButton.FlatStyle = FlatStyle.Flat;
            helpButton.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            helpButton.Location = new Point(1138, 248);
            helpButton.Name = "helpButton";
            helpButton.Size = new Size(75, 32);
            helpButton.TabIndex = 30;
            helpButton.Text = "Help";
            helpButton.UseVisualStyleBackColor = false;
            helpButton.Visible = false;
            helpButton.Click += HelpButton_Click;
            // 
            // undoButton
            // 
            undoButton.BackColor = SystemColors.ControlLight;
            undoButton.Enabled = false;
            undoButton.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
            undoButton.FlatStyle = FlatStyle.Flat;
            undoButton.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            undoButton.Location = new Point(313, 585);
            undoButton.Name = "undoButton";
            undoButton.Size = new Size(75, 34);
            undoButton.TabIndex = 31;
            undoButton.Text = "Undo";
            undoButton.UseVisualStyleBackColor = false;
            undoButton.Visible = false;
            undoButton.Click += UndoButton_Click;
            // 
            // redoButton
            // 
            redoButton.BackColor = SystemColors.ControlLight;
            redoButton.Enabled = false;
            redoButton.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
            redoButton.FlatStyle = FlatStyle.Flat;
            redoButton.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            redoButton.Location = new Point(313, 625);
            redoButton.Name = "redoButton";
            redoButton.Size = new Size(75, 34);
            redoButton.TabIndex = 32;
            redoButton.Text = "Redo";
            redoButton.UseVisualStyleBackColor = false;
            redoButton.Visible = false;
            redoButton.Click += RedoButton_Click;
            // 
            // AppTitle
            // 
            AppTitle.AutoSize = true;
            AppTitle.Font = new Font("Segoe UI Black", 33.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AppTitle.Location = new Point(313, 120);
            AppTitle.Name = "AppTitle";
            AppTitle.Size = new Size(703, 61);
            AppTitle.TabIndex = 33;
            AppTitle.Text = "BACKUP MANAGEMENT TOOL";
            AppTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // historyTextBox
            // 
            historyTextBox.BackColor = SystemColors.ControlLightLight;
            historyTextBox.ColumnWidth = 2000;
            historyTextBox.Cursor = Cursors.Hand;
            historyTextBox.DrawMode = DrawMode.OwnerDrawFixed;
            historyTextBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            historyTextBox.FormattingEnabled = true;
            historyTextBox.HorizontalScrollbar = true;
            historyTextBox.ItemHeight = 25;
            historyTextBox.Location = new Point(394, 305);
            historyTextBox.Name = "historyTextBox";
            historyTextBox.Size = new Size(819, 354);
            historyTextBox.TabIndex = 34;
            toolTip.SetToolTip(historyTextBox, "Select the device you want to manage");
            historyTextBox.Visible = false;
            historyTextBox.DrawItem += HistoryTextBox_DrawItem;
            historyTextBox.SelectedIndexChanged += HistoryTextBox_SelectedIndexChanged;
            // 
            // inventoryId
            // 
            inventoryId.BackColor = SystemColors.ControlLightLight;
            inventoryId.Enabled = false;
            inventoryId.Location = new Point(12, 437);
            inventoryId.Name = "inventoryId";
            inventoryId.Size = new Size(133, 23);
            inventoryId.TabIndex = 35;
            inventoryId.Visible = false;
            // 
            // inventarIdLabel
            // 
            inventarIdLabel.AutoSize = true;
            inventarIdLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            inventarIdLabel.Location = new Point(12, 419);
            inventarIdLabel.Name = "inventarIdLabel";
            inventarIdLabel.Size = new Size(70, 15);
            inventarIdLabel.TabIndex = 36;
            inventarIdLabel.Text = "ID inventar";
            inventarIdLabel.Visible = false;
            // 
            // redCodeLabel
            // 
            redCodeLabel.AutoSize = true;
            redCodeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            redCodeLabel.ForeColor = Color.Red;
            redCodeLabel.Location = new Point(22, 595);
            redCodeLabel.Name = "redCodeLabel";
            redCodeLabel.Size = new Size(194, 15);
            redCodeLabel.TabIndex = 37;
            redCodeLabel.Text = "ROSU - Backup mai vechi de 2 ani";
            redCodeLabel.Visible = false;
            // 
            // yellowCodeLabel
            // 
            yellowCodeLabel.AutoSize = true;
            yellowCodeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            yellowCodeLabel.ForeColor = Color.Gold;
            yellowCodeLabel.Location = new Point(22, 610);
            yellowCodeLabel.Name = "yellowCodeLabel";
            yellowCodeLabel.Size = new Size(185, 15);
            yellowCodeLabel.TabIndex = 38;
            yellowCodeLabel.Text = "GALBEN - Backup intre 1 si 2 ani";
            yellowCodeLabel.Visible = false;
            // 
            // greenCodeLabel
            // 
            greenCodeLabel.AutoSize = true;
            greenCodeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            greenCodeLabel.ForeColor = Color.Green;
            greenCodeLabel.Location = new Point(22, 625);
            greenCodeLabel.Name = "greenCodeLabel";
            greenCodeLabel.Size = new Size(193, 15);
            greenCodeLabel.TabIndex = 39;
            greenCodeLabel.Text = "VERDE - Backup mai nou de un an";
            greenCodeLabel.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1264, 681);
            Controls.Add(greenCodeLabel);
            Controls.Add(yellowCodeLabel);
            Controls.Add(redCodeLabel);
            Controls.Add(userPictureBox);
            Controls.Add(appToBeSearched);
            Controls.Add(endDate);
            Controls.Add(startDate);
            Controls.Add(selectId);
            Controls.Add(inventarIdLabel);
            Controls.Add(inventoryId);
            Controls.Add(historyTextBox);
            Controls.Add(AppTitle);
            Controls.Add(redoButton);
            Controls.Add(undoButton);
            Controls.Add(helpButton);
            Controls.Add(aboutButton);
            Controls.Add(usersNameLabel);
            Controls.Add(searchByApp);
            Controls.Add(logoPictureBox);
            Controls.Add(appsLabel);
            Controls.Add(endDateLabel);
            Controls.Add(startDateLabel);
            Controls.Add(dateLabel);
            Controls.Add(appsTextBox);
            Controls.Add(dateForAdvanced);
            Controls.Add(searchByID);
            Controls.Add(searchByDate);
            Controls.Add(signOutButton);
            Controls.Add(deleteButton);
            Controls.Add(addNewButton);
            Controls.Add(updateButton);
            Controls.Add(signInButton);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(passwordLabel);
            Controls.Add(userLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Inventory_Tool";
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)userPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label userLabel;
        private Label passwordLabel;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Button signInButton;
        private Button updateButton;
        private Button addNewButton;
        private Button deleteButton;
        private Button signOutButton;
        private DateTimePicker startDate;
        private DateTimePicker endDate;
        private ComboBox selectId;
        private RadioButton searchByDate;
        private RadioButton searchByID;
        private DateTimePicker dateForAdvanced;
        private TextBox appsTextBox;
        private Label dateLabel;
        private Label startDateLabel;
        private Label endDateLabel;
        private Label appsLabel;
        private PictureBox logoPictureBox;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand2;
        private RadioButton searchByApp;
        private TextBox appToBeSearched;
        private PictureBox userPictureBox;
        private Label usersNameLabel;
        private Button aboutButton;
        private Button helpButton;
        private Button undoButton;
        private Button redoButton;
        private Label AppTitle;
        private ListBox historyTextBox;
        private ToolTip toolTip;
        private TextBox inventoryId;
        private Label inventarIdLabel;
        private Label redCodeLabel;
        private Label yellowCodeLabel;
        private Label greenCodeLabel;
    }
}
