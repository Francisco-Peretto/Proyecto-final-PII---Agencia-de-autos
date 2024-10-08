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
            // testeo de push --- Franco 
            
            string vehiculosArchivo = "Vehiculos.txt";
            string ventasArchivo = "Ventas.txt";
            string clientesArchivo = "Clientes.txt";
            string marcasArchivo = "Marcas.txt";
            string segmentosArchivo = "Segmentos.txt";
            string combustiblesArchivo = "Combustibles.txt";
            string localidadesArchivo = "Localidades.txt";
            string provinciasArchivo = "Provincias.txt";
            string motosArchivo = "Motos.txt";
            string autosCamionetasArchivo = "Autoscamionetas.txt";
            string camionesArchivo = "Camion.txt";


            Concesionaria con = new Concesionaria ();
            con.CargarAutosCamionetas(autosCamionetasArchivo);
            con.CargarCamiones(camionesArchivo);
            /*
            con.CargarVehiculos(vehiculosArchivo);
            con.CargarVentas(ventasArchivo);
            con.CargarClientes(clientesArchivo);
            con.CargarMarcas(marcasArchivo);
            con.CargarSegmentos(segmentosArchivo);
            con.CargarCombustibles(combustiblesArchivo);
            con.CargarLocalidades(localidadesArchivo);
            con.CargarProvincias(provinciasArchivo);
            con.CargarMotos(motosArchivo);
            con.CargarAutosCamionetas(autosCamionetasArchivo);
            con.CargarCamiones(camionesArchivo);
            con.actualizarProvincias();
            con.actualizarCombustibles();
            con.actualizarLocalidades();
            con.actualizarSegmentos();
            con.ActualizarAutoCamioneta();
            con.ActualizarCamiones();
            con.ActualizarClientes();
            con.ActualizarMarcas();
            con.ActualizarMotos();
            con.ActualizarVentas();
            */


            Vehiculo vehiculo = new Vehiculo ();
            Menu menu = new Menu ();
            menu.MenuPrincipal();
            /*
int opc;
con.CargarVehiculo();
con.mostrarDatos();
Console.ReadKey();
*/
            //do
            //{
            //    Console.Clear();
            //    con.IngresarVehiculo();
            //    con.MostrarVehiculos();
            //    Console.WriteLine("\n\nIngrese 1");
            //    opc = int.Parse(Console.ReadLine());
            //} while (opc == 1);
            Console.ReadKey();
        }
    }
}
