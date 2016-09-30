using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;

namespace MouseSwitch
{
    public partial class msMain : MetroFramework.Forms.MetroForm
    {
        public msMain()
        {
            InitializeComponent();
            this.Theme = MetroFramework.MetroThemeStyle.Dark;

            var usbDevices = GetUSBDevices();
            foreach (var usbDevice in usbDevices)
            {
                Console.WriteLine("Device ID: {0}, PNP Device ID: {1}, Description: {2}",
                    usbDevice.DeviceID, usbDevice.PnpDeviceID, usbDevice.Description);
            }



            RawInput.RawInputDeviceEnumerator info = new RawInput.RawInputDeviceEnumerator();
            List<RawInput.RawInputDevice> info_list = info.Devices.ToList();

            for (int i = 0; i < info_list.Count; i++)
            {
                RawInput.RawInputDevice device = info_list[i];
                if (device.DeviceType == RawInput.Win32.RawInputDeviceType.Mouse)
                {
                    Console.WriteLine(info_list[i].DeviceInfo.HIDInfo.VendorID);
                }
            }
        }

        static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }

            collection.Dispose();
            return devices;
        }

    }

    class USBDeviceInfo
    {
        public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
        {
            this.DeviceID = deviceID;
            this.PnpDeviceID = pnpDeviceID;
            this.Description = description;
        }
        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }
    }
}
