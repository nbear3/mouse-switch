using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;


using System.Windows.Forms;

namespace MouseSwitch
{

    public partial class msMain : MetroFramework.Forms.MetroForm
    {
        public msMain()
        {
            InitializeComponent();
            //this.Theme = MetroFramework.MetroThemeStyle.Dark;


            UsbNotification.RegisterUsbDeviceNotification(this.Handle);


            var usbDevices = UsbNotification.GetUSBDevices();
            foreach (var usbDevice in usbDevices)
            {

                DeviceGrid.Rows.Add(usbDevice.Description, usbDevice.DeviceID);
            }
        }
        
        /// <summary>
        /// Recieve messages from windows and process USB messages
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == UsbNotification.WmDevicechange)
            {
                switch ((int)m.WParam)
                {
                    case UsbNotification.DbtDeviceremovecomplete:
                        Console.WriteLine("Removed"); // this is where you do your magic
                        break;
                    case UsbNotification.DbtDevicearrival:
                        Console.WriteLine("Added"); // this is where you do your magic
                        break;
                }
            }
        }

    }
}
