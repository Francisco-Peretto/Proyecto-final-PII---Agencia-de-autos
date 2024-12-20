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
            -No se valida provincia al crear localidad (poner lista de provincias con menú reutilizable)
            -No se puede modificar provincia cuando se modifica una localidad
            -Al consultar una venta no se muestran datos del vehículo (llamar datos del vehículo por id en la venta). Aún no funciona
            -Al ver localidad que diga a qué provincia corresponde
            -Al finalizar, ver cómo solucionar el problema de llamado de las cosas por id cuando hay uno elimitado. Probablemente hacer que a partir de la id devuelva nombre/patente/cuit. Otra opcion al eliminar reacondicionar todas las ids pero podría traer problemas en una base de datos
            
            -Iba a eliminar la opción de modificar id de marca, localidad, etc., pero es un dato unique que no difiere de cuit, patente, etc.
            */

            /*
            string[] opciones = {"Prueba 1", "Prueba 2", "Prueba 3", "Prueba 4", "Prueba 5"};
            string mensaje = "Mensaje interno";
            int opcion = con.MenuReutilizable(opciones, mensaje);
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
