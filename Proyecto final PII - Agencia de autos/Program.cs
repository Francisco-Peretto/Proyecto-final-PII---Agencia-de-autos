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
            Menu menu = new Menu();
            menu.MenuPrincipal();

            /*
            -(GENERAL) Cambiar TODOS los listados de ids para usar MenuReutilizable, ver ejemplo en Program).
            -En el menú no vuelve a la opción anterior
            -No debe pedir ID al registrar (hacer autoincremental)
            -No se valida provincia al crear localidad (poner lista de provincias con menú reutilizable)
            -No se puede modificar provincia cuando se modifica una localidad
            -Al registrar una moto aparece opciones de autos y no están claros los errores (ej segmentos mostrar solamente los que pertenecen y en el caso de camiones que no lo pida porque hay uno solo).
            -Al registrar un cliente, no deja registrar clientes con un mismo DNI (supongo que no debería).
            -Al realizar una venta, el subtotal no lo debe cargar el operador (calcular solo, pero me suena que esto estaba?).
            -Al modificar una venta no se debe poder modificar el total, se debe recalcular (modificar como el de crear venta).
            -Al consultar una venta no se muestran datos del vehículo (llamar datos del vehículo por id en la venta).
            */

            /*
            string[] opciones = {"Prueba 1", "Prueba 2", "Prueba 3", "Prueba 4", "Prueba 5"};

            int opcion = con.MenuReutilizable(opciones);
            Console.WriteLine("ID de la opción: " + opcion);
            Console.ReadKey();
            
            AutoCamioneta ac = new AutoCamioneta();
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
            */
        }
    }
}
