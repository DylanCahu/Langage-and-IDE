using System;
using System.IO;
using System.Globalization;

namespace FichierTexte
{
    class Program
    {
        static public Variables mesVariables;//nos variables utilisé dans le programme
        static string chemin = "P:\\SIO2\\Slam\\C#\\c-sharp\\ExtraireCodeFichier2\\code.txt";

        //=====================  Programme principal =============
        public static void Main()
        {


            mesVariables = new Variables();

            Parser.Compiler(chemin);
            Console.WriteLine("Compiler ok");
            Parser.leProgramme.afficher();
            Console.WriteLine("Afficher ok");
            Parser.leProgramme.executer();
            Console.WriteLine("Executer ok");

            Console.WriteLine(""); Console.WriteLine("Fin du fichier."); Console.ReadLine();
        }
    }
}