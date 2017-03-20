/* *
 * Projet : CubeLed2K17
 * Description : GUI for user interaction with the 3D Cube led.
 * Authors     : Devaud Alan, Amado Kevin & Mendez Gregory
 * Date        :
 * Version 1.0
 */
using System;
using System.Windows.Forms;

namespace CubeLed2K17
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CL2K17MainView form = new CL2K17MainView();
            form.Show();
            CL2K17Viewer3D game = new CL2K17Viewer3D(form.getDrawSurface());
            form.connect(game);
            game.Run();   
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CL2K17MainView());*/
            //Application.Run(form);
        }
    }
}
