namespace BMFilePublisher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblTargetDriverData = new System.Windows.Forms.Label();
            this.lblDefaultWizardData = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDriverDataSource = new System.Windows.Forms.Button();
            this.btnWizardDataSource = new System.Windows.Forms.Button();
            this.lblSourceDriverData = new System.Windows.Forms.Label();
            this.lblSourceWizard = new System.Windows.Forms.Label();
            this.btnPublish = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDomain = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lvLog = new System.Windows.Forms.ListView();
            this.lvIpList = new System.Windows.Forms.ListView();
            this.AppInterval = new System.Windows.Forms.Timer(this.components);
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IpMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.mInstanceConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.mWizardFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mDriverFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mPluginsFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.mEnableDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.mComment = new System.Windows.Forms.ToolStripTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblBackupFolder = new System.Windows.Forms.Label();
            this.btnDeviceJsons = new System.Windows.Forms.Button();
            this.IpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 471);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(153, 38);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(176, 471);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(165, 38);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblTargetDriverData
            // 
            this.lblTargetDriverData.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetDriverData.ForeColor = System.Drawing.Color.Black;
            this.lblTargetDriverData.Location = new System.Drawing.Point(517, 68);
            this.lblTargetDriverData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetDriverData.Name = "lblTargetDriverData";
            this.lblTargetDriverData.Size = new System.Drawing.Size(344, 23);
            this.lblTargetDriverData.TabIndex = 4;
            this.lblTargetDriverData.Text = "_";
            // 
            // lblDefaultWizardData
            // 
            this.lblDefaultWizardData.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefaultWizardData.ForeColor = System.Drawing.Color.Black;
            this.lblDefaultWizardData.Location = new System.Drawing.Point(477, 95);
            this.lblDefaultWizardData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefaultWizardData.Name = "lblDefaultWizardData";
            this.lblDefaultWizardData.Size = new System.Drawing.Size(384, 22);
            this.lblDefaultWizardData.TabIndex = 5;
            this.lblDefaultWizardData.Text = "_";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(345, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Log:";
            // 
            // btnDriverDataSource
            // 
            this.btnDriverDataSource.Location = new System.Drawing.Point(349, 513);
            this.btnDriverDataSource.Margin = new System.Windows.Forms.Padding(4);
            this.btnDriverDataSource.Name = "btnDriverDataSource";
            this.btnDriverDataSource.Size = new System.Drawing.Size(168, 39);
            this.btnDriverDataSource.TabIndex = 8;
            this.btnDriverDataSource.Text = "Select Driver Source";
            this.btnDriverDataSource.UseVisualStyleBackColor = true;
            this.btnDriverDataSource.Click += new System.EventHandler(this.btnDriverDataSource_Click);
            // 
            // btnWizardDataSource
            // 
            this.btnWizardDataSource.Location = new System.Drawing.Point(525, 513);
            this.btnWizardDataSource.Margin = new System.Windows.Forms.Padding(4);
            this.btnWizardDataSource.Name = "btnWizardDataSource";
            this.btnWizardDataSource.Size = new System.Drawing.Size(168, 39);
            this.btnWizardDataSource.TabIndex = 9;
            this.btnWizardDataSource.Text = "Select Wizard Source";
            this.btnWizardDataSource.UseVisualStyleBackColor = true;
            this.btnWizardDataSource.Click += new System.EventHandler(this.btnWizardDataSource_Click);
            // 
            // lblSourceDriverData
            // 
            this.lblSourceDriverData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSourceDriverData.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceDriverData.ForeColor = System.Drawing.Color.Blue;
            this.lblSourceDriverData.Location = new System.Drawing.Point(504, 11);
            this.lblSourceDriverData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSourceDriverData.Name = "lblSourceDriverData";
            this.lblSourceDriverData.Size = new System.Drawing.Size(652, 22);
            this.lblSourceDriverData.TabIndex = 10;
            this.lblSourceDriverData.Text = "_";
            this.lblSourceDriverData.Click += new System.EventHandler(this.lblSourceDriverData_Click);
            // 
            // lblSourceWizard
            // 
            this.lblSourceWizard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSourceWizard.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceWizard.ForeColor = System.Drawing.Color.Blue;
            this.lblSourceWizard.Location = new System.Drawing.Point(465, 41);
            this.lblSourceWizard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSourceWizard.Name = "lblSourceWizard";
            this.lblSourceWizard.Size = new System.Drawing.Size(613, 22);
            this.lblSourceWizard.TabIndex = 11;
            this.lblSourceWizard.Text = "_";
            this.lblSourceWizard.Click += new System.EventHandler(this.lblSourceWizard_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.Enabled = false;
            this.btnPublish.Location = new System.Drawing.Point(935, 513);
            this.btnPublish.Margin = new System.Windows.Forms.Padding(4);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(188, 39);
            this.btnPublish.TabIndex = 12;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "User Name:";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(108, 75);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(4);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(193, 22);
            this.tbUserName.TabIndex = 14;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(108, 107);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(193, 22);
            this.tbPassword.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 24);
            this.label7.TabIndex = 20;
            this.label7.Text = "Credentials:";
            // 
            // tbDomain
            // 
            this.tbDomain.Location = new System.Drawing.Point(108, 43);
            this.tbDomain.Margin = new System.Windows.Forms.Padding(4);
            this.tbDomain.Name = "tbDomain";
            this.tbDomain.Size = new System.Drawing.Size(193, 22);
            this.tbDomain.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 47);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Domain:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 560);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1107, 22);
            this.progressBar.TabIndex = 23;
            // 
            // lvLog
            // 
            this.lvLog.HideSelection = false;
            this.lvLog.Location = new System.Drawing.Point(349, 182);
            this.lvLog.Margin = new System.Windows.Forms.Padding(4);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(772, 323);
            this.lvLog.TabIndex = 24;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.List;
            // 
            // lvIpList
            // 
            this.lvIpList.HideSelection = false;
            this.lvIpList.Location = new System.Drawing.Point(16, 182);
            this.lvIpList.Margin = new System.Windows.Forms.Padding(4);
            this.lvIpList.Name = "lvIpList";
            this.lvIpList.Size = new System.Drawing.Size(324, 281);
            this.lvIpList.TabIndex = 25;
            this.lvIpList.UseCompatibleStateImageBehavior = false;
            this.lvIpList.View = System.Windows.Forms.View.List;
            this.lvIpList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvIpList_ColumnClick);
            this.lvIpList.SelectedIndexChanged += new System.EventHandler(this.lvIpList_SelectedIndexChanged);
            this.lvIpList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvIpList_MouseClick);
            this.lvIpList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvIpList_MouseDoubleClick);
            // 
            // AppInterval
            // 
            this.AppInterval.Enabled = true;
            this.AppInterval.Tick += new System.EventHandler(this.AppInterval_Tick);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(176, 517);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(165, 36);
            this.btnRemoveAll.TabIndex = 27;
            this.btnRemoveAll.Text = "RemoveAll";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(15, 517);
            this.btnScan.Margin = new System.Windows.Forms.Padding(4);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(153, 36);
            this.btnScan.TabIndex = 26;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(325, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Target Driver Data  : ";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(325, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 23);
            this.label6.TabIndex = 29;
            this.label6.Text = "Target Wizard  : ";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(325, 39);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 23);
            this.label9.TabIndex = 31;
            this.label9.Text = "Source Wizard : ";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(325, 10);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(227, 23);
            this.label10.TabIndex = 30;
            this.label10.Text = "Source Driver Data :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 156);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 32;
            this.label1.Text = "Targets : ";
            // 
            // IpMenu
            // 
            this.IpMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.IpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mBackup,
            this.mInstanceConfig,
            this.mSetup,
            this.mWizardFolder,
            this.mDriverFolder,
            this.mPluginsFolder,
            this.mRemote,
            this.mEnableDisable,
            this.mComment});
            this.IpMenu.Name = "IpMenu";
            this.IpMenu.Size = new System.Drawing.Size(209, 225);
            this.IpMenu.Opening += new System.ComponentModel.CancelEventHandler(this.IpMenu_Opening);
            this.IpMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.IpMenu_ItemClicked);
            // 
            // mBackup
            // 
            this.mBackup.Name = "mBackup";
            this.mBackup.Size = new System.Drawing.Size(208, 24);
            this.mBackup.Text = "Backup Machine";
            this.mBackup.Click += new System.EventHandler(this.mBackup_Click);
            // 
            // mInstanceConfig
            // 
            this.mInstanceConfig.Name = "mInstanceConfig";
            this.mInstanceConfig.Size = new System.Drawing.Size(208, 24);
            this.mInstanceConfig.Text = "InstanceConfig Json";
            // 
            // mSetup
            // 
            this.mSetup.Name = "mSetup";
            this.mSetup.Size = new System.Drawing.Size(208, 24);
            this.mSetup.Text = "Setup Json";
            // 
            // mWizardFolder
            // 
            this.mWizardFolder.Name = "mWizardFolder";
            this.mWizardFolder.Size = new System.Drawing.Size(208, 24);
            this.mWizardFolder.Text = "Wizard Folder";
            // 
            // mDriverFolder
            // 
            this.mDriverFolder.Name = "mDriverFolder";
            this.mDriverFolder.Size = new System.Drawing.Size(208, 24);
            this.mDriverFolder.Text = "Driver Folder";
            this.mDriverFolder.Click += new System.EventHandler(this.mDriverFolder_Click);
            // 
            // mPluginsFolder
            // 
            this.mPluginsFolder.AccessibleName = "PluginsFolder";
            this.mPluginsFolder.Name = "mPluginsFolder";
            this.mPluginsFolder.Size = new System.Drawing.Size(208, 24);
            this.mPluginsFolder.Text = "Plugins Folder";
            // 
            // mRemote
            // 
            this.mRemote.Name = "mRemote";
            this.mRemote.Size = new System.Drawing.Size(208, 24);
            this.mRemote.Text = "Remote Desktop";
            // 
            // mEnableDisable
            // 
            this.mEnableDisable.Name = "mEnableDisable";
            this.mEnableDisable.Size = new System.Drawing.Size(208, 24);
            this.mEnableDisable.Text = "Disable";
            // 
            // mComment
            // 
            this.mComment.Name = "mComment";
            this.mComment.Size = new System.Drawing.Size(100, 27);
            this.mComment.Click += new System.EventHandler(this.mComment_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(325, 123);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 23);
            this.label11.TabIndex = 33;
            this.label11.Text = "Backup Folder  : ";
            // 
            // lblBackupFolder
            // 
            this.lblBackupFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBackupFolder.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackupFolder.ForeColor = System.Drawing.Color.Blue;
            this.lblBackupFolder.Location = new System.Drawing.Point(469, 123);
            this.lblBackupFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBackupFolder.Name = "lblBackupFolder";
            this.lblBackupFolder.Size = new System.Drawing.Size(652, 22);
            this.lblBackupFolder.TabIndex = 34;
            this.lblBackupFolder.Text = "_";
            this.lblBackupFolder.Click += new System.EventHandler(this.lblBackupFolder_Click);
            // 
            // btnDeviceJsons
            // 
            this.btnDeviceJsons.Location = new System.Drawing.Point(713, 512);
            this.btnDeviceJsons.Name = "btnDeviceJsons";
            this.btnDeviceJsons.Size = new System.Drawing.Size(194, 39);
            this.btnDeviceJsons.TabIndex = 35;
            this.btnDeviceJsons.Text = "DeviceJsonsLocalFolder";
            this.btnDeviceJsons.UseVisualStyleBackColor = true;
            this.btnDeviceJsons.Click += new System.EventHandler(this.btnDeviceJsons_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 593);
            this.Controls.Add(this.btnDeviceJsons);
            this.Controls.Add(this.lblBackupFolder);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSourceDriverData);
            this.Controls.Add(this.lblSourceWizard);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblDefaultWizardData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.lvIpList);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tbDomain);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.btnWizardDataSource);
            this.Controls.Add(this.btnDriverDataSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTargetDriverData);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BM File Publisher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.IpMenu.ResumeLayout(false);
            this.IpMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblTargetDriverData;
        private System.Windows.Forms.Label lblDefaultWizardData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDriverDataSource;
        private System.Windows.Forms.Button btnWizardDataSource;
        private System.Windows.Forms.Label lblSourceDriverData;
        private System.Windows.Forms.Label lblSourceWizard;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDomain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ListView lvIpList;
        private System.Windows.Forms.Timer AppInterval;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip IpMenu;
        private System.Windows.Forms.ToolStripMenuItem mInstanceConfig;
        private System.Windows.Forms.ToolStripMenuItem mSetup;
        private System.Windows.Forms.ToolStripMenuItem mWizardFolder;
        private System.Windows.Forms.ToolStripMenuItem mDriverFolder;
        private System.Windows.Forms.ToolStripMenuItem mRemote;
        private System.Windows.Forms.ToolStripMenuItem mPluginsFolder;
        private System.Windows.Forms.ToolStripMenuItem mEnableDisable;
        private System.Windows.Forms.ToolStripTextBox mComment;
        private System.Windows.Forms.ToolStripMenuItem mBackup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBackupFolder;
        private System.Windows.Forms.Button btnDeviceJsons;
    }
}

