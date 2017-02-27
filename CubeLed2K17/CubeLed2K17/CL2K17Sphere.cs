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
    public class CL2K17Sphere
    {
        private const int DEFAULT_BRIGHTNESS = 50;

        private CL2K17SpherePrimitive primitive;

        public Vector3 Position;
        public Vector3 Velocity;
        public Color ledColor;
        private int brightness;

        public int Brightness
        {
            get { return brightness; }
            set
            {
                if (value == 0)
                {
                    On = false;
                }
                else
                {
                    On = true;
                }
                brightness = value;
            }
        }
        public bool On; // state of the led (on/off)
        public float Radius { get; private set; }

        public BoundingSphere Bounds
        {
            get { return new BoundingSphere(Position, Radius); }
        }

        public CL2K17Sphere(GraphicsDevice graphics, float radius, Vector3 position)
        {
            primitive = new CL2K17SpherePrimitive(graphics, radius, 10);
            this.Radius = radius;
            this.ledColor = Color.LightBlue;
            this.Brightness = DEFAULT_BRIGHTNESS;
            this.On = true;
            this.Position = position;
        }

        public void Update(GameTime gameTime)
        {
            //this.Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // calcul la luminosité de la sphère 
            if (On)
            {
                this.ledColor = Color.FromNonPremultiplied((Brightness * 2), (Brightness * 2), (int)(Color.LightBlue.B), Color.LightBlue.A);
            }
            else
            {
                this.ledColor = Color.Black;
            }

        }

        public void Draw(Matrix view, Matrix projection)
        {
            primitive.Draw(Matrix.CreateTranslation(Position), view, projection, ledColor);
        }
    }
}
