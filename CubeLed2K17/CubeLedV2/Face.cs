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
        private Led[,] _t_Leds;
        private uint _id;
        #endregion

        #region Properties

        public Led[,] T_Leds
        {
            get { return _t_Leds; }
            set { _t_Leds = value; }
        }

        public uint Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="radius">radius of each </param>
        /// <param name="position"></param>
        /// <param name="id"></param>
        public Face(GraphicsDevice graphics, float radius, Vector3 position, uint id)
        {
            this.T_Leds = new Led[WIDTH, HEIGHT];
            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    this.T_Leds[x, y] = new Led(graphics, radius, new Vector3(25 + x * 25, 25 + y * 25, 25 * id), x, y);
                }
            }

            this.Id = id;
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

        public void ChangeLed(int x, int y)
        {
            T_Leds[Math.Abs(x - 7), y].On = false;
        }

        public void SelectLed(int x, int y)
        {
            T_Leds[Math.Abs(x - 7), y].Selected = true;
        }

        public void UnSelectLed(int x, int y)
        {
            T_Leds[Math.Abs(x - 7), y].Selected = false;
        }
    }
}
