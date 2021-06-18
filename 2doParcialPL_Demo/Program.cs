using System;
using System.Linq;

namespace Segundo_Parcial
{
	class Program
	{
		public static string[,] instruments = LoadInstruments();
		public static int[,] priceStock = LoadPriceStock();
		public static string[] hRetailer = LoadHeaderRetailer();
		public static string[] hWholesaler = LoadHeaderWholesaler();
		public static double[] totalBilling = Info();

		static void Main(string[] args)
		{
			MainMenu();
		}

		/// <summary>
		/// Dibuja el menu principal.
		/// </summary>
		static void MainMenu()
		{
			do
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("╔═════════════════════════════════════╗");
				Console.WriteLine("║    Casa de Musica - Do Sostenido    ║");
				Console.WriteLine("║                                     ║");
				Console.WriteLine("║    1) Inventario y Precios.         ║");
				Console.WriteLine("║    2) Modificar registros.          ║");
				Console.WriteLine("║    3) Contabilidad.                 ║");
				Console.WriteLine("║    4) Resgistrar Venta.             ║");
				Console.WriteLine("║                                     ║");
				Console.WriteLine("║    9) Salir.                        ║");
				Console.WriteLine("╚═════════════════════════════════════╝");
				Console.ResetColor();
			} while (ControlApp() != 9);
		}

		/// <summary>
		/// Le da funcionamiento al Menu principal, utilizando opciones numericas.
		/// </summary>
		/// <returns> Retorna 'opt'. Variable que indica que opciones en el Menu Principal </returns>
		static int ControlApp()
		{
			int opt;
			int.TryParse(Console.ReadLine(), out opt);

			switch (opt)
			{
				case 1:
					Console.Clear();
					ListProducts();
					break;
				case 2:
					Console.Clear();
					EditProductsMenu();
					break;
				case 3:
					Console.Clear();
					AccountingMenu();
					break;
				case 4:
					Console.Clear();
					RegSale();
					break;
				case 9:
					Console.Clear();
					Exit(opt);
					break;

				default:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Error! Ingrese una opcion correcta.");
					Console.ResetColor();
					Console.ReadKey();
					break;
			}
			return opt;
		}

		/// <summary>
		/// Dibuja el listado de productos con precios minoristas.
		/// </summary>
		static void ListProducts()
		{
			for (int i = 0; i < hRetailer.Length; i++)
			{
				Console.BackgroundColor = ConsoleColor.DarkCyan;
				Console.Write($"|{hRetailer[i],-13}");
				Console.ResetColor();
			}
			Console.WriteLine();
			for (int fi = 0; fi < instruments.GetLength(0); fi++)
			{
				Console.Write("|");
				for (int ci = 0; ci < instruments.GetLength(1); ci++)
				{
					Console.Write($"{instruments[fi, ci],-13}|");
				}
				for (int cp = 0; cp < priceStock.GetLength(1); cp++)
				{
					Console.Write($"{priceStock[fi, cp],-13}|");
				}
				Console.WriteLine();
			}
			Console.ReadKey();
		}

		/// <summary>
		/// Dibuja el Menu para editar el listado de productos.
		/// </summary>
		static void EditProductsMenu()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("╔═════════════════════════════════════╗");
			Console.WriteLine("║    Casa de Musica - Do Sostenido    ║");
			Console.WriteLine("║        *Modificar Registros*        ║");
			Console.WriteLine("║                                     ║");
			Console.WriteLine("║    1) Agregar productos             ║");
			Console.WriteLine("║    2) Eliminar productos            ║");
			Console.WriteLine("║                                     ║");
			Console.WriteLine("║    8) Volver                        ║");
			Console.WriteLine("╚═════════════════════════════════════╝");
			Console.ResetColor();
			ControlEditProducts();
		}

		/// <summary>
		/// Controla el Menu para editar el listado de productos.
		/// </summary>
		/// <returns> Retorna 'opt'. Variable que indica que opciones en el Menu que edita el listado de productos</returns>
		static int ControlEditProducts()
		{
			int opt;
			int.TryParse(Console.ReadLine(), out opt);

			switch (opt)
			{
				case 1:
					Console.Clear();
					AddProducts();
					break;
				case 2:
					Console.Clear();
					DeleteProducts();
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
			return opt;
		}

		/// <summary>
		/// Agrega productos al listado.
		/// </summary>
		static void AddProducts()
		{
			for (int fi = 0; fi < instruments.GetLength(0); fi++)
			{
				if (string.IsNullOrEmpty(instruments[fi, 1]))
				{
					for (int ci = 1; ci < instruments.GetLength(1); ci++)
					{
						switch (ci)
						{
							case 1:
								Console.Clear();
								Console.WriteLine("Ingrese Marca del Instrumento:");
								instruments[fi, ci] = ValStr();
								break;
							case 2:
								Console.Clear();
								Console.WriteLine("Ingrese Modelo del Instrumento:");
								instruments[fi, ci] = ValStr();
								break;
							case 3:
								Console.Clear();
								Console.WriteLine("Ingrese Submodelo del Instrumento:");
								instruments[fi, ci] = ValStr();
								break;
						}
					}
					break;
				}
			}
			for (int fp = 0; fp < priceStock.GetLength(0); fp++)
			{
				if (priceStock[fp, 0] == 0)
				{
					for (int cp = 0; cp < instruments.GetLength(1); cp++)
					{
						switch (cp)
						{
							case 0:
								Console.Clear();
								Console.WriteLine("Ingrese el Precio de Lista del Instrumento:");
								priceStock[fp, cp] = ValInt();
								break;
							case 1:
								Console.Clear();
								Console.WriteLine("Ingrese la cantidad de unidades en Stock:");
								priceStock[fp, cp] = ValInt();
								break;
						}
					}
					break;
				}
			}
		}

		/// <summary>
		/// Borra productos del listado.
		/// </summary>
		static void DeleteProducts()
		{
			ListProducts();

			Console.WriteLine("\nIngrese el ID del instrumento que desea eliminar:");

			string search = ValStr();

			for (int fi = 0; fi < instruments.GetLength(0); fi++)
			{
				for (int ci = 0; ci < instruments.GetLength(1); ci++)
				{
					if (instruments[fi, ci] == search)
					{
						instruments[fi, 1] = null;
						instruments[fi, 2] = null;
						instruments[fi, 3] = null;

						for (int fp = 0; fp < priceStock.GetLength(0); fp++)
						{
							priceStock[fi, 0] = 0;
							priceStock[fi, 1] = 0;
						}
					}
				}
			}
			Console.Clear();
			ListProducts();
		}

		/// <summary>
		/// Resta una cantidad unidades establecidas por el usuario del stock.
		/// </summary>
		static void RegSale()
		{
			string id;
			int cant;

			ListProducts();

			Console.WriteLine("\nIngrese el ID del instrumento: ");
			id = ValStr();

			Console.WriteLine("Ingrese la cantidad de unidades vendidas: ");
			cant = ValInt();

			Console.Clear();

			for (int fi = 0; fi < instruments.GetLength(0); fi++)
			{
				for (int ci = 0; ci < instruments.GetLength(1); ci++)
				{
					if (instruments[fi, ci] == id)
					{
						for (int cp = 1; cp < priceStock.GetLength(1); cp++)
						{
							priceStock[fi, 1] = priceStock[fi, 1] - cant;
						}
					}
				}
			}
			Console.Clear();
			ListProducts();
		}
		/// <summary>
		/// Dibuja el Menu de Contabilidad 
		/// </summary>
		static void AccountingMenu()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("╔═════════════════════════════════════╗");
			Console.WriteLine("║    Casa de Musica - Do Sostenido    ║");
			Console.WriteLine("║           *Contabilidad*            ║");
			Console.WriteLine("║                                     ║");
			Console.WriteLine("║    1) Precios de Costo              ║");
			Console.WriteLine("║    2) Info                          ║");
			Console.WriteLine("║                                     ║");
			Console.WriteLine("║    8) Volver                        ║");
			Console.WriteLine("╚═════════════════════════════════════╝");
			Console.ResetColor();
			ControlCalculator();
		}
		/// <summary>
		/// Controla el Menu de Contabilidad.
		/// </summary>
		/// <returns> Retorna 'opt'. Variable que indica que opciones en el Menu de Contabilidad.</returns>
		static int ControlCalculator()
		{
			int opt;
			int.TryParse(Console.ReadLine(), out opt);

			switch (opt)
			{
				case 1:
					Console.Clear();
					CostPrice();
					break;
				case 2:
					Info();
					break;
				case 8:
					break;

				default:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Error!!! Ingrese una opcion correcta.");
					Console.ResetColor();
					Console.ReadKey();
					break;
			}
			return opt;
		}

		/// <summary>
		/// Dibuja el listado de Productos con los precios mayoristas.
		/// </summary>
		static void CostPrice()
		{
			for (int c = 0; c < hWholesaler.Length; c++)
			{
				Console.BackgroundColor = ConsoleColor.DarkGreen;
				Console.Write($"|{hWholesaler[c],-13}");
				Console.ResetColor();
			}
			Console.WriteLine();
			for (int fi = 0; fi < instruments.GetLength(0); fi++)
			{
				Console.Write("|");
				for (int ci = 0; ci < instruments.GetLength(1); ci++)
				{
					Console.Write($"{instruments[fi, ci],-13}|");
				}
				for (int fp = 1; fp < priceStock.GetLength(1); fp++)
				{
					Console.Write($"{priceStock[fi, 0] * 0.7,-18}|");
				}
				Console.WriteLine();
			}
			Console.ReadKey();
		}

		/// <summary>
		/// Da informacion sobre la contabilidad del negocio.
		/// </summary>
		static double[] Info()
		{
			totalBilling = new double[10];
			int instSum = 0;
			int stkSum = 0;
			double billing = 0;
			double prof = 0;
			double cost = 0;

			for (int i = 0; i < totalBilling.Length; i++)
			{
				for (int fp = 0; fp < priceStock.GetLength(0); fp++)
				{
					totalBilling[i] = priceStock[i, 0] * priceStock[i, 1];
					break;
				}
			}

			billing = totalBilling.Sum();

			for (int fp = 0; fp < priceStock.GetLength(0); fp++)
			{
				instSum += priceStock[fp, 0];
				stkSum += priceStock[fp, 1];
				cost = (billing) * 0.7;
				prof = billing - cost;
			}

			Console.BackgroundColor = ConsoleColor.DarkMagenta;
			Console.WriteLine("\n\n La ganancia por cada instrumento es del +30%.");
			Console.WriteLine($" Nro de instrumentos en deposito: {stkSum}.");
			Console.WriteLine($" Facturacion total estimada: ${billing}.");
			Console.WriteLine($" Costo total: ${cost}.");
			Console.WriteLine($" Ganancia total estimada: ${prof}.");
			Console.ResetColor();
			Console.ReadKey();

			return totalBilling;
		}

		/// <summary>
		/// Valida entradas del usuario del tipo int.
		/// </summary>
		/// <returns> Retorna 'num'. Variable del tipo int que funciona como auxiliar cuando valida un numero entero.</returns>
		static int ValInt()
		{
			int num;
			string val;

			bool conv = int.TryParse(Console.ReadLine().Trim(), out num);

			while (!conv)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error!!! Ingrese un dato valido:");
				Console.ResetColor();
				conv = int.TryParse(Console.ReadLine().Trim(), out num);
			}

			Console.WriteLine($"Ingreso '{num}' ¿es correcto? s/n");
			val = Console.ReadLine();

			while (val.Any(char.IsDigit) || string.IsNullOrEmpty(val) || val != "s")
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error!!! Ingrese s/n");
				Console.ResetColor();
				val = Console.ReadLine().Trim().ToLower();

				while (val == "n")
				{
					Console.WriteLine("Vuelva a Ingresar el dato:");
					int.TryParse(Console.ReadLine().Trim(), out num);
					Console.WriteLine($"Ingreso '{num}' ¿es correcto? s/n");
					val = Console.ReadLine().Trim().ToLower();
				}
			}
			if (val == "s")
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Hecho!");
				Console.ResetColor();
				Console.ReadKey();
			}
			return num;
		}

		/// <summary>
		/// Valida entradas del usuario del tipo string.
		/// </summary>
		/// <returns> Retorna 'str'. Variable que funciona como auxiliar cuando validamos un dato del tipo string.</returns>
		static string ValStr()
		{
			string str;
			string val;

			str = Console.ReadLine().Trim();

			while (string.IsNullOrEmpty(str))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error!!! Ingrese un dato valido:");
				Console.ResetColor();
				str = Console.ReadLine().Trim();
			}

			Console.WriteLine($"Ingreso '{str}' ¿es correcto? s/n");
			val = Console.ReadLine();

			while (val.Any(char.IsDigit) || string.IsNullOrEmpty(val) || val != "s")
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error!!! Ingrese s/n");
				Console.ResetColor();
				val = Console.ReadLine().Trim().ToLower();

				while (val == "n")
				{
					Console.WriteLine("Vuelva a ingresar el dato:");
					str = Console.ReadLine().Trim();
					Console.WriteLine($"Ingreso '{str}' ¿es correcto? s/n");
					val = Console.ReadLine().Trim().ToLower();
				}
			}
			if (val == "s")
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Hecho!");
				Console.ResetColor();
				Console.ReadKey();
			}
			return str;
		}

		/// <summary>
		/// Valida la salida del programa.
		/// </summary>
		/// <param name="opt"></param>
		/// <returns> Retorna 'opt'. Variable que utiliza ControlApp() para ejecutar la salida del programa. </returns>
		static int Exit(int opt)
		{
			string val;
			Console.WriteLine("¿Esta seguro que desea salir? s/n");
			val = Console.ReadLine().Trim().ToLower();
			if (val == "s")
			{
				opt = 9;
			}
			if (val == "n")
			{
				opt = 0;
			}
			return opt;
		}

		/// <summary>
		/// Carga el listado de Productos desde el arranque del programa.
		/// </summary>
		/// <returns> Retorna 'aux'. Variable auxiliar que llena la matriz "instruments". </returns>
		static string[,] LoadInstruments()
		{
			string[,] aux = new string[10, 4]
			{
				{"1", "Gibson", "Les Paul", "Studio 2013" },
				{"2", "Epiphone", "SG", "G-310" },
				{"3",  null, null, null },
				{"4", "Washburn", "KC44V", "FloydRose" },
				{"5",  null, null, null },
				{"6", "SX", "Les Paul", "Black" },
				{"7", "Rockman", "Stratocaster", "2009" },
				{"8", "Dean", "Dave Mustaine", "VMNTX" },
				{"9", null, null, null },
				{"10", "Squier", "Telecaster", "Custom" }
			};
			return aux;
		}

		/// <summary>
		/// Carga el listado de precios minoristas y stock desde el arranque del programa.
		/// </summary>
		/// <returns> Retorna 'aux'. Variable auxiliar que llena la matriz "priceStock" </returns>
		static int[,] LoadPriceStock()
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

		/// <summary>
		/// Carga el encabezado del listado de productos con precios minoristas.
		/// </summary>
		/// <returns>Retorna 'aux'. Variable auxiliar que llena el array de "hRetailer". </returns>
		static string[] LoadHeaderRetailer()
		{
			string[] aux = { "Id", "Marca", "Modelo", "SubModelo", "Precio Lista", "Stock" };
			return aux;
		}

		/// <summary>
		/// Carga el encabezado de la lista de productos con precio de costo.
		/// </summary>
		/// <returns>Retorna 'aux'. Variable auxiliar que llena el array de "hWholesaler". </returns>
		static string[] LoadHeaderWholesaler()
		{
			string[] aux = { "Id", "Marca", "Modelo", "SubModelo", "Costo" };
			return aux;
		}
	}
}
