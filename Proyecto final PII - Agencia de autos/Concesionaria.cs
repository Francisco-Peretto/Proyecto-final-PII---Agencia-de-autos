using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Concesionaria
    {
        public Concesionaria() { }

        public void CargarVehiculo()
        {
            int id_vehiculo, anio, id_marca, id_combustible, id_segmento;
            string patente, observaciones, color, modelo;
            double kilometros, precio_vta;
            // Los métodos Array van a desaparecer o a modificarse una vez estén las listas

            Console.Write("Ingrese el id del vehículo a registrar: "); // ID vehículo
            if (!int.TryParse(Console.ReadLine(), out id_vehiculo))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }

            // Convencionar los detalles de las patentes
            Console.Write("Ingrese la patente del vehículo a registrar: "); // Patente
            patente = Console.ReadLine();

            Console.Write("Ingrese los kilómetros del vehículo a registrar: "); // Kilómetros
            if (!double.TryParse(Console.ReadLine(), out kilometros))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }

            Console.Write("Ingrese el año del vehículo a registrar: "); // Año. Se puede establecer rango min-max
            if (!int.TryParse(Console.ReadLine(), out anio))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }

            id_marca = ArrayMarcas(); // id_marca INCOMPLETO. FALTA ARRAY DE MARCAS

            id_combustible = ArrayCombustibles();

            Console.Write("Ingrese el precio de venta del vehículo a registrar: "); // Precio
            if (!double.TryParse(Console.ReadLine(), out precio_vta))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }

            Console.Write("Ingrese las observaciones del vehículo a registrar o déje el espacio en blanco: "); // Observaciones
            observaciones = Console.ReadLine();
            if (observaciones == "")
            {
                observaciones = "Sin observaciones";
            }

            Console.Write("Ingrese el color del vehículo a registrar: "); // color. SE PUEDE HACER UNA LISTA DE COLORES
            color = Console.ReadLine();

            // modelo = arrayModelo();
            modelo = Console.ReadLine();

            // id_segmento. 1-4 auto, 5-7 moto, 8 camión
            id_segmento = ArraySegmentos();

            switch (id_segmento)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    // va a funcionar bien hasta arreglar los detalles
                    AutoCamioneta autoCamioneta = new AutoCamioneta(id_vehiculo, patente, kilometros, anio, id_marca, modelo, id_segmento, id_combustible,
                 precio_vta, observaciones, color);
                    //Agregar a lista
                    break;
                case 5:
                case 6:
                case 7:
                    int cilindrada;
                    Console.Write("Ingrese la cilindrada de la moto a registrar: "); // cilindrada. Se puede establecer lista de cilindradas
                    if (!int.TryParse(Console.ReadLine(), out cilindrada))
                    {
                        Console.WriteLine("Error. Presione una tecla y reintente.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    // va a funcionar bien hasta arreglar los detalles
                    Moto moto = new Moto(id_vehiculo, patente, kilometros, anio, id_marca, modelo, id_segmento, id_combustible, precio_vta, observaciones, color, cilindrada);

                    break;
                case 8:

                    int caja_carga, dimension_caja, carga_max;
                    Console.Write("Ingrese la caja de carga del camión a registrar: "); // caja_carga. Esto qué es? Un INT?
                    if (!int.TryParse(Console.ReadLine(), out caja_carga))
                    {
                        Console.WriteLine("Error. Presione una tecla y reintente.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    Console.Write("Ingrese la dimensión de la caja a registrar: "); // dimension_caja supongo que es un volúmen en cm3? también se puede pedir ancho * largo * profundidad pero me parece demasiado
                    if (!int.TryParse(Console.ReadLine(), out dimension_caja))
                    {
                        Console.WriteLine("Error. Presione una tecla y reintente.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    Console.Write("Ingrese la carga máxima del camión a registrar: "); // carga_max
                    if (!int.TryParse(Console.ReadLine(), out carga_max))
                    {
                        Console.WriteLine("Error. Presione una tecla y reintente.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    // va a funcionar bien hasta arreglar los detalles
                    Camion camion = new Camion(id_vehiculo, patente, kilometros, anio, id_marca, modelo, id_segmento, id_combustible, precio_vta, observaciones, color, caja_carga, dimension_caja, carga_max);
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        int ArraySegmentos()
        {
            int id_segmento = 0;
            string[] segmentos = { "1 - Sedan", "2 - Coupe", "3 - SUV", "4 - Pick Up", "5 - Enduro", "6 - Rutera", "7 - Scooter", "8 - Camión" };
            bool loopSegmento = false;

            while (!loopSegmento)
            {
                foreach (string segmento in segmentos)
                {
                    Console.WriteLine(segmento);
                }

                Console.Write("Ingrese el número correspondiente al tipo de vehículo a registrar: ");

                if (!int.TryParse(Console.ReadLine(), out id_segmento) && id_segmento >= 1 && id_segmento <= 8)
                {
                    Console.WriteLine("Error. Presione una tecla y reintente.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    loopSegmento = true;
                    return id_segmento;
                }
            }
            return 0;
        }

        int ArrayMarcas() // INCOMPLETO. FALTA ARRAY DE MARCAS
        {
            int id_marca = 0;
            string[] marcas = { "" };
            bool loopMarca = false;

            while (!loopMarca)
            {
                foreach (string marca in marcas)
                {
                    Console.WriteLine(marca);
                }

                Console.Write("Ingrese el número correspondiente a la marca del vehículo a registrar: ");

                if (!int.TryParse(Console.ReadLine(), out id_marca) && id_marca >= 1 && id_marca <= 8) // modificar
                {
                    Console.WriteLine("Error. Presione una tecla y reintente.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    loopMarca = true;
                    return id_marca;
                }
            }
            return 0;
        }

        int ArrayCombustibles()
        {
            int id_combustible = 0;
            string[] combustibles = { "1 - Nafta", "2 - Diesel", "3 - GNC", "4 - Eléctrico" };
            bool loopCombustible = false;

            while (!loopCombustible)
            {
                foreach (string combustible in combustibles)
                {
                    Console.WriteLine(combustible);
                }

                Console.Write("Ingrese el número correspondiente al tipo de combustible: ");

                if (!int.TryParse(Console.ReadLine(), out id_combustible) || id_combustible < 1 || id_combustible > 4)
                {
                    Console.WriteLine("Error. Presione una tecla y reintente.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    loopCombustible = true;
                    return id_combustible;
                }
            }
            return 0;
        }
    }
}
