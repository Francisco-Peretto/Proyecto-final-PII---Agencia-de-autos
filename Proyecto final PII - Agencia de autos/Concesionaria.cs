using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Concesionaria
    {
        private Validacion validar;
        private FileStream arch;
        private StreamWriter wr;
        private StreamReader r;
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
        public Concesionaria(Validacion validar, List<Vehiculo> _listaVehiculos, List<Venta> _listaVentas, List<Cliente> _listaClientes,
            List<Marca> _listaMarcas, List<Segmento> _listaSegmentos, List<Combustible> _listaCombustibles,
            List<Localidad> _listaLocalidades, List<Provincia> _listaProvincias, List<Moto> _listaMotos, List<AutoCamioneta> _listaAutoCamionetas,
            List<Camion> _listaCamiones)
        {
            this.validar = new Validacion();
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
            this.validar = new Validacion();
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
                    //validar.validarEntero(id_vehiculo);
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

                    int id_venta = int.Parse(split[0]);
                    int id_cliente = int.Parse(split[1]);
                    int id_vehiculo = int.Parse(split[2]);
                    DateTime fecha_compra = DateTime.Parse(split[3]);
                    DateTime fecha_entrega = DateTime.Parse(split[4]);
                    double subtotal = double.Parse(split[5]);
                    int iva = int.Parse(split[6]);
                    int descuento = int.Parse(split[7]);
                    double total = double.Parse(split[8]);

                    Venta ventas = new Venta(id_venta, id_cliente, id_vehiculo, fecha_compra, fecha_entrega, subtotal, iva, descuento, total);

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

        public void cargarAutoCamioneta()
        {

            int id_vehiculo, anio, id_marca, id_combustible, id_segmento;
            double kilometros, precio_vta;
            Vehiculo vehi = new Vehiculo();
            Moto mot = new Moto();
            AutoCamioneta autcam = new AutoCamioneta();
            Camion cam = new Camion();


            Console.Write("\t\t\t*****CARGA DE AUTO/CAMIONETA*****\n\n");
            Console.Write("Ingrese el ID del vehículo a registrar: "); // ID vehículo
            if (!int.TryParse(Console.ReadLine(), out id_vehiculo))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            autcam.pId_vehiculo = id_vehiculo;

            Console.Write("\nIngrese la PATENTE del vehículo a registrar (AAA000 / AA000AA): "); // Patente
            //patente = Console.ReadLine();
            autcam.pPatente = Console.ReadLine();

            Console.Write("\nIngrese los KILOMETROS del vehículo a registrar: "); // Kilómetros
            if (!double.TryParse(Console.ReadLine(), out kilometros))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            autcam.pKilometros = kilometros;

            Console.Write("\nIngrese el AÑO del vehículo a registrar: "); // Año. Se puede establecer rango min-max
            if (!int.TryParse(Console.ReadLine(), out anio))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            autcam.pAnio = anio;

            Console.Write("\nIngrese el ID de la MARCA del vehiculo a registrar: ");
            if (!int.TryParse(Console.ReadLine(), out id_marca))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            autcam.pId_marca = id_marca;

            Console.Write("\nIngrese el nombre del MODELO del vehiculo a registrar: ");
            autcam.pModelo = Console.ReadLine();
           // do
           // {
                Console.Write("\nIngrese el ID del SEGMENTO del vehiculo a registrar: ");
                if (!int.TryParse(Console.ReadLine(), out id_segmento))
                {
                    Console.WriteLine("Error. Presione una tecla y reintente.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (id_segmento > 4)
                {
                    Console.WriteLine("Error. El segmento ingresado no corresponde a un Auto/Camioneta.");
                    Console.ReadKey();
                }
            //} while (!int.TryParse(Console.ReadLine(), out id_segmento) || id_segmento>4);
            
            autcam.pId_segmento = id_segmento;

            Console.Write("\nIngrese el ID del COMBUSTIBLE del vehiculo a registrar: ");
            if (!int.TryParse(Console.ReadLine(), out id_combustible))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            autcam.pId_combustible = id_combustible;


            Console.Write("\nIngrese el precio de venta del vehículo a registrar: "); // Precio
            if (!double.TryParse(Console.ReadLine(), out precio_vta))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            autcam.pPrecio_vta = precio_vta;

            Console.Write("\nIngrese las OBSERVACIONES del vehículo a registrar (en caso de existir alguna): "); // Observaciones
            autcam.pObservaciones = Console.ReadLine();
            if (autcam.pObservaciones == " ")
            {
                autcam.pObservaciones = "Sin observaciones";
            }

            Console.Write("\nIngrese el COLOR del vehículo a registrar: "); // color. SE PUEDE HACER UNA LISTA DE COLORES
            autcam.pColor = Console.ReadLine();

            _listaAutoCamionetas.Add(autcam);
        }
        public void cargarMoto()
        {
            int id_vehiculo, anio, id_marca, id_combustible, id_segmento, cilindrada;
            double kilometros, precio_vta;
            Vehiculo vehi = new Vehiculo();
            Moto mot = new Moto();
            AutoCamioneta autcam = new AutoCamioneta();
            Camion cam = new Camion();


            Console.Write("\t\t\t*****CARGA DE MOTO*****\n\n");
            Console.Write("Ingrese el ID del vehículo a registrar: "); // ID vehículo
            if (!int.TryParse(Console.ReadLine(), out id_vehiculo))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            mot.pId_vehiculo = id_vehiculo;

            Console.Write("\nIngrese la PATENTE del vehículo a registrar (AAA000 / AA000AA): "); // Patente
            //patente = Console.ReadLine();
            mot.pPatente = Console.ReadLine();

            Console.Write("\nIngrese los KILOMETROS del vehículo a registrar: "); // Kilómetros
            if (!double.TryParse(Console.ReadLine(), out kilometros))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            mot.pKilometros = kilometros;

            Console.Write("\nIngrese el AÑO del vehículo a registrar: "); // Año. Se puede establecer rango min-max
            if (!int.TryParse(Console.ReadLine(), out anio))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            mot.pAnio = anio;

            Console.Write("\nIngrese el ID de la MARCA del vehiculo a registrar: ");
            if (!int.TryParse(Console.ReadLine(), out id_marca))
            {
                vehi = new Camion();
                Console.Write("\nIngrese si el camion posee caja (true/false): "); //HACER MENU PARA SELECCIONAR
                if (!bool.TryParse(Console.ReadLine(), out caja_carga))
                {
                    Console.WriteLine("Error. Presione una tecla y reintente.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (id_segmento < 5 || id_segmento > 7)
                {
                    Console.WriteLine("Error. El segmento ingresado no corresponde a una Moto.");
                    Console.ReadKey();
                }
            //} while (!int.TryParse(Console.ReadLine(), out id_segmento) || id_segmento < 5 || id_segmento > 7);

            mot.pId_segmento = id_segmento;

            Console.Write("\nIngrese la CILINDRADA: ");
            if (!int.TryParse(Console.ReadLine(), out cilindrada))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            mot.pCilindrada = cilindrada;

            Console.Write("\nIngrese el ID del COMBUSTIBLE del vehiculo a registrar: ");
            if (!int.TryParse(Console.ReadLine(), out id_combustible))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            mot.pId_combustible = id_combustible;


            Console.Write("\nIngrese el precio de venta del vehículo a registrar: "); // Precio
            if (!double.TryParse(Console.ReadLine(), out precio_vta))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            mot.pPrecio_vta = precio_vta;

            Console.Write("\nIngrese las OBSERVACIONES del vehículo a registrar (en caso de existir alguna): "); // Observaciones
            mot.pObservaciones = Console.ReadLine();
            if (mot.pObservaciones == " ")
            {
                mot.pObservaciones = "Sin observaciones";
            }

            Console.Write("\nIngrese el COLOR del vehículo a registrar: "); // color. SE PUEDE HACER UNA LISTA DE COLORES
            mot.pColor = Console.ReadLine();

            _listaMotos.Add(mot);
        }
        public void cargarCamion()
        {
            int id_vehiculo, anio, id_marca, id_combustible, id_segmento, dimension_caja, carga_max, largocaja, anchocaja;
            double kilometros, precio_vta;
            bool caja_carga;
            Vehiculo vehi = new Vehiculo();
            Moto mot = new Moto();
            AutoCamioneta autcam = new AutoCamioneta();
            Camion cam = new Camion();


            Console.Write("\t\t\t*****CARGA DE CAMION*****\n\n");
            Console.Write("Ingrese el ID del vehículo a registrar: "); // ID vehículo
            if (!int.TryParse(Console.ReadLine(), out id_vehiculo))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            cam.pId_vehiculo = id_vehiculo;

            Console.Write("\nIngrese la PATENTE del vehículo a registrar (AAA000 / AA000AA): "); // Patente
            //patente = Console.ReadLine();
            cam.pPatente = Console.ReadLine();

            Console.Write("\nIngrese los KILOMETROS del vehículo a registrar: "); // Kilómetros
            if (!double.TryParse(Console.ReadLine(), out kilometros))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            cam.pKilometros = kilometros;

            Console.Write("\nIngrese el AÑO del vehículo a registrar: "); // Año. Se puede establecer rango min-max
            if (!int.TryParse(Console.ReadLine(), out anio))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            cam.pAnio = anio;

            Console.Write("\nIngrese el ID de la MARCA del vehiculo a registrar: ");
            if (!int.TryParse(Console.ReadLine(), out id_marca))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            cam.pId_marca = id_marca;

            Console.Write("\nIngrese el nombre del MODELO del vehiculo a registrar: ");
            cam.pModelo = Console.ReadLine();
           // do
           // {
                Console.Write("\nIngrese el ID del SEGMENTO del vehiculo a registrar: ");
                if (!int.TryParse(Console.ReadLine(), out id_segmento))
                {
                    Console.WriteLine("Error. Presione una tecla y reintente.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (id_segmento != 8)
                {
                    Console.WriteLine("Error. El segmento ingresado no corresponde a un Auto/Camioneta.");
                    Console.ReadKey();
                }
           // } while (!int.TryParse(Console.ReadLine(), out id_segmento) || id_segmento != 8);

            cam.pId_segmento = id_segmento;

            Console.Write("\nIngrese si el camion posee caja (true/false): ");
            if (!bool.TryParse(Console.ReadLine(), out caja_carga))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            cam.pCaja_Carga = caja_carga;

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
            cam.pDimension_caja = dimension_caja;

            Console.Write("\nIngrese la CARGA MAXIMA de la caja del camion (en kg): ");
            if (!int.TryParse(Console.ReadLine(), out carga_max))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            cam.pCarga_max = carga_max;

            Console.Write("\nIngrese el ID del COMBUSTIBLE del vehiculo a registrar: ");
            if (!int.TryParse(Console.ReadLine(), out id_combustible))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            cam.pId_combustible = id_combustible;


            Console.Write("\nIngrese el precio de venta del vehículo a registrar: "); // Precio
            if (!double.TryParse(Console.ReadLine(), out precio_vta))
            {
                Console.WriteLine("Error. Presione una tecla y reintente.");
                Console.ReadKey();
                Console.Clear();
            }
            cam.pPrecio_vta = precio_vta;

            Console.Write("\nIngrese las OBSERVACIONES del vehículo a registrar (en caso de existir alguna): "); // Observaciones
            cam.pObservaciones = Console.ReadLine();
            if (cam.pObservaciones == " ")
            {
                cam.pObservaciones = "Sin observaciones";
            }

            Console.Write("\nIngrese el COLOR del vehículo a registrar: "); // color. SE PUEDE HACER UNA LISTA DE COLORES
            cam.pColor = Console.ReadLine();

            _listaCamiones.Add(cam);
        }
        public void CargarVehiculo()
        {
            Console.WriteLine("****carga de vehiculo***");
            Vehiculo vehi = new Vehiculo();
            Moto mot = new Moto();
            AutoCamioneta autcam = new AutoCamioneta();
            Camion cam = new Camion();

            Console.WriteLine("Ingrese el vehiculo que desaea cargar:\n\t1 auto, 2 moto, 3 camion");
            int opc = int.Parse(Console.ReadLine());

            if(opc == 1)
            {
                cargarAutoCamioneta();
            }else if(opc == 2)
            {
                cargarMoto();
            }else if(opc == 3)
            {
                cargarCamion();
            }

        }

        public void mostrarVehiculos()
        {
            Console.WriteLine("Autos y Camionets\n");
            foreach(AutoCamioneta a in _listaAutoCamionetas)
            {
                a.MostrarDatos();
            }
            Console.WriteLine("\nMotos\n");
            foreach(Moto mot in _listaMotos)
            {
                mot.MostrarDatos();
            }
            Console.WriteLine("Camiones\n");
            foreach (Camion cam in _listaCamiones)
            {
                cam.MostrarDatos();
            }
        }

        public void cargarVenta()
        {
            
            int id_cliente, id_vehiculo = 0, iva, descuento;
            DateTime fecha_compra, fecha_entrega;
            double subtotal, total;
            Console.WriteLine("****CARGA DE VENTA****\n\n");

            Console.Write("Ingrese el ID del cliente: ");
            foreach(Cliente cl in this._listaClientes)
            {
                Console.WriteLine($"ID: {cl.pId_cliente} Razon Social: {cl.pCliente}");
            }
            id_cliente = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese el tipo vehiculo que desaea vender:\n\t1 auto, 2 moto, 3 camion");
            int opc = int.Parse(Console.ReadLine());

            if (opc == 1)
            {
                foreach (AutoCamioneta gen in this._listaAutoCamionetas)
                {
                    Console.WriteLine($"ID: {gen.pId_vehiculo} Modelo: {gen.pModelo}");
                }
                Console.Write("\nIngrese el ID del vehiculo a vender: ");
                
                id_vehiculo = int.Parse(Console.ReadLine());

            }
            else if (opc == 2)
            {
                foreach (Moto moto in this._listaMotos)
                {
                    Console.WriteLine($"ID: {moto.pId_vehiculo} Modelo: {moto.pModelo}");
                }
                Console.Write("\nIngrese el ID del vehiculo a vender: ");
                
                id_vehiculo = int.Parse(Console.ReadLine());

            }
            else if (opc == 3)
            {
                foreach (Camion camion in this._listaCamiones)
                {
                    Console.WriteLine($"ID: {camion.pId_vehiculo} Modelo: {camion.pModelo}");
                }
                Console.Write("\nIngrese el ID del vehiculo a vender: ");
                
                id_vehiculo = int.Parse(Console.ReadLine());

            }

            Console.Write("\nIngrese la FECHA DE COMPRA del vehiculo: ");
            fecha_compra = DateTime.Parse(Console.ReadLine());

            Console.Write("\nIngrese la FECHA DE COMPRA del vehiculo: ");
            fecha_entrega = DateTime.Parse(Console.ReadLine());

            Console.Write("\nIngrese el SUBTOTAL de la venta: ");
            subtotal = double.Parse(Console.ReadLine());

            Console.Write("\nIngrese el % de IVA: ");
            iva = int.Parse(Console.ReadLine());

            Console.Write("\nIngrese el % de DESCUENTO: ");
            descuento = int.Parse(Console.ReadLine());

            
            Venta venta = new Venta(id_cliente, id_vehiculo, fecha_compra, fecha_entrega, subtotal, iva, descuento);


        }

        public void cargarLocalidad()
        {
            int id_localidad, id_provincia;
            string localidad;
            Console.Write("****CARGA DE LOCALIDAD****\n\n");
            Console.Write("Ingrese el ID de la Localidad: ");
            id_localidad = int.Parse(Console.ReadLine());

            Console.Write("\nIngrese el NOMBRE de la localidad");
            localidad = Console.ReadLine();

            foreach(Provincia prov in this._listaProvincias)
            {
                Console.Write($"ID: {prov.pId_provincia} -> {prov.pProvincia}");
            }
            Console.Write("\nIngrese el ID de la Provincia");
            id_provincia = int.Parse(Console.ReadLine());

            Localidad loc = new Localidad(id_localidad, localidad, id_provincia);
        }

        public void cargarProvincia()
        {
            int id_provincia;
            string provincia;
            Console.Write("****CARGA DE PROVINCIA****\n\n");
            Console.Write("Ingrese el ID de la Provincia: ");
            id_provincia = int.Parse(Console.ReadLine());
            Console.Write("\nIngrese el NOMBRE de la Provincia");
            provincia = Console.ReadLine();

            Provincia prov = new Provincia(id_provincia, provincia);

        }
        public void cargarMarca()
        {
            int id_marca;
            string marca;
            Console.Write("****CARGA DE MARCA****\n\n");
            Console.Write("Ingrese el ID de la Marca: ");
            id_marca = int.Parse(Console.ReadLine());
            Console.Write("\nIngrese el NOMBRE de la Marca");
            marca = Console.ReadLine();

            Marca marc = new Marca(id_marca, marca);

        }
        public void cargarCombustible()
        {
            int id_combustible;
            string combustible;
            Console.Write("****CARGA DE COMBUSTIBLE****\n\n");
            Console.Write("Ingrese el ID del Combustible: ");
            id_combustible = int.Parse(Console.ReadLine());
            Console.Write("\nIngrese el NOMBRE del Combustible");
            combustible = Console.ReadLine();

            Combustible comb = new Combustible(id_combustible, combustible);

        }
        public void cargarSegmento()
        {
            int id_segmento;
            string segmento;
            Console.Write("****CARGA DE SEGMENTO****\n\n");
            Console.Write("Ingrese el ID del Segmento: ");
            id_segmento = int.Parse(Console.ReadLine());
            Console.Write("\nIngrese el NOMBRE del Segmento");
            segmento = Console.ReadLine();

            Segmento seg = new Segmento(id_segmento,segmento);

        }

        public void actualizarVentas()
        {
            arch = new FileStream("Ventas.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (Venta ven in this._listaVentas)
            {
                wr.WriteLine($"{ven.pId_cliente};{ven.pId_vehiculo}" +
                    $";{ven.pFecha_compra};{ven.pFecha_entrega};{ven.pSubtotal};{ven.pIva};" +
                    $"{ven.pDescuento};{ven.pTotal}");
            }
            wr.Close();
            arch.Close();
        }

        public void actualizarClientes()
        {
            arch = new FileStream("Clientes.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (Cliente cl in this._listaClientes)
            {
                wr.WriteLine($"{cl.pId_cliente};{cl.pCliente}" +
                    $";{cl.pCuit};{cl.pDomicilio};{cl.pId_localidad};{cl.pTelefono};" +
                    $"{cl.pCorreo}");
            }
            wr.Close();
            arch.Close();
        }

        public void actualizarAutoCamioneta()
        {
            arch = new FileStream("AutosCamioneta.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (AutoCamioneta autcam in this._listaAutoCamionetas)
            {
                wr.WriteLine($"{autcam.pId_vehiculo};{autcam.pPatente};{autcam.pKilometros};{autcam.pAnio};" +
                    $"{autcam.pId_marca};{autcam.pModelo};{autcam.pId_segmento};{autcam.pId_combustible};" +
                    $"{autcam.pPrecio_vta};{autcam.pObservaciones};{autcam.pColor}");
            }
            wr.Close();
            arch.Close();
        }
        public void actualizarMotos()
        {
            arch = new FileStream("Motos.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (Moto moto in this._listaMotos)
            {
                wr.WriteLine($"{moto.pId_vehiculo};{moto.pPatente};{moto.pKilometros};{moto.pAnio};" +
                    $"{moto.pId_marca};{moto.pModelo};{moto.pId_segmento};{moto.pId_combustible};" +
                    $"{moto.pPrecio_vta};{moto.pObservaciones};{moto.pColor};{moto.pCilindrada}");
            }
            wr.Close();
            arch.Close();
        }
        public void actualizarCamiones()
        {
            arch = new FileStream("Camiones.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (Camion cam in this._listaCamiones)
            {
                wr.WriteLine($"{cam.pId_vehiculo};{cam.pPatente};{cam.pKilometros};{cam.pAnio};" +
                    $"{cam.pId_marca};{cam.pModelo};{cam.pId_segmento};{cam.pId_combustible};" +
                    $"{cam.pPrecio_vta};{cam.pObservaciones};{cam.pColor};{cam.pCaja_Carga};" +
                    $"{cam.pDimension_caja};{cam.pCarga_max}");
            }
            wr.Close();
            arch.Close();
        }

        public void modificarVenta()
        {
            Venta venta= new Venta();
            int id, flag = 0;
            string cad;
            Console.WriteLine("Ingrese el ID de la venta a modificar");
            cad = Console.ReadLine();
            id = int.Parse(cad);
            foreach (Venta ven in this._listaVentas)
            {
                if (ven.pId_venta == id)
                {
                    string[] menumodif = { "Cliente", "Vehiculo", "Fecha de compra", "Fecha de entrega",
                    "Subtotal", "IVA", "Descuento", "Total"};
                    int indexmodif = 0;
                    ConsoleKeyInfo opcmodif;
                    Console.Clear();
                    Console.WriteLine("Ingrese el dato que desea modificar\n");
                    do
                    {


                        //Fondo menu
                        for (int i = 0; i < menumodif.Length; i++)
                        {

                            if (i == indexmodif)
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.Gray;

                            }
                            else
                            {
                                Console.ResetColor();
                            }
                            Console.WriteLine(menumodif[i]);


                        }

                        Console.ResetColor();
                        Console.Write($"\n\n\t\tPresiones ESCAPE para salir.");
                        opcmodif = Console.ReadKey();

                        switch (opcmodif.Key)
                        {
                            case ConsoleKey.UpArrow:
                                Console.Clear();
                                if (indexmodif > 0)
                                {
                                    indexmodif--;
                                }
                                else if (indexmodif == 0)
                                {
                                    indexmodif = 7;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                Console.Clear();
                                if (indexmodif < (menumodif.Length - 1))
                                {
                                    indexmodif++;
                                }
                                else if (indexmodif == 7)
                                {
                                    indexmodif = 0;
                                }
                                break;
                            case ConsoleKey.Enter:
                                Console.Clear();
                                if (menumodif[indexmodif] == "Cliente")
                                {
                                    int idclmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el ID que modficara el actual -{venta.pId_cliente}-: ");
                                    idclmodif = int.Parse(Console.ReadLine());
                                    venta.pId_cliente = idclmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Vehiculo")
                                {
                                    int vehimodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el ID del vehiculo que modficara el actual -{venta.pId_vehiculo}-: ");
                                    vehimodif = int.Parse(Console.ReadLine());
                                    venta.pId_vehiculo = vehimodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Fecha de compra")
                                {

                                    DateTime feccompmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la fecha que modficara la actual -{venta.pFecha_compra}-: ");
                                    cad = Console.ReadLine();
                                    feccompmodif = DateTime.Parse(cad);
                                    venta.pFecha_compra = feccompmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }
                                else if (menumodif[indexmodif] == "Fecha de entrega")
                                {
                                    DateTime fecentmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la fecha que modficara la actual -{venta.pFecha_entrega}-: ");
                                    cad = Console.ReadLine();
                                    fecentmodif = DateTime.Parse(cad);
                                    venta.pFecha_entrega = fecentmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }
                                else if (menumodif[indexmodif] == "Subtotal")
                                {
                                    double subtotmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el subtotal que modificara el actual -{venta.pSubtotal}-: ");
                                    cad = Console.ReadLine();
                                    subtotmodif = double.Parse(cad);
                                    venta.pSubtotal = subtotmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }
                                else if (menumodif[indexmodif] == "IVA")
                                {
                                    int ivamodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el % de IVA que modificara el actual -{venta.pIva}-: ");
                                    cad = Console.ReadLine();
                                    ivamodif = int.Parse(cad);
                                    venta.pIva = ivamodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }
                                else if (menumodif[indexmodif] == "Descuento")
                                {
                                    int descmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el descuento que modificara el actual -{venta.pDescuento}-: ");
                                    cad = Console.ReadLine();
                                    descmodif = int.Parse(cad);
                                    venta.pDescuento = descmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }
                                else if (menumodif[indexmodif] == "Total")
                                {
                                    int descmodif, ivamodif;
                                    double subtotmodif, totalmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el SUBTOTAL que modificar el actual -{venta.pSubtotal}-: ");
                                    cad = Console.ReadLine();
                                    subtotmodif = double.Parse(cad);
                                    venta.pSubtotal = subtotmodif;

                                    Console.WriteLine($"Ingrese el % DE IVA que modificar el actual -{venta.pIva}-: ");
                                    cad = Console.ReadLine();
                                    ivamodif = int.Parse(cad);
                                    venta.pIva = ivamodif;

                                    Console.WriteLine($"Ingrese el % DE DESCUENTO que modificar el actual -{venta.pDescuento}-: ");
                                    cad = Console.ReadLine();
                                    descmodif = int.Parse(cad);
                                    venta.pDescuento = descmodif;
                                    totalmodif = (subtotmodif+((ivamodif*subtotmodif)/100))-((descmodif*subtotmodif)/100);
                                    venta.pTotal = totalmodif;

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }


                                Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menu");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                        }
                    } while (opcmodif.Key != ConsoleKey.Escape);

                }
                else
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                Console.Clear();
                Console.Write($"La ID -{id}- no existe en la lista de articulos.");
            }

        }

        public void modificarCliente()
        {
            Cliente cliente = new Cliente();
            int id, flag = 0;
            string cad;
            Console.WriteLine("Ingrese el ID del cliente a modificar");
            cad = Console.ReadLine();
            id = int.Parse(cad);
            foreach (Cliente cl in this._listaClientes)
            {
                if (cl.pId_cliente == id)
                {
                    string[] menumodif = { "Razon social", "CUIT", "Domicilio", "ID Localidad",
                    "Telefono", "Correo"};
                    int indexmodif = 0;
                    ConsoleKeyInfo opcmodif;
                    Console.Clear();
                    Console.WriteLine("Ingrese el dato que desea modificar\n");
                    do
                    {


                        //Fondo menu
                        for (int i = 0; i < menumodif.Length; i++)
                        {

                            if (i == indexmodif)
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.Gray;

                            }
                            else
                            {
                                Console.ResetColor();
                            }
                            Console.WriteLine(menumodif[i]);


                        }

                        Console.ResetColor();
                        Console.Write($"\n\n\t\tPresiones ESCAPE para salir.");
                        opcmodif = Console.ReadKey();

                        switch (opcmodif.Key)
                        {
                            case ConsoleKey.UpArrow:
                                Console.Clear();
                                if (indexmodif > 0)
                                {
                                    indexmodif--;
                                }
                                else if (indexmodif == 0)
                                {
                                    indexmodif = 5;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                Console.Clear();
                                if (indexmodif < (menumodif.Length - 1))
                                {
                                    indexmodif++;
                                }
                                else if (indexmodif == 5)
                                {
                                    indexmodif = 0;
                                }
                                break;
                            case ConsoleKey.Enter:
                                Console.Clear();
                                if (menumodif[indexmodif] == "Razon Social")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la razon social que modficara la actual -{cliente.pCliente}");
                                    cliente.pCliente = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "CUIT")
                                {
                                    long cuitmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el CUIT del Cliente que modficara el actual -{cliente.pCuit}-: ");
                                    cuitmodif = long.Parse(Console.ReadLine());
                                    cliente.pCuit = cuitmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Domicilio")
                                {

                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la direccion que modficara la actual -{cliente.pDomicilio}-: ");
                                    cliente.pDomicilio = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }
                                else if (menumodif[indexmodif] == "ID Localidad")
                                {
                                    int localmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la localidad que modficara la actual -{cliente.pId_localidad}-: ");
                                    cad = Console.ReadLine();
                                    localmodif = int.Parse(cad);
                                    cliente.pId_localidad = localmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }
                                else if (menumodif[indexmodif] == "Telefono")
                                {
                                    long telmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el telefono que modificara el actual -{cliente.pTelefono}-: ");
                                    cad = Console.ReadLine();
                                    telmodif = long.Parse(cad);
                                    cliente.pTelefono = telmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }
                                else if (menumodif[indexmodif] == "Correo")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el Correo que modificara el actual -{cliente.pCorreo}-: ");
                                    cliente.pCorreo = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }


                                Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menu");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                        }
                    } while (opcmodif.Key != ConsoleKey.Escape);

                }
                else
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                Console.Clear();
                Console.Write($"La ID -{id}- no existe en la lista de articulos.");
            }

        }

        public void modifcarLocalidad()
        {
            Localidad localidad = new Localidad();
            int id, flag = 0;
            string cad;
            Console.WriteLine("Ingrese el ID de la Localidad a modificar");
            cad = Console.ReadLine();
            id = int.Parse(cad);
            foreach (Localidad loc in this._listaLocalidades)
            {
                if (loc.pId_localidad == id)
                {
                    string[] menumodif = { "Localidad", "ID Provincia"};
                    int indexmodif = 0;
                    ConsoleKeyInfo opcmodif;
                    Console.Clear();
                    Console.WriteLine("Ingrese el dato que desea modificar\n");
                    do
                    {


                        //Fondo menu
                        for (int i = 0; i < menumodif.Length; i++)
                        {

                            if (i == indexmodif)
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.Gray;

                            }
                            else
                            {
                                Console.ResetColor();
                            }
                            Console.WriteLine(menumodif[i]);


                        }

                        Console.ResetColor();
                        Console.Write($"\n\n\t\tPresiones ESCAPE para salir.");
                        opcmodif = Console.ReadKey();

                        switch (opcmodif.Key)
                        {
                            case ConsoleKey.UpArrow:
                                Console.Clear();
                                if (indexmodif > 0)
                                {
                                    indexmodif--;
                                }
                                else if (indexmodif == 0)
                                {
                                    indexmodif = 1;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                Console.Clear();
                                if (indexmodif < (menumodif.Length - 1))
                                {
                                    indexmodif++;
                                }
                                else if (indexmodif == 1)
                                {
                                    indexmodif = 0;
                                }
                                break;
                            case ConsoleKey.Enter:
                                Console.Clear();
                                if (menumodif[indexmodif] == "Localidad")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la localidad que modficara la actual -{localidad.pLocalidad}");
                                    localidad.pLocalidad= Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "ID Provincia")
                                {
                                    int idprovmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el ID de la provincia que modficara el actual -{localidad.pId_provincia}-: ");
                                    idprovmodif = int.Parse(Console.ReadLine());
                                    localidad.pId_provincia = idprovmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                


                                Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menu");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                        }
                    } while (opcmodif.Key != ConsoleKey.Escape);

                }
                else
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                Console.Clear();
                Console.Write($"La ID -{id}- no existe en la lista de articulos.");
            }

        }

        public void modificarProvincia()
        {
            Provincia provincia = new Provincia();
            int id, flag = 0;
            string cad;
            Console.WriteLine("Ingrese el ID de la Provincia a modificar");
            cad = Console.ReadLine();
            id = int.Parse(cad);
            foreach (Provincia prov in this._listaProvincias)
            {
                if (prov.pId_provincia == id)
                {
                    Console.Clear();
                    Console.WriteLine($"Ingrese la provincia que modficara la actual -{provincia.pProvincia}");
                    provincia.pProvincia = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\n\n\t\tProvincia Modificada correctamente.");
                    Console.WriteLine("Ingrese el dato que desea modificar\n");
                    

                }
                else
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                Console.Clear();
                Console.Write($"La ID -{id}- no existe en la lista de articulos.");
            }

        }

        public void borrarVehiculo()
        {
            int id, flag = 0, i, j, k;
            string cad;
            Console.WriteLine("Ingrese el ID del Vehiculo a eliminar: ");
            cad = Console.ReadLine();
            id = int.Parse(cad);
            for (i = _listaAutoCamionetas.Count() - 1; i >= 0; i--)
            {
                if (_listaAutoCamionetas[i].pId_vehiculo == id)
                {
                    flag = i;
                }

            }
            for (j = _listaMotos.Count() - 1; j >= 0; j--)
            {
                if (_listaMotos[j].pId_vehiculo == id)
                {
                    flag = j;
                }

            }
            for (k = _listaCamiones.Count() - 1; k >= 0; k--)
            {
                if (_listaCamiones[k].pId_vehiculo == id)
                {
                    flag = k;
                }

            }

            if (flag == 0)
            {
                Console.Write($"El ID -{id}- no existe en la lista de Vehiculos");

            }
            else
            {
                if (flag == i)
                {
                    _listaAutoCamionetas.RemoveAt(flag);
                }
                else if (flag == j)
                {
                    _listaMotos.RemoveAt(flag);
                }
                else if (flag == k)
                {
                    _listaCamiones.RemoveAt(flag);
                }

                Console.Write($"El articulo con ID -{id}- fue eliminado");
            }

        }
    }
}

