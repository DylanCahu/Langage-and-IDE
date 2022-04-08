using System;
using System.IO;
using System.Globalization;


namespace CodeFicherGraphique
{
    //Classe abstraite servant de bibliothèque de méthodes. Abstract empêche de créer un objet
    abstract class Parser
    {

        static public Bloc leProgramme; //le programme à construire
        static public Bloc leBlocEnCours; //le programme en cours d'execution
        static StreamReader FichierEntree;//le fichier à analyser
        static int cpt = 0;
        static int PosLecture; //indice de position de lecture de la ligne en cours
        static string LigneLecture; //dernière ligne lue du fichier d'entré
        //=====================  Syntaxe =========================
        /*static void Erreur(string instruction, string texte)
        {
            //gestion d'erreurs
            Console.Write(" Erreur " + instruction + ": " + texte);
        }*/ //TEMPO
        static void Erreur(string texte)
        {
            //gestion d'erreurs
            Console.Write(" Erreur " + texte);
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
        static void traiterLet(string ligne)
        {
            string variableLET = ExtraireToken();
            if (!estVariable(variableLET)) ; //Erreur("LET", "le paramètre 1 doit etre une variable : " + variableLET + ". ");
            else Console.Write(" variable =  " + variableLET + ", ");
            //---------------------------------------------------------------
            string contenue = ExtraireToken();
            if (!estNombre(contenue)) ;//Erreur("LET", "le paramètre 2 doit etre une variable ou un nombre: " + contenue + ". ");
                                       //tempo en estNombre, devra etre remis en VariableOuNombre
            else Console.Write(" contenue =  " + contenue + ", ");
            //---------------------------------------------------------------
            string reste = ExtraireToken();
            if (reste != "") ;//Erreur("LET", "LET ne prend que 2 paramètres : " + reste);
                              //---------------------------------------------------------------
            Instruction_LET instructionLet = new Instruction_LET(variableLET[0], Int32.Parse(contenue));
            //le variableLET[0] renvoi la première valeur du string, ici il n'y en a qu'une donc ça
            //"traduit" un string en char.
            leBlocEnCours.ajouter(instructionLet);//ajouter dans le programme
        }
        static void traiterADD(string ligne)
        {

            string ADD1 = ExtraireToken();
            if (!estVariable(ADD1)) Erreur("le paramètre 1 doit etre une variable ou un nombre : " + ADD1 + ". ");
            else if (estNombre(ADD1))
            {
                int number1 = Int32.Parse(ADD1, NumberStyles.AllowThousands);
                Console.Write("ADD1 =  " + number1 + ", ");
            }
            else Console.Write("ADD1 =  " + ADD1 + ", ");
            //---------------------------------------------------------------
            string ADD2 = ExtraireToken();
            if (!estVariable(ADD2)) Erreur("le paramètre 2 doit etre une variable ou un nombre : " + ADD2 + ". ");
            else if (estNombre(ADD2))
            {
                int number1 = Int32.Parse(ADD2, NumberStyles.AllowThousands);
                Console.Write("ADD2 =  " + number1 + ", ");
            }
            else Console.Write("ADD2 =  " + ADD2 + ", ");
            //---------------------------------------------------------------
            string variableADD = ExtraireToken();
            if (!estVariable(variableADD)) Erreur("ADD le paramètre 3 doit etre une variable : " + variableADD + ". ");
            else Console.Write(" variable =  " + variableADD + ", ");
            //---------------------------------------------------------------
            string reste = ExtraireToken();
            if (reste != "") Erreur("ADD ne prend que 3 paramètres : " + reste);
            //---------------------------------------------------------------


            Instruction_ADD instructionADD = new Instruction_ADD(ADD1[0], ADD2[0], variableADD[0]);
            //le variableLET[0] renvoi la première valeur du string, ici il n'y en a qu'une donc ça
            //"traduit" un string en char.
            leBlocEnCours.ajouter(instructionADD);//ajouter dans le programme*/
        }
        static void traiterDIV(string ligne)
        {

            string DIV1 = ExtraireToken();
            if (!estVariable(DIV1)) Erreur("le paramètre 1 doit etre une variable ou un nombre : " + DIV1 + ". ");
            else if (estNombre(DIV1))
            {
                int number1 = Int32.Parse(DIV1, NumberStyles.AllowThousands);
                Console.Write("DIV1 =  " + number1 + ", ");
            }
            else Console.Write("DIV1 =  " + DIV1 + ", ");
            //---------------------------------------------------------------
            string DIV2 = ExtraireToken();
            if (!estVariable(DIV2)) Erreur("le paramètre 2 doit etre une variable ou un nombre : " + DIV2 + ". ");
            else if (estNombre(DIV2))
            {
                int number1 = Int32.Parse(DIV2, NumberStyles.AllowThousands);
                Console.Write("DIV2 =  " + number1 + ", ");
            }
            else Console.Write("DIV2 =  " + DIV2 + ", ");
            //---------------------------------------------------------------
            string variableDIV = ExtraireToken();
            if (!estVariable(variableDIV)) Erreur("DIV le paramètre 3 doit etre une variable : " + variableDIV + ". ");
            else Console.Write(" variable =  " + variableDIV + ", ");
            //---------------------------------------------------------------
            string reste = ExtraireToken();
            if (reste != "") Erreur("DIV ne prend que 3 paramètres : " + reste);
            //---------------------------------------------------------------


            Instruction_DIV instructionDIV = new Instruction_DIV(DIV1[0], DIV2[0], variableDIV[0]);
            //le variableLET[0] renvoi la première valeur du string, ici il n'y en a qu'une donc ça
            //"traduit" un string en char.
            leBlocEnCours.ajouter(instructionDIV);//ajouter dans le programme*/
        }
        static void traiterMOD(string ligne)
        {

            string MOD1 = ExtraireToken();
            if (!estVariable(MOD1)) Erreur("le paramètre 1 doit etre une variable ou un nombre : " + MOD1 + ". ");
            else if (estNombre(MOD1))
            {
                int number1 = Int32.Parse(MOD1, NumberStyles.AllowThousands);
                Console.Write("MOD1 =  " + number1 + ", ");
            }
            else Console.Write("MOD1 =  " + MOD1 + ", ");
            //---------------------------------------------------------------
            string MOD2 = ExtraireToken();
            if (!estVariable(MOD2)) Erreur("le paramètre 2 doit etre une variable ou un nombre : " + MOD2 + ". ");
            else if (estNombre(MOD2))
            {
                int number1 = Int32.Parse(MOD2, NumberStyles.AllowThousands);
                Console.Write("MOD2 =  " + number1 + ", ");
            }
            else Console.Write("MOD2 =  " + MOD2 + ", ");
            //---------------------------------------------------------------
            string variableMOD = ExtraireToken();
            if (!estVariable(variableMOD)) Erreur("MOD le paramètre 3 doit etre une variable : " + variableMOD + ". ");
            else Console.Write(" variable =  " + variableMOD + ", ");
            //---------------------------------------------------------------
            string reste = ExtraireToken();
            if (reste != "") Erreur("MOD ne prend que 3 paramètres : " + reste);
            //---------------------------------------------------------------


            Instruction_MOD instructionMOD = new Instruction_MOD(MOD1[0], MOD2[0], variableMOD[0]);
            //le variableLET[0] renvoi la première valeur du string, ici il n'y en a qu'une donc ça
            //"traduit" un string en char.
            leBlocEnCours.ajouter(instructionMOD);//ajouter dans le programme*/
        }
        static void traiterINC(string ligne)
        {

            string INC1 = ExtraireToken();
            if (!estVariable(INC1)) Erreur("le paramètre 1 doit etre une variable : " + INC1 + ". ");
            else Console.Write("INC1 =  " + INC1 + ", ");
            //---------------------------------------------------------------
            string reste = ExtraireToken();
            if (reste != "") Erreur("INC ne prend qu'un paramètre : " + reste);
            //---------------------------------------------------------------


            Instruction_INC instructionINC = new Instruction_INC(INC1[0]);
            //le INC1[0] renvoi la première valeur du string, ici il n'y en a qu'une donc ça
            //"traduit" un string en char.
            leBlocEnCours.ajouter(instructionINC);//ajouter dans le programme*/
        }
        static void traiterIF(string ligne)
        {

            string IF1 = ExtraireToken();
            if (!estVariable(IF1)) Erreur("le paramètre 1 doit etre une variable ou un nombre : " + IF1 + ". ");
            else if (estNombre(IF1))
            {
                int number1 = Int32.Parse(IF1, NumberStyles.AllowThousands);
                Console.Write("IF1 =  " + number1 + ", ");
            }
            else Console.Write("IF1 =  " + IF1 + ", ");
            //---------------------------------------------------------------
            int CompaIFInt = 0;
            string CompaIF = ExtraireToken();
            switch (CompaIF)
            {

                case "==":
                    CompaIFInt = 1;
                    break;

                case "!=":
                    CompaIFInt = 2;
                    break;

                case ">":
                    CompaIFInt = 3;
                    break;

                case "<":
                    CompaIFInt = 4;
                    break;

                case ">=":
                    CompaIFInt = 5;
                    break;

                case "<=":
                    CompaIFInt = 6;
                    break;
                default:
                    Console.WriteLine("Le comparateur est incorect :" + CompaIF);
                    break;
            }
            Console.Write("CompaIF =  " + CompaIF + ", "); //(1:"==" 2:"<>" 3:">" 4:"<" 5:">=" 6:"<=")
            //---------------------------------------------------------------
            string IF2 = ExtraireToken();
            if (!estVariable(IF2)) Erreur("IF le paramètre 3 doit etre une variable : " + IF2 + ". ");
            else Console.Write(" variable =  " + IF2 + ", ");
            //---------------------------------------------------------------
            string reste = ExtraireToken();
            if (reste != "") Erreur("IF ne prend que 3 paramètres : " + reste);
            //---------------------------------------------------------------
            //lire le bloc du if
            Bloc blocIF = LireBloc();
            //construire l'instruction
            Instruction_IF instructionIF = new Instruction_IF(IF1[0], IF2[0], CompaIFInt, blocIF);
            leBlocEnCours.ajouter(instructionIF);//ajouter dans le programme*/
        }
        static void traiterWHILE(string ligne)
        {

            string WHILE1 = ExtraireToken();
            if (!estVariable(WHILE1) && !estNombre(WHILE1)) Erreur("le paramètre 1 doit etre une variable ou un nombre : " + WHILE1 + ". ");
            else if (estNombre(WHILE1))
            {
                int number1 = Int32.Parse(WHILE1, NumberStyles.AllowThousands);
                Console.Write("WHILE1 =  " + number1 + ", ");
            }
            else Console.Write("WHILE1 =  " + WHILE1 + ", ");
            //---------------------------------------------------------------
            int CompaWHILEInt = 0;
            string CompaWHILE = ExtraireToken();
            //estCompa(CompaWHILE);
            switch (CompaWHILE)
            {
                case "==":
                    CompaWHILEInt = 1;
                    break;

                case "!=":
                    CompaWHILEInt = 2;
                    break;

                case ">":
                    CompaWHILEInt = 3;
                    break;

                case "<":
                    CompaWHILEInt = 4;
                    break;

                case ">=":
                    CompaWHILEInt = 5;
                    break;

                case "<=":
                    CompaWHILEInt = 6;
                    break;
                default:
                    Console.WriteLine("Le comparateur est incorect :" + CompaWHILE);
                    break;
            }
            Console.Write("CompaWHILE =  " + CompaWHILE + ", "); //(1:"==" 2:"<>" 3:">" 4:"<" 5:">=" 6:"<=")
            //---------------------------------------------------------------
            string WHILE2 = ExtraireToken();
            if (!estVariable(WHILE2) && !estNombre(WHILE2)) Erreur("le paramètre 2 doit etre une variable ou un nombre : " + WHILE2 + ". ");
            else if (estNombre(WHILE2))
            {
                int number1 = Int32.Parse(WHILE2, NumberStyles.AllowThousands);
                Console.Write("WHILE2 =  " + number1 + ", ");
            }
            else Console.Write("WHILE2 =  " + WHILE2 + ", ");
            //---------------------------------------------------------------
            string reste = ExtraireToken();
            if (reste != "") Erreur("WHILE ne prend que 3 paramètres : " + reste);
            //---------------------------------------------------------------
            //lire le bloc du WHILE
            Bloc blocWHILE = LireBloc();
            //construire l'instruction
            Instruction_WHILE instructionWHILE = new Instruction_WHILE(WHILE1, WHILE2, CompaWHILEInt, blocWHILE);
            leBlocEnCours.ajouter(instructionWHILE);//ajouter dans l'exécution
        }
        /*static void traiterINSTRUCT(ref int i, string ligne, string INSTRUCT)
        {

            string INSTRUCT1 = ExtraireToken();
            if (!estVariable(INSTRUCT1)) Erreur(INSTRUCT, "le paramètre 1 doit etre une variable ou un nombre : " + INSTRUCT1 + ". ");
            else if (estNombre(INSTRUCT1))
            {
                int number1 = Int32.Parse(INSTRUCT1, NumberStyles.AllowThousands);
                Console.Write(INSTRUCT + "1 =  " + number1 + ", ");
            }
            else Console.Write(INSTRUCT +"1 =  " + INSTRUCT1 + ", ");
            //---------------------------------------------------------------
            string INSTRUCT2 = ExtraireToken();
            if (!estVariable(INSTRUCT2)) Erreur(INSTRUCT, "le paramètre 2 doit etre une variable ou un nombre : " + INSTRUCT2 + ". ");
            else if (estNombre(INSTRUCT2))
            {
                int number1 = Int32.Parse(INSTRUCT2, NumberStyles.AllowThousands);
                Console.Write(INSTRUCT + "2 =  " + number1 + ", ");
            }
            else Console.Write(INSTRUCT + "2 =  " + INSTRUCT2 + ", ");
            //---------------------------------------------------------------
            string variableINSTRUCT = ExtraireToken();
            if (!estVariable(variableINSTRUCT)) Erreur(INSTRUCT, "le paramètre 3 doit etre une variable : " + variableINSTRUCT + ". ");
            else Console.Write(" variable =  " + variableINSTRUCT + ", ");
            //---------------------------------------------------------------
            string reste = ExtraireToken();
            if (reste != "") Erreur(INSTRUCT , INSTRUCT + "ne prend que 3 paramètres : " + reste);
            //---------------------------------------------------------------


            Instruction_LET instructionLet = new Instruction_I(INSTRUCT1[0], INSTRUCT2[0], INSTRUCT3[0]);
            //le variableLET[0] renvoi la première valeur du string, ici il n'y en a qu'une donc ça
            //"traduit" un string en char.
            leProgramme.ajouter(instructionLet);//ajouter dans le programme
        }*/
        static void traiterWrite(string ligne)
        {
            string WRITE = ExtraireToken();
            if (!estVariable(WRITE)) Erreur("le paramètre 1 doit etre une variable ou un nombre : " + WRITE + ". ");
            else if (estNombre(WRITE))
            {
                int number1 = Int32.Parse(WRITE, NumberStyles.AllowThousands);
                Console.Write("WRITE =  " + number1 + ", ");
            }
            else Console.Write("WRITE =  " + WRITE + ", ");
            Instruction_WRITE instructionWRITE = new Instruction_WRITE(WRITE[0]);
            leBlocEnCours.ajouter(instructionWRITE);//ajouter dans le programme*/
        }
        //=====================  Traitement du fichier ===========
        static string ExtraireToken()
        {
            string token = "";
            int lgn = LigneLecture.Length;

            if (LigneLecture == "") return token;
            if (lgn <= PosLecture) return token;


            while (LigneLecture[PosLecture] <= ' ')
            {
                PosLecture++;
                if (PosLecture >= lgn) return token;
            }

            while (LigneLecture[PosLecture] > ' ')
            {
                token += LigneLecture[PosLecture];
                PosLecture++;
                if (PosLecture >= lgn) return token;
            }

            return token;
        }
        static public void Compiler(string chemin)
        {//compiler le fichier texte en arbre de programme
         // String line;
            leProgramme = new Bloc();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                FichierEntree = new StreamReader(chemin);

                //Lecture du bloc 
                leProgramme = LireBloc();

                /*
                //Read the first line of text
                line = FichierEntree.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //on fait traiter la ligne
                    traiterLigne(line);

                    //Read the next line
                    line = FichierEntree.ReadLine();
                }*/

                //close the file
                FichierEntree.Close();
            }
            catch (Exception f)
            {
                Console.WriteLine("Exception: " + f.Message);
            }
            finally
            {
                Console.WriteLine("");
                Console.WriteLine("Fin du traitement.");
                Console.WriteLine("");
            }
        }
        static void traiterLigne()
        {

            cpt++;
            Console.Write("Ligne N°" + cpt + " :");
            string token = ExtraireToken();

            // Console.WriteLine(i);
            switch (token)
            {
                case "//":
                    //Je te fais un dessin ?

                    break;

                case "LET":

                    traiterLet(LigneLecture);

                    break;

                case "MOD":

                    traiterMOD(LigneLecture);

                    break;


                case "DIV":

                    traiterDIV(LigneLecture);

                    break;

                case "ADD":

                    traiterADD(LigneLecture);

                    break;

                case "INC":

                    traiterINC(LigneLecture);

                    break;

                case "IF":

                    traiterIF(LigneLecture);

                    break;

                case "WHILE":

                    traiterWHILE(LigneLecture);

                    break;

                case "WRITE":

                    traiterWrite(LigneLecture);

                    break;

                case "":
                    //ne renvoi rien si la ligne est vide
                    break;

                case "NL":

                    Console.WriteLine("");

                    break;

                default:
                    Erreur("L'instruction demandé n'est pas défini : " + token);
                    break;
            }
            Console.WriteLine("");
        }
        static Bloc LireBloc()
        {
            //lire et vérifier le Begin puis créer un liste d'instruction et la renvoyer
            Bloc ancienBloc = leBlocEnCours;
            leBlocEnCours = new Bloc();

            lireLigne();
            string token1 = ExtraireToken();
            if (token1 != "Begin") Erreur("Begin manquant");

            lireLigne();
            token1 = ExtraireToken();
            while (token1 != "End")
            {
                PosLecture = 0;//repartir à 0 dans la lecture de la ligne 
                traiterLigne();
                lireLigne();
                token1 = ExtraireToken();
            }
            //Bidouille pour appeler lirebloc dans lirebloc (ex: si imbriquer)
            //C'est pour pouvoir remonter au bloc principal après le bloc d'un if ou autre
            Bloc nouveauBloc = leBlocEnCours;
            leBlocEnCours = ancienBloc;
            return nouveauBloc;
        }
        static void lireLigne()
        {
            PosLecture = 0;
            LigneLecture = FichierEntree.ReadLine();
            //return FichierEntree.ReadLine();
        }
    }
}
