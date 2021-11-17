using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMFilePublisher
{
    public class instanceConfigFormat
    {
        [JsonProperty("All Devices")]
        private List<Device> allDevices;

        internal List<Device> AllDevices { get => allDevices; set => allDevices = value; }
    }
    class Device
    {
        [JsonProperty("Device type")]
        public string DeviceType { get; set; }
        [JsonProperty("Devices")]
        public List<Devices> Devices;
    }
    public class Devices
    {
        [JsonProperty("Device Name")]
        public string DeviceName { get; set; }

    }


}

