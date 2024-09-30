using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Menu
    {
        string[] menuOpciones;
        int posicionActual;
        bool bucle;

        void MenuPrincipal()
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
                            Console.WriteLine("\nSaliendo...");
                            bucle = true;
                        }
                        else if (posicionActual == 0)
                        {
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
        void menuVehiculos()
        {
            string[] menuOpcionesClientes = { "Agregar nuevo vehículo", "Modificar vehículo", "Eliminar vehículo", "Listar vehículos", "Buscar vehículo", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;
        }   // Dentro de cada menú ha de consultar el tipo para acceder al constructor

            // Menú clientes
            void MenuClientes()
        {
            string[] menuOpcionesClientes = { "Agregar nuevo cliente", "Modificar cliente", "Eliminar cliente", "Listar clientes", "Buscar cliente", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;
        }

        // Menú Ventas
        void MenuVentas()
        {
            string[] menuOpcionesVentas = { "Realizar nueva venta", "Modificar venta", "Eliminar venta", "Listado de ventas", "Búsqueda de una venta", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;
        }

        // Menú Parámetros
        void MenuParametros()
        {
            string[] menuOpcionesParámetros = { "Marcas", "Modelos", "Colores", "Localidades", "Provincias", "Salir" };
            posicionActual = 0;
            Console.CursorVisible = false;
            bucle = false;
        }
    }
}
