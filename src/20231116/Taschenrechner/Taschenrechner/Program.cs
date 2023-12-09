using System;
using System.Windows.Forms;
using Taschenrechner.ControllerTypes;

namespace Taschenrechner
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new CalcForm();

            var controller = new CalculatorController(view);
            view.SetController(controller);

            Application.Run(view);
        }
    }
}
