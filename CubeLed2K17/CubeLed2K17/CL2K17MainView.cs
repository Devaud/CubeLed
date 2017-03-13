/* *
 * Projet      : CubeLed2K17
 * Description : GUI for user interaction with the 3D Cube led.
 * Authors     : Devaud Alan, Amado Kevin & Mendez Gregory
 * Date        :
 * Version     : 1.0
 */
using CFPT.UsbCommunicator;
using Microsoft.Xna.Framework;
using System;
using System.Windows.Forms;

namespace CubeLed2K17
{
    public partial class CL2K17MainView : Form
    {
        public CLCLManager UsbComm { get; set; }
        public Timer CheckUsbState { get; set; }
        public CL2K17Viewer3D Game { get; set; }
        public CL2K17Controller Ctrl { get; set; }

        //public Game1 Game { get; set; }

        public CL2K17MainView()
        {
            InitializeComponent();

            this.Ctrl = new CL2K17Controller(this);
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
            this.UpdateFaceShowing();
        }

        private void FrmCubeLed_Load(object sender, EventArgs e)
        {
            this.UsbComm = new CLCLManager();
        }

        public void connect(CL2K17Viewer3D game)
        {
            this.Game = game;
            this.UpdateFaceShowing();
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
            /*string[,,] cubeState = this.Game.GetCubeState();
            this.UsbComm.SendDataToCube(cubeState);*/
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Game.ChangeLed(3, 6, 7);
            Game.ChangeLed(4, 6, 7);
            Game.ChangeLed(3, 5, 7);
            Game.ChangeLed(4, 5, 7);
            Game.ChangeLed(3, 4, 7);
            Game.ChangeLed(4, 4, 7);
            Game.ChangeLed(3, 3, 7);
            Game.ChangeLed(4, 3, 7);
            Game.ChangeLed(3, 2, 7);
            Game.ChangeLed(4, 2, 7);
            Game.ChangeLed(3, 1, 7);
            Game.ChangeLed(4, 1, 7);
            Game.ChangeLed(1, 4, 7);
            Game.ChangeLed(5, 4, 7);
            Game.ChangeLed(5, 4, 7);
            Game.ChangeLed(6, 4, 7);
            Game.ChangeLed(1, 3, 7);
            Game.ChangeLed(2, 3, 7);
            Game.ChangeLed(5, 3, 7);
            Game.ChangeLed(2, 4, 7);
            Game.ChangeLed(6, 3, 7);
            this.UpdateCube();
        }

        /// <summary>
        /// Met à jour le cube 3D
        /// </summary>
        private void UpdateCube()
        {
            this.UsbComm.SendDataToCube(this.Game.GetCubeState());
        }

        private void UpdateFaceShowing()
        {
            this.lblFaceShowing.Text = "Face : " + Game.faceShowed.ToString();
        }
    }
}