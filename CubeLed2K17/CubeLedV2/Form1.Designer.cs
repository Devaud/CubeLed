namespace CubeLed
{
    partial class FrmCubeLed
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pctSurface = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RdbOn = new System.Windows.Forms.RadioButton();
            this.RdbOff = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RdbAnimOn = new System.Windows.Forms.RadioButton();
            this.RdbAnimOff = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TRBIntensity = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnCouleur = new System.Windows.Forms.Button();
            this.TBNbImage = new System.Windows.Forms.TextBox();
            this.TBms = new System.Windows.Forms.TextBox();
            this.BtnPlay = new System.Windows.Forms.Button();
            this.BtnPause = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctSurface)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRBIntensity)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctSurface
            // 
            this.pctSurface.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctSurface.Location = new System.Drawing.Point(1, 2);
            this.pctSurface.Name = "pctSurface";
            this.pctSurface.Size = new System.Drawing.Size(836, 441);
            this.pctSurface.TabIndex = 0;
            this.pctSurface.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnCouleur);
            this.groupBox1.Controls.Add(this.TRBIntensity);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.RdbOff);
            this.groupBox1.Controls.Add(this.RdbOn);
            this.groupBox1.Location = new System.Drawing.Point(12, 459);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 154);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // RdbOn
            // 
            this.RdbOn.AutoSize = true;
            this.RdbOn.Checked = true;
            this.RdbOn.Location = new System.Drawing.Point(16, 20);
            this.RdbOn.Name = "RdbOn";
            this.RdbOn.Size = new System.Drawing.Size(39, 17);
            this.RdbOn.TabIndex = 0;
            this.RdbOn.TabStop = true;
            this.RdbOn.Text = "On";
            this.RdbOn.UseVisualStyleBackColor = true;
            this.RdbOn.Click += new System.EventHandler(this.RdbOn_Click);
            // 
            // RdbOff
            // 
            this.RdbOff.AutoSize = true;
            this.RdbOff.Location = new System.Drawing.Point(16, 44);
            this.RdbOff.Name = "RdbOff";
            this.RdbOff.Size = new System.Drawing.Size(39, 17);
            this.RdbOff.TabIndex = 1;
            this.RdbOff.Text = "Off";
            this.RdbOff.UseVisualStyleBackColor = true;
            this.RdbOff.Click += new System.EventHandler(this.RdbOff_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnStop);
            this.groupBox2.Controls.Add(this.BtnPause);
            this.groupBox2.Controls.Add(this.BtnPlay);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.RdbAnimOff);
            this.groupBox2.Controls.Add(this.RdbAnimOn);
            this.groupBox2.Location = new System.Drawing.Point(352, 459);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 154);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // RdbAnimOn
            // 
            this.RdbAnimOn.AutoSize = true;
            this.RdbAnimOn.Checked = true;
            this.RdbAnimOn.Location = new System.Drawing.Point(20, 44);
            this.RdbAnimOn.Name = "RdbAnimOn";
            this.RdbAnimOn.Size = new System.Drawing.Size(88, 17);
            this.RdbAnimOn.TabIndex = 0;
            this.RdbAnimOn.TabStop = true;
            this.RdbAnimOn.Text = "Animation On";
            this.RdbAnimOn.UseVisualStyleBackColor = true;
            this.RdbAnimOn.Click += new System.EventHandler(this.RdbAnimOn_Click);
            // 
            // RdbAnimOff
            // 
            this.RdbAnimOff.AutoSize = true;
            this.RdbAnimOff.Location = new System.Drawing.Point(20, 98);
            this.RdbAnimOff.Name = "RdbAnimOff";
            this.RdbAnimOff.Size = new System.Drawing.Size(86, 17);
            this.RdbAnimOff.TabIndex = 1;
            this.RdbAnimOff.Text = "Animaton Off";
            this.RdbAnimOff.UseVisualStyleBackColor = true;
            this.RdbAnimOff.Click += new System.EventHandler(this.RdbAnimOff_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Intensité :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nb images :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ms/image :";
            // 
            // TRBIntensity
            // 
            this.TRBIntensity.Location = new System.Drawing.Point(92, 44);
            this.TRBIntensity.Maximum = 100;
            this.TRBIntensity.Name = "TRBIntensity";
            this.TRBIntensity.Size = new System.Drawing.Size(225, 45);
            this.TRBIntensity.TabIndex = 3;
            this.TRBIntensity.Value = 50;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TBms);
            this.groupBox3.Controls.Add(this.TBNbImage);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(251, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // BtnCouleur
            // 
            this.BtnCouleur.Location = new System.Drawing.Point(16, 92);
            this.BtnCouleur.Name = "BtnCouleur";
            this.BtnCouleur.Size = new System.Drawing.Size(301, 23);
            this.BtnCouleur.TabIndex = 4;
            this.BtnCouleur.Text = "Changer la couleur";
            this.BtnCouleur.UseVisualStyleBackColor = true;
            // 
            // TBNbImage
            // 
            this.TBNbImage.Location = new System.Drawing.Point(100, 20);
            this.TBNbImage.Name = "TBNbImage";
            this.TBNbImage.Size = new System.Drawing.Size(77, 20);
            this.TBNbImage.TabIndex = 5;
            this.TBNbImage.Text = "8";
            // 
            // TBms
            // 
            this.TBms.Location = new System.Drawing.Point(100, 52);
            this.TBms.Name = "TBms";
            this.TBms.Size = new System.Drawing.Size(77, 20);
            this.TBms.TabIndex = 6;
            this.TBms.Text = "300";
            // 
            // BtnPlay
            // 
            this.BtnPlay.Location = new System.Drawing.Point(135, 41);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(75, 23);
            this.BtnPlay.TabIndex = 3;
            this.BtnPlay.Text = "Play";
            this.BtnPlay.UseVisualStyleBackColor = true;
            // 
            // BtnPause
            // 
            this.BtnPause.Location = new System.Drawing.Point(135, 72);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(75, 23);
            this.BtnPause.TabIndex = 4;
            this.BtnPause.Text = "Pause";
            this.BtnPause.UseVisualStyleBackColor = true;
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(135, 101);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(75, 23);
            this.BtnStop.TabIndex = 5;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            // 
            // FrmCubeLed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 624);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pctSurface);
            this.Name = "FrmCubeLed";
            this.Text = "CubeLed";
            ((System.ComponentModel.ISupportInitialize)(this.pctSurface)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRBIntensity)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctSurface;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar TRBIntensity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RdbOff;
        private System.Windows.Forms.RadioButton RdbOn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RdbAnimOff;
        private System.Windows.Forms.RadioButton RdbAnimOn;
        private System.Windows.Forms.Button BtnCouleur;
        private System.Windows.Forms.TextBox TBms;
        private System.Windows.Forms.TextBox TBNbImage;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Button BtnPause;
        private System.Windows.Forms.Button BtnPlay;
    }
}

