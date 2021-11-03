using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMFilePublisher
{
    public class FormData
    {
        public string TargetWizardPath { set; get; }
        public string SourceWizardPath { set; get; }
        public string TargetDriverDataPath { set; get; }
        public string SourceDriverDataPath { set; get; }
        public string BackupFolder { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Domain { set; get; }
        public string LineValidate { set; get; }
        public int ConnectionTimeout { set; get; }
        public List<IpItem> IpList { set; get; }

    }

    public class SetupFile
    {
        public string line { set; get; }
    }

    public class IpItem
    {
        public IpItem(string ip, bool enabled ,string comment)
        {
            this.Ip = ip;
            this.Enabled = enabled;
            this.Comment = comment;
        }
        public string Ip { set; get; }
        public bool Enabled { set; get; }
        public string Comment { set; get; }
    }
}