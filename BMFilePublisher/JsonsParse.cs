using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private static WizardInputFormat wizardInputsFormat;
        private static DriversDataFormat driversDataFormat;
        private string _format;
        private string _path;

        public JsonsParse()
        {
            _path ="./devices/";
            InitializeComponent();
            // Create an instance of a ListView column sorter and assign it
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }
        public JsonsParse(string path, string format)
        {
            _format = format;
            _path = path;
            InitializeComponent();
            // Create an instance of a ListView column sorter and assign it
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        private void btnLoadFiles_Click(object sender, EventArgs e)
        {
            dir = new DirectoryInfo(_path); //(@"./devices/");
            fileList = dir.GetFiles("*.json"); //Getting files
            foreach (FileInfo file in fileList)
            {
                List<string> row;
                switch (_format)
                {
                    case "DriversDataFormat":
                        using (StreamReader reader = new StreamReader(file.FullName))
                        {
                            driversDataFormat = JsonConvert.DeserializeObject<DriversDataFormat>(reader.ReadToEnd());
                        }
                        row = new List<string>() { file.Name, driversDataFormat.DeviceName, driversDataFormat.DeviceType };
                        listView1.Items.Add(new ListViewItem(row.ToArray()));
                        break;
                    case "WizardInputFormat":
                        using (StreamReader reader = new StreamReader(file.FullName))
                        {
                            wizardInputsFormat = JsonConvert.DeserializeObject<WizardInputFormat>(reader.ReadToEnd());
                        }
                        row = new List<string>() { file.Name, wizardInputsFormat.DeviceName, wizardInputsFormat.DeviceType };
                        listView1.Items.Add(new ListViewItem(row.ToArray()));
                        break;
                    default:
                        break;
                }
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

        private void btnToCsv_Click(object sender, EventArgs e)
        {
            List<RowCsv> rowsToCsv = new List<RowCsv>();
            //listView1.GetItemAt
            short index = 0;
            Row row = new Row();
            foreach (var item in listView1.Items)
            {
                row.rowID = index;
                row.FileName = listView1.Items[index].SubItems[0].Text;
                row.DeviceName = listView1.Items[index].SubItems[1].Text;
                row.DeviceType = listView1.Items[index].SubItems[2].Text;
                row.Path = _path;
                rowsToCsv.Add(new RowCsv(row));
                //}

                index++;

            }

            string fileName = _format + ".csv";
            using (var writer = new StreamWriter(fileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(rowsToCsv);
            }

        }
    }
    public class WizardInputFormat
    {
        [JsonProperty("deviceName")]
        public string DeviceName { get; set; }
        [JsonProperty("deviceType")]
        public string DeviceType { get; set; } // was int

    }
    public class DriversDataFormat
    {
        [JsonProperty("deviceType")]
        public string DeviceName { get; set; }
        [JsonProperty("deviceTypeId")]
        public string DeviceType { get; set; } // was int

    }
    public class RowCsv : Row
    {
        public RowCsv(Row row) : base(row)
        {
           
        }
    }
    public class Row
    {
        public short rowID { get; set; }
        public String FileName { get; set; }

        public String DeviceName { get; set; } // 
        public String DeviceType { get; set; } // device -> to EN_Device
        public String Path { get; set; } 

        public Row()
        {
            //this.parameters = new List<Parameters>();
        }

        public Row(Row other)
        {
            this.rowID = other.rowID;
            this.FileName = other.FileName;
            this.DeviceName = other.DeviceName;
            this.DeviceType = other.DeviceType;
            this.Path = other.Path;
        }
    }

}
