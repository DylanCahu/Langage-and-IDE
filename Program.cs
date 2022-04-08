using System;
using System.IO;
using System.Globalization;

namespace readfile
{
    class Test
    {
        //=====================  Syntaxe =========================
        static void Erreur(string instruction, string texte)
        {
            //gestion d'erreurs
            Console.Write(" Erreur "+ instruction +": " + texte);
        }
        static bool estVariable(string token)
        {   //vrai si le token envoyé est une variable (Exemple: A)

            /*
            if (token.Length != 1) return false;
            return (token[0] >= 'A') && (token[0] <= 'Z');//renverra true si la Variable est en MAJ et entre A et Z (soit 26 possibilité de variable)
            */

            try
            {
                if (token.Length != 1) return false;
                return (token[0] >= 'A') && (token[0] <= 'Z');
            }
            catch (Exception)
            {
                return false;
            }
        }
        static bool estNombre(string token)
        {
            bool local = false;
            //vrai si le token envoyé est une constante (Exemple: 123) 
            //return 0 <= Int32.Parse(token, NumberStyles.AllowThousands); //retourne vrai si la trad du string token est un integer
            try
            {
                if (0 <= Int32.Parse(token, NumberStyles.AllowThousands)) local = true; //retourne vrai si la trad du string token est un integer
                return local;
            }
            catch (Exception)
            {
                local = false;
                return local;
            }


        }
        static bool estVariableOuNombre(string token)
        {
            return estVariable(token) || estNombre(token);
        }
        //=====================  Instructions ====================
        static void traiterLet(ref int i, string ligne)
        {
            string variableLET = ExtraireToken(ref i, ligne);
            if (!estVariable(variableLET)) Erreur( "LET", "le paramètre 1 doit etre une variable : " + variableLET + ". ");
            else Console.Write(" variable =  " + variableLET + ", ");

            string contenue = ExtraireToken(ref i, ligne);
            if (!estVariableOuNombre(contenue)) Erreur("LET",  "le paramètre 2 doit etre une variable ou un nombre: " + contenue + ". ");
            else Console.Write(" contenue =  " + contenue + ", ");

            string reste = ExtraireToken(ref i, ligne);
            if (reste != "") Erreur("LET",  "LET ne prend que 2 paramètres : " + reste);

           /* variableLET = contenue;
            Console.Write(" resultat =  " + variableLET);*/
        }
        static void traiterADD(ref int i, string ligne)
        {

            string ADD1 = ExtraireToken(ref i, ligne);
            if (!estVariableOuNombre(ADD1)) Erreur("ADD", "le paramètre 2 doit etre une variable ou un nombre : " + ADD1 + ". ");
            else if (estNombre(ADD1))
            {
                int number1 = Int32.Parse(ADD1, NumberStyles.AllowThousands);
                Console.Write(" ADD1 =  " + number1 + ", ");
            }
            else Console.Write(" ADD1 =  " + ADD1 + ", ");

            string ADD2 = ExtraireToken(ref i, ligne);
            if (!estVariableOuNombre(ADD2)) Erreur("ADD", "le paramètre 2 doit etre une variable ou un nombre : " + ADD2 + ". ");
            else if(estNombre(ADD2))
            {
                int number1 = Int32.Parse(ADD2, NumberStyles.AllowThousands);
                Console.Write(" ADD1 =  " + number1 + ", ");
            }
            else Console.Write(" ADD2 =  " + ADD2 + ", ");

            string variableADD = ExtraireToken(ref i, ligne);
            if (!estVariable(variableADD)) Erreur("ADD", "le paramètre 1 doit etre une variable : " + variableADD + ". ");
            else Console.Write(" variable =  " + variableADD + ", ");

            string reste = ExtraireToken(ref i, ligne);
            if (reste != "") Erreur("ADD", "ADD ne prend que 3 paramètres : " + reste);

            /*int variableINT = number1 + number2;

            string resultat = variableINT.ToString();
            Console.Write(" resultat : "+variableADD+" = "+ resultat);*/
        }
        static void traiterSUB(ref int i, string ligne)
        {

            string SUB1 = ExtraireToken(ref i, ligne);
            if (!estVariableOuNombre(SUB1)) Erreur("SUB", "le paramètre 2 doit etre une variable ou un nombre : " + SUB1 + ". ");
            else if (estNombre(SUB1))
            {
                int number1 = Int32.Parse(SUB1, NumberStyles.AllowThousands);
                Console.Write(" SUB1 =  " + number1 + ", ");
            }
            else Console.Write(" SUB1 =  " + SUB1 + ", ");

            string SUB2 = ExtraireToken(ref i, ligne);
            if (!estVariableOuNombre(SUB2)) Erreur("SUB", "le paramètre 2 doit etre une variable ou un nombre : " + SUB2 + ". ");
            else if (estNombre(SUB2))
            {
                int number1 = Int32.Parse(SUB2, NumberStyles.AllowThousands);
                Console.Write(" SUB1 =  " + number1 + ", ");
            }
            else Console.Write(" SUB2 =  " + SUB2 + ", ");

            string variableSUB = ExtraireToken(ref i, ligne);
            if (!estVariable(variableSUB)) Erreur("SUB", "le paramètre 1 doit etre une variable : " + variableSUB + ". ");
            else Console.Write(" variable =  " + variableSUB + ", ");

            string reste = ExtraireToken(ref i, ligne);
            if (reste != "") Erreur("SUB", "SUB ne prend que 3 paramètres : " + reste);

        }
        static void traiterMUL(ref int i, string ligne)
        {

            string MUL1 = ExtraireToken(ref i, ligne);
            if (!estVariableOuNombre(MUL1)) Erreur("MUL", "le paramètre 2 doit etre une variable ou un nombre : " + MUL1 + ". ");
            else if (estNombre(MUL1))
            {
                int number1 = Int32.Parse(MUL1, NumberStyles.AllowThousands);
                Console.Write(" MUL1 =  " + number1 + ", ");
            }
            else Console.Write(" MUL1 =  " + MUL1 + ", ");

            string MUL2 = ExtraireToken(ref i, ligne);
            if (!estVariableOuNombre(MUL2)) Erreur("MUL", "le paramètre 2 doit etre une variable ou un nombre : " + MUL2 + ". ");
            else if (estNombre(MUL2))
            {
                int number1 = Int32.Parse(MUL2, NumberStyles.AllowThousands);
                Console.Write(" MUL1 =  " + number1 + ", ");
            }
            else Console.Write(" MUL2 =  " + MUL2 + ", ");

            string variableMUL = ExtraireToken(ref i, ligne);
            if (!estVariable(variableMUL)) Erreur("MUL", "le paramètre 1 doit etre une variable : " + variableMUL + ". ");
            else Console.Write(" variable =  " + variableMUL + ", ");

            string reste = ExtraireToken(ref i, ligne);
            if (reste != "") Erreur("MUL", "MUL ne prend que 3 paramètres : " + reste);

        }
        static void traiterDIV(ref int i, string ligne)
        {

            string DIV1 = ExtraireToken(ref i, ligne);
            if (!estVariableOuNombre(DIV1)) Erreur("DIV", "le paramètre 2 doit etre une variable ou un nombre : " + DIV1 + ". ");
            else if (estNombre(DIV1))
            {
                int number1 = Int32.Parse(DIV1, NumberStyles.AllowThousands);
                Console.Write(" DIV1 =  " + number1 + ", ");
            }
            else Console.Write(" DIV1 =  " + DIV1 + ", ");

            string DIV2 = ExtraireToken(ref i, ligne);
            if (!estVariableOuNombre(DIV2)) Erreur("DIV", "le paramètre 2 doit etre une variable ou un nombre : " + DIV2 + ". ");
            else if (estNombre(DIV2))
            {
                int number1 = Int32.Parse(DIV2, NumberStyles.AllowThousands);
                Console.Write(" DIV1 =  " + number1 + ", ");
            }
            else Console.Write(" DIV2 =  " + DIV2 + ", ");

            string variableDIV = ExtraireToken(ref i, ligne);
            if (!estVariable(variableDIV)) Erreur("DIV", "le paramètre 1 doit etre une variable : " + variableDIV + ". ");
            else Console.Write(" variable =  " + variableDIV + ", ");

            string reste = ExtraireToken(ref i, ligne);
            if (reste != "") Erreur("DIV", "DIV ne prend que 3 paramètres : " + reste);

        }
        static void traiterMOD(ref int i, string ligne)
        {

            string MOD1 = ExtraireToken(ref i, ligne);
            if (!estVariableOuNombre(MOD1)) Erreur("MOD", "le paramètre 2 doit etre une variable ou un nombre : " + MOD1 + ". ");
            else if (estNombre(MOD1))
            {
                int number1 = Int32.Parse(MOD1, NumberStyles.AllowThousands);
                Console.Write(" MOD1 =  " + number1 + ", ");
            }
            else Console.Write(" MOD1 =  " + MOD1 + ", ");

            string MOD2 = ExtraireToken(ref i, ligne);
            if (!estVariableOuNombre(MOD2)) Erreur("MOD", "le paramètre 2 doit etre une variable ou un nombre : " + MOD2 + ". ");
            else if (estNombre(MOD2))
            {
                int number1 = Int32.Parse(MOD2, NumberStyles.AllowThousands);
                Console.Write(" MOD1 =  " + number1 + ", ");
            }
            else Console.Write(" MOD2 =  " + MOD2 + ", ");

            string variableMOD = ExtraireToken(ref i, ligne);
            if (!estVariable(variableMOD)) Erreur("MOD", "le paramètre 1 doit etre une variable : " + variableMOD + ". ");
            else Console.Write(" variable =  " + variableMOD + ", ");

            string reste = ExtraireToken(ref i, ligne);
            if (reste != "") Erreur("MOD", "MOD ne prend que 3 paramètres : " + reste);

        }
        //=====================  Traitement du fichier ===========
        static string ExtraireToken(ref int indice, string ligne)
        {
            string token = "";
            int lgn = ligne.Length;

            if (ligne == "") return token;
            if (lgn <= indice) return token;


            while (ligne[indice] <= ' ')
            {
                indice++;
                if (indice >= lgn) return token;
            }

            while (ligne[indice] > ' ')
            {
                token += ligne[indice];
                indice++;
                if (indice >= lgn) return token;
            }

            return token;
        }
        static void traiterFichier(string chemin)
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(chemin);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //on fait traiter la ligne
                    traiterLigne(line);


                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception f)
            {
                Console.WriteLine("Exception: " + f.Message);
            }
            finally
            {
                Console.WriteLine("");
                Console.WriteLine("Fin du traitement.");
            }
        }
        static int cpt = 0;
        static void traiterLigne(string ligne)
        {
            
            int i = 0; //FAUT LA METTRE ICI, PAS EN GLOBAL
            cpt++;
            Console.Write("Ligne N°" + cpt + " :");
            string token = ExtraireToken(ref i, ligne);

            // Console.WriteLine(i);
            switch (token)
            {
                case "LET":

                    traiterLet(ref i, ligne);

                    break;

                case "ADD":

                    traiterADD(ref i, ligne);

                    break;

                case "":
                    //ne renvoi rien si la ligne est vide
                    break;

                default:
                    Erreur("", "L'instruction demandé n'est pas défini : "+ token);
                    break;
            }
            Console.WriteLine("");

        }
        //=====================  Programme principal =============
        public static void Main()
        {

            traiterFichier("P:\\SIO2\\Slam\\C#\\c-sharp\\ExtraireCodeFichier\\code.txt");

            Console.WriteLine(""); Console.WriteLine("Fin du fichier."); Console.ReadLine();
        }
    }
}