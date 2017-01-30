using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeLed
{
    public class Led
    {
        private const int DEFAULT_BRIGHTNESS = 50;

        private SpherePrimitive primitive;
        private int _x;
        private int _y;


        public Vector3 Position;
        public Vector3 Velocity;
        public Color ledColor;
        private int brightness;
        public bool On; // state of the led (on/off)
        private bool _selected = false;

        public float Radius { get; private set; }

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

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public BoundingSphere Bounds
        {
            get { return new BoundingSphere(Position, Radius); }
        }

        public Led(GraphicsDevice graphics, float radius, Vector3 position, int x, int y)
        {
            primitive = new SpherePrimitive(graphics, radius, 10);
            this.Radius = radius;
            this.ledColor = Color.LightBlue;
            this.Brightness = DEFAULT_BRIGHTNESS;
            this.Position = position;
            this.X = x;
            this.Y = y;
        }

        public void Update(GameTime gameTime)
        {
            //this.Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // calcul la luminosité de la sphère 
            if (Selected)
            {
                this.ledColor = Color.Orange;
            }
            else if (On)
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
