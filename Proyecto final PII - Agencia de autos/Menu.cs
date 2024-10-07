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
                            MenuVehiculos();
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

                        Console.WriteLine("\nPresione una tecla para continuar.");
                        Console.ReadKey();
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
    
        void MenuVehiculos()
        {
            string[] menuOpcionesVehiculos = { "Registrar nuevo vehículo", "Modificar un vehículo existente", "Eliminar un vehículo existente", "Listar vehículos", "Buscar un vehículo", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;

            while (!bucle)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                Console.WriteLine("-------------------------------------------");

                for (int i = 0; i < menuOpcionesVehiculos.Length; i++)
                {
                    if (posicionActual == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (char)62 + " ");
                    }
                    Console.WriteLine(menuOpcionesVehiculos[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuOpcionesVehiculos.Length - 1)
                        {
                            Console.WriteLine("\nSaliendo del menú de vehículos.");
                            MenuPrincipal();
                        }
                        else if (posicionActual == 0)
                        {
                            string[] menuTresVehiculos = { "Registrar un auto o una camioneta", "Registar una moto", "Registrar un camión", "Salir" };
                            posicionActual = 0;
                            Console.CursorVisible = false;
                            bucle = false;

                            while (!bucle)
                            {
                                Console.Clear();
                                Console.ResetColor();
                                Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                                Console.WriteLine("-------------------------------------------");

                                for (int i = 0; i < menuTresVehiculos.Length; i++)
                                {
                                    if (posicionActual == i)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Blue;
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(" " + (char)62 + " ");
                                    }
                                    Console.WriteLine(menuTresVehiculos[i]);
                                    Console.ResetColor();
                                }

                                ConsoleKeyInfo tecla2 = Console.ReadKey();
                                switch (tecla2.Key)
                                {
                                    case ConsoleKey.Enter:
                                    case ConsoleKey.Spacebar:
                                        if (posicionActual == menuTresVehiculos.Length - 1)
                                        {
                                            Console.WriteLine("\nSaliendo del menú de vehículos.");
                                            bucle = true;
                                            MenuVehiculos();
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
                                            concesionaria.ActualizarCamiones();
                                        }

                                        Console.WriteLine("\nPresione una tecla para continuar.");
                                        Console.ReadKey();
                                        break;

                                    case ConsoleKey.UpArrow:
                                        if (posicionActual == 0)
                                            posicionActual = menuTresVehiculos.Length - 1;
                                        else
                                            posicionActual--;
                                        break;

                                    case ConsoleKey.DownArrow:
                                        if (posicionActual == menuTresVehiculos.Length - 1)
                                            posicionActual = 0;
                                        else
                                            posicionActual++;
                                        break;

                                    default:
                                        Console.WriteLine("Opción no válida.");
                                        break;

                                }
                            }
                        } // Registrar vehículo

                        else if (posicionActual == 1)
                        {

                            concesionaria.ModificarVehiculo(); //MODIFICA
                            //Actualiza los txt
                            concesionaria.ActualizarAutoCamioneta();
                            concesionaria.ActualizarCamiones();
                            concesionaria.ActualizarMotos();

                            //string[] menuTresModificaciones = { "Modificar un auto o una camioneta", "Modificar una moto", "Modificar un camión", "Salir" };
                            //posicionActual = 0;
                            //Console.CursorVisible = false;
                            //bucle = false;

                            //while (!bucle)
                            //{
                            //    Console.Clear();
                            //    Console.ResetColor();
                            //    Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                            //    Console.WriteLine("-------------------------------------------");

                            //    for (int i = 0; i < menuTresModificaciones.Length; i++)
                            //    {
                            //        if (posicionActual == i)
                            //        {
                            //            Console.BackgroundColor = ConsoleColor.Blue;
                            //            Console.ForegroundColor = ConsoleColor.Yellow;
                            //            Console.Write(" " + (char)62 + " ");
                            //        }
                            //        Console.WriteLine(menuTresModificaciones[i]);
                            //        Console.ResetColor();
                            //    }

                            //    ConsoleKeyInfo tecla2 = Console.ReadKey();
                            //    switch (tecla2.Key)
                            //    {
                            //        case ConsoleKey.Enter:
                            //        case ConsoleKey.Spacebar:
                            //            if (posicionActual == menuTresModificaciones.Length - 1)
                            //            {
                            //                Console.WriteLine("\nSaliendo del menú de vehículos.");
                            //                bucle = true;
                            //                MenuVehiculos();
                            //            } 
                            //            else if (posicionActual == 0) // Buscar por ID
                            //            {
                            //                concesionaria.ActualizarAutoCamioneta();
                            //            }

                            //            else if (posicionActual == 1)
                            //            {
                            //                concesionaria.ActualizarMotos();
                            //            }

                            //            else if (posicionActual == 2)
                            //            {
                            //                concesionaria.ActualizarCamiones();
                            //            }

                            //            Console.WriteLine("\nPresione una tecla para continuar.");
                            //            Console.ReadKey();
                            //            break;

                            //        case ConsoleKey.UpArrow:
                            //            if (posicionActual == 0)
                            //                posicionActual = menuTresModificaciones.Length - 1;
                            //            else
                            //                posicionActual--;
                            //            break;

                            //        case ConsoleKey.DownArrow:
                            //            if (posicionActual == menuTresModificaciones.Length - 1)
                            //                posicionActual = 0;
                            //            else
                            //                posicionActual++;
                            //            break;

                            //        default:
                            //            Console.WriteLine("Opción no válida.");
                            //            break;

                            //    }
                            //}
                        } // Modificar un vehículo

                        else if (posicionActual == 2)
                        {
                            concesionaria.BorrarVehiculo();
                            concesionaria.ActualizarAutoCamioneta();
                            concesionaria.ActualizarCamiones();
                            concesionaria.ActualizarMotos();
                        } // Eliminar un vehículo

                        else if (posicionActual == 3)
                        {
                            concesionaria.MostrarVehiculos();
                        } // Listar vehículos

                        else if (posicionActual == 4)
                        {
                            string[] menuBuscar = { "Buscar un auto o una camioneta", "Buscar una moto", "Buscar un camión", "Salir" };
                            posicionActual = 0;
                            Console.CursorVisible = false;
                            bucle = false;

                            while (!bucle)
                            {
                                Console.Clear();
                                Console.ResetColor();
                                Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                                Console.WriteLine("-------------------------------------------");

                                for (int i = 0; i < menuBuscar.Length; i++)
                                {
                                    if (posicionActual == i)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Blue;
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(" " + (char)62 + " ");
                                    }
                                    Console.WriteLine(menuBuscar[i]);
                                    Console.ResetColor();
                                }

                                ConsoleKeyInfo tecla2 = Console.ReadKey();
                                switch (tecla2.Key)
                                {
                                    case ConsoleKey.Enter:
                                    case ConsoleKey.Spacebar:
                                        if (posicionActual == menuBuscar.Length - 1)
                                        {
                                            Console.WriteLine("\nSaliendo del menú de vehículos.");
                                            bucle = true;
                                            MenuVehiculos();
                                        }
                                        else if (posicionActual == 0)
                                        {
                                            // concesionario.BuscarAutos();
                                        }

                                        else if (posicionActual == 1)
                                        {
                                            // concesionario.BuscarMotos();
                                        }

                                        else if (posicionActual == 2)
                                        {
                                            // concesionaria.BuscarCamiones();
                                        }

                                        Console.WriteLine("\nPresione una tecla para continuar.");
                                        Console.ReadKey();
                                        break;

                                    case ConsoleKey.UpArrow:
                                        if (posicionActual == 0)
                                            posicionActual = menuBuscar.Length - 1;
                                        else
                                            posicionActual--;
                                        break;

                                    case ConsoleKey.DownArrow:
                                        if (posicionActual == menuBuscar.Length - 1)
                                            posicionActual = 0;
                                        else
                                            posicionActual++;
                                        break;

                                    default:
                                        Console.WriteLine("Opción no válida.");
                                        break;

                                }
                            }
                        } // Buscar vehículo (PARA MI NO VA - GENA)
                        
                        Console.WriteLine("\nPresione una tecla para continuar.");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.UpArrow:
                        if (posicionActual == 0)
                            posicionActual = menuOpcionesVehiculos.Length - 1;
                        else
                            posicionActual--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (posicionActual == menuOpcionesVehiculos.Length - 1)
                            posicionActual = 0;
                        else
                            posicionActual++;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                    break;
                }    
            }
        } // FALTA búsqueda

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

                        else if (posicionActual == 4) //(PARA MI NO VA- GENA)
                        {
                            // concesionaria.BuscarCliente();
                        }

                        Console.WriteLine("\nPresione una tecla para continuar.");
                        Console.ReadKey();
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

                        else if (posicionActual == 4) //IDEM DEMAS
                        {
                            // concesionaria.BuscarVenta();
                        }

                        Console.WriteLine("\nPresione una tecla para continuar.");
                        Console.ReadKey();
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
        {   // Agregar, listar, eliminar
            string[] menuOpcionesParametros = { "Marcas", "Modelos", "Colores", "Localidades", "Provincias", "Combustible", "Segmento", "Salir" };
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

                        else if (posicionActual == 1) // Modelos
                        {
                            MenuModelos();
                        }

                        else if (posicionActual == 2) // Colores
                        {
                            MenuColores();
                        }

                        else if (posicionActual == 3) // Localidades
                        {
                            MenuLocalidades();
                        }

                        else if (posicionActual == 4) // Provincias
                        {
                            MenuProvincias();
                        }

                        else if (posicionActual == 4) // Combustibles
                        {
                            MenuCombustibles();
                        }

                        else if (posicionActual == 4) // Segmentos
                        {
                            MenuSegmentos();
                        }

                        Console.WriteLine("\nPresione una tecla para continuar.");
                        Console.ReadKey();
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

            void MenuMarcas()
            {   // Agregar, listar, eliminar
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
                                // A probar. Tal vez haya que llamar a MenuVehiculos()
                            }
                            else if (posicionActual == 0)
                            {
                                concesionaria.IngresarMarca();
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

                            Console.WriteLine("\nPresione una tecla para continuar.");
                            Console.ReadKey();
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

            
            void MenuModelos()
            {   // Agregar, listar, eliminar
                string[] menuModelos = { "Agregar modelo", "Listar modelos", "Modificar modelo", "Eliminar modelo", "Salir" };
                posicionActual = 0;
                Console.CursorVisible = false;
                bucle = false;

                while (!bucle)
                {
                    Console.Clear();
                    Console.ResetColor();
                    Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                    Console.WriteLine("-------------------------------------------");

                    for (int i = 0; i < menuModelos.Length; i++)
                    {
                        if (posicionActual == i)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" " + (char)62 + " ");
                        }
                        Console.WriteLine(menuModelos[i]);
                        Console.ResetColor();
                    }

                    ConsoleKeyInfo tecla = Console.ReadKey();
                    switch (tecla.Key)
                    {
                        case ConsoleKey.Enter:
                        case ConsoleKey.Spacebar:
                            if (posicionActual == menuModelos.Length - 1)
                            {
                                Console.WriteLine("\nSaliendo del menú de parámetros.");
                                bucle = true;
                                MenuParametros();
                            }
                            else if (posicionActual == 0)
                            {
                                // concesionaria.AgregarMarca()
                            }

                            else if (posicionActual == 1)
                            {
                                // concesionaria.ListarMarca()
                            }

                            else if (posicionActual == 2)
                            {
                                // concesionaria.ModificarMarca()
                            }

                            else if (posicionActual == 2)
                            {
                                // concesionaria.EliminarMarca()
                            }

                            Console.WriteLine("\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.UpArrow:
                            if (posicionActual == 0)
                                posicionActual = menuModelos.Length - 1;
                            else
                                posicionActual--;
                            break;

                        case ConsoleKey.DownArrow:
                            if (posicionActual == menuModelos.Length - 1)
                                posicionActual = 0;
                            else
                                posicionActual++;
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            } //IDEM

            void MenuColores()
            {   // Agregar, listar, eliminar
                string[] menuColores = { "Agregar color", "Listar colores", "Modificar color", "Eliminar color", "Salir" };
                posicionActual = 0;
                Console.CursorVisible = false;
                bucle = false;

                while (!bucle)
                {
                    Console.Clear();
                    Console.ResetColor();
                    Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                    Console.WriteLine("-------------------------------------------");

                    for (int i = 0; i < menuColores.Length; i++)
                    {
                        if (posicionActual == i)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" " + (char)62 + " ");
                        }
                        Console.WriteLine(menuColores[i]);
                        Console.ResetColor();
                    }

                    ConsoleKeyInfo tecla = Console.ReadKey();
                    switch (tecla.Key)
                    {
                        case ConsoleKey.Enter:
                        case ConsoleKey.Spacebar:
                            if (posicionActual == menuColores.Length - 1)
                            {
                                Console.WriteLine("\nSaliendo del menú de parámetros.");
                                bucle = true;
                                MenuParametros();
                            }
                            else if (posicionActual == 0)
                            {
                                // concesionaria.AgregarColor()
                            }

                            else if (posicionActual == 1)
                            {
                                // concesionaria.ListarColor()
                            }

                            else if (posicionActual == 2)
                            {
                                // concesionaria.EliminarColor()
                            }

                            else if (posicionActual == 3)
                            {
                                // concesionaria.EliminarColor()
                            }

                            Console.WriteLine("\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.UpArrow:
                            if (posicionActual == 0)
                                posicionActual = menuColores.Length - 1;
                            else
                                posicionActual--;
                            break;

                        case ConsoleKey.DownArrow:
                            if (posicionActual == menuColores.Length - 1)
                                posicionActual = 0;
                            else
                                posicionActual++;
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            } //IDEM

            void MenuLocalidades()
            {   // Agregar, listar, eliminar
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

                            Console.WriteLine("\nPresione una tecla para continuar.");
                            Console.ReadKey();
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
            {   // Agregar, listar, eliminar
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
                            }

                            else if (posicionActual == 1)
                            {
                                concesionaria.ListarProvincias();
                            }

                            else if (posicionActual == 2)
                            {
                                concesionaria.ModificarProvincia();
                            }

                            else if (posicionActual == 3)
                            {
                                concesionaria.BorrarProvincia();
                            }

                            Console.WriteLine("\nPresione una tecla para continuar.");
                            Console.ReadKey();
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
            {   // Agregar, listar, eliminar
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

                            Console.WriteLine("\nPresione una tecla para continuar.");
                            Console.ReadKey();
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
            {   // Agregar, listar, eliminar
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

                            Console.WriteLine("\nPresione una tecla para continuar.");
                            Console.ReadKey();
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
}
