using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CioUI.Examples.SimpleApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CioApplication app = new CioApplication();
            app.Initialize(RenderMode.WinForms);
            app.Start();
        }
    }
}
