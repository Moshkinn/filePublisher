using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMFilePublisher
{
    public partial class ScanForm : Form
    {
        private FormData formData;
        private Thread scanThread;
        FilePublisher filePublisher;

        public List<string> selectedList;
        public ScanForm(string defaultIP, FormData formData)
        {
            InitializeComponent();

            this.formData = formData;
            this.selectedList = new List<string>();

            initFormDialog(defaultIP);
            SetElementsAttr();
            

        }

        private void initFormDialog(string defaultIP)
        {
            
            this.AcceptButton = btnAdd;
            this.CancelButton = btnClose;
            tbIpToScan.Text = defaultIP;
        }

        private void SetElementsAttr()
        {
            lvScanedList.View = View.Details;
            lvScanedList.HeaderStyle = ColumnHeaderStyle.Clickable;
            lvScanedList.FullRowSelect = true;
            lvScanedList.Columns.Add("IP", 160);
            lvScanedList.Columns.Add("LineID", 150);
            lvScanedList.MultiSelect = true;
        }

        private void initScanThread()
        {
            filePublisher = new FilePublisher(formData);
            filePublisher.AddToLog += new AddLog(CallAddToList);
            filePublisher.UpdateProgressBar += new UpdateProgressBar(CallUpdateProgressBar);
            filePublisher.subnetIpScan = tbIpToScan.Text;
            scanThread = new Thread(filePublisher.getScanAllIpSubnet);
        }


        public void AddToList(string msg, Color BgColor)
        {
            if (msg.Contains(","))
            {
                string[] msgs = msg.Split(',');
                lvScanedList.Items.Add(new ListViewItem(msgs)).BackColor = BgColor;
            }
            else
            {
                lvScanedList.Items.Add(msg).BackColor = BgColor;
            }
            
        }

        public void updateProgressBar(int min, int max, int value)
        {
            progressBar.Minimum = min;
            progressBar.Maximum = max;
            if (value > max)
            {
                value = max;
            }
            progressBar.Value = value;
        }

        public void CallUpdateProgressBar(int min, int max, int value)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    var d = new UpdateProgressBar(CallUpdateProgressBar);
                    this.Invoke(d, new object[] { min, max, value });
                }
                else
                {
                    this.updateProgressBar(min, max, value);
                }
            }
            catch
            {

            }
        }

        public void CallAddToList(string msg, Color BgColor)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    var d = new AddLog(CallAddToList);
                    this.Invoke(d, new object[] { msg, BgColor });
                }
                else
                {
                    this.AddToList(msg, BgColor);
                }
            }
            catch
            {

            }

        }



        private void btnScan_Click(object sender, EventArgs e)
        {
            initScanThread();
            scanThread.Start();
        }

        private void ScanForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(scanThread != null)
            {
                scanThread.Abort();
            }
        }

        private void ScanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (scanThread != null)
            {
                scanThread.Abort();
            }
        }

        private void timerValidate_Tick(object sender, EventArgs e)
        {
            if(scanThread != null)
            {
                btnScan.Enabled = MainForm.ValidateIPFormat(tbIpToScan.Text) && !scanThread.IsAlive;
                tbIpToScan.Enabled = !scanThread.IsAlive;
            }
            else
            {
                btnScan.Enabled = MainForm.ValidateIPFormat(tbIpToScan.Text);
            }
            
            
            btnAdd.Enabled = lvScanedList.SelectedItems.Count > 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.selectedList = new List<string>();
            foreach(ListViewItem item in lvScanedList.SelectedItems)
            {
                selectedList.Add(item.Text);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lvScanedList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewItem lvi = (ListViewItem)lvScanedList.SelectedItems[0];
                NetworkCredential nc = new NetworkCredential(this.formData.UserName, this.formData.Password, this.formData.Domain);
                FilePublisher fp = new FilePublisher(this.formData);
                if (!fp.OpenNetworkDirectory(lvi.Text, nc))
                {
                    throw new Exception(String.Format("Could not open {0}", lvi.Text));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error open network directory");
            }
        }
    }
}
