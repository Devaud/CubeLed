/* *
 * Projet      : CubeLed2K17
 * Description : GUI for user interaction with the 3D Cube led.
 * Authors     : Devaud Alan, Amado Kevin & Mendez Gregory
 * Date        :
 * Version     : 1.0
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CubeLed2K17
{
    class CL2K17Face
    {
        private const int WIDTH = 8;
        private const int HEIGHT = 8;

        #region Fields
        private CL2K17Led[,] _t_Leds;
        private uint _id;
        #endregion

        #region Properties

        public CL2K17Led[,] T_Leds
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
        public CL2K17Face(GraphicsDevice graphics, float radius, Vector3 position, uint id)
        {
            this.T_Leds = new CL2K17Led[WIDTH, HEIGHT];
            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    this.T_Leds[x, y] = new CL2K17Led(graphics, radius, new Vector3(25 + x * 25, 25 + y * 25, 25 * id));
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
                    this.T_Leds[x, y].Draw(view, projection);
                }            
			}           
        }

        public void ChangeLed(int x, int y)
        {
            //T_Leds[Math.Abs(x - 7), y].On = false;
            //T_Leds[x, y].On = !T_Leds[x, y].On;
            T_Leds[x, y].Brightness = 100;
        }

        public void SelectLed(int x, int y)
        {
            T_Leds[x, y].Selected = true;
        }

        public void UnSelectLed(int x, int y)
        {
            T_Leds[x, y].Selected = false;
        }
    }
}