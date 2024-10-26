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
        bool subbucle;
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
                Console.WriteLine("Seleccione una opción con las flechas \u2191 y \u2193");
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
                            MenuClientes(20, 1);
                        }

                        else if (posicionActual == 2)
                        {
                            MenuVentas(20, 2);
                        }

                        else if (posicionActual == 3)
                        {
                            MenuParametros(20, 3);
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = (posicionActual == 0) ? menuOpciones.Length - 1 : posicionActual - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = (posicionActual == menuOpciones.Length - 1) ? 0 : posicionActual + 1;
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
            bool subbucle = false;

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
            Console.WriteLine("-------------------------------------------");

            while (!subbucle)
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
                            return;
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
                                            Console.Clear();
                                            Console.ResetColor();
                                            subbucle = true;
                                            MenuPrincipal();

                                            return; 
                                        }

                                        else if (posicionActual == 0)
                                        {
                                            Console.Clear();
                                            concesionaria.IngresarAutoCamioneta();
                                            concesionaria.ActualizarAutoCamioneta();
                                            Console.Clear();
                                            MenuPrincipal();
                                            return;
                                        }
                                        else if (posicionActual == 1)
                                        {
                                            Console.Clear();
                                            concesionaria.IngresarMoto();
                                            concesionaria.ActualizarMotos();
                                            Console.Clear();
                                            MenuPrincipal();
                                            return;
                                        }
                                        else if (posicionActual == 2)
                                        {
                                            Console.Clear();
                                            concesionaria.IngresarCamion();
                                            concesionaria.ActualizarCamiones();
                                            Console.Clear();
                                            MenuPrincipal();
                                            return;
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
                            Console.Clear();
                            concesionaria.ModificarVehiculo();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }
                        else if (posicionActual == 2)
                        {
                            Console.Clear();
                            concesionaria.BorrarVehiculo();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }
                        else if (posicionActual == 3)
                        {
                            
                            Console.Clear();
                            concesionaria.MostrarVehiculos();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }
                        else if (posicionActual == 4)
                        {
                            Console.Clear();
                            concesionaria.BuscarVehiculo();
                            Console.Clear();
                            MenuPrincipal();
                            return;
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

        void MenuClientes(int posX, int posY)
        {
            string[] menuOpcionesClientes = { "Agregar nuevo cliente", "Modificar cliente", "Eliminar cliente", "Listar clientes", "Buscar cliente", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            subbucle = false;

            while (!subbucle)
            {
                for (int i = 0; i < menuOpcionesClientes.Length; i++)
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

                    Console.WriteLine(menuOpcionesClientes[i]);
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuOpcionesClientes.Length - 1) // "Salir"
                        {
                            Console.Clear();
                            Console.ResetColor();
                            MenuPrincipal();
                            return;
                        }
                        else if (posicionActual == 0)
                        {
                            Console.Clear();
                            concesionaria.CargarCliente();
                            concesionaria.ActualizarClientes();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 1)
                        {
                            Console.Clear();
                            concesionaria.ModificarCliente();
                            concesionaria.ActualizarClientes();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 2)
                        {
                            Console.Clear();
                            concesionaria.BorrarCliente();
                            concesionaria.ActualizarClientes();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 3)
                        {
                            Console.Clear();
                            concesionaria.ListarClientes();
                            Console.Clear();
                            return;
                        }

                        else if (posicionActual == 4)
                        {
                            Console.Clear();
                            concesionaria.BuscarCliente();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = (posicionActual == 0) ? menuOpcionesClientes.Length - 1 : posicionActual - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = (posicionActual == menuOpcionesClientes.Length - 1) ? 0 : posicionActual + 1;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuVentas(int posX, int posY)
        {
            string[] menuOpcionesVentas = { "Realizar nueva venta", "Modificar venta", "Eliminar venta", "Listado de ventas", "Búsqueda de una venta", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            subbucle = false;

            while (!subbucle)
            {
                for (int i = 0; i < menuOpcionesVentas.Length; i++)
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

                    Console.WriteLine(menuOpcionesVentas[i]);
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuOpcionesVentas.Length - 1) // "Salir"
                        {
                            Console.Clear();
                            Console.ResetColor();
                            MenuPrincipal();
                            return;
                        }
                        else if (posicionActual == 0)
                        {
                            Console.Clear();
                            concesionaria.CargarVenta();
                            concesionaria.ActualizarVentas();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 1)
                        {
                            Console.Clear();
                            concesionaria.ModificarVenta();
                            concesionaria.ActualizarVentas();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 2)
                        {
                            Console.Clear();
                            concesionaria.BorrarVenta();
                            concesionaria.ActualizarVentas();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 3)
                        {
                            Console.Clear();
                            concesionaria.ListarVentas();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 4)
                        {
                            Console.Clear();
                            concesionaria.BuscarVenta();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = (posicionActual == 0) ? menuOpcionesVentas.Length - 1 : posicionActual - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = (posicionActual == menuOpcionesVentas.Length - 1) ? 0 : posicionActual + 1;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuParametros(int posX, int posY)
        {
            string[] menuOpcionesParametros = { "Marcas", "Localidades", "Provincias", "Combustible", "Segmento", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            subbucle = false;

            while (!subbucle)
            {
                for (int i = 0; i < menuOpcionesParametros.Length; i++)
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

                    Console.WriteLine(menuOpcionesParametros[i]);
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuOpcionesParametros.Length - 1) // "Salir"
                        {
                            Console.Clear();
                            Console.ResetColor();
                            MenuPrincipal();
                            return;
                        }
                        else if (posicionActual == 0) // Marcas
                        {
                            MenuMarcas(40, 3);
                        }

                        else if (posicionActual == 1) // Localidades
                        {
                            MenuLocalidades(40, 4);
                        }

                        else if (posicionActual == 2) // Provincias
                        {
                            MenuProvincias(40, 5);
                        }

                        else if (posicionActual == 3) // Combustibles
                        {
                            MenuCombustibles(40, 6);
                        }

                        else if (posicionActual == 4) // Segmentos
                        {
                            MenuSegmentos(40, 7);
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = (posicionActual == 0) ? menuOpcionesParametros.Length - 1 : posicionActual - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = (posicionActual == menuOpcionesParametros.Length - 1) ? 0 : posicionActual + 1;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuMarcas(int posX, int posY)
        {
            string[] menuMarcas = { "Agregar marca", "Listar marcas", "Modificar marca", "Eliminar marca", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            subbucle = false;

            while (!subbucle)
            {
                for (int i = 0; i < menuMarcas.Length; i++)
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

                    Console.WriteLine(menuMarcas[i]);
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuMarcas.Length - 1) // "Salir"
                        {
                            Console.Clear();
                            Console.ResetColor();
                            MenuPrincipal();
                            return;
                        }
                        else if (posicionActual == 0)
                        {
                            Console.Clear();
                            concesionaria.IngresarMarca();
                            concesionaria.ActualizarMarcas();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 1)
                        {
                            Console.Clear();
                            concesionaria.ListarMarcas();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 2)
                        {
                            Console.Clear();
                            concesionaria.ModificarMarca();
                            concesionaria.ActualizarMarcas();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 3)
                        {
                            Console.Clear();
                            concesionaria.BorrarMarca();
                            concesionaria.ActualizarMarcas();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = (posicionActual == 0) ? menuMarcas.Length - 1 : posicionActual - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = (posicionActual == menuMarcas.Length - 1) ? 0 : posicionActual + 1;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuLocalidades(int posX, int posY)
        {
            string[] menuLocalidades = { "Agregar localidad", "Listar localidades", "Modificar localidad", "Eliminar localidad", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            subbucle = false;

            while (!subbucle)
            {
                for (int i = 0; i < menuLocalidades.Length; i++)
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

                    Console.WriteLine(menuLocalidades[i]);
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuLocalidades.Length - 1)
                        {
                            Console.Clear();
                            Console.ResetColor();
                            MenuPrincipal();
                            return;
                        }
                        else if (posicionActual == 0)
                        {
                            Console.Clear();
                            concesionaria.CargarLocalidad();
                            concesionaria.actualizarLocalidades();
                            Console.Clear();
                        }

                        else if (posicionActual == 1)
                        {
                            Console.Clear();
                            concesionaria.ListarLocalidades();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 2)
                        {
                            Console.Clear();
                            concesionaria.ModificarLocalidad();
                            concesionaria.actualizarLocalidades();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 3)
                        {
                            Console.Clear();
                            concesionaria.BorrarLocalidad();
                            concesionaria.actualizarLocalidades();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = (posicionActual == 0) ? menuLocalidades.Length - 1 : posicionActual - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = (posicionActual == menuLocalidades.Length - 1) ? 0 : posicionActual + 1;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuProvincias(int posX, int posY)
        {
            string[] menuProvincias = { "Agregar provincia", "Listar provincias", "Modificar provincia", "Eliminar provincia", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            subbucle = false;

            while (!subbucle)
            {
                for (int i = 0; i < menuProvincias.Length; i++)
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

                    Console.WriteLine(menuProvincias[i]);
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuProvincias.Length - 1)
                        {
                            Console.Clear();
                            Console.ResetColor();
                            MenuPrincipal();
                            return;
                        }
                        else if (posicionActual == 0)
                        {
                            Console.Clear();
                            concesionaria.CargarProvincia();
                            concesionaria.actualizarProvincias();
                            Console.Clear();
                        }

                        else if (posicionActual == 1)
                        {
                            Console.Clear();
                            concesionaria.ListarProvincias();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 2)
                        {
                            Console.Clear();
                            concesionaria.ModificarProvincia();
                            concesionaria.actualizarProvincias();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 3)
                        {
                            Console.Clear();
                            concesionaria.BorrarProvincia();
                            concesionaria.actualizarProvincias();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = (posicionActual == 0) ? menuProvincias.Length - 1 : posicionActual - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = (posicionActual == menuProvincias.Length - 1) ? 0 : posicionActual + 1;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuCombustibles(int posX, int posY)
        {
            string[] menuCombustibles = { "Agregar combustible", "Listar combustibles", "Modificar combustible", "Eliminar combustible", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            subbucle = false;

            while (!subbucle)
            {
                for (int i = 0; i < menuCombustibles.Length; i++)
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

                    Console.WriteLine(menuCombustibles[i]);
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuCombustibles.Length - 1)
                        {
                            Console.Clear();
                            Console.ResetColor();
                            MenuPrincipal();
                            return;
                        }
                        else if (posicionActual == 0)
                        {
                            Console.Clear();
                            concesionaria.IngresarNuevoCombustible();
                            concesionaria.actualizarCombustibles();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 1)
                        {
                            Console.Clear();
                            concesionaria.ListarCombustibles();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 2)
                        {
                            Console.Clear();
                            concesionaria.ModificarCombustible();
                            concesionaria.actualizarCombustibles();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 3)
                        {
                            Console.Clear();
                            concesionaria.BorrarCombustible();
                            concesionaria.actualizarCombustibles();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = (posicionActual == 0) ? menuCombustibles.Length - 1 : posicionActual - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = (posicionActual == menuCombustibles.Length - 1) ? 0 : posicionActual + 1;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        void MenuSegmentos(int posX, int posY)
        {
            string[] menuSegmentos = { "Agregar Segmento", "Listar Segmentos", "Modificar Segmento", "Eliminar Segmento", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            subbucle = false;

            while (!subbucle)
            {
                for (int i = 0; i < menuSegmentos.Length; i++)
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

                    Console.WriteLine(menuSegmentos[i]);
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuSegmentos.Length - 1)
                        {
                            Console.Clear();
                            Console.ResetColor();
                            MenuPrincipal();
                            return;
                        }
                        else if (posicionActual == 0)
                        {
                            Console.Clear();
                            concesionaria.CargarSegmento();
                            concesionaria.actualizarSegmentos();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 1)
                        {
                            Console.Clear();
                            concesionaria.ListarSegmentos();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 2)
                        {
                            Console.Clear();
                            concesionaria.ModificarSegmento();
                            concesionaria.actualizarSegmentos();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        else if (posicionActual == 3)
                        {
                            Console.Clear();
                            concesionaria.BorrarSegmento();
                            concesionaria.actualizarSegmentos();
                            Console.Clear();
                            MenuPrincipal();
                            return;
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = (posicionActual == 0) ? menuSegmentos.Length - 1 : posicionActual - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = (posicionActual == menuSegmentos.Length - 1) ? 0 : posicionActual + 1;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
