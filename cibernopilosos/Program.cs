using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using cibernopilosos.formularios_de_registro;
using cibernopilosos.formularios;

namespace cibernopilosos
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicacisón.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMenu(true));
        }
    }
}
