namespace BMFilePublisher
{
    partial class JsonsParse
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnToCsv = new System.Windows.Forms.Button();
            this.lblCsvFolder = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1003, 987);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // btnToCsv
            // 
            this.btnToCsv.Location = new System.Drawing.Point(12, 1008);
            this.btnToCsv.Name = "btnToCsv";
            this.btnToCsv.Size = new System.Drawing.Size(114, 29);
            this.btnToCsv.TabIndex = 4;
            this.btnToCsv.Text = "Export to CSV";
            this.btnToCsv.UseVisualStyleBackColor = true;
            this.btnToCsv.Click += new System.EventHandler(this.btnToCsv_Click);
            // 
            // lblCsvFolder
            // 
            this.lblCsvFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCsvFolder.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCsvFolder.ForeColor = System.Drawing.Color.Blue;
            this.lblCsvFolder.Location = new System.Drawing.Point(275, 1013);
            this.lblCsvFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCsvFolder.Name = "lblCsvFolder";
            this.lblCsvFolder.Size = new System.Drawing.Size(740, 22);
            this.lblCsvFolder.TabIndex = 36;
            this.lblCsvFolder.Text = "_";
            this.lblCsvFolder.Click += new System.EventHandler(this.lblCsvFolder_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(146, 1012);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 22);
            this.label11.TabIndex = 35;
            this.label11.Text = "CSV Folder:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // JsonsParse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1044, 1056);
            this.Controls.Add(this.lblCsvFolder);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnToCsv);
            this.Controls.Add(this.listView1);
            this.Name = "JsonsParse";
            this.Text = "JsonsParse";
            this.Load += new System.EventHandler(this.JsonsParse_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnToCsv;
        private System.Windows.Forms.Label lblCsvFolder;
        private System.Windows.Forms.Label label11;
    }
}