using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Utilisation de la bibliothèque pour l'usb
using UsbLibraryCfptAdd;

namespace CFPT.Manager
{
    public class CubeLedManager
    {
        #region Properties
        public UsbHidPort UsbPort { get; set; }
        public DataByte BufferIn { get; set; }
        public DataByte BufferOut { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Create new CubeLedManager
        /// </summary>
        public CubeLedManager()
        {
            this.UsbPort = new UsbHidPort();
            this.UsbPort.OnDeviceArrived += UsbPort_OnDeviceArrived;
            this.UsbPort.OnSpecifiedDeviceArrived += UsbPort_OnSpecifiedDeviceArrived;
            this.UsbPort.OnDeviceRemoved += UsbPort_OnDeviceRemoved;
            this.UsbPort.OnSpecifiedDeviceRemoved += UsbPort_OnSpecifiedDeviceRemoved;
        }


        #endregion

        private void UsbPort_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            // Stop device processus
            this.BufferIn = null;
            this.BufferOut = null;
            Console.WriteLine("Device VID : 0x{0} / PID 0x{1} is awating to connect", this.UsbPort.VendorId.ToString("X4"), this.UsbPort.ProductId.ToString("X4"));
        }

        void UsbPort_OnDeviceRemoved(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event called when a device is connected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsbPort_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            try
            {
                this.BufferIn = new DataByte(this.UsbPort.SpecifiedDevice.InputReportLength);
                this.BufferOut = new DataByte(this.UsbPort.SpecifiedDevice.OutputReportLength);
                Console.WriteLine("Device VID : 0x{0} / PID 0x{1} is connected", this.UsbPort.VendorId.ToString("X4"), this.UsbPort.ProductId.ToString("X4"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UsbPort_OnDeviceArrived(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
