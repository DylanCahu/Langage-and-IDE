using System;
using System.IO;

namespace readfile
{
    class Test
    {
        static string [] tabline ;
        static int cpt=0;
        static void lire()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("P:\\SIO2\\Slam\\C#\\c-sharp\\readfile\\text.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    cpt++;
                    //write the line to console window
                    Console.WriteLine(cpt+" : "+ line);
                    //Read the next line
                    line = sr.ReadLine();
                    
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception f)
            {
                Console.WriteLine("Exception: " + f.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        static void ecrire()
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("P:\\SIO2\\Slam\\C#\\c-sharp\\readfile\\text.txt");
                //Write a line of text
                sw.WriteLine("Hello World!!");
                //Write a second line of text
                sw.WriteLine("From the StreamWriter class");
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        public static void Main()
        {
            lire();
        }
    }
}

