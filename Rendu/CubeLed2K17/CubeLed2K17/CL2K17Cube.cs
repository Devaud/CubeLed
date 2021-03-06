﻿/* *
 * Projet      : CubeLed2K17
 * Description : GUI for user interaction with the 3D Cube led.
 * Authors     : Devaud Alan, Amado Kevin & Mendez Gregory
 * Date        :
 * Version     : 1.0
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CubeLed2K17
{
    class CL2K17Cube
    {
        private const int NB_FACE = 8;

        #region Fields
        private List<CL2K17Face> faces;
        private int[, ,] LedSelected = new int[,,] { { { 0, 0, 0 } } };
        #endregion

        #region Properties

        public List<CL2K17Face> Faces
        {
            get { return this.faces; }
            set { this.faces = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="radius">radius of </param>
        /// <param name="position"></param>
        public CL2K17Cube(GraphicsDevice graphics, float radius, Vector3 position)
        {
            this.Faces = new List<CL2K17Face>();

            for (uint i = 1; i < NB_FACE + 1; i++)
            {
                Faces.Add(new CL2K17Face(graphics, radius, new Vector3(10, 10, 10), i));
            }
        }
        #endregion

        #region Methods
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < NB_FACE; i++)
            {
                Faces[i].Update(gameTime);
            }
        }

        public void Draw(Matrix view, Matrix projection)
        {
            for (int i = 0; i < NB_FACE; i++)
            {
                Faces[i].Draw(view, projection);
            }
        }

        public void showFace(int nbFace, Matrix view, Matrix projection)
        {
            this.faces[nbFace].Draw(view, projection);
        }

        /// <summary>
        /// return in the format string all characteristic of the leds in the cube
        /// </summary>
        /// <returns>Leds values with the format "Frame;State;intensity;Color"
        ///                                 ex : "2;true;50;65535</returns>
        public string[, ,] GetCubeState()
        {
            string[, ,] ledStates = new string[8, 8, 8];

            /*foreach (Face face in this.Faces)
            {
                for (int y = 0; y < 8; y++ )
                {
                    for (int x = 0; x < 8; x++)
                    {
                        int inversedX = Math.Abs(x - 7) % 8;

                        ledStates[x, y, face.Id - 1] = "0;" + face.T_Leds[inversedX, y].On.ToString() + ";" +
                                    face.T_Leds[inversedX, y].Brightness.ToString() + ";" +
                                    face.T_Leds[inversedX, y].ledColor.R.ToString() + ";" +
                                    face.T_Leds[inversedX, y].ledColor.G.ToString() + ";" +
                                    face.T_Leds[inversedX, y].ledColor.B.ToString() + ";";
                    }
                }
            }*/

            for (int z = 0; z < this.Faces.Count; z++)
                for (int y = 0; y < 8; y++)
                    for (int x = 0; x < 8; x++)
                    {
                        int inversedZ = Math.Abs(z - 7) % 8;

                        ledStates[y, z, Math.Abs(x - 7)] = "0;" + this.Faces[inversedZ].T_Leds[x, y].On.ToString() + ";" +
                                    this.Faces[inversedZ].T_Leds[x, y].Brightness.ToString() + ";" +
                                    this.Faces[inversedZ].T_Leds[x, y].ledColor.R.ToString() + ";" +
                                    this.Faces[inversedZ].T_Leds[x, y].ledColor.G.ToString() + ";" +
                                    this.Faces[inversedZ].T_Leds[x, y].ledColor.B.ToString() + ";";
                    }

            return ledStates;
        }

        public void ChangeLed(int x, int y, int z)
        {
            this.Faces[z].ChangeLed(x, y);
        }

        public void SelectLed(int x, int y, int z)
        {
            this.Faces[z].SelectLed(x, y);
            // this.Faces[]
        }

        #endregion
    }
}
