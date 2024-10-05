using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Concesionaria
    {


        List<Vehiculo> _listaVehiculos;
        List<Venta> _listaVentas;
        List<Cliente> _listaClientes;
        List<Marca> _listaMarcas;
        List<Segmento> _listaSegmentos;
        List<Combustible> _listaCombustibles;
        List<Localidad> _listaLocalidades;
        List<Provincia> _listaProvincias;
        List<Moto> _listaMotos;
        List<AutoCamioneta> _listaAutoCamionetas;
        List<Camion> _listaCamiones;

        // constructores
        public Concesionaria(List<Vehiculo> _listaVehiculos, List<Venta> _listaVentas, List<Cliente> _listaClientes,
            List<Marca> _listaMarcas, List<Segmento> _listaSegmentos, List<Combustible> _listaCombustibles,
            List<Localidad> _listaLocalidades, List<Provincia> _listaProvincias, List<Moto> _listaMotos, List<AutoCamioneta> _listaAutoCamionetas,
            List<Camion> _listaCamiones)
        {
            this._listaVehiculos = new List<Vehiculo>();
            this._listaVentas = new List<Venta>();
            this._listaClientes = new List<Cliente>();
            this._listaMarcas = new List<Marca>();
            this._listaSegmentos = new List<Segmento>();
            this._listaCombustibles = new List<Combustible>();
            this._listaLocalidades = new List<Localidad>();
            this._listaProvincias = new List<Provincia>();
            this._listaMotos = new List<Moto>();
            this._listaAutoCamionetas = new List<AutoCamioneta>();
            this._listaCamiones = new List<Camion>();
        }
        public Concesionaria()
        {
            this._listaVehiculos = new List<Vehiculo>();
            this._listaVentas = new List<Venta>();
            this._listaClientes = new List<Cliente>();
            this._listaMarcas = new List<Marca>();
            this._listaSegmentos = new List<Segmento>();
            this._listaCombustibles = new List<Combustible>();
            this._listaLocalidades = new List<Localidad>();
            this._listaProvincias = new List<Provincia>();
            this._listaMotos = new List<Moto>();
            this._listaAutoCamionetas = new List<AutoCamioneta>();
            this._listaCamiones = new List<Camion>();
        }
        // metodos
        public void CargarVehiculos(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                FileStream archivo = new FileStream(nombreArchivo, FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(':');

                    int id_vehiculo = int.Parse(split[0]);
                    string patente = split[1];
                    double kilometros = double.Parse(split[2]);
                    int anio = int.Parse(split[3]);
                    int id_marca = int.Parse(split[4]);
                    string modelo = split[5];
                    int id_segmento = int.Parse(split[6]);
                    int id_combustible = int.Parse(split[7]);
                    double precio_vta = double.Parse(split[8]);
                    string observaciones = split[9];
                    string color = split[10];

                    Vehiculo v = new Vehiculo(id_vehiculo, patente, kilometros, anio, id_marca, modelo, id_segmento, id_combustible, precio_vta, observaciones, color);
                    _listaVehiculos.Add(v);
                }
                archivo.Close();
                reader.Close();
            }
        }
        public void CargarVentas(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                FileStream archivo = new FileStream(nombreArchivo, FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(':');

                    int id_cliente = int.Parse(split[0]);
                    int id_vehiculo = int.Parse(split[1]);
                    DateTime fecha_compra = DateTime.Parse(split[2]);
                    DateTime fecha_entrega = DateTime.Parse(split[3]);
                    double subtotal = double.Parse(split[4]);
                    int iva = int.Parse(split[5]);
                    int descuento = int.Parse(split[6]);
                    double total = double.Parse(split[7]);

                    Venta ventas = new Venta(id_cliente, id_vehiculo, fecha_compra, fecha_entrega, subtotal, iva, descuento, total);
                    _listaVentas.Add(ventas);
                }
                archivo.Close();
                reader.Close();
            }
        }
        public void CargarClientes(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                FileStream archivo = new FileStream(nombreArchivo, FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(':');

                    int id_cliente = int.Parse(split[0]);
                    string cliente = split[1];
                    long cuit = int.Parse(split[2]);
                    string domicilio = split[3];
                    int id_localidad = int.Parse(split[4]);
                    long telefono = long.Parse(split[5]);
                    string correo = split[6];

                    Cliente clientes = new Cliente(id_cliente, cliente, cuit, domicilio, id_localidad, telefono, correo);
                    _listaClientes.Add(clientes);
                }
                archivo.Close();
                reader.Close();
            }
        }
        public void CargarMarcas()
        {

        }
        public void CargarSegmentos(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                FileStream archivo = new FileStream(nombreArchivo, FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(':');

                    int id_segmento = int.Parse(split[0]);
                    string segmento = split[1];

                    Segmento segmentos = new Segmento(id_segmento, segmento);
                    _listaSegmentos.Add(segmentos);
                }
                archivo.Close();
                reader.Close();
            }
        }
        public void CargarCombustibles(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {

                FileStream archivo = new FileStream(nombreArchivo, FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(':');


                    int id_combustible = int.Parse(split[0]);
                    string combustible = split[1];


                    Combustible combustibles = new Combustible(id_combustible, combustible);
                    _listaCombustibles.Add(combustibles);
                }
                archivo.Close();
                reader.Close();
            }
        }
        public void CargarLocalidades(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {

                FileStream archivo = new FileStream(nombreArchivo, FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(';');


                    int id_combustible = int.Parse(split[0]);
                    string combustible = split[1];


                    Combustible combustibles = new Combustible(id_combustible, combustible);
                    _listaCombustibles.Add(combustibles);
                }
                archivo.Close();
                reader.Close();
            }
        }
        public void CargarProvincias()
        {

        }
        public void CargarVehiculo()
        {
            int id_vehiculo, anio, id_marca, id_combustible, id_segmento, cilindrada, dimension_caja, carga_max, largocaja, anchocaja;
            double kilometros, precio_vta;
            bool caja_carga;
            Vehiculo vehi = new Vehiculo();
            Moto mot = new Moto();
            AutoCamioneta autcam = new AutoCamioneta();
            Camion cam = new Camion();

            // Los métodos Array van a desaparecer o a modificarse una vez estén las listas
            Console.Clear();
            Console.Write("\t\t\t*****CARGA DE VEHICULO*****\n\n");
            Console.Write("Ingrese el ID del vehículo a registrar: "); // ID vehículo
            if (!int.TryParse(Console.ReadLine(), out id_vehiculo))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            vehi.pId_vehiculo = id_vehiculo;

            Console.Write("\nIngrese la PATENTE del vehículo a registrar (AAA000 / AA000AA): "); // Patente
            //patente = Console.ReadLine();
            vehi.pPatente = Console.ReadLine();

            Console.Write("\nIngrese los KILOMETROS del vehículo a registrar: "); // Kilómetros
            if (!double.TryParse(Console.ReadLine(), out kilometros))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            vehi.pKilometros = kilometros;

            Console.Write("\nIngrese el AÑO del vehículo a registrar: "); // Año. Se puede establecer rango min-max
            if (!int.TryParse(Console.ReadLine(), out anio))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            vehi.pAnio = anio;

            Console.Write("\nIngrese el ID de la MARCA del vehiculo a registrar: ");
            if (!int.TryParse(Console.ReadLine(), out id_marca))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            vehi.pId_marca = id_marca;

            Console.Write("\nIngrese el nombre del MODELO del vehiculo a registrar: ");
            vehi.pModelo = Console.ReadLine();

            Console.Write("\nIngrese el ID del SEGMENTO del vehiculo a registrar: ");
            if (!int.TryParse(Console.ReadLine(), out id_segmento))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            vehi.pId_segmento = id_segmento;
            if (vehi.pId_segmento >= 5 && vehi.pId_segmento <= 7)
            {
                vehi = new Moto();
                Console.Write("\nIngrese la CILINDRADA: ");
                if (!int.TryParse(Console.ReadLine(), out cilindrada))
                {
                    Console.WriteLine("Error. Presione una tecla y reintente.");
                    Console.ReadKey();
                    Console.Clear();
                }
                ((Moto)vehi).pCilindrada = cilindrada;


            }
            else if (vehi.pId_segmento == 8)
            {
                vehi = new Camion();
                Console.Write("\nIngrese si el camion posee caja (true/false): ");
                if (!bool.TryParse(Console.ReadLine(), out caja_carga))
                {
                    Console.WriteLine("Error. Presione una tecla y reintente.");
                    Console.ReadKey();
                    Console.Clear();
                }
                ((Camion)vehi).pCaja_Carga = caja_carga;

                Console.Write("\nIngrese el LARGO de la caja del camion (en metros): ");
                if (!int.TryParse(Console.ReadLine(), out largocaja))
                {
                    Console.WriteLine("Error. Presione una tecla y reintente.");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.Write("\nIngrese el ANCHO de la caja del camion (en metros): ");
                if (!int.TryParse(Console.ReadLine(), out anchocaja))
                {
                    Console.WriteLine("Error. Presione una tecla y reintente.");
                    Console.ReadKey();
                    Console.Clear();
                }
                dimension_caja = largocaja * anchocaja;
                ((Camion)vehi).pDimension_caja = dimension_caja;

                Console.Write("\nIngrese la CARGA MAXIMA de la caja del camion (en kg): ");
                if (!int.TryParse(Console.ReadLine(), out carga_max))
                {
                    Console.WriteLine("Error. Presione una tecla y reintente.");
                    Console.ReadKey();
                    Console.Clear();
                }
                ((Camion)vehi).pCarga_max = carga_max;

            }
            else
            {
                vehi = new Vehiculo();
            }

            Console.Write("\nIngrese el ID del COMBUSTIBLE del vehiculo a registrar: ");
            if (!int.TryParse(Console.ReadLine(), out id_combustible))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            vehi.pId_combustible = id_combustible;


            Console.Write("\nIngrese el precio de venta del vehículo a registrar: "); // Precio
            if (!double.TryParse(Console.ReadLine(), out precio_vta))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            vehi.pPrecio_vta = precio_vta;

            Console.Write("\nIngrese las OBSERVACIONES del vehículo a registrar (en caso de existir alguna): "); // Observaciones
            vehi.pObservaciones = Console.ReadLine();
            if (vehi.pObservaciones == " ")
            {
                vehi.pObservaciones = "Sin observaciones";
            }

            Console.Write("\nIngrese el COLOR del vehículo a registrar: "); // color. SE PUEDE HACER UNA LISTA DE COLORES
            vehi.pColor = Console.ReadLine();

            _listaVehiculos.Add(vehi);

        }

        public void mostrarDatos()
        {
            foreach(Vehiculo vehi in _listaVehiculos)
            {
                Console.WriteLine(vehi.MostrarDatos());
            }
        }
    }
}

