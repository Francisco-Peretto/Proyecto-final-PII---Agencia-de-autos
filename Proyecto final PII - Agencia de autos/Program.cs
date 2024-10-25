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

            


            AutoCamioneta ac = new AutoCamioneta();
            Menu menu = new Menu ();

            menu.MenuPrincipal();

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
            Console.ReadKey();
        }
    }
}
