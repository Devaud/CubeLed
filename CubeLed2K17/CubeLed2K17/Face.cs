using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeLed2K17
{
    class Face
    {
        #region Fields
        private int width;
        private int height;
        private Led[,] t_Leds;
        #endregion

        #region Properties
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public Led[,] T_Leds
        {
            get { return this.t_Leds; }
            set { this.t_Leds = value; }
        }
        #endregion

        #region Constructor
        public Face()
        {
            this.Height = 8;
            this.Width = 8;
            this.T_Leds = new Led[this.Width, this.Height];
        }
        #endregion
    }
}
