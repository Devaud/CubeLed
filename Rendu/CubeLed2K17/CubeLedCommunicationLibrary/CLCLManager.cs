/* *
 * Projet      : CubeLedCommunicationLibrary
 * Description : Library for communication between GUI and the cube led.
 * Authors     : Devaud Alan, Amado Kevin & Mendez Gregory
 * Date        :
 * Version     : 1.0
 */
using System;
using System.Text;
using UsbLibraryCfptAdd; // use usb library

namespace CFPT.UsbCommunicator
{
    public class CLCLManager
    {
        #region Constant
        private const char SEPARATOR = ';';
        private const int BUFFER_SIZE = 65;
        private const int NULL_VALUE = 0x00;
        private const int DEFAULT_VENDOR_ID = 0x16C0;
        private const int DEFAULT_PRODUCT_ID = 0x2010;
        private const int MAX_LED = 8;

        private const int FRAME_POS = 0;
        private const int LIGHT_POS = 1;
        private const int INTENSITY_POS = 2;
        private const int RED_COLOR_POS = 3;
        private const int GREE_COLOR_POS = 4;
        private const int BLUE_COLOR_POS = 5;

        private const string STR_CUBE_READY = "#ready$"; // Frame received in case of good connexion
        private const string STR_START_DRAWING = "#draw$"; // Frame send for start the draw
        private const string STR_CUBE_NOT_READY = "#notready$"; // Frame received 
        #endregion

        #region Properties
        public UsbHidPort UsbPort { get; set; }
        public CLCLDataByte BufferIn { get; set; }
        public CLCLDataByte BufferOut { get; set; }
        public bool IsConnected { get; set; } // If the device is connected
        public bool CanCommunicate { get; set; } // If the device can communicate with the software
        #endregion

        #region Constructor

        /// <summary>
        /// Create new CubeLedManager
        /// </summary>
        /// <param name="param_vendorId">VendorId</param>
        /// <param name="param_productId">ProductId</param>
        public CLCLManager(int param_vendorId, int param_productId)
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
        public CLCLManager()
            : this(DEFAULT_VENDOR_ID, DEFAULT_PRODUCT_ID)
        {

        }
        #endregion

        #region Methods

        #region Usb connection
        private void UsbPort_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            // Stop device processus
            this.BufferIn = null;
            this.BufferOut = null;
            this.IsConnected = false;
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
                this.BufferIn = new CLCLDataByte(this.UsbPort.SpecifiedDevice.InputReportLength);
                this.BufferOut = new CLCLDataByte(this.UsbPort.SpecifiedDevice.OutputReportLength);
                this.IsConnected = true;
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
        #endregion

        #region Data transfert
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
                    this.SendCommand(STR_START_DRAWING);
                    this.Send0x00();

                    this.CanCommunicate = true;
                }

                if (str_rec.Contains(STR_CUBE_NOT_READY))
                {
                    this.CanCommunicate = false;
                }
            }
        }
        #endregion

        #region Utilities function for data
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

        private void SendFrame(byte[, ,] data, int frameIndex)
        {
            int bufferIndex = 1;
            for (int i = 0; i < data.GetLength(0); i++)
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    try
                    {
                        this.BufferOut[bufferIndex] = data[j, i, frameIndex];
                        bufferIndex++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            try
            {
                this.UsbPort.SpecifiedDevice.SendData(this.BufferOut.ToBytes());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Send the data cube
        /// </summary>
        /// <param name="data">Data cube</param>
        public void SendDataToCube(string[, ,] data)
        {
            byte[, ,] datacube = this.Cube3DToCubeled(data);

            this.SendCommand(STR_START_DRAWING);
            this.SendFrame(datacube, 0);


        }

        /// <summary>
        /// Convert the data cube in a Cubeled data
        /// </summary>
        /// <param name="data">Data cube</param>
        /// <param name="separator">char separator to do the split (optional)</param>
        /// <returns>Cubeled data</returns>
        private byte[, ,] Cube3DToCubeled(string[, ,] data, char separator = SEPARATOR)
        {
            byte[, ,] datacube = new byte[8, 8, 8];

            for (int z = 0; z < data.GetLength(2); z++)
                for (int x = 0; x < data.GetLength(0); x++)
                    for (int y = 0; y < data.GetLength(1); y++)
                    {
                        string[] dataSplited = data[y, x, z].Split(separator);

                        int line = x / MAX_LED;
                        int bitRow = (byte)((MAX_LED - 1) - (z % MAX_LED));

                        if (Convert.ToBoolean(dataSplited[LIGHT_POS]))
                            datacube[x, y, Convert.ToInt32(dataSplited[FRAME_POS])] |= (byte)(0x01 << bitRow);
                        else if (!Convert.ToBoolean(dataSplited[1]))
                            datacube[x, y, Convert.ToInt32(dataSplited[FRAME_POS])] &= (byte)~(0x01 << bitRow);
                    }

            return datacube;
        }
        #endregion

        #endregion
    }
}
