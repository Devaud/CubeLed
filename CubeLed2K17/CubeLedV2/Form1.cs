using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CubeLed
{
    public partial class FrmCubeLed : Form
    {
        public FrmCubeLed()
        {
            InitializeComponent();
            this.Text = "CubeLed";
        }

        public IntPtr getDrawSurface()
        {
            return pctSurface.Handle;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void RdbOff_Click(object sender, EventArgs e)
        {
            
                BtnCouleur.Enabled = false;
                TRBIntensity.Enabled = false;
            
                
            
        }

        private void RdbOn_Click(object sender, EventArgs e)
        {
            BtnCouleur.Enabled = true;
            TRBIntensity.Enabled = true;
        }

        private void RdbAnimOn_Click(object sender, EventArgs e)
        {
            BtnPlay.Enabled = true;
            BtnPause.Enabled = true;
            BtnStop.Enabled = true;
            TBms.Enabled = true;
            TBNbImage.Enabled = true;
        }

        private void RdbAnimOff_Click(object sender, EventArgs e)
        {
            BtnPlay.Enabled = false;
            BtnPause.Enabled = false;
            BtnStop.Enabled = false;
            TBms.Enabled = false;
            TBNbImage.Enabled = false;
        }
    }
}