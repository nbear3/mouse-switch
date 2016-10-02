using System;
using System.Runtime.InteropServices;
using System.Management;
using System.Collections.Generic;


internal static class UsbNotification
{
    public const int DbtDevicearrival = 0x8000; // system detected a new device        
    public const int DbtDeviceremovecomplete = 0x8004; // device is gone      
    public const int WmDevicechange = 0x0219; // device change event      
    private const int DbtDevtypDeviceinterface = 5;
    private static readonly Guid GuidDevinterfaceUSBDevice = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED"); // USB devices
    private static IntPtr notificationHandle;

    /// <summary>
    /// Registers a window to receive notifications when USB devices are plugged or unplugged.
    /// </summary>
    /// <param name="windowHandle">Handle to the window receiving notifications.</param>
    public static void RegisterUsbDeviceNotification(IntPtr windowHandle)
    {
        DevBroadcastDeviceinterface dbi = new DevBroadcastDeviceinterface
        {
            DeviceType = DbtDevtypDeviceinterface,
            Reserved = 0,
            ClassGuid = GuidDevinterfaceUSBDevice,
            Name = 0
        };

        dbi.Size = Marshal.SizeOf(dbi);
        IntPtr buffer = Marshal.AllocHGlobal(dbi.Size);
        Marshal.StructureToPtr(dbi, buffer, true);

        notificationHandle = RegisterDeviceNotification(windowHandle, buffer, 0);
    }

    /// <summary>
    /// List usb devices
    /// </summary>
    /// <returns>List of USB devices</returns>
    public static List<USBDeviceInfo> GetUSBDevices()
    {
        List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

        ManagementObjectCollection collection;
        using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PointingDevice"))
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

    /// <summary>
    /// Unregisters the window for USB device notifications
    /// </summary>
    public static void UnregisterUsbDeviceNotification()
    {
        UnregisterDeviceNotification(notificationHandle);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr RegisterDeviceNotification(IntPtr recipient, IntPtr notificationFilter, int flags);

    [DllImport("user32.dll")]
    private static extern bool UnregisterDeviceNotification(IntPtr handle);

    [StructLayout(LayoutKind.Sequential)]
    private struct DevBroadcastDeviceinterface
    {
        internal int Size;
        internal int DeviceType;
        internal int Reserved;
        internal Guid ClassGuid;
        internal short Name;
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

