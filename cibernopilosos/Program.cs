using System;
using System.Runtime.Versioning;
using System.Windows.Forms;
using cibernopilosos.formularios_de_registro;
using cibernopilosos.formularios;

namespace cibernopilosos
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMenu(true));
        }
    }
}
