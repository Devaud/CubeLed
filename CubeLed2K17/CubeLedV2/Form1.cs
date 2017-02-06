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
using CFPT.Manager;

namespace CubeLed
{
    public partial class FrmCubeLed : Form
    {
        public CubeLedManager UsbComm { get; set; }
        public Timer CheckUsbState { get; set; }
        public Game1 Game { get; set; }

        //public Game1 Game { get; set; }

        public FrmCubeLed()
        {
            InitializeComponent();
            this.Text = "CubeLed";

            this.CheckUsbState = new Timer();
            this.CheckUsbState.Interval = 100;
            this.CheckUsbState.Tick += CheckUsbState_Tick;
            this.CheckUsbState.Start();
        }

        void CheckUsbState_Tick(object sender, EventArgs e)
        {
            this.TSSLIsConnected.Text = (this.UsbComm.IsConnected) ? "USB connected" : "USB disconnected";
            this.TSSLCanCommunicate.Text = (this.UsbComm.CanCommunicate) ? "USB can communicate" : "USB can't communicate";
        }

        private void FrmCubeLed_Load(object sender, EventArgs e)
        {
            this.UsbComm = new CubeLedManager();
        }

        public void connect(Game1 game)
        {
            this.Game = game; 
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

        private void FrmCubeLed_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.pctSurface.Dispose();
            this.ApplicationExit();
        }



        private void ApplicationExit()
        {
            Application.Exit();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ApplicationExit();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            Game.SelectLed(0, 0, 0);
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            string[,,] cubeState = this.Game.GetCubeState();
            this.UsbComm.SendDataToCube(cubeState);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Game.ChangeLed(0, 0, 0);
            Game.ChangeLed(0, 0, 1);
        }
    }
}