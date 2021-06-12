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

			MainMenu(instruments, pricestock, clasificacion);     
		}
		static void MainMenu(string[,] instruments, int[,] pricestock, string[] clasificacion)
		{
			do
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("╔═════════════════════════════════════╗");
				Console.WriteLine("║    Casa de Musica - Do Sostenido    ║");
				Console.WriteLine("║                                     ║");
				Console.WriteLine("║    1) Lista de productos            ║");
				Console.WriteLine("║    2) Modificar registros           ║");
				Console.WriteLine("║    3) Calculadora de precios        ║");
				Console.WriteLine("║                                     ║");
				Console.WriteLine("║    9) Salir                         ║");
				Console.WriteLine("╚═════════════════════════════════════╝");
				Console.ResetColor();
			} while (ControlApp(instruments, pricestock, clasificacion) != 9);
		}
		static int ControlApp(string[,] instruments, int[,] pricestock, string[] clasificacion)
		{
			int op;
			int.TryParse(Console.ReadLine(), out op);

			switch (op)
			{
				case 1:
					Console.Clear();
					ListProducts(instruments, pricestock, clasificacion);
					break;
				case 2 :
					Console.Clear();
					Console.WriteLine("Entro a 4 - EditProducts");
					EditProductsMenu(instruments, pricestock, clasificacion);
					break;
				case 3:
					Console.Clear();
					Console.WriteLine("Entro a 4 - PriceCalculator");
					break;
				case 9:
					Console.Clear();
					Exit(op);
					break;

				default:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Error! Ingrese una opcion correcta.");
					Console.ResetColor();
					Console.ReadKey();
					break;
			}
			return op;
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
		static void EditProductsMenu(string[,] instruments, int[,] pricestock, string[] clasificacion)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("╔═════════════════════════════════════╗");
			Console.WriteLine("║    Casa de Musica - Do Sostenido    ║");
			Console.WriteLine("║        *Modificar Registros*        ║");
			Console.WriteLine("║                                     ║");
			Console.WriteLine("║    1) Agregar productos             ║");
			Console.WriteLine("║    2) Eliminar productos            ║");
			Console.WriteLine("║    3) Modificar productos           ║");
			Console.WriteLine("║                                     ║");
			Console.WriteLine("║    8) Volver                        ║");
			Console.WriteLine("╚═════════════════════════════════════╝");
			Console.ResetColor();
			ControlEditProducts(instruments, pricestock, clasificacion);
		}
		static int ControlEditProducts(string[,] instruments, int[,] pricestock, string[] clasificacion)
		{
			int op;
			int.TryParse(Console.ReadLine(), out op);

			switch (op)
			{
				case 1:
					Console.Clear();
					Console.WriteLine("Entro a 1 - Agregar Productos");
					AddProducts(instruments, pricestock);
					break;
				case 2:
					Console.Clear();
					Console.WriteLine("Entro a 2 - Eliminar Productos");
					DeleteProducts(instruments, pricestock, clasificacion);
					break;
				case 3:
					Console.Clear();
					Console.WriteLine("Entro a 4 - Modificar Productos");
					break;
				case 8:
					break;

				default:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Error! Ingrese una opcion correcta.");
					Console.ResetColor();
					Console.ReadKey();
					break;
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
		static void DeleteProducts(string[,] instruments, int[,] pricestock, string[] clasificacion)
		{

			ListProducts(instruments, pricestock, clasificacion);

			Console.WriteLine("\nIngrese la marca del instrumento que desea eliminar:");

			string elementtosearch = Console.ReadLine();

			for (int fi = 0; fi < instruments.GetLength(0); fi++)
			{
				for (int ci = 0; ci < instruments.GetLength(1); ci++)
				{
					if (instruments[fi, ci] == elementtosearch)
					{
						instruments[fi, 0] = null;
						instruments[fi, 1] = null;
						instruments[fi, 2] = null;

						for (int fp = 0; fp < pricestock.GetLength(0); fp++)
						{
							for (int cp = 0; cp < pricestock.GetLength(1); cp++)
							{
								pricestock[fi, 0] = 0;
								pricestock[fi, 1] = 0;
							}
						}
					}
				}
			}
        }
		static void ModifyProducts()
		{

		}
		static void Calculator()
		{

		}
		static int ValInt()
		{
			int num;
			string val;

			bool conv = int.TryParse(Console.ReadLine().Trim(), out num);

			while (!conv)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error! ingrese un dato valido:");
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

			while (string.IsNullOrEmpty(str))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error! ingrese un dato valido:");
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
					op = 9;
				}
				if (val == "n")
				{
					op = 0;
				}
			return op;
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


