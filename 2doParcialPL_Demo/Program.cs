using System;
using System.Linq;
namespace _2doParcialPL_Demo
{
	class Program
	{
		static Program() 	
		{
			public static string[,] instruments = CargarInstruments();
			public static int[,] pricestock = CargarPreciosStock();
			public static string[] clasificacion = CargarClas();
			public static string[] clasificacionInv = CargarClasInv();
			public static double[] facArray = new double[10];
	
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
			/// <returns> Retorna 'op'. Variable que indica que opciones en el Menu Principal </returns>
			static int ControlApp()
			{
				int op;
				int.TryParse(Console.ReadLine(), out op);

				switch (op)
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
						CalculatorMenu();
						break;
					case 4:
						Console.Clear();
						RegVenta();
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
			/// <summary>
			/// Dibuja la lista de productos standard.
			/// </summary>
			static void ListProducts()
			{
				for (int i = 0; i < clasificacion.Length; i++)
				{
					Console.BackgroundColor = ConsoleColor.DarkCyan;
					Console.Write($"|{clasificacion[i],-13}");
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
					for (int cp = 0; cp < pricestock.GetLength(1); cp++)
					{
						Console.Write($"{pricestock[fi, cp],-13}|");
					}
					Console.WriteLine();
				}
				Console.ReadKey();
			}
			/// <summary>
			/// Dibuja el Menu que edita la lista de productos.
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
			/// Controla el Menu que edita la lista de productos.
			/// </summary>
			/// <returns> Retorna 'op'. Variable que indica que opciones en el Menu que edita la lista de productos</returns>
			static int ControlEditProducts()
			{
				int op;
				int.TryParse(Console.ReadLine(), out op);

				switch (op)
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
				return op;
			}
			/// <summary>
			/// Agrega productos a la lista.
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
									Console.WriteLine("Ingrese Marca:");
									instruments[fi, ci] = ValStr();
									break;
								case 2:
									Console.Clear();
									Console.WriteLine("Ingrese Modelo:");
									instruments[fi, ci] = ValStr();
									break;
								case 3:
									Console.Clear();
									Console.WriteLine("Ingrese Submodelo:");
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
									Console.WriteLine("Ingrese Precio de Lista:");
									pricestock[fp, cp] = ValInt();
									break;
								case 1:
									Console.Clear();
									Console.WriteLine("Ingrese Stock:");
									pricestock[fp, cp] = ValInt();
									break;
							}
						}
						break;
					}
				}
			}
			/// <summary>
			/// Borra productos de la lista.
			/// </summary>
			static void DeleteProducts()
			{
				ListProducts();

				Console.WriteLine("\nIngrese el ID del instrumento que desea eliminar:");

				string elementtosearch = ValStr();

				for (int fi = 0; fi < instruments.GetLength(0); fi++)
				{
					for (int ci = 0; ci < instruments.GetLength(1); ci++)
					{
						if (instruments[fi, ci] == elementtosearch)
						{
							instruments[fi, 1] = null;
							instruments[fi, 2] = null;
							instruments[fi, 3] = null;

							for (int fp = 0; fp < pricestock.GetLength(0); fp++)
							{
								pricestock[fi, 0] = 0;
								pricestock[fi, 1] = 0;
							}
						}
					}
				}

				Console.Clear();
				ListProducts();
			}
			/// <summary>
			/// Resta unidades en stock
			/// </summary>
			static void RegVenta()
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
							for (int cp = 1; cp < pricestock.GetLength(1); cp++)
							{
								pricestock[fi, 1] = pricestock[fi, 1] - cant;
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
			static void CalculatorMenu()
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
			/// <returns> Retorna 'op'. Variable que indica que opciones en el Menu de Contabilidad.</returns>
			static int ControlCalculator()
			{
				int op;
				int.TryParse(Console.ReadLine(), out op);

				switch (op)
				{
					case 1:
						Console.Clear();
						PreciosCost();
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
				return op;
			}
			/// <summary>
			/// Dibuja la Lista de Productos con la lista de Costos.
			/// </summary>
			static void PreciosCost()
			{
				for (int c = 0; c < clasificacionInv.Length; c++)
				{
					Console.BackgroundColor = ConsoleColor.DarkGreen;
					Console.Write($"|{clasificacionInv[c],-13}");
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
					for (int fp = 1; fp < pricestock.GetLength(1); fp++)
					{
						Console.Write($"{pricestock[fi, 0] * 0.7,-18}|");
					}
					Console.WriteLine();
				}
				Console.ReadKey();
			}
			/// <summary>
			/// Da informacion sobre la contabilidad del negocio.
			/// </summary>
			static void Info()
			{
				int resSumIns = 0;
				int resSumStk = 0;
				double fac = 0;
				double gan = 0;
				double cos = 0;

				for (int i = 0; i < facArray.Length; i++)
				{
					for (int fp = 0; fp < pricestock.GetLength(0); fp++)
					{
						facArray[i] = pricestock[i, 0] * pricestock[i, 1];
						break;
					}
				}

				fac = facArray.Sum();

				for (int fp = 0; fp < pricestock.GetLength(0); fp++)
				{
					resSumIns += pricestock[fp, 0];
					resSumStk += pricestock[fp, 1];
					cos = (fac) * 0.7;
					gan = fac - cos;
				}

				Console.BackgroundColor = ConsoleColor.DarkMagenta;
				Console.WriteLine("\n\n La ganancia por cada instrumento es del +30%.");
				Console.WriteLine($" Nro de instrumentos en deposito: {resSumStk}.");
				Console.WriteLine($" Facturacion total estimada: ${fac}.");
				Console.WriteLine($" Costo total: ${cos}.");
				Console.WriteLine($" Ganancia total estimada: ${gan}.");
				Console.ResetColor();
				Console.ReadKey();
			}
			/// <summary>
			/// Valida variables del tipo int..
			/// </summary>
			/// <returns> Retorna 'num'. Variable del tipo int que funciona como auxiliar cuando valida un numero entero</returns>
			static int ValInt()
			{
				int num;
				string val;

				bool conv = int.TryParse(Console.ReadLine().Trim(), out num);

				while (!conv)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Error!!! ingrese un dato valido:");
					Console.ResetColor();
					conv = int.TryParse(Console.ReadLine().Trim(), out num);
				}

				Console.WriteLine($"Ingreso '{num}' ¿es correcto? s/n");
				val = Console.ReadLine();

				while (val == "n")
				{
					Console.WriteLine("Vuelva a ingresar el dato:");
					int.TryParse(Console.ReadLine().Trim(), out num);
					Console.WriteLine($"Ingreso '{num}' ¿es correcto? s/n");
					val = Console.ReadLine().Trim().ToLower();
				}
				while (val.Any(char.IsDigit) || string.IsNullOrEmpty(val))
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Error!!! Ingrese s/n");
					Console.ResetColor();
					val = Console.ReadLine().Trim().ToLower();
				}
				if (val == "s")
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Hecho!");
					Console.ResetColor();
				}
				return num;
			}
			/// <summary>
			/// Valida variables del tipo string.
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
					Console.WriteLine("Error!!! ingrese un dato valido:");
					Console.ResetColor();
					str = Console.ReadLine().Trim();
				}

				Console.WriteLine($"Ingreso '{str}' ¿es correcto? s/n");
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
					Console.WriteLine("Error!!! Ingrese s/n");
					Console.ResetColor();
					val = Console.ReadLine().Trim().ToLower();
				}
				if (val == "s")
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Hecho!");
					Console.ReadKey();
					Console.ResetColor();
				}
				return str;
			}
			/// <summary>
			/// Toma como parametro la variable de 'op' de las funciones de control.
			/// Valida la salida del programa.
			/// </summary>
			/// <param name="op"></param>
			/// <returns></returns>
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
			/// <summary>
			/// Carga la lista de Instrumentos desde el arranque del programa.
			/// </summary>
			/// <returns> Retorna 'aux'. Variable auxiliar que llena la matriz "instruments" </returns>
			static string[,] CargarInstruments()
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
			/// Carga la lista de precios de lista y stock desde el arranque del programa.
			/// </summary>
			/// <returns> Retorna 'aux'. Variable auxiliar que llena la matriz "pricestock" </returns>
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
			/// <summary>
			/// Carga el encabezado de la lista de productos con precio de lista.
			/// </summary>
			/// <returns>Retorna 'aux'. Variable auxiliar que llena el array de "clasificacion". </returns>
			static string[] CargarClas()
			{
				string[] aux = { "Id", "Marca", "Modelo", "SubModelo", "Precio Lista", "Stock" };
				return aux;
			}
			/// <summary>
			/// Carga el encabezado de la lista de productos con precio de costo.
			/// </summary>
			/// <returns>Retorna 'aux'. Variable auxiliar que llena el array de "clasificacionInv". </returns>
			static string[] CargarClasInv()
			{
				string[] aux = { "Id", "Marca", "Modelo", "SubModelo", "Costo" };
				return aux;
			}		
		}
	}
}

