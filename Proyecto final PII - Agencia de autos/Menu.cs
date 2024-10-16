using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Menu
    {
        int posicionActual;
        bool bucle;
        Concesionaria concesionaria = new Concesionaria();

        public void MenuPrincipal()
        {
            string[] menuOpciones = { "Vehículos", "Clientes", "Ventas", "Parámetros", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;

            while (!bucle)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                Console.WriteLine("-------------------------------------------");

                for (int i = 0; i < menuOpciones.Length; i++)
                {
                    if (posicionActual == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (char)62 + " ");
                    }

                    Console.WriteLine(menuOpciones[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuOpciones.Length - 1)
                        {
                            Console.WriteLine("\nSaliendo del programa.");
                            bucle = true;
                        }
                        else if (posicionActual == 0)
                        {
                            MenuVehiculos(20, 0);
                        }

                        else if (posicionActual == 1)
                        {
                            MenuClientes();
                        }

                        else if (posicionActual == 2)
                        {
                            MenuVentas();
                        }

                        else if (posicionActual == 3)
                        {
                            MenuParametros();
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (posicionActual == 0)
                            posicionActual = menuOpciones.Length - 1;
                        else
                            posicionActual--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (posicionActual == menuOpciones.Length - 1)
                            posicionActual = 0;
                        else
                            posicionActual++;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuVehiculos(int posX, int posY)
        {
            string[] menuOpcionesVehiculos = { "Registrar nuevo vehículo", "Modificar un vehículo existente", "Eliminar un vehículo existente", "Listar vehículos", "Buscar un vehículo", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bool bucle = false;

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
            Console.WriteLine("-------------------------------------------");

            while (!bucle)
            {
                for (int i = 0; i < menuOpcionesVehiculos.Length; i++)
                {
                    Console.SetCursorPosition(posX, posY + 2 + i);
                    Console.ResetColor();

                    if (posicionActual == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (char)62 + " ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }

                    Console.WriteLine(menuOpcionesVehiculos[i]);
                }

                ConsoleKeyInfo tecla = Console.ReadKey(true);
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuOpcionesVehiculos.Length - 1)
                        {
                            Console.ResetColor();
                            Console.Clear();
                            Console.WriteLine("\nSaliendo del menú de vehículos.");
                            MenuPrincipal();
                        }
                        else if (posicionActual == 0)
                        {
                            string[] menuTresVehiculos = { "Registrar un auto o una camioneta", "Registrar una moto", "Registrar un camión", "Salir" };
                            posicionActual = 0;
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                            Console.WriteLine("-------------------------------------------");

                            while (true)
                            {
                                for (int j = 0; j < menuTresVehiculos.Length; j++)
                                {
                                    Console.SetCursorPosition(60, posY + 2 + j);
                                    Console.ResetColor();

                                    if (posicionActual == j)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Blue;
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(" " + (char)62 + " ");
                                    }
                                    else
                                    {
                                        Console.Write("   ");
                                    }

                                    Console.WriteLine(menuTresVehiculos[j]);
                                }

                                ConsoleKeyInfo tecla2 = Console.ReadKey(true);
                                switch (tecla2.Key)
                                {
                                    case ConsoleKey.Enter:
                                    case ConsoleKey.Spacebar:
                                        Console.SetCursorPosition(0, 10);
                                        if (posicionActual == menuTresVehiculos.Length - 1) // "Salir"
                                        {
                                            Console.Clear(); // Clear the console
                                            Console.ResetColor(); // Reset colors
                                            MenuPrincipal(); // Return to MenuPrincipal
                                            return; // Ensure to exit the current method
                                        }

                                        else if (posicionActual == 0)
                                        {
                                            concesionaria.IngresarAutoCamioneta();
                                        }
                                        else if (posicionActual == 1)
                                        {
                                            concesionaria.IngresarMoto();
                                        }
                                        else if (posicionActual == 2)
                                        {
                                            concesionaria.IngresarCamion();
                                        }
                                        break;

                                    case ConsoleKey.UpArrow:
                                        posicionActual = (posicionActual == 0) ? menuTresVehiculos.Length - 1 : posicionActual - 1;
                                        break;

                                    case ConsoleKey.DownArrow:
                                        posicionActual = (posicionActual == menuTresVehiculos.Length - 1) ? 0 : posicionActual + 1;
                                        break;
                                }
                            }
                        }
                        else if (posicionActual == 1)
                        {
                            concesionaria.ModificarVehiculo();
                        }
                        else if (posicionActual == 2)
                        {
                            concesionaria.BorrarVehiculo();
                        }
                        else if (posicionActual == 3)
                        {
                            concesionaria.MostrarVehiculos();
                        }
                        else if (posicionActual == 4)
                        {
                            concesionaria.BuscarVehiculo();
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = (posicionActual == 0) ? menuOpcionesVehiculos.Length - 1 : posicionActual - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = (posicionActual == menuOpcionesVehiculos.Length - 1) ? 0 : posicionActual + 1;
                        break;
                }
            }
        }

        void MenuClientes()
        {
            string[] menuOpcionesClientes = { "Agregar nuevo cliente", "Modificar cliente", "Eliminar cliente", "Listar clientes", "Buscar cliente", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;

            while (!bucle)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                Console.WriteLine("-------------------------------------------");

                for (int i = 0; i < menuOpcionesClientes.Length; i++)
                {
                    if (posicionActual == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (char)62 + " ");
                    }
                    Console.WriteLine(menuOpcionesClientes[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuOpcionesClientes.Length - 1)
                        {
                            Console.WriteLine("\nSaliendo del menú de clientes.");
                            bucle = true;
                            MenuPrincipal();
                        }
                        else if (posicionActual == 0)
                        {
                            concesionaria.CargarCliente();
                            concesionaria.ActualizarClientes();
                        }

                        else if (posicionActual == 1)
                        {
                            concesionaria.ModificarCliente();
                            concesionaria.ActualizarClientes();
                        }

                        else if (posicionActual == 2)
                        {
                            concesionaria.BorrarCliente();
                            concesionaria.ActualizarClientes();
                        }

                        else if (posicionActual == 3)
                        {
                            concesionaria.ListarClientes();
                        }

                        else if (posicionActual == 4)
                        {
                            concesionaria.BuscarCliente();
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        if (posicionActual == 0)
                            posicionActual = menuOpcionesClientes.Length - 1;
                        else
                            posicionActual--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (posicionActual == menuOpcionesClientes.Length - 1)
                            posicionActual = 0;
                        else
                            posicionActual++;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuVentas()
        {
            string[] menuOpcionesVentas = { "Realizar nueva venta", "Modificar venta", "Eliminar venta", "Listado de ventas", "Búsqueda de una venta", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;

            while (!bucle)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                Console.WriteLine("-------------------------------------------");

                for (int i = 0; i < menuOpcionesVentas.Length; i++)
                {
                    if (posicionActual == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (char)62 + " ");
                    }
                    Console.WriteLine(menuOpcionesVentas[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuOpcionesVentas.Length - 1)
                        {
                            Console.WriteLine("\nSaliendo del menú de ventas.");
                            bucle = true;
                            MenuPrincipal();
                        }
                        else if (posicionActual == 0)
                        {
                            concesionaria.CargarVenta();
                            concesionaria.ActualizarVentas();
                        }

                        else if (posicionActual == 1)
                        {
                            concesionaria.ModificarVenta();
                            concesionaria.ActualizarVentas();
                        }

                        else if (posicionActual == 2)
                        {
                            concesionaria.BorrarVenta();
                            concesionaria.ActualizarVentas();
                        }

                        else if (posicionActual == 3)
                        {
                            concesionaria.ListarVentas();
                        }

                        else if (posicionActual == 4)
                        {
                            concesionaria.BuscarVenta();
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        if (posicionActual == 0)
                            posicionActual = menuOpcionesVentas.Length - 1;
                        else
                            posicionActual--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (posicionActual == menuOpcionesVentas.Length - 1)
                            posicionActual = 0;
                        else
                            posicionActual++;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuParametros()
        {
            string[] menuOpcionesParametros = { "Marcas", "Localidades", "Provincias", "Combustible", "Segmento", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;

            while (!bucle)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                Console.WriteLine("-------------------------------------------");

                for (int i = 0; i < menuOpcionesParametros.Length; i++)
                {
                    if (posicionActual == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (char)62 + " ");
                    }
                    Console.WriteLine(menuOpcionesParametros[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuOpcionesParametros.Length - 1)
                        {
                            Console.WriteLine("\nSaliendo del menú de parámetros.");
                            bucle = true;
                            MenuPrincipal();
                        }
                        else if (posicionActual == 0) // Marcas
                        {
                            MenuMarcas();
                        }

                        else if (posicionActual == 1) // Localidades
                        {
                            MenuLocalidades();
                        }

                        else if (posicionActual == 2) // Provincias
                        {
                            MenuProvincias();
                        }

                        else if (posicionActual == 3) // Combustibles
                        {
                            MenuCombustibles();
                        }

                        else if (posicionActual == 4) // Segmentos
                        {
                            MenuSegmentos();
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        if (posicionActual == 0)
                            posicionActual = menuOpcionesParametros.Length - 1;
                        else
                            posicionActual--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (posicionActual == menuOpcionesParametros.Length - 1)
                            posicionActual = 0;
                        else
                            posicionActual++;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuMarcas()
        {
            string[] menuMarcas = { "Agregar marca", "Listar marcas", "Modificar marca", "Eliminar marca", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;

            while (!bucle)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                Console.WriteLine("-------------------------------------------");

                for (int i = 0; i < menuMarcas.Length; i++)
                {
                    if (posicionActual == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (char)62 + " ");
                    }
                    Console.WriteLine(menuMarcas[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuMarcas.Length - 1)
                        {
                            Console.WriteLine("\nSaliendo del menú de parámetros.");
                            bucle = true;
                            MenuParametros();
                        }
                        else if (posicionActual == 0)
                        {
                            concesionaria.IngresarMarca();
                            concesionaria.ActualizarMarcas();
                        }

                        else if (posicionActual == 1)
                        {
                            concesionaria.ListarMarcas();
                        }

                        else if (posicionActual == 2)
                        {
                            concesionaria.ModificarMarca();
                            concesionaria.ActualizarMarcas();
                        }

                        else if (posicionActual == 3)
                        {
                            concesionaria.BorrarMarca();
                            concesionaria.ActualizarMarcas();
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        if (posicionActual == 0)
                            posicionActual = menuMarcas.Length - 1;
                        else
                            posicionActual--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (posicionActual == menuMarcas.Length - 1)
                            posicionActual = 0;
                        else
                            posicionActual++;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuLocalidades()
        {
            string[] menuLocalidades = { "Agregar localidad", "Listar localidades", "Modificar localidad", "Eliminar localidad", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;

            while (!bucle)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                Console.WriteLine("-------------------------------------------");

                for (int i = 0; i < menuLocalidades.Length; i++)
                {
                    if (posicionActual == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (char)62 + " ");
                    }
                    Console.WriteLine(menuLocalidades[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuLocalidades.Length - 1)
                        {
                            Console.WriteLine("\nSaliendo del menú de parámetros.");
                            bucle = true;
                            MenuParametros();
                        }
                        else if (posicionActual == 0)
                        {
                            concesionaria.CargarLocalidad();
                            concesionaria.actualizarLocalidades();
                        }

                        else if (posicionActual == 1)
                        {
                            concesionaria.ListarLocalidades();
                        }

                        else if (posicionActual == 2)
                        {
                            concesionaria.ModificarLocalidad();
                            concesionaria.actualizarLocalidades();
                        }

                        else if (posicionActual == 3)
                        {
                            concesionaria.BorrarLocalidad();
                            concesionaria.actualizarLocalidades();
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        if (posicionActual == 0)
                            posicionActual = menuLocalidades.Length - 1;
                        else
                            posicionActual--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (posicionActual == menuLocalidades.Length - 1)
                            posicionActual = 0;
                        else
                            posicionActual++;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuProvincias()
        {
            string[] menuProvincias = { "Agregar provincia", "Listar provincias", "Modificar provincia", "Eliminar provincia", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;

            while (!bucle)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                Console.WriteLine("-------------------------------------------");

                for (int i = 0; i < menuProvincias.Length; i++)
                {
                    if (posicionActual == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (char)62 + " ");
                    }
                    Console.WriteLine(menuProvincias[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuProvincias.Length - 1)
                        {
                            Console.WriteLine("\nSaliendo del menú de parámetros.");
                            bucle = true;
                            MenuParametros();
                        }
                        else if (posicionActual == 0)
                        {
                            concesionaria.CargarProvincia();
                            concesionaria.actualizarProvincias();
                        }

                        else if (posicionActual == 1)
                        {
                            concesionaria.ListarProvincias();
                        }

                        else if (posicionActual == 2)
                        {
                            concesionaria.ModificarProvincia();
                            concesionaria.actualizarProvincias();
                        }

                        else if (posicionActual == 3)
                        {
                            concesionaria.BorrarProvincia();
                            concesionaria.actualizarProvincias();
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        if (posicionActual == 0)
                            posicionActual = menuProvincias.Length - 1;
                        else
                            posicionActual--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (posicionActual == menuProvincias.Length - 1)
                            posicionActual = 0;
                        else
                            posicionActual++;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuCombustibles()
        {
            string[] menuCombustible = { "Agregar combustible", "Listar combustibles", "Modificar combustible", "Eliminar combustible", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;

            while (!bucle)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                Console.WriteLine("-------------------------------------------");

                for (int i = 0; i < menuCombustible.Length; i++)
                {
                    if (posicionActual == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (char)62 + " ");
                    }
                    Console.WriteLine(menuCombustible[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuCombustible.Length - 1)
                        {
                            Console.WriteLine("\nSaliendo del menú de parámetros.");
                            bucle = true;
                            MenuParametros();
                        }
                        else if (posicionActual == 0)
                        {
                            concesionaria.IngresarNuevoCombustible();
                        }

                        else if (posicionActual == 1)
                        {
                            concesionaria.ListarCombustibles();
                        }

                        else if (posicionActual == 2)
                        {
                            concesionaria.ModificarCombustible();
                            concesionaria.actualizarCombustibles();
                        }

                        else if (posicionActual == 3)
                        {
                            concesionaria.BorrarCombustible();
                            concesionaria.actualizarCombustibles();
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        if (posicionActual == 0)
                            posicionActual = menuCombustible.Length - 1;
                        else
                            posicionActual--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (posicionActual == menuCombustible.Length - 1)
                            posicionActual = 0;
                        else
                            posicionActual++;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuSegmentos()
        {
            string[] menuSegmento = { "Agregar Segmento", "Listar Segmentos", "Modificar Segmento", "Eliminar Segmento", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;

            while (!bucle)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                Console.WriteLine("-------------------------------------------");

                for (int i = 0; i < menuSegmento.Length; i++)
                {
                    if (posicionActual == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (char)62 + " ");
                    }
                    Console.WriteLine(menuSegmento[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuSegmento.Length - 1)
                        {
                            Console.WriteLine("\nSaliendo del menú de parámetros.");
                            bucle = true;
                            MenuParametros();
                        }
                        else if (posicionActual == 0)
                        {
                            concesionaria.CargarSegmento();
                            concesionaria.actualizarSegmentos();
                        }

                        else if (posicionActual == 1)
                        {
                            concesionaria.ListarSegmentos();
                        }

                        else if (posicionActual == 2)
                        {
                            concesionaria.ModificarSegmento();
                            concesionaria.actualizarSegmentos();
                        }

                        else if (posicionActual == 3)
                        {
                            concesionaria.BorrarSegmento();
                            concesionaria.actualizarSegmentos();
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        if (posicionActual == 0)
                            posicionActual = menuSegmento.Length - 1;
                        else
                            posicionActual--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (posicionActual == menuSegmento.Length - 1)
                            posicionActual = 0;
                        else
                            posicionActual++;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
