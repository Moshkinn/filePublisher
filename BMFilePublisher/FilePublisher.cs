using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BMFilePublisher
{
    public class FilePublisher
    {
        private FormData formData;
        private List<string> wizardFilesList;
        private List<string> driverFilesList;

        private NetworkMgr NetworkMgr;

        private int maxFileAllProccess;
        private int maxFilePerProccess;
        private int proccessBarValue;

        private int minProgress = 1, maxProgress = 255, actProgress = 1;

        public string subnetIpScan { set; get; }
        public Dictionary<string, string> LastLineIdUpdate;
        public List<string> toUpdate;

        public event AddLog AddToLog = null;
        public event UpdateProgressBar UpdateProgressBar = null;
        public event MarkIp MarkIp = null;
        public event UpdateLineId UpdateLineId = null;


        public FilePublisher(FormData formData)
        {
            this.formData = formData;
            
        }

        public void Run()
        {
            try
            {
                AddToLog("Generate source file list", Color.White);
                AddToLog("Driver Data : " + Path.GetDirectoryName(this.formData.SourceDriverDataPath), Color.White);
                driverFilesList = genereateSourceFileList(this.formData.SourceDriverDataPath);
                AddToLog("Wizard Data : " + Path.GetDirectoryName(this.formData.SourceWizardPath), Color.White);
                wizardFilesList = genereateSourceFileList(this.formData.SourceWizardPath);

                maxFilePerProccess = wizardFilesList.Count + driverFilesList.Count;
                maxFileAllProccess = (formData.IpList.Count * maxFilePerProccess);

                int fileIndex = 0;

                foreach (IpItem ip in this.formData.IpList)
                {
                    if (!ip.Enabled)
                    {
                        AddToLog(String.Format("( {0} ), Address Is Disabled", ip.Ip), Color.Gray);
                        MarkIp(ip.Ip, Color.Gray);
                        proccessBarValue += maxFilePerProccess;
                        UpdateProgressBar(0, maxFileAllProccess, proccessBarValue);
                        continue;
                    }
                    bool replaceLogFlag = false;
                    bool skip = false;
                    AddToLog(String.Format("Start copy DriverData to ( {0} )", ip.Ip), Color.White);
                    fileIndex = 0;
                    foreach (string path in this.driverFilesList)
                    {
                        string target = formData.TargetDriverDataPath.Replace("C:", "\\\\" + ip.Ip + "\\c$") + "\\" + Path.GetFileName(path);
                        if (!this.Copy(ip.Ip, path, target))
                        {
                            skip = true;
                            break;
                        }
                        else
                        {
                            if (!replaceLogFlag)
                            {
                                AddToLog(String.Format("_", Path.GetFileName(target), ip.Ip), Color.White);
                                replaceLogFlag = true;
                            }
                            fileIndex++;
                            AddToLog(String.Format("-Saved DriverData File {0}/{1} : {2} To ({3})", fileIndex.ToString(), driverFilesList.Count, Path.GetFileName(target), ip.Ip), Color.LightGreen);
                        }
                    }

                    replaceLogFlag = false;
                    fileIndex = 0;
                    if (skip)
                    {
                        AddToLog(String.Format("Skipped on ( {0} )", ip.Ip), Color.Red);
                        MarkIp(ip.Ip, Color.Red);
                        continue;
                    }

                    AddToLog(String.Format("Start copy WizardData to ( {0} )", ip.Ip), Color.White);
                    foreach (string path in this.wizardFilesList)
                    {
                        string target = formData.TargetWizardPath.Replace("C:", "\\\\" + ip.Ip + "\\c$") + "\\" + Path.GetFileName(path);
                        if (!this.Copy(ip.Ip, path, target))
                        {
                            skip = true;
                            break;
                        }
                        else{
                            if (!replaceLogFlag)
                            {
                                AddToLog(String.Format("_", Path.GetFileName(target), ip.Ip), Color.White);
                                replaceLogFlag = true;
                            }
                            fileIndex++;
                            AddToLog(String.Format("-Saved Wizard File {0}/{1} : {2} To ({3})", fileIndex.ToString(), wizardFilesList.Count, Path.GetFileName(target), ip.Ip), Color.LightGreen);
                        }
                    }

                    if (skip)
                    {
                        AddToLog(String.Format("Skipped on ( {0} )", ip.Ip), Color.Red);
                        MarkIp(ip.Ip, Color.Red);
                        continue;
                    }
                    else
                    {
                        AddToLog(String.Format("Finish Transfer to ( {0} )", ip.Ip), Color.LightGreen);
                        MarkIp(ip.Ip, Color.LightGreen);
                    }
                    
                }
            }catch(Exception ex)
            {
                AddToLog(String.Format("Exception {0}", ex.Message), Color.Red);
            }
            AddToLog("Process Done!", Color.LightGreen);
        }

        private List<string> genereateSourceFileList(string path)
        {
            AddToLog("_", Color.White);
            int index = 1;
            List<string> result = new List<string>();
            string[] fileList = Directory.GetFiles(path).Where(x => Path.GetExtension(x).ToLower() == ".json").ToArray();
            foreach (string fileName in fileList)
            {
                if(Path.GetExtension(fileName).ToLower() == ".json")
                {
                    result.Add(fileName);
                    AddToLog(String.Format("-Loading {0}/{1} : {2}", index, fileList.Length, Path.GetFileName(fileName)), Color.LightGreen);
                    index++;
                }
            }
            return result;
        }

        private string folderIpFormat(string ip)
        {
            return @"\\" + ip + @"\";
        }

        public bool OpenNetworkPath(string ip, NetworkCredential nc, string filePath)
        {
            try
            {
                if (CheckPing(ip, 1000))
                {
                    string path = String.Format("\\\\{0}\\c$", ip);
                    
                    using (new NetworkMgr(path, nc))
                    {
                        if (filePath != string.Empty)
                        {
                            path += @"\" + filePath;
                        }
                        Process.Start(path);
                        
                        return true;
                    }
                }
            }
            catch
            {

            }
            return false;

        }

        public bool OpenNetworkDirectory(string ip ,NetworkCredential nc)
        {
            try
            {
                if (CheckPing(ip, 1000))
                {
                    string path = String.Format("\\\\{0}\\c$", ip);
                    using (new NetworkMgr(path, nc))
                    {
                        Process.Start(path);
                        return true;
                    }
                }
            }
            catch
            {
               
            }
            return false;

        }




        private void DirectoryCopy(string sourceDirName, string destDirName)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            foreach (DirectoryInfo subdir in dirs)
            {
                string tempPath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, tempPath);
            }
        }
    



         public void CopyFormIP(string ip)
         {
            AddToLog("Backup " + ip + " Started.", Color.LightGreen);
            if(!CheckPing(ip, 2000))
            {
                AddToLog("Could not connect to machine.", Color.Red);
            }
            int progressCounter = 0;
            List<string> foldersToCopy = new List<string>();
            foldersToCopy.Add(@"c$\BRC\configuration");
            foldersToCopy.Add(@"c$\inetpub\wwwroot\data\wizardDevices");
            foldersToCopy.Add(@"c$\BRC\Apps\DriverManager\DriversData");
            foldersToCopy.Add(@"c$\BRC\Recipes");
            //string targetFolderPath = Path.GetDirectoryName(source);
            foreach(string folder in foldersToCopy)
            {
                string toCopy = @"\\" + ip + "\\" + folder;
                string folderName = Path.GetFileName(folder);
                string toPaste = this.formData.BackupFolder + "\\" + ip + "\\" + folderName;

                try
                {
                    CustomeCheckPath ccp = new CustomeCheckPath(toCopy, this.formData.ConnectionTimeout);
                    if (CheckPing(ip, this.formData.ConnectionTimeout) && ccp.CheckPathTimeout())
                    {

                        NetworkCredential nc = new NetworkCredential(formData.UserName, formData.Password, formData.Domain);
                        using (NetworkMgr = new NetworkMgr(toCopy, nc))
                        {

                            DirectoryCopy(toCopy, toPaste);
                            AddToLog(String.Format("Backup Source : {0} Into : {1} ", toCopy, toPaste), Color.LightBlue);
                            progressCounter++;
                            UpdateProgressBar(0, foldersToCopy.Count, progressCounter);
                        }
                    }
                }catch(Exception ex)
                {
                    AddToLog("Error : " + folder + " " + ex.Message, Color.Red);
                    progressCounter++;
                    UpdateProgressBar(0, foldersToCopy.Count, progressCounter);
                }
                
                if (progressCounter == foldersToCopy.Count)
                {
                    AddToLog("Backup Done.", Color.LightGreen);
                }

            }
            
         }



        private bool Copy(string ip, string source, string target)
        {
            this.formData.ConnectionTimeout = 1000;
            try
            {
                string targetFolderPath = Path.GetDirectoryName(target);
                CustomeCheckPath ccp = new CustomeCheckPath(targetFolderPath, this.formData.ConnectionTimeout);
                if (CheckPing(ip, this.formData.ConnectionTimeout) && ccp.CheckPathTimeout())
                {
                    
                    NetworkCredential nc = new NetworkCredential(formData.UserName, formData.Password, formData.Domain);
                    using (NetworkMgr = new NetworkMgr(targetFolderPath, nc))
                    {

                        File.Copy(source, target, true);  
                    }
                }
                else
                {
                    throw new Exception(String.Format("Could not connect to ( {0} )", ip));
                }
                
            }
            catch(Exception ex)
            {
                AddToLog(String.Format("Error copy to : {0} ", target), Color.Red);
                AddToLog(String.Format("Exception : {0}", ex.Message), Color.Red);




                proccessBarValue += maxFilePerProccess;
                UpdateProgressBar(0, maxFileAllProccess, proccessBarValue);
                return false;
            }

            proccessBarValue++;
            UpdateProgressBar(0, maxFileAllProccess, proccessBarValue);
            return true;

        }


        public void getScanAllIpSubnet()
        {
            string[] arrIp = this.subnetIpScan.Split('.');
            List<string> result = new List<string>();
            minProgress = Int32.Parse(arrIp[3]);
            for (int i = minProgress; i <= maxProgress; i++)
            {
                arrIp[3] = i.ToString();
                string newIP = string.Join(".", arrIp);
                if (CheckPing(newIP, 10))
                {
                    string lineId = getLineId(newIP);
                    if (lineId != string.Empty)
                    {
                        AddToLog(newIP + "," + lineId, Color.White);
                    }
                    else
                    {
                        AddToLog(newIP + ",Unknown", Color.White);
                    }
                    
                    //result.Add(newIP);
                }
                actProgress++;
                UpdateProgressBar(minProgress, maxProgress, actProgress);
            }
        }



        public void UpdateLineIdNameList()
        {
            LastLineIdUpdate = new Dictionary<string, string>();
            string lineId = string.Empty;
            foreach(string ip in this.toUpdate)
            {
                if (CheckPing(ip, 10))
                {
                    lineId = getLineId(ip);
                    if (lineId == string.Empty)
                    {
                        lineId = "Unknown";
                    }
                    
                }
                else
                {
                    lineId = "Unknown";
                }
                LastLineIdUpdate.Add(ip, lineId);
                string[] kv = new string[2];
                kv[0] = ip;
                kv[1] = lineId;
              
               
                UpdateLineId(kv);
            }

            
        }

        private string getLineId(string ip)
        {
            string result = string.Empty;
            string basePath = @"\\" + ip + @"\c$\";
            string setupFilePath = basePath + @"BRC\configuration\";
            string setupFileName = "setup.json";
            string setupFullPath = setupFilePath + setupFileName;
            try
            {
                CustomeCheckPath ccp = new CustomeCheckPath(String.Format(@"\\{0}\c$", ip), 11000);
                if (ccp.CheckPathTimeout())
                {
                    NetworkCredential nc = new NetworkCredential(formData.UserName, formData.Password, formData.Domain);
                    using (NetworkMgr = new NetworkMgr(Path.GetDirectoryName(basePath), nc))
                    {

                        if (File.Exists(setupFullPath))
                        {
                            SetupFile sf = new SetupFile();
                            using (StreamReader r = new StreamReader(setupFullPath))
                            {
                                string jsonString = r.ReadToEnd();
                                sf = JsonConvert.DeserializeObject<SetupFile>(jsonString);
                                result = sf.line;
                            }
                        }
                    }
                }
                
            }
            catch
            {
                
            }
            

            return result;
        }

        private bool CheckPing(string ip, int timeout)
        {
            try
            {
                IPStatus E_Status;
                Ping pingSender = new Ping();
                byte[] buffer = new byte[32];

                E_Status = pingSender.Send(ip, timeout, buffer).Status;
                return E_Status == IPStatus.Success;

            }
            catch
            {
                return false;
            }

            
        }

    }


    public class CustomeCheckPath
    {
        public bool IsDirExist;
        private string path;
        private int timeout;
        public CustomeCheckPath(string path, int timeout)
        {
            this.path = path;
            this.timeout = timeout;
        }

        public bool CheckPathTimeout()
        {
            IsDirExist = false;
            bool result = true;
            Thread tr = new Thread(this.CheckPath);
            DateTime st = DateTime.Now;
            TimeSpan ts = new TimeSpan();
            tr.Start();
            while (tr.IsAlive)
            {
                ts = (DateTime.Now - st);
                if (Convert.ToDecimal(ts.TotalMilliseconds) >= timeout)
                {
                    result = false;
                    break;
                }
                
            }
            tr.Abort();
            return result;
        }

        private void CheckPath()
        {
            IsDirExist = Directory.Exists(this.path);
        }
    }
    
}

