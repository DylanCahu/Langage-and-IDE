using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFicherGraphique
{
    static class Program
    {


        static public Variables mesVariables;//nos variables utilisé dans le programme
        static public Form1 form1;
        [STAThread]
        static void Main()
        {


            mesVariables = new Variables();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
            Application.Run(form1);
        }
    }
}
