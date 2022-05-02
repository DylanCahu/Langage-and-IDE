using System;
//using System.Collections.Generic;

namespace CodeFicherGraphique
{

	class Variables
    {
		static int[] tabVar;

		public Variables() //constructeur pour allouer le tableau
        {
			tabVar = new int[26];
			init();
		}

		static void init() //remise à 0 des 26 variables.
		{
			for (int i = 0; i < 26; i++)
				tabVar[i] = i+1; //rempli le tableau de 26 case " 0 "
		}

		public void Dump()
		{
			for (int i = 0; i < 26; i++)
			{
				Program.form1.writeln2(tabVar[i] + "  ");
			}
			Console.WriteLine();
		}

		public void setVariable(char NomVar, int Val)
		{
			tabVar[NomVar - 'A'] = Val; //code ascii de notre Variable - code ascii de A soit 65
		}

		public int getVariable(char NomVar)
        {
			int valGet = tabVar[NomVar - 'A'];
			return valGet;
		}

		public bool estVariable(char var)
		{   //vrai si le token envoyé est une variable (Exemple: A)

			try
			{
				return (var >= 'A') && (var <= 'Z');
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	class Bloc
	{
		
		Instruction instruction; //instrcution du noeud
		Bloc suivant; //instruction suivante, ou null
		public Bloc()
        {
			suivant = null;
        }
		public void ajouter(Instruction instruction)
		{
			if (this.suivant == null)
			{
				this.suivant = new Bloc();
				this.instruction = instruction;
			}
			else this.suivant.ajouter(instruction); //appel recursif
		}

		public void afficher()
		{//affiche les instructions du bloc
			Bloc liste = this;

			if (liste.suivant != null)
			{
				instruction.afficher();  //polymorphisme
				this.suivant.afficher(); //appel récursif
			}

		}

		public void executer()
		{//affiche les instructions du bloc
			Bloc liste = this;

			if (liste.suivant != null)
			{
				instruction.executer();  //polymorphisme
				this.suivant.executer(); //appel récursif
			}

		}
	}
	class Instruction
    {
		public virtual void afficher()
		{ 
			Console.WriteLine("afficher: Je ne devrais pas exister. Toi non plus d'ailleur");
		}
		public virtual void executer()
		{
			Console.WriteLine("executer: Je ne devrais pas exister. Toi non plus d'ailleur");
		}
	}

	class Instruction_LET : Instruction
    {
		char variable1;
		int valeur; //soit const

		public Instruction_LET(char var1, int val)
        {
			//this.name = "LET "+var1+" "+val; //bidouille
			this.variable1 = var1;
			this.valeur   = val;
		}

		public override void afficher()
		{
			Program.form1.writeln2("Je suis un LET, je range " + this.valeur + " dans " +this.variable1);
		}

		public override void executer()
        {
			Program.mesVariables.setVariable(this.variable1, this.valeur);
		}
	}

	class Instruction_ADD : Instruction
	{
		char variable1;
		char variable2;
		char variable3;
		

		public Instruction_ADD(char var1, char var2, char var3)
		{
			//this.name = "ADD : " + var2 + " + " + var3 + " => " + var1; //bidouille
			this.variable1	= var1;
			this.variable2	= var2;
			this.variable3	= var3;
		}
		public override void afficher()
		{
			Program.form1.writeln2("Je suis un ADD, j'additionne " + this.variable1 + " et " +this.variable2+" dans "+ this.variable3);
		}
		public override void executer()
		{
			int ADD1 = Program.mesVariables.getVariable(this.variable1);
			int ADD2 = Program.mesVariables.getVariable(this.variable2);
			int Result = ADD1 + ADD2;
			Program.mesVariables.setVariable(this.variable3, Result);
		}
	}

	class Instruction_MOD : Instruction
	{
		char variable1;
		char variable2;
		char variable3;


		public Instruction_MOD(char var1, char var2, char var3)
		{
			//this.name = "MOD : " + var2 + " + " + var3 + " => " + var1; //bidouille
			this.variable1 = var1;
			this.variable2 = var2;
			this.variable3 = var3;
		}
		public override void afficher()
		{
			Program.form1.writeln2("Je suis un MOD, je modulo " + this.variable1 + " et " + this.variable2 + " dans " + this.variable3);
		}
		public override void executer()
		{
			int MOD1 = Program.mesVariables.getVariable(this.variable1);
			int MOD2 = Program.mesVariables.getVariable(this.variable2);
			int Result = MOD1 % MOD2;
			Program.mesVariables.setVariable(this.variable3, Result);
		}
	}

	class Instruction_DIV : Instruction
	{
		char variable1;
		char variable2;
		char variable3;


		public Instruction_DIV(char var1, char var2, char var3)
		{
			//this.name = "DIV : " + var2 + " + " + var3 + " => " + var1; //bidouille
			this.variable1 = var1;
			this.variable2 = var2;
			this.variable3 = var3;
		}
		public override void afficher()
		{
			Program.form1.writeln2("Je suis un DIV, je divise " + this.variable1 + " et " + this.variable2 + " dans " + this.variable3);
		}
		public override void executer()
		{
			int DIV1 = Program.mesVariables.getVariable(this.variable1);
			int DIV2 = Program.mesVariables.getVariable(this.variable2);
			int Result = DIV1 / DIV2;
			Program.mesVariables.setVariable(this.variable3, Result);
		}
	}

	class Instruction_INC : Instruction
	{
		char variable1;


		public Instruction_INC(char var1)
		{
			this.variable1 = var1;
		}
		public override void afficher()
		{
			Program.form1.writeln2("Je suis un INC, j'incrémente " + this.variable1 + " à 1");
		}
		public override void executer()
		{
			int INC1 = Program.mesVariables.getVariable(this.variable1);
			int Result = INC1 + 1;
			Program.mesVariables.setVariable(this.variable1, Result);
		}
	}

	class Instruction_WRITE : Instruction
	{
		char variable1;
		public Instruction_WRITE(char var1)
		{
			this.variable1 = var1;
		}
		public override void afficher()
		{
			Program.form1.writeln2("Je suis un WRITE qui montre : "+this.variable1);
		}
		public override void executer()
		{
			int valeur = Program.mesVariables.getVariable(this.variable1);
			Program.form1.writeln2(" "+valeur);
		}
	}

	class Instruction_IF : Instruction
	{
		char variable1, variable2; //les deux valeurs
		int comparateur; //le comparateur ( 1:"=" 2:"!=" 3:">" 4:"<" 5:">=" 6:"<=" )
		Bloc blocAlors; //Bloc à executer
		public Instruction_IF(char var1, char var2, int comparateur, Bloc blocAlors)
		{
			this.variable1 = var1;
			this.variable2 = var2;
			this.comparateur = comparateur;
			this.blocAlors = blocAlors;
		}
		public override void afficher()
		{
			Program.form1.writeln2("Je suis un IF qui vérifie : " + this.variable1+ " "+ this.comparateur + " "+this.variable2);
			blocAlors.afficher();
		}

		public override void executer()
		{
			bool condition=false;
			int val1 = Program.mesVariables.getVariable(this.variable1);
			int val2 = Program.mesVariables.getVariable(this.variable2);
			switch (this.comparateur)
			{
				case 1:
					condition = val1 == val2;
					break;

				case 2:
					condition = val1 != val2;
					break;

				case 3:
					condition = val1 > val2;
					break;

				case 4:
					condition = val1 < val2;
					break;

				case 5:
					condition = val1 >= val2;
					break;

				case 6:
					condition = val1 <= val2;
					break;
			}
			if (condition == true)
			{
				blocAlors.executer();
			}		
		}
	}

	class Instruction_WHILE : Instruction
	{
		string variable1, variable2; //les deux valeurs
		int comparateur; //le comparateur ( 1:"=" 2:"!=" 3:">" 4:"<" 5:">=" 6:"<=" )
		Bloc blocAlors; //Bloc à executer
		string CompaString;
		public Instruction_WHILE(string var1, string var2, int comparateur, Bloc blocAlors)
		{
			this.variable1 = var1;
			this.variable2 = var2;
			this.comparateur = comparateur;
			this.blocAlors = blocAlors;
		}

		public override void afficher()
		{
			switch (this.comparateur)
			{
				case 1:
					CompaString="=";
					break;

				case 2:
					CompaString = "!=";
					break;

				case 3:
					CompaString = ">";
					break;

				case 4:
					CompaString = "<";
					break;

				case 5:
					CompaString = ">=";
					break;

				case 6:
					CompaString = "<=";
					break;
			}
			Program.form1.writeln2("Je suis un WHILE qui vérifie : " + this.variable1 + " " + this.CompaString + " " + this.variable2);
			blocAlors.afficher();
		}

		public override void executer()
		{
			bool condition = true;
			
			while (condition)
			{
				int val1;
				if (Program.mesVariables.estVariable(this.variable1[0]))
				{
					val1 = Program.mesVariables.getVariable(this.variable1[0]);
				}
				else
                {
					val1 = Int32.Parse(this.variable1);

				}
				int val2;
				if (Program.mesVariables.estVariable(this.variable2[0]))
				{
					val2 = Program.mesVariables.getVariable(this.variable2[0]);
				}
				else
				{
					val2 = Int32.Parse(this.variable2);

				}
				switch (this.comparateur)
				{
					case 1:
						condition = val1 == val2;
						break;

					case 2:
						condition = val1 != val2;
						break;

					case 3:
						condition = val1 > val2;
						break;

					case 4:
						condition = val1 < val2;
						break;

					case 5:
						condition = val1 >= val2;
						break;

					case 6:
						condition = val1 <= val2;
						break;
				}
				if (condition == true)
				{
					blocAlors.executer();
				}
			}
		}
	}
}
