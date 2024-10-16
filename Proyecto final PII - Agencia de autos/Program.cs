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
           
            string vehiculosArchivo = "Vehiculos.txt";
            string ventasArchivo = "Ventas.txt";
            string clientesArchivo = "Clientes.txt";
            string marcasArchivo = "Marcas.txt";
            string segmentosArchivo = "Segmentos.txt";
            string combustiblesArchivo = "Combustibles.txt";
            string localidadesArchivo = "Localidades.txt";
            string provinciasArchivo = "Provincias.txt";
            string motosArchivo = "Motos.txt";
            string autosCamionetasArchivo = "AutosCamioneta.txt";
            string camionesArchivo = "Camiones.txt";

            Concesionaria con = new Concesionaria ();

            //con.CargarVehiculos(vehiculosArchivo);
            //con.CargarVentas(ventasArchivo);
            //con.CargarClientes(clientesArchivo);
            //con.CargarMarcas(marcasArchivo);
            //con.CargarSegmentos(segmentosArchivo);
            //con.CargarCombustibles(combustiblesArchivo);
            //con.CargarLocalidades(localidadesArchivo);
            //con.CargarProvincias(provinciasArchivo);
            //con.CargarMotos(motosArchivo);
            //con.CargarAutosCamionetas(autosCamionetasArchivo);
            //con.CargarCamiones(camionesArchivo);
            //con.CargarVehiculos(vehiculosArchivo);
            con.CargarVentas();
            con.CargarClientes();
            con.CargarMarcas();
            con.CargarSegmentos();
            con.CargarCombustibles();
            con.CargarLocalidades();
            con.CargarProvincias();
            con.CargarMotos();
            con.CargarAutosCamionetas();
            con.CargarCamiones();
            


            AutoCamioneta ac = new AutoCamioneta();
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
