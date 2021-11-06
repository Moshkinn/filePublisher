using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using Newtonsoft.Json;

namespace BMFilePublisher
{
    public delegate void AddLog(string msg, Color bgColor);

    public delegate void MarkIp(string ip, Color bgColor);

    public delegate void UpdateProgressBar(int min, int max, int value);

    public delegate void UpdateLineId(string[] kv);



    public partial class MainForm : Form
    {
        private string cfgDefaultIP;
        private string cfgDriverDataTarget;
        private string cfgWizardDataTarget;
        private string cfgUserName;
        private string cfgPassword;
        private string cfgDomain;
        private string cfgBackupFolder;

        private string rightClickIp;

        private string driverSourceSelectedPath;
        private string wizardSourceSelectedPath;

        private FilePublisher filePublisher;
        private FilePublisher fplines;
        private Thread processThread;
        private Thread updateIpListLineIdThread;




        private const string FormDataPath = "FormData.json";

        public NetworkMgr NetworkMgr { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            ReadConfig();
            loadFormDataFromJson();

            StyleListView();

            updateIpListLineId();

            mComment.KeyUp += MComment_KeyUp;



        }



        private void StyleListView()
        {        
            lvLog.View = View.Details;
            lvLog.HeaderStyle = ColumnHeaderStyle.None;
            lvLog.FullRowSelect = true;
            lvLog.Columns.Add("", -2);
            lvLog.MultiSelect = false;


            lvIpList.View = View.Details;
            lvIpList.HeaderStyle = ColumnHeaderStyle.Clickable;
            lvIpList.FullRowSelect = true;
            lvIpList.Columns.Add("IP", 80);
            lvIpList.Columns.Add("LineID", 80);
            lvIpList.Columns.Add("Comment", 80);
            lvIpList.MultiSelect = false;
        }


        public void updateLineId(string[] kv)
        {
            foreach(ListViewItem item in lvIpList.Items)
            {
                if (item.SubItems[0].Text == kv[0])
                {
                    item.SubItems[1].Text = kv[1];
                }
            }
        }

        private void updateIpListLineId()
        {
            
            fplines = new FilePublisher(getFormData());
            fplines.UpdateLineId += new UpdateLineId(CallUpdateLineId);
            List<string> toUpdate = new List<string>();
            foreach(ListViewItem li in lvIpList.Items)
            {
                if(li.SubItems[1].Text == "---")
                {
                    toUpdate.Add(li.SubItems[0].Text);
                }
            }
            if(toUpdate.Count > 0)
            {
                fplines.toUpdate = toUpdate;
                updateIpListLineIdThread = new Thread(fplines.UpdateLineIdNameList);
                updateIpListLineIdThread.Start();
            }
            
        }


        public void CallUpdateLineId(string[] kv)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    var d = new UpdateLineId(CallUpdateLineId);
                    this.Invoke(d, new object[] { kv });
                }
                else
                {
                    this.updateLineId(kv);
                }
            }
            catch
            {

            }

        }

        public void CallAddLog(string msg, Color BgColor)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    var d = new AddLog(CallAddLog);
                    this.Invoke(d, new object[] { msg, BgColor });
                }
                else
                {
                    this.addToLogList(msg, BgColor);
                }
            }
            catch
            {

            }

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

        public void CallMarkIpColor(string ip, Color BgColor)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    var d = new MarkIp(CallMarkIpColor);
                    this.Invoke(d, new object[] { ip, BgColor });
                }
                else
                {
                    this.MarkIpColor(ip, BgColor);
                }
            }
            catch
            {

            }
        }


        public void MarkIpColor(string ip, Color bg)
        {
            foreach(ListViewItem lvi in lvIpList.Items)
            {
                if(lvi.Text == ip)
                {
                    lvi.ForeColor = Color.Black;
                    if (bg == Color.Red)
                    {
                        lvi.ForeColor = Color.White;
                    }
                    lvi.BackColor = bg;
                    
                }
            }
        }

        public void CleanIpListBgColor()
        {
            foreach (ListViewItem lvi in lvIpList.Items)
            {
                lvi.BackColor = Color.White;
                lvi.ForeColor = Color.Black;
            }
        }

        public void addToLogList(string msg, Color BgColor)
        {
            ListViewItem li = new ListViewItem(msg);
            li.BackColor = BgColor;
            if(BgColor == Color.Red)
            {
                li.ForeColor = Color.White;
            }

            if (msg.StartsWith("-"))
            {
                li.Text = msg;
                lvLog.Items[lvLog.Items.Count - 1] = li;
            }
            else
            {
                lvLog.Items.Add(li);
                lvLog.EnsureVisible(lvLog.Items.Count - 1);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            openNewIpDialogBox();
        }

        private void openNewIpDialogBox()
        {
            string value = this.cfgDefaultIP;
            if (InputBox("New IP Address", "IP Address", ref value) == DialogResult.OK)
            {
                if (validateNewIp(value))
                {
                    ListViewItem li = new ListViewItem(new List<string>() { value, "---", "---" }.ToArray());
                    li.ForeColor = Color.Black;
                    lvIpList.Items.Add(li);                    
                    saveFormDataToJson();
                    updateIpListLineId();
                }
                else
                {
                    openNewIpDialogBox();
                }

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lvIpList.Items.Remove((ListViewItem)lvIpList.SelectedItems[0]);
            btnRemove.Enabled = false;
            saveFormDataToJson();
        }

        public static bool ValidateIPFormat(string ip)
        {
            return new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$").IsMatch(ip);
        }


        private bool validateNewIp(string ip)
        {
            if (!ValidateIPFormat(ip))
            {
                MessageBox.Show(String.Format("({0}) is not a valid IP", ip));
                return false;
            }
            foreach(ListViewItem lvi in lvIpList.Items)
            {
                if(lvi.Text == ip)
                {
                    MessageBox.Show(String.Format("({0}) already exist in IP Addresses List", ip));
                    return false;
                }
            }

            return true;
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            textBox.SelectionStart = textBox.Text.LastIndexOf('.') + 1;
            textBox.SelectionLength = 3;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            
            ScanForm sf = new ScanForm(cfgDefaultIP, getFormData());
            if(sf.ShowDialog() == DialogResult.OK)
            {
                foreach(var ip in sf.selectedList)
                {
                    if (validateNewIp(ip))
                    {
                        List<string> row = new List<string>() { ip, "---", "---" };
                        lvIpList.Items.Add(new ListViewItem(row.ToArray()));
                    }
                }
                updateIpListLineId();
                saveFormDataToJson();
            }
            
        }

        public static DialogResult ScanIpWindow(string defaultIP, FormData formData, ref List<string> value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            Button buttonScan = new Button();
            ListView scanList = new ListView();

            FilePublisher fp = new FilePublisher(formData);
            Thread scanThread = new Thread(fp.getScanAllIpSubnet);

            form.Text = "Scan Network";
            label.Text = "IP Address (Subnet) :";
            textBox.Text = defaultIP;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonScan.Text = "Scan";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 570, 75, 23);
            buttonCancel.SetBounds(309, 570, 75, 23);
            buttonScan.SetBounds(11, 65, 372, 23);
            scanList.SetBounds(11, 95, 372, 460);

            scanList.View = View.Details;
            scanList.HeaderStyle = ColumnHeaderStyle.Clickable;
            scanList.FullRowSelect = true;
            //scanList.Columns.Add("IP", 186);
            //scanList.Columns.Add("LineID", 186);
            scanList.Columns.Add("", -2);
            scanList.MultiSelect = true;



            buttonScan.Click += (s, e) => {
                
                fp.AddToLog += new AddLog((string msg, Color color) => { scanList.Items.Add(msg).BackColor = color; });
                fp.subnetIpScan = textBox.Text;
                scanThread.Start();
            };

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonScan.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(400, 600);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel, buttonScan, scanList });
            //form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = new List<string>();
            return dialogResult;
        }


        public bool ReadConfig()
        {
            try
            {
                this.cfgDefaultIP = System.Configuration.ConfigurationSettings.AppSettings["defaultIP"];
                this.cfgDriverDataTarget = System.Configuration.ConfigurationSettings.AppSettings["DriverDataTarget"];
                this.cfgWizardDataTarget = System.Configuration.ConfigurationSettings.AppSettings["WizardDataTarget"];
                this.cfgUserName = System.Configuration.ConfigurationSettings.AppSettings["UserName"];
                this.cfgPassword = System.Configuration.ConfigurationSettings.AppSettings["Password"];
                this.cfgDomain = System.Configuration.ConfigurationSettings.AppSettings["Domain"];
                this.cfgBackupFolder = System.Configuration.ConfigurationSettings.AppSettings["BackupFolder"];

            } catch (Exception ex)
            {
                return false;
            }
            if (cfgDriverDataTarget == null || cfgWizardDataTarget == null)
            {
                return false;
            }
            else
            {
                lblTargetDriverData.Text = this.cfgDriverDataTarget;
                lblDefaultWizardData.Text = this.cfgWizardDataTarget;
                lblBackupFolder.Text = this.cfgBackupFolder;
                tbUserName.Text = this.cfgUserName;
                tbPassword.Text = this.cfgPassword;
                tbDomain.Text = this.cfgDomain;
                return true;
            }
        }

        private bool validateDirectoryContainJson(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
            {
                if (Path.GetExtension(file).ToLower() == ".json")
                {
                    return true;
                }
            }
            MessageBox.Show("Folder path is not contain any json file.");
            return false;
        }

        private void btnDriverDataSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (validateDirectoryContainJson(fbd.SelectedPath))
                {
                    lblSourceDriverData.Text = fbd.SelectedPath;
                    driverSourceSelectedPath = fbd.SelectedPath;
                    saveFormDataToJson();
                }
                else
                {
                    btnDriverDataSource_Click(sender, e);
                }
            }
        }

        private void btnWizardDataSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (validateDirectoryContainJson(fbd.SelectedPath))
                {
                    lblSourceWizard.Text = fbd.SelectedPath;
                    wizardSourceSelectedPath = fbd.SelectedPath; ;
                    saveFormDataToJson();
                }
                else
                {
                    btnWizardDataSource_Click(sender, e);
                }
            }
        }


        private void loadFormDataFromJson()
        {
            if (File.Exists(FormDataPath))
            {
                FormData obj = new FormData();
                using (StreamReader r = new StreamReader(FormDataPath))
                {
                    string jsonString = r.ReadToEnd();
                    obj = JsonConvert.DeserializeObject<FormData>(jsonString);

                    if (obj.SourceDriverDataPath != null)
                    {
                        lblSourceDriverData.Text = obj.SourceDriverDataPath;
                        driverSourceSelectedPath = obj.SourceDriverDataPath;
                    }
                    else
                    {
                        lblSourceDriverData.Text = "X";
                    }
                    if (obj.SourceWizardPath != null)
                    {
                        lblSourceWizard.Text = obj.SourceWizardPath;
                        wizardSourceSelectedPath = obj.SourceWizardPath;
                    }
                    else
                    {
                        lblSourceWizard.Text = "X";
                    }

                    

                    if (obj.IpList != null)
                    {
                        foreach (IpItem ip in obj.IpList)
                        {
                            string ipComment = "---";
                            if (ip.Comment != string.Empty)
                            {
                                ipComment = ip.Comment;
                            }
                            List<string> row = new List<string>() { ip.Ip, "---", ipComment };
                            ListViewItem lvi = new ListViewItem(row.ToArray());
                            if (!ip.Enabled)
                            {
                                lvi.BackColor = Color.Gray;
                            }
                            lvIpList.Items.Add(lvi);
                        }

                    }
                }
            }
        }

        private FormData saveFormDataToJson()
        {
            FormData fd = new FormData();
            fd.SourceDriverDataPath = driverSourceSelectedPath;
            fd.SourceWizardPath = wizardSourceSelectedPath;
            fd.IpList = ListViewToIpItemList(lvIpList);
            string json = JsonConvert.SerializeObject(fd);
            File.WriteAllText(FormDataPath, json);

            return fd;
        }

        private List<IpItem> ListViewToIpItemList(ListView lv)
        {
            List<IpItem> result = new List<IpItem>();
            foreach(ListViewItem item in lv.Items.Cast<ListViewItem>())
            {
                bool isEnable = item.BackColor != Color.Gray;
                result.Add(new IpItem(item.SubItems[0].Text, isEnable, item.SubItems[2].Text));
            }
            return result;
            //return lv.Items.Cast<ListViewItem>().Select(item => item.Text).ToList();
        }


        private void tbLineValidate_Leave(object sender, EventArgs e)
        {

            saveFormDataToJson();
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            FormData formData = getFormData();

            lvLog.Items.Clear();
            CleanIpListBgColor();

            filePublisher = new FilePublisher(formData);
            filePublisher.AddToLog += new AddLog(CallAddLog);
            filePublisher.UpdateProgressBar += new UpdateProgressBar(CallUpdateProgressBar);
            filePublisher.MarkIp += new MarkIp(CallMarkIpColor);
            processThread = new Thread(filePublisher.Run);
            processThread.Start();

            EnableDisableControllers();
        }

        private FormData getFormData()
        {
            FormData formData = saveFormDataToJson();
            formData.TargetDriverDataPath = this.cfgDriverDataTarget;
            formData.TargetWizardPath = this.cfgWizardDataTarget;
            formData.UserName = tbUserName.Text;
            formData.Password = tbPassword.Text;
            formData.Domain = tbDomain.Text;
            formData.BackupFolder = this.cfgBackupFolder;

            return formData;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (processThread != null)
            {
                processThread.Abort();
            }
            if(updateIpListLineIdThread != null)
            {
                updateIpListLineIdThread.Abort();
            }
        }

        private void lvIpList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = lvIpList.SelectedItems.Count > 0;
        }

        private void AppInterval_Tick(object sender, EventArgs e)
        {
            EnableDisableControllers();
        }

        public void EnableDisableControllers()
        {
            if (wizardSourceSelectedPath != "" &&
                driverSourceSelectedPath != "" &&
                tbUserName.Text != "" &&
                tbPassword.Text != "" &&
                lvIpList.Items.Count > 0 &&
                IsProcessNotRuning())
            {
                btnPublish.Enabled = true;
            }
            else
            {
                btnPublish.Enabled = false;
            }

            if (IsProcessNotRuning())
            {
                btnAdd.Enabled = true;
                tbUserName.Enabled = true;
                tbPassword.Enabled = true;
                tbDomain.Enabled = true;
                btnDriverDataSource.Enabled = true;
                btnWizardDataSource.Enabled = true;
                btnScan.Enabled = true;
                btnRemoveAll.Enabled = lvIpList.Items.Count > 0;

                
                
            }
            else
            {
                btnAdd.Enabled = false;
                btnRemove.Enabled = false;
                tbUserName.Enabled = false;
                tbPassword.Enabled = false;
                tbDomain.Enabled = false;
                btnDriverDataSource.Enabled = false;
                btnWizardDataSource.Enabled = false;
                btnScan.Enabled = false;
                btnRemoveAll.Enabled = false;
            }
        }

        private bool IsProcessNotRuning()
        {
            return (processThread == null || (processThread != null && !processThread.IsAlive));
        }

        private void lblSourceWizard_Click(object sender, EventArgs e)
        {
            string folderPath = lblSourceWizard.Text;
            if (Directory.Exists(folderPath))
            {
                Process.Start( folderPath);
            }
        }

        private void lblSourceDriverData_Click(object sender, EventArgs e)
        {
            string folderPath = lblSourceDriverData.Text;
            if (Directory.Exists(folderPath))
            {
                Process.Start(folderPath);
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete all IP list?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lvIpList.Items.Clear();
                saveFormDataToJson();
            }
        }

        private void lvIpList_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void lvIpList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = (ListViewItem)lvIpList.SelectedItems[0];
            OpenRemotePath(lvi.Text, "");

        }

        private void OpenRemotePath(string ip, string path)
        {
            try
            {
                NetworkCredential nc = new NetworkCredential(tbUserName.Text, tbPassword.Text, tbDomain.Text);
                FilePublisher fp = new FilePublisher(getFormData());
                if (!fp.OpenNetworkPath(ip, nc, path))
                {
                    throw new Exception(String.Format("Could not open {0}", ip));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error open network directory");
            }

        }

        private void lvIpList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = lvIpList.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    rightClickIp = lvIpList.SelectedItems[0].Text;
                    IpMenu.Show(Cursor.Position);
                }
            }
        }

        private void updateIpItem(string ip, string comment, bool enable)
        {
            FormData fd = getFormData();
            fd.IpList.FirstOrDefault(x => x.Ip == ip).Comment = comment;
            fd.IpList.FirstOrDefault(x => x.Ip == ip).Enabled = enable;

        }



        private void IpMenu_Opening(object sender, CancelEventArgs e)
        {
            if (File.Exists(FormDataPath))
            {
                FormData obj = new FormData();
                using (StreamReader r = new StreamReader(FormDataPath))
                {
                    string jsonString = r.ReadToEnd();
                    obj = JsonConvert.DeserializeObject<FormData>(jsonString);

                    IpItem it = obj.IpList.FirstOrDefault(x => x.Ip == rightClickIp);
                    bool isEnabled = it.Enabled;
                    if (isEnabled)
                    {
                        mEnableDisable.Text = "Disable";
                    }
                    else
                    {
                        mEnableDisable.Text = "Enable";
                    }
                    mComment.Text = it.Comment;
                }
            }
        }

        private void IpMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "InstanceConfig Json":
                    OpenRemotePath(rightClickIp, @"BRC\Configuration\InstanceConfig.json");
                    break;
                case "Setup Json":
                    OpenRemotePath(rightClickIp, @"BRC\Configuration\setup.json");
                    break;
                case "Wizard Folder":
                    OpenRemotePath(rightClickIp, @"inetpub\wwwroot\data\wizardDevices");
                    break;
                case "Driver Folder": 
                    OpenRemotePath(rightClickIp, @"BRC\Apps\DriverManager\DriversData");
                    break;
                case "Plugins Folder":
                    OpenRemotePath(rightClickIp, @"BRC\apps\BmUniRunnerSvc");
                    break;
                case "Remote Desktop":
                    Process.Start("mstsc", "/v:" + rightClickIp);
                    break;
                case "Enable":
                    lvIpList.SelectedItems[0].BackColor = Color.White;
                    saveFormDataToJson();
                    break;
                case "Disable":
                    lvIpList.SelectedItems[0].BackColor = Color.Gray;
                    saveFormDataToJson();
                    break;
            } 
        }

        private void MComment_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode != Keys.Enter)
            {
                lvIpList.SelectedItems[0].SubItems[2].Text = mComment.Text;
                saveFormDataToJson();
            }
            else
            {
                IpMenu.Close();
            }
            
        }


        private void mDriverFolder_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void mComment_Click(object sender, EventArgs e)
        {

        }

        private void mBackup_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem button = (ToolStripMenuItem)sender;
            button.Enabled = false;
            FormData formData = getFormData();
            formData.ConnectionTimeout = 2000;
            filePublisher = new FilePublisher(formData);
            filePublisher.AddToLog += new AddLog(CallAddLog);
            filePublisher.UpdateProgressBar += new UpdateProgressBar(CallUpdateProgressBar);
            Thread tr = new Thread(() => filePublisher.CopyFormIP(rightClickIp));
            tr.Start();
            button.Enabled = true;

        }

        private void lblBackupFolder_Click(object sender, EventArgs e)
        {
            string folderPath = lblBackupFolder.Text;
            if (Directory.Exists(folderPath))
            {
                Process.Start(folderPath);
            }
        }

        private void btnDeviceJsons_Click(object sender, EventArgs e)
        {
            JsonsParse jf = new JsonsParse();
            if (jf.ShowDialog() == DialogResult.OK)
            {
                //foreach (var ip in jf.selectedList)
                //{
                    
                    
                //        List<string> row = new List<string>() { ip, "---", "---" };
                //        lvIpList.Items.Add(new ListViewItem(row.ToArray()));
                    
                //}

            }
        }
    }

   
}
