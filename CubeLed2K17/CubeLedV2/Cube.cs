using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeLed
{
    class Cube
    {
        private const int NB_FACE = 8;

        #region Fields
        private List<Face> faces;
        private int[, ,] LedSelected = new int[,,] { { { 0, 0, 0 } } };
        #endregion

        #region Properties

        public List<Face> Faces
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
        public Cube(GraphicsDevice graphics, float radius, Vector3 position)
        {
            this.Faces = new List<Face>();

            for (uint i = 1; i < NB_FACE + 1; i++)
            {
                Faces.Add(new Face(graphics, radius, new Vector3(10, 10, 10), i));
            }
        }

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

        /// <summary>
        /// return in the format string all characteristic of the leds in the cube
        /// </summary>
        /// <returns>Leds values with the format "Frame;State;intensity;Color"
        ///                                 ex : "2;true;50;65535</returns>
        public string[, ,] GetCubeState()
        {
            string[, ,] ledStates = new string[8, 8, 8];

            foreach (Face face in this.Faces)
            {
                for (int y = 8; y > 0; y-- )
                {
                    for (int x = 0; x < 8; x++)
                    {
                        ledStates[x, y, face.Id - 1] = "0;" + face.T_Leds[x,y].On.ToString() + ";" +
                                    face.T_Leds[x, y].Brightness.ToString() + ";" +
                                    face.T_Leds[x, y].ledColor.R.ToString() + ";" +
                                    face.T_Leds[x, y].ledColor.G.ToString() + ";" +
                                    face.T_Leds[x, y].ledColor.B.ToString() + ";";
                    }
                }
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
