using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeLed
{
    class Face
    {
        private const int WIDTH = 8;
        private const int HEIGHT = 8;

        #region Fields
        private Sphere[,] _t_Leds;
        #endregion

        #region Properties

        public Sphere[,] T_Leds
        {
            get { return _t_Leds; }
            set { _t_Leds = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="radius">radius of each </param>
        /// <param name="position"></param>
        /// <param name="number"></param>
        public Face(GraphicsDevice graphics, float radius, Vector3 position, int number)
        {
            this.T_Leds = new Sphere[WIDTH, HEIGHT];
            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    this.T_Leds[x, y] = new Sphere(graphics, radius, new Vector3(25 + x * 25, 25 + y * 25, 25 * number));
                }
            }  
        }
        #endregion

        public void Update(GameTime gameTime)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    this.T_Leds[x, y].Update(gameTime);
                }
            }  
        }

        public void Draw(Matrix view, Matrix projection)
        {
            for (int x = 0; x < WIDTH; x++)
			{
                for (int y = 0; y < HEIGHT; y++)
                {
                    this.T_Leds[x,y].Draw(view, projection);
                }            
			}           
        }
    }
}
