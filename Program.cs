using System;
using System.IO;
using System.Windows.Forms;
using Poppel_Order_Processing_System.PresentationLayer;
// ReSharper disable All

namespace Poppel_Order_Processing_System
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PoppelOrderProcessingSystem());
        }
    }
}