using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMFilePublisher
{
    public partial class JsonsParse : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        public DirectoryInfo dir;
        public FileInfo[] fileList;
        private static WizardInputFormat wizardInputs;

        public JsonsParse()
        {
            InitializeComponent();
            // Create an instance of a ListView column sorter and assign it
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        private void btnLoadFiles_Click(object sender, EventArgs e)
        {
            dir = new DirectoryInfo(@"./devices/");//Assuming recipes is your Folder
            fileList = dir.GetFiles("*.json"); //Getting Text files
            foreach (FileInfo file in fileList)
            {
                using (StreamReader reader = new StreamReader(file.FullName))
                {
                    wizardInputs = JsonConvert.DeserializeObject<WizardInputFormat>(reader.ReadToEnd());
                }
                List<string> row = new List<string>() { file.Name, wizardInputs.DeviceName, wizardInputs.DeviceType };
                listView1.Items.Add(new ListViewItem(row.ToArray()));
            }
        }

        private void JsonsParse_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("File Name", 180);
            listView1.Columns.Add("deviceName", 180);
            listView1.Columns.Add("deviceType(EN_Device)", 180);

            listView1.MultiSelect = false;
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }
    }
    public class WizardInputFormat
    {
        [JsonProperty("deviceName")]
        public string DeviceName { get; set; }
        [JsonProperty("deviceType")]
        public string DeviceType { get; set; } // was int

    }
}
