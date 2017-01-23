using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeLed
{
    class Led
    {
        #region Fields
        private Cl2k17Color color;
        private bool on;
        private int intensity;

        #endregion

        #region Properties
        public Cl2k17Color Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public bool On
        {
            get { return this.on; }
            set { this.on = value; }
        }

        public int Intensity
        {
            get { return this.intensity; }
            set { this.intensity = value; }
        }
        #endregion

        #region constructor
        public Led()
        {
            this.On = false;
            this.Intensity = 100;
        }

        #endregion


    }
}
