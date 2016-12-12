using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeLed2K17
{
    class Cube
    {
        #region Fields
        private int nbFace;
        private List<Face> faces;
        #endregion

        #region Properties
        public int NbFace
        {
            get { return this.nbFace; }
            set { this.nbFace = value; }
        }

        public List<Face> Faces
        {
            get { return this.faces; }
            set { this.faces = value; }
        }
        #endregion

        #region Constructor
        public Cube()
        {
            this.NbFace = 8;
            this.Faces = new List<Face>();
        }
        #endregion
    }
}
