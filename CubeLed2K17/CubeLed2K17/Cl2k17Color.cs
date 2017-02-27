/* *
 * Projet      : CubeLed2K17
 * Description : GUI for user interaction with the 3D Cube led.
 * Authors     : Devaud Alan, Amado Kevin & Mendez Gregory
 * Date        :
 * Version     : 1.0
 */
using System;

namespace CubeLed2K17
{
    class CL2K17Color
    {
        #region Fields
        private const int RED_MASK = 0xFF0000;
        private const int GREEN_MASK = 0xFF00;
        private const int BLUE_MASK = 0xFF;
        private const int RED_POSITION = 16;
        private const int GREEN_POSITION = 8;
        private const int BLUE_POSITION = 0;
        private const int DEFAULT_COLOR = 0x000000;

        private byte _red;
        private byte _green;
        private byte _blue;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set the red value
        /// </summary>
        public byte Red
        {
            get { return _red; }
            set { _red = value; }
        }

        /// <summary>
        /// Get or set the green value
        /// </summary>
        public byte Green
        {
            get { return _green; }
            set { _green = value; }
        }

        /// <summary>
        /// Get or set the blue value
        /// </summary>
        public byte Blue
        {
            get { return _blue; }
            set { _blue = value; }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Create new IrpColor with the default color
        /// </summary>
        public CL2K17Color()
            : this(DEFAULT_COLOR)
        {

        }

        /// <summary>
        /// Create new IrpColor with a RGB value
        /// </summary>
        /// <param name="color">Color int value</param>
        public CL2K17Color(int color) :
            this(Convert.ToByte((color & RED_MASK) >> RED_POSITION), Convert.ToByte((color & GREEN_MASK) >> GREEN_POSITION), Convert.ToByte((color & BLUE_MASK) >> BLUE_POSITION))
        {

        }

        /// <summary>
        /// Create new IrpColor with red, green, blue value
        /// </summary>
        /// <param name="param_red">Red value</param>
        /// <param name="param_green">Green value</param>
        /// <param name="param_blue">Blue value</param>
        public CL2K17Color(byte param_red, byte param_green, byte param_blue)
        {
            this.Red = param_red;
            this.Green = param_green;
            this.Blue = param_blue;
        }
        #endregion

        #region Methdos
        /// <summary>
        /// Convert IrpColor in a BGR entier value
        /// </summary>
        /// <returns>Bgr value</returns>
        public int ToBgr()
        {
            // Reb position for blue color and Blue position for red color make BGR
            return (this.Blue << RED_POSITION) + (this.Green << GREEN_POSITION) + (this.Red << BLUE_POSITION);
        }

        /// <summary>
        /// Convert IrpColor in a RGB entier value
        /// </summary>
        /// <returns>Rgb Value</returns>
        public int ToRgb()
        {
            return (this.Red << RED_POSITION) + (this.Green << GREEN_POSITION) + (this.Blue << BLUE_POSITION);
        }
        #endregion
    }
}
