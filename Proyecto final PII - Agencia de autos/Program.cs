using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Concesionaria con = new Concesionaria ();
            Vehiculo vehiculo = new Vehiculo ();
            Menu menu = new Menu ();
            menu.MenuPrincipal();
            int opc;
            /*
            con.CargarVehiculo();
            con.mostrarDatos();
            Console.ReadKey();
            */
            do
            {
                Console.Clear();
                con.CargarVehiculo();
                con.mostrarVehiculos();
                Console.WriteLine("\n\nIngrese 1");
                opc = int.Parse(Console.ReadLine());
            } while (opc == 1);
             Console.ReadKey();
            /*
            Menu menu = new Menu();
            menu.MenuPrincipal();

            /* Notas de Fran:
             * Dejé varias notas el registro de un vehículo nuevo en año, id_marca, color, cilindrada, caja_carga
              Al tener que limpiar la consola O luego de cada ingreso correcto de vehículos/clientes se puede listar las cosas ya establecidas.
            Supongo que habría que hacer un array dinámico, quizá dejarlo para el final
            Ej:
            Id_vehiculo: 1
            Patente: ADEC1234
            Kilómetros = 123494

            Ingrese ...

            --------------

            Clases obligatorias según DER: Marca, Segmento, Combustible, Cliente, Localidad, Provincia, Vehiculo, Auto/Camioneta, Moto, Camion
            A contemplar: Color, Modelo
            Caja_carga es un bool sí/no??
            Falta id_venta en Venta
             */
        }
    }
}
