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
                foreach (Led led in face.T_Leds)
                {
                    ledStates[led.X, led.Y, face.Id-1] = led.On.ToString() + ";" + 
                                                        led.Brightness.ToString() + ";" + 
                                                        led.ledColor.R.ToString() + ";" + 
                                                        led.ledColor.G.ToString() + ";" + 
                                                        led.ledColor.B.ToString() + ";";
                }
            }

            return ledStates;
        }

        #endregion
    }
}
