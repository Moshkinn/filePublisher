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
            this.btnLoadFiles = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnToCsv = new System.Windows.Forms.Button();
            this.btnInstanceConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadFiles
            // 
            this.btnLoadFiles.Location = new System.Drawing.Point(12, 70);
            this.btnLoadFiles.Name = "btnLoadFiles";
            this.btnLoadFiles.Size = new System.Drawing.Size(115, 36);
            this.btnLoadFiles.TabIndex = 3;
            this.btnLoadFiles.Text = "LoadFiles";
            this.btnLoadFiles.UseVisualStyleBackColor = true;
            this.btnLoadFiles.Click += new System.EventHandler(this.btnLoadFiles_Click);
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(161, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(854, 966);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // btnToCsv
            // 
            this.btnToCsv.Location = new System.Drawing.Point(13, 127);
            this.btnToCsv.Name = "btnToCsv";
            this.btnToCsv.Size = new System.Drawing.Size(114, 36);
            this.btnToCsv.TabIndex = 4;
            this.btnToCsv.Text = "to CSV";
            this.btnToCsv.UseVisualStyleBackColor = true;
            this.btnToCsv.Click += new System.EventHandler(this.btnToCsv_Click);
            // 
            // btnInstanceConfig
            // 
            this.btnInstanceConfig.Location = new System.Drawing.Point(12, 189);
            this.btnInstanceConfig.Name = "btnInstanceConfig";
            this.btnInstanceConfig.Size = new System.Drawing.Size(115, 36);
            this.btnInstanceConfig.TabIndex = 5;
            this.btnInstanceConfig.Text = "instanceConfig";
            this.btnInstanceConfig.UseVisualStyleBackColor = true;
            this.btnInstanceConfig.Click += new System.EventHandler(this.btnInstanceConfig_Click);
            // 
            // JsonsParse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 971);
            this.Controls.Add(this.btnInstanceConfig);
            this.Controls.Add(this.btnToCsv);
            this.Controls.Add(this.btnLoadFiles);
            this.Controls.Add(this.listView1);
            this.Name = "JsonsParse";
            this.Text = "JsonsParse";
            this.Load += new System.EventHandler(this.JsonsParse_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFiles;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnToCsv;
        private System.Windows.Forms.Button btnInstanceConfig;
    }
}