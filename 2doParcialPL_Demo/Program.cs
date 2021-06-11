using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2doParcialPL_Demo
{
	class Program
	{ 
		static void Main(string[] args)
		{
			string[,] instruments = CargarInstruments();
			int[,] pricestock = CargarPreciosStock();
			string[] clasificacion = { "Marca", "Modelo", "SubModelo", "Precio", "Stock"};
			do
				ShowMenu();
            while (Options(instruments, pricestock, clasificacion) != 5);
		}
		static int Options(string[,] instruments, int[,] pricestock, string[] clasificacion)
		{
			int op;
			int.TryParse(Console.ReadLine(), out op);

			switch (op)
			{
				case 1:
					Console.Clear();
					Console.WriteLine("Entro a 1 - ListProducts");
					ListProducts(instruments, pricestock, clasificacion);
					break;
				case 2:
					Console.Clear();
					Console.WriteLine("Entro a 2 - AddProducts");
					AddProducts(instruments, pricestock);
					break;
				case 3:
					Console.Clear();
					Console.WriteLine("Entro a 3 - DeleteProducts");
					break;
				case 4:
					Console.Clear();
					Console.WriteLine("Entro a 4 - PriceCalculator");
					break;
				case 5:
					Console.Clear();
					Exit(op);
					break;

				default:
					Console.WriteLine("Error default");
					Console.ReadKey();
					break;
			}
			return op;
		}
		static void ShowMenu()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("╔═════════════════════════════════════╗");
			Console.WriteLine("║    Casa de Musica - Do Sostenido    ║");
			Console.WriteLine("║    1) Lista de productos            ║");
			Console.WriteLine("║    2) Agregar productos             ║");
			Console.WriteLine("║    3) Eliminar productos            ║");
			Console.WriteLine("║    4) Calculadora de precios        ║");
			Console.WriteLine("║    5) Salir                         ║");
			Console.WriteLine("╚═════════════════════════════════════╝");
			Console.ResetColor();
		}
		static int ValInt()
		{
			int num;
			string val;

			bool conv = int.TryParse(Console.ReadLine().Trim(), out num);

			while (!conv)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error! ingrese un dato correcto:");
				Console.ResetColor();
				conv = int.TryParse(Console.ReadLine().Trim(), out num);
			}

			Console.WriteLine($"ingreso '{num}' ¿es correcto? s/n");
			val = Console.ReadLine();

			while (val == "n")
			{
				Console.WriteLine("Vuelva a ingresar el dato:");
				int.TryParse(Console.ReadLine().Trim(), out num);
				Console.WriteLine($"ingreso '{num}' ¿es correcto? s/n");
				val = Console.ReadLine().Trim().ToLower();
			}
			while (val.Any(char.IsDigit) || string.IsNullOrEmpty(val))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error Ingrese s/n");
				Console.ResetColor();
				val = Console.ReadLine().Trim().ToLower();
			}
			if (val == "s")
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("El dato se cargo con exito!");
				Console.ResetColor();
			}
			return num;
		}
		static string ValStr()
		{
			string str;
			string val;

			str = Console.ReadLine().Trim();

			while (str.Any(char.IsDigit) || string.IsNullOrEmpty(str))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error! ingrese un dato correcto:");
				Console.ResetColor();
				str = Console.ReadLine().Trim();
			}

			Console.WriteLine($"ingreso '{str}' ¿es correcto? s/n");
			val = Console.ReadLine();

			while (val == "n")
			{
				Console.WriteLine("Vuelva a ingresar el dato:");
				str = Console.ReadLine().Trim();
				Console.WriteLine($"ingreso '{str}' ¿es correcto? s/n");
				val = Console.ReadLine().Trim().ToLower();
			}
			while (val.Any(char.IsDigit) || string.IsNullOrEmpty(val))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error Ingrese s/n");
				Console.ResetColor();
				val = Console.ReadLine().Trim().ToLower();
			}
			if (val == "s")
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("El dato se cargo con exito!");
				Console.ReadKey();
				Console.ResetColor();
			}
			return str;
		}
		static int Exit(int op)
		{
			string val;
			Console.WriteLine("¿Esta seguro que desea salir? s/n");
			val = Console.ReadLine().Trim().ToLower();
			if (val == "s")
			{
				op = 5;
			}
			if (val == "n")
			{
				op = 0;
			}
			return op;
		}
		static void AddProducts(string[,] instruments, int[,] pricestock)
		{
            for (int fi = 0; fi < instruments.GetLength(0); fi++)
            {
                if (string.IsNullOrEmpty(instruments[fi, 0]))
                {
                    for (int ci = 0; ci < instruments.GetLength(1); ci++)
                    {
                        switch (ci)
                        {
							case 0:
								Console.Clear();
								Console.WriteLine("Ingrese Marca");
								instruments[fi, ci] = ValStr();
								break;
							case 1:
								Console.Clear();
								Console.WriteLine("Ingrese Modelo");
								instruments[fi, ci] = ValStr();
								break;
							case 2:
								Console.Clear();
								Console.WriteLine("Ingrese Submodelo");
								instruments[fi, ci] = ValStr();
								break;
						}
                    }
					break;
                }
            }
			for (int fp = 0; fp < pricestock.GetLength(0); fp++)
			{
				if (pricestock[fp, 0] == 0)
				{
					for (int cp = 0; cp < instruments.GetLength(1); cp++)
					{
						switch (cp)
						{
							case 0:
								Console.Clear();
								Console.WriteLine("Ingrese Precio");
								pricestock[fp, cp] = ValInt();
								break;
							case 1:
								Console.Clear();
								Console.WriteLine("Ingrese Stock");
								pricestock[fp, cp] = ValInt();
								break;
						}
					}
					break;
				}
			}
		}
		static void ListProducts(string[,] instruments, int[,] pricestock, string[] clasificacion)
		{
            for (int i = 0; i < clasificacion.Length; i++)
            {
				Console.BackgroundColor = ConsoleColor.DarkCyan;
				Console.Write($"|{clasificacion[i],-15}");
				Console.ResetColor();
			}
			Console.WriteLine();
			for (int fI = 0; fI < instruments.GetLength(0); fI++)
			{
				Console.Write("|");
				for (int cI = 0; cI < instruments.GetLength(1); cI++)
				{
					Console.Write($"{instruments[fI, cI],-15}|");
				}
				for (int cP = 0; cP < pricestock.GetLength(1); cP++)
				{
					Console.Write($"{pricestock[fI, cP],-15}|");
				}
				Console.WriteLine();
			}			
		Console.ReadKey();
		}
		static string[,] CargarInstruments()
        {
			string[,] aux = new string[10, 3]
			{
				{ "Gibson", "Les Paul", "Studio 2013"},
				{ "Epiphone", "SG", "G-310"},
				{  null, null, null},
				{ "Washburn", "KC44V", "FloydRose"},
				{  null, null, null},
				{ "SX", "Les Paul", "Black"},
				{ "Rockman", "Stratocaster", "2009"},
				{ "Dean", "Dave Mustaine", "VMNTX"},
				{ null, null, null},
				{ "Squier", "Telecaster", "Custom"}
			};
			return aux;
        }
		static int[,] CargarPreciosStock()
		{
			int[,] aux = new int[10, 2]
			{
				{ 1050, 5},
				{ 365, 20},
				{ 0, 0},
				{ 420, 2},
				{ 0, 0},
				{ 260, 10},
				{ 200, 15},
				{ 890, 8},
				{ 0, 0},
				{ 500, 18}
			};
			return aux;
		}





	} 
}


