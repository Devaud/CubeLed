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
        private const int BUFFER_SIZE = 65;
        private const int NULL_VALUE = 0x00;
        private const int DEFAULT_VENDOR_ID = 0x16C0;
        private const int DEFAULT_PRODUCT_ID = 0x2010;

        private const string STR_CUBE_READY = "#ready$"; // Frame received in case of good connexion
        private const string STR_START_DRAWING = "#draw$"; // Frame send for start the draw
        private const string STR_CUBE_NOT_READY = "#notready$"; // Frame received 

        public UsbHidPort UsbPort { get; set; }
        public DataByte BufferIn { get; set; }
        public DataByte BufferOut { get; set; }
        public bool IsConnected { get; set; } // If the device is connected
        public bool CanCommunicate { get; set; } // If the device can communicate with the software
        #endregion

        #region Constructor
        
        /// <summary>
        /// Create new CubeLedManager
        /// </summary>
        /// <param name="param_vendorId">VendorId</param>
        /// <param name="param_productId">ProductId</param>
        public CubeLedManager(int param_vendorId, int param_productId)
        {
            this.UsbPort = new UsbHidPort();

            this.UsbPort.VendorId = param_vendorId;
            this.UsbPort.ProductId = param_productId;

            // Create connect / disconnect EventHandler
            this.UsbPort.OnDeviceArrived += new EventHandler(UsbPort_OnDeviceArrived);
            this.UsbPort.OnSpecifiedDeviceArrived += new EventHandler(UsbPort_OnSpecifiedDeviceArrived);
            this.UsbPort.OnDeviceRemoved += new EventHandler(UsbPort_OnDeviceRemoved);
            this.UsbPort.OnSpecifiedDeviceRemoved += new EventHandler(UsbPort_OnSpecifiedDeviceRemoved);

            // Create send and receive EventHandler
            this.UsbPort.OnDataRecieved += new DataRecievedEventHandler(UsbPort_OnDataRecieved);
            this.UsbPort.OnDataSend += new EventHandler(UsbPort_OnDataSend);

            this.IsConnected = false;
            this.CanCommunicate = false;

            this.UsbPort.CheckDevicePresent();
        }

        /// <summary>
        /// Create new CubeLedManager with default VendorId and ProductId
        /// </summary>
        public CubeLedManager()
            : this(DEFAULT_VENDOR_ID, DEFAULT_PRODUCT_ID)
        {

        }
        #endregion

        private void UsbPort_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            // Stop device processus
            this.BufferIn = null;
            this.BufferOut = null;
            this.IsConnected = false;
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
                this.IsConnected = true;
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

        void UsbPort_OnDataSend(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
        }

        void UsbPort_OnDataRecieved(object sender, DataRecievedEventArgs args)
        {
            if (DataChange(args))
            {
                int currentPosition = 0;
                string str_rec = "";
                foreach (byte byteData in args.data)
                    this.BufferIn[currentPosition++] = byteData;

                byte[] bufferCopy = new byte[BUFFER_SIZE];
                for (int i = 0; i < BUFFER_SIZE; i++)
                    bufferCopy[i] = this.BufferIn[i];

                str_rec = new string(UTF8Encoding.UTF8.GetChars(bufferCopy)); // Array convert in ASCII UTF8

                // if the cube is ready to receive data
                if (str_rec.Contains(STR_CUBE_READY))
                {
                    SendCommand(STR_START_DRAWING);
                    Send0x00();

                    this.CanCommunicate = true;
                }

                if (str_rec.Contains(STR_CUBE_NOT_READY))
                {
                    this.CanCommunicate = false;
                }
            }
        }

        /// <summary>
        /// Check if the buffer change
        /// </summary>
        /// <param name="args"></param>
        /// <returns>True -> buffer changed, False -> Buffer unchanged</returns>
        private bool DataChange(DataRecievedEventArgs args)
        {
            bool changed = false;

            int bufferIndex = 0;
            foreach (byte byteData in args.data)
                changed |= byteData != this.BufferIn[bufferIndex++];

            return changed;
        }

        /// <summary>
        /// Send the null value to the cube
        /// </summary>
        private void Send0x00()
        {
            try
            {
                for (int i = 0; i < BUFFER_SIZE; i++)
                    this.BufferOut[i] = NULL_VALUE;
                this.UsbPort.SpecifiedDevice.SendData(this.BufferOut.ToBytes());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Send commande to the cube
        /// </summary>
        /// <param name="command">Command to send</param>
        private void SendCommand(string command)
        {
            try
            {
                int i = 1;
                foreach (byte dat in command)
                {
                    this.BufferOut[i] = dat;
                    i++;
                }

                do
                {
                    this.BufferOut[i] = NULL_VALUE;
                    i++;
                } while (i < BUFFER_SIZE);

                this.UsbPort.SpecifiedDevice.SendData(this.BufferOut.ToBytes());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
