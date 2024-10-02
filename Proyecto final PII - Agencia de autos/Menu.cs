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
                        posicionActual = Math.Max(0, posicionActual - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = Math.Min(menuOpciones.Length - 1, posicionActual + 1);
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        // Ménú vehículos
        void MenuVehiculos()
        {
            string[] menuOpcionesVehiculos = { "Agregar nuevo vehículo", "Modificar vehículo", "Eliminar vehículo", "Listar vehículos", "Buscar vehículo", "Salir" };
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
                            bucle = true;
                            // A probar. Tal vez haya que llamar a MenuVehiculos()
                        }
                        else if (posicionActual == 0)
                        {
                            concesionaria.CargarVehiculo();
                        }

                        else if (posicionActual == 1)
                        {
                            // concesionaria.ModificarVehiculo();
                        }

                        else if (posicionActual == 2)
                        {
                            // concesionaria.EliminarVehiculo();
                        }

                        else if (posicionActual == 3)
                        {
                            // concesionaria.ListarVehiculo();
                        }

                        else if (posicionActual == 4)
                        {
                            // concesionaria.BuscarVehiculo();
                        }

                        Console.WriteLine("\nPresione una tecla para continuar.");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = Math.Max(0, posicionActual - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = Math.Min(menuOpcionesVehiculos.Length - 1, posicionActual + 1);
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        // Menú clientes
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
                            // A probar. Tal vez haya que llamar a MenuVehiculos()
                        }
                        else if (posicionActual == 0)
                        {
                            // concesionaria.CargarCliente();
                        }

                        else if (posicionActual == 1)
                        {
                            // concesionaria.ModificarCliente();
                        }

                        else if (posicionActual == 2)
                        {
                            // concesionaria.EliminarCliente();
                        }

                        else if (posicionActual == 3)
                        {
                            // concesionaria.ListarCliente();
                        }

                        else if (posicionActual == 4)
                        {
                            // concesionaria.BuscarCliente();
                        }

                        Console.WriteLine("\nPresione una tecla para continuar.");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = Math.Max(0, posicionActual - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = Math.Min(menuOpcionesClientes.Length - 1, posicionActual + 1);
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        // Menú Ventas
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
                            // A probar. Tal vez haya que llamar a MenuVehiculos()
                        }
                        else if (posicionActual == 0)
                        {
                            // concesionaria.CargarVenta();
                        }

                        else if (posicionActual == 1)
                        {
                            // concesionaria.ModificarVenta();
                        }

                        else if (posicionActual == 2)
                        {
                            // concesionaria.EliminarVenta();
                        }

                        else if (posicionActual == 3)
                        {
                            // concesionaria.ListarVenta();
                        }

                        else if (posicionActual == 4)
                        {
                            // concesionaria.BuscarVenta();
                        }

                        Console.WriteLine("\nPresione una tecla para continuar.");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = Math.Max(0, posicionActual - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = Math.Min(menuOpcionesVentas.Length - 1, posicionActual + 1);
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        // Menú Parámetros
        void MenuParametros()
        {   // Agregar, listar, eliminar
            string[] menuOpcionesParametros = { "Marcas", "Modelos", "Colores", "Localidades", "Provincias", "Salir" };
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
                            // A probar. Tal vez haya que llamar a MenuVehiculos()
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

                        Console.WriteLine("\nPresione una tecla para continuar.");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = Math.Max(0, posicionActual - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = Math.Min(menuOpcionesParametros.Length - 1, posicionActual + 1);
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }

            void MenuMarcas()
            {   // Agregar, listar, eliminar
                string[] menuMarcas = { "Agregar marca", "Listar marcas", "Eliminar marca", "Salir" };
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
                                // concesionaria.AgregarMarca()
                            }

                            else if (posicionActual == 1)
                            {
                                // concesionaria.ListarMarca()
                            }

                            else if (posicionActual == 2)
                            {
                                // concesionaria.EliminarMarca()
                            }

                            Console.WriteLine("\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.UpArrow:
                            posicionActual = Math.Max(0, posicionActual - 1);
                            break;

                        case ConsoleKey.DownArrow:
                            posicionActual = Math.Min(menuMarcas.Length - 1, posicionActual + 1);
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            }

            void MenuModelos()
            {   // Agregar, listar, eliminar
                string[] menuModelos = { "Agregar modelo", "Listar modelos", "Eliminar modelo", "Salir" };
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
                                // A probar. Tal vez haya que llamar a MenuVehiculos()
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
                                // concesionaria.EliminarMarca()
                            }

                            Console.WriteLine("\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.UpArrow:
                            posicionActual = Math.Max(0, posicionActual - 1);
                            break;

                        case ConsoleKey.DownArrow:
                            posicionActual = Math.Min(menuModelos.Length - 1, posicionActual + 1);
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            }

            void MenuColores()
            {   // Agregar, listar, eliminar
                string[] menuColores = { "Agregar color", "Listar colores", "Eliminar color", "Salir" };
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
                                // A probar. Tal vez haya que llamar a MenuVehiculos()
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

                            Console.WriteLine("\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.UpArrow:
                            posicionActual = Math.Max(0, posicionActual - 1);
                            break;

                        case ConsoleKey.DownArrow:
                            posicionActual = Math.Min(menuColores.Length - 1, posicionActual + 1);
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            }

            void MenuLocalidades()
            {   // Agregar, listar, eliminar
                string[] menuLocalidades = { "Agregar localidad", "Listar localidades", "Eliminar localidad", "Salir" };
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
                                // A probar. Tal vez haya que llamar a MenuVehiculos()
                            }
                            else if (posicionActual == 0)
                            {
                                // concesionaria.AgregarLocalidad()
                            }

                            else if (posicionActual == 1)
                            {
                                // concesionaria.ListarLocalidad()
                            }

                            else if (posicionActual == 2)
                            {
                                // concesionaria.EliminarLocalidad()
                            }

                            Console.WriteLine("\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.UpArrow:
                            posicionActual = Math.Max(0, posicionActual - 1);
                            break;

                        case ConsoleKey.DownArrow:
                            posicionActual = Math.Min(menuLocalidades.Length - 1, posicionActual + 1);
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            }

            void MenuProvincias()
            {   // Agregar, listar, eliminar
                string[] menuProvincias = { "Agregar provincia", "Listar provincias", "Eliminar provincia", "Salir" };
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
                                // A probar. Tal vez haya que llamar a MenuVehiculos()
                            }
                            else if (posicionActual == 0)
                            {
                                // concesionaria.AgregarProvincia()
                            }

                            else if (posicionActual == 1)
                            {
                                // concesionaria.ListarProvincia()
                            }

                            else if (posicionActual == 2)
                            {
                                // concesionaria.EliminarProvincia()
                            }

                            Console.WriteLine("\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.UpArrow:
                            posicionActual = Math.Max(0, posicionActual - 1);
                            break;

                        case ConsoleKey.DownArrow:
                            posicionActual = Math.Min(menuProvincias.Length - 1, posicionActual + 1);
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
