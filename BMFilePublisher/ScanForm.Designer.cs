namespace BMFilePublisher
{
    partial class ScanForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.tbIpToScan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.lvScanedList = new System.Windows.Forms.ListView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timerValidate = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(237, 388);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 26);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(138, 388);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // tbIpToScan
            // 
            this.tbIpToScan.Location = new System.Drawing.Point(12, 29);
            this.tbIpToScan.Name = "tbIpToScan";
            this.tbIpToScan.Size = new System.Drawing.Size(317, 20);
            this.tbIpToScan.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Address (subnet)";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(12, 353);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(317, 29);
            this.btnScan.TabIndex = 5;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lvScanedList
            // 
            this.lvScanedList.HideSelection = false;
            this.lvScanedList.Location = new System.Drawing.Point(12, 103);
            this.lvScanedList.Name = "lvScanedList";
            this.lvScanedList.Size = new System.Drawing.Size(317, 244);
            this.lvScanedList.TabIndex = 25;
            this.lvScanedList.UseCompatibleStateImageBehavior = false;
            this.lvScanedList.View = System.Windows.Forms.View.List;
            this.lvScanedList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvScanedList_MouseDoubleClick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 55);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(317, 23);
            this.progressBar.TabIndex = 26;
            // 
            // timerValidate
            // 
            this.timerValidate.Enabled = true;
            this.timerValidate.Tick += new System.EventHandler(this.timerValidate_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "For multi select use CTRL";
            // 
            // ScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 426);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lvScanedList);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbIpToScan);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScanForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScanForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbIpToScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ListView lvScanedList;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timerValidate;
        private System.Windows.Forms.Label label2;
    }
}