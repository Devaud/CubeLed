using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeLed
{
    public class Sphere
    {
        private const int DEFAULT_BRIGHTNESS = 50;

        private SpherePrimitive primitive;

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

        public Sphere(GraphicsDevice graphics, float radius, Vector3 position)
        {
            primitive = new SpherePrimitive(graphics, radius, 10);
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
