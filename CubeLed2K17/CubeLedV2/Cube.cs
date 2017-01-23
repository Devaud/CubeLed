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
        public Cube(GraphicsDevice graphics, float radius, Vector3 position)
        {
            this.Faces = new List<Face>();

            for (int i = 1; i < NB_FACE+1; i++)
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
                Faces[i].Draw(view,projection);
            }
        }


        #endregion
    }
}
