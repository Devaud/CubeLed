using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeLed2K17
{
    public class CL2K17Controller
    {
        #region Properties
        public CL2K17MainView MainView { get; set; }
        public CL2K17Viewer3D Viewer3D { get; set; }
        #endregion

        #region Constructor
        public CL2K17Controller(CL2K17MainView pMainView)
        {
            this.MainView = pMainView;
            this.Viewer3D = new CL2K17Viewer3D(this.MainView.getDrawSurface());
            //this.Viewer3D.Run();
        }
        #endregion
    }
}
