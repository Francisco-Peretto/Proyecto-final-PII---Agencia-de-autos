using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Security.Principal;
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
        List<AutoCamioneta> _listaAutoCamionetasDisponibles;
        List<AutoCamioneta> _listaAutoCamionetasVendidos;
        List<Camion> _listaCamionesDisponibles;
        List<Camion> _listaCamionesVendidos;
        List<Moto> _listaMotosDisponibles;
        List<Moto> _listaMotosVendidas;

        // Constructores
        public Concesionaria(Validacion validar, List<Vehiculo> _listaVehiculos, List<Venta> _listaVentas, List<Cliente> _listaClientes,
            List<Marca> _listaMarcas, List<Segmento> _listaSegmentos, List<Combustible> _listaCombustibles,
            List<Localidad> _listaLocalidades, List<Provincia> _listaProvincias, List<Moto> _listaMotos, List<AutoCamioneta> _listaAutoCamionetas,
            List<Camion> _listaCamiones, List<AutoCamioneta> _listaAutoCamionetasDisponibles, List<AutoCamioneta> _listaAutoCamionetasVendidos,
            List<Camion> _listaCamionesDisponibles, List<Camion> _listaCamionesVendidos, List<Moto> _listaMotosDisponibles, List<Moto> _listaMotosVendidas)
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
            this._listaAutoCamionetasDisponibles = new List<AutoCamioneta>();
            this._listaAutoCamionetasVendidos = new List<AutoCamioneta>();
            this._listaCamionesDisponibles = new List<Camion>();
            this._listaCamionesVendidos = new List<Camion>();
            this._listaMotosDisponibles = new List<Moto>();
            this._listaMotosVendidas = new List<Moto>();
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
            this._listaAutoCamionetasDisponibles = new List<AutoCamioneta>();
            this._listaAutoCamionetasVendidos = new List<AutoCamioneta>();
            this._listaCamionesDisponibles = new List<Camion>();
            this._listaCamionesVendidos = new List<Camion>();
            this._listaMotosDisponibles = new List<Moto>();
            this._listaMotosVendidas = new List<Moto>();
        }

        //METODOS DE CARGAR LISTAS----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------

        public void CargarVehiculos(string nombreArchivo)
        {   
            try
            {
                _listaVehiculos.Clear();
                FileStream archivo = new FileStream(nombreArchivo, FileMode.Open);
                StreamReader reader = new StreamReader(archivo);
                
                while (!reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(';');
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
                    bool estado = bool.Parse(split[11]);

                    Vehiculo v = new Vehiculo(id_vehiculo, patente, kilometros, anio, id_marca, modelo, id_segmento, id_combustible, precio_vta, observaciones, color, estado);
                    
                    //if (v.pEstado == true )
                    //{
                    //    _listaAutoCamionetasVendidos.Add(v);
                    //}
                    //else
                    //{
                    //    _listaAutoCamionetasDisponibles.Add(v);
                    //}
                    _listaVehiculos.Add(v);
                }
                archivo.Close();
                reader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontrado en CargarVehiculos: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos en CargarVehiculos: {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Se ha producido un error en CargarVehiculos.");
            }
        } // No se usa

        public void CargarMotos()
        {
            try
            {
                _listaMotos.Clear();
                _listaMotosDisponibles.Clear();
                _listaMotosVendidas.Clear();
                FileStream archivo = new FileStream("Motos.txt", FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (!reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(';');
                    //validar.validarEntero(id_vehiculo);
                    int id_vehiculo = int.Parse(split[0]);
                    string patente = split[1];
                    double kilometros = double.Parse(split[2]);
                    int anio = int.Parse(split[3]);
                    int id_marca = int.Parse(split[4]);
                    string modelo = split[5];
                    int id_segmento = int.Parse(split[6]);
                    int cilindrada = int.Parse(split[7]);
                    int id_combustible = int.Parse(split[8]);
                    double precio_vta = double.Parse(split[9]);
                    string observaciones = split[10];
                    string color = split[11];                 
                    bool estado = bool.Parse(split[12]);

                    Moto m = new Moto(id_vehiculo, patente, kilometros, anio, id_marca, modelo, id_segmento,
                        id_combustible, precio_vta, observaciones, color, cilindrada, estado);

                    if (bool.Parse(split[12]) == true)
                    {
                        this._listaMotosVendidas.Add(m);
                    }
                    else
                    {
                        this._listaMotosDisponibles.Add(m);
                    }
                    _listaMotos.Add(m);
                    _listaVehiculos.Add(m);
                }
                archivo.Close();
                reader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontrado en CargarMotos: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos en CargarMotos: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Se ha producido un error en CargarMotos: {e.Message}");
            }
        } 

        public void CargarAutosCamionetas()
        {
            try
            {
                _listaAutoCamionetas.Clear();
                _listaAutoCamionetasDisponibles.Clear();
                _listaAutoCamionetasVendidos.Clear();
                FileStream archivo = new FileStream("AutosCamioneta.txt", FileMode.Open);
                StreamReader reader = new StreamReader(archivo);
                while (reader.EndOfStream == false)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(';');
                    int id_vehiculo = int.Parse(split[0]);
                    string patente = split[1];
                    double kilometros = double.Parse(split[2]);
                    int anio = int.Parse(split[3]);
                    int id_marca = int.Parse(split[4]);
                    string modelo = split[5];
                    int id_segmento = int.Parse(split[6]);
                    int id_combustible = int.Parse(split[7]);
                    double precio_venta = double.Parse(split[8]);
                    string observaciones = split[9];
                    string color = split[10];
                    bool estado = bool.Parse(split[11]);

                    AutoCamioneta ac = new AutoCamioneta(id_vehiculo, patente, kilometros, anio,
                        id_marca, modelo, id_segmento, id_combustible, precio_venta,
                        observaciones, color, estado);

                    if (bool.Parse(split[11]) == true)
                    {
                        this._listaAutoCamionetasVendidos.Add(ac);
                    }
                    else
                    {
                        this._listaAutoCamionetasDisponibles.Add(ac);
                    }
                    _listaAutoCamionetas.Add(ac);
                    _listaVehiculos.Add(ac);
                }
                reader.Close();
                archivo.Close();              
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontrado en CargarAutosCamionetas: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos en CargarAutosCamionetas: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Se ha producido un error en CargarAutosCamionetas: {e.Message}");
            }
        }

        public void CargarCamiones()
        {
            FileStream archivo = null;
            StreamReader reader = null;

            try
            {
                _listaCamiones.Clear();
                _listaCamionesDisponibles.Clear();
                _listaCamionesVendidos.Clear();

                archivo = new FileStream("Camiones.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
                reader = new StreamReader(archivo);

                while (!reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(';');

                    int id_vehiculo = int.Parse(split[0]);
                    string patente = split[1];
                    double kilometros = double.Parse(split[2]);
                    int anio = int.Parse(split[3]);
                    int id_marca = int.Parse(split[4]);
                    string modelo = split[5];
                    int id_segmento = int.Parse(split[6]);
                    bool caja_carga = bool.Parse(split[7]);
                    int dimension_caja = int.Parse(split[8]);
                    int carga_max = int.Parse(split[9]);
                    int id_combustible = int.Parse(split[10]);
                    double precio_vta = double.Parse(split[11]);
                    string observaciones = split[12];
                    string color = split[13];                    
                    bool estado = bool.Parse(split[14]);

                    Camion cam = new Camion(id_vehiculo, patente, kilometros, anio, id_marca, modelo, id_segmento,
                    id_combustible, precio_vta, observaciones, color, caja_carga, dimension_caja, carga_max, estado);
                    if (estado)
                    {
                        _listaCamionesVendidos.Add(cam);
                    }
                    else
                    {
                        _listaCamionesDisponibles.Add(cam);
                    }
                    _listaCamiones.Add(cam);
                    _listaVehiculos.Add(cam);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontrado en CargarCamiones: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos en CargarCamiones: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Se ha producido un error en CargarCamiones: {e.Message}");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (archivo != null)
                {
                    archivo.Close();
                }
            }
        }

        public void CargarVentas()
        {
            try
            {
                _listaVentas.Clear();
                FileStream archivo = new FileStream("Ventas.txt", FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (!reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(';');
                    int id_venta = int.Parse(split[0]);
                    int id_cliente = int.Parse(split[1]);
                    int id_vehiculo = int.Parse(split[2]);
                    DateTime fecha_compra = DateTime.Parse(split[3]);
                    DateTime fecha_entrega = DateTime.Parse(split[4]);
                    double subtotal = double.Parse(split[5]);
                    int iva = int.Parse(split[6]);
                    int descuento = int.Parse(split[7]);

                    Venta ventas = new Venta(id_venta, id_cliente, id_vehiculo, fecha_compra, fecha_entrega, subtotal, iva, descuento);
                    _listaVentas.Add(ventas);
                }
                archivo.Close();
                reader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontrado en CargarVentas: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos en CargarVentas: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Se ha producido un error en CargarVentas: {e.Message}");
            }
        }

        public void CargarClientes()
        {
            try
            {
                _listaClientes.Clear();
                FileStream archivo = new FileStream("Clientes.txt", FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (!reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(';');
                    int id_cliente = int.Parse(split[0]);
                    string cliente = split[1];
                    long cuit = long.Parse(split[2]);
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
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontrado en CargarClientes: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos en CargarClientes: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Se ha producido un error en CargarClientes: {e.Message}");
            }
        }

        public void CargarMarcas()
        {
            try
            {
                _listaMarcas.Clear();
                FileStream archivo = new FileStream("Marcas.txt", FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (!reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(';');
                    int id_marca = int.Parse(split[0]);
                    string marca = split[1];
                    Marca marc = new Marca(id_marca, marca);
                    _listaMarcas.Add(marc);
                }
                archivo.Close();
                reader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontrado en CargarMarcas: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos en CargarMarcas: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Se ha producido un error en CargarMarcas: {e.Message}");
            }
        } 

        public void CargarSegmentos()
        {
            try
            {
                _listaSegmentos.Clear();
                FileStream archivo = new FileStream("Segmentos.txt", FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (!reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(';');
                    int id_segmento = int.Parse(split[0]);
                    string segmento = split[1];

                    Segmento segmentos = new Segmento(id_segmento, segmento);
                    _listaSegmentos.Add(segmentos);
                }
                archivo.Close();
                reader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontrado en CargarSegmentos: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos en CargarSegmentos: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Se ha producido un error en CargarSegmentos: {e.Message}");
            }
        }

        public void CargarCombustibles()
        {
            try
            {
                _listaCombustibles.Clear();
                FileStream archivo = new FileStream("Combustibles.txt", FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (!reader.EndOfStream)
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
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontrado en CargarCombustibles: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos en CargarCombustibles: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Se ha producido un error en CargarCombustibles: {e.Message}");
            }
        }

        public void CargarLocalidades()
        {
            try
            {
                _listaLocalidades.Clear();
                FileStream archivo = new FileStream("Localidades.txt", FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (!reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(';');
                    int id_localidad = int.Parse(split[0]);
                    string localidad = split[1];
                    int id_provincia = int.Parse(split[2]);
                    Localidad localidades = new Localidad(id_localidad, localidad, id_provincia);
                    _listaLocalidades.Add(localidades);
                }
                archivo.Close();
                reader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontradoen CargarLocalidades: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datosen CargarLocalidades: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Se ha producido un erroren CargarLocalidades: {e.Message}");
            }
        }

        public void CargarProvincias()
        {
            try
            {
                _listaProvincias.Clear();
                FileStream archivo = new FileStream("Provincias.txt", FileMode.Open);
                StreamReader reader = new StreamReader(archivo);

                while (!reader.EndOfStream)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(';');
                    int id_provincia = int.Parse(split[0]);
                    string provincia = split[1];
                    Provincia prov = new Provincia(id_provincia, provincia);
                    _listaProvincias.Add(prov);
                }
                archivo.Close();
                reader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontrado en CargarProvincia: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos en CargarProvincia: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Se ha producido un error en CargarProvincia: {e.Message}");
            }
        }

        //VEHICULOS----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------    

        public void IngresarAutoCamioneta()
        {
            CargarAutosCamionetas();
            CargarMotos();
            CargarCamiones();
            CargarSegmentos();
            CargarCombustibles();
            int id_vehiculo, anio, id_marca, id_combustible, id_segmento;
            double kilometros, precio_vta;
            DateTime fecact = DateTime.Now;
            Vehiculo vehi = new Vehiculo();
            Moto mot = new Moto();
            AutoCamioneta autcam = new AutoCamioneta();
            Camion cam = new Camion();

            Console.Write("\t\t\t*****CARGA DE AUTO/CAMIONETA*****\n\n");
            Console.Write("Ingrese el ID del vehículo a registrar: "); // ID vehículo
            do
            {
                Console.Write("Ingrese el ID del vehículo a registrar: ");
                id_vehiculo = validar.validarEntero(Console.ReadLine());

                if (!IsIdValid(id_vehiculo))
                {
                    Console.WriteLine("Error. El ID ingresado no es válido. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!IsIdValid(id_vehiculo));
            autcam.pId_vehiculo = id_vehiculo;

            /*
            while (!int.TryParse(Console.ReadLine(), out id_vehiculo) || !IsIdValid(id_vehiculo))
            {
                Console.WriteLine("Error. El ID ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del vehículo a registrar: ");
            }
            autcam.pId_vehiculo = id_vehiculo;
            */

            /*foreach (AutoCamioneta ac in this._listaAutoCamionetas)
            //{

            //    while (ac.pId_vehiculo == id_vehiculo || ac.pEstado == true)
            //    {
            //        Console.WriteLine("Error. El ID ingresado ya existe o ya fue vendido. Presione una tecla para continuar");
            //        Console.ReadKey();
            //        Console.Clear();
            //        Console.Write("Ingrese el ID del vehículo a registrar: ");
            //        int.TryParse(Console.ReadLine(), out id_vehiculo);
            //    }

            //}
            //foreach (Moto m in this._listaMotos)
            //{
            //    while (m.pId_vehiculo == id_vehiculo || m.pEstado == true)
            //    {
            //        Console.WriteLine("Error. El ID ingresado ya existe o ya fue vendido. Presione una tecla para continuar");
            //        Console.ReadKey();
            //        Console.Clear();
            //        Console.Write("Ingrese el ID del vehículo a registrar: ");
            //        int.TryParse(Console.ReadLine(), out id_vehiculo);
            //    }
            //}

            //foreach (Camion c in this._listaCamiones)
            //{
            //    while (c.pId_vehiculo == id_vehiculo || c.pEstado == true)
            //    {
            //        Console.WriteLine("Error. El ID ingresado ya existe o ya fue vendido. Presione una tecla para continuar");
            //        Console.ReadKey();
            //        Console.Clear();
            //        Console.Write("Ingrese el ID del vehículo a registrar: ");
            //        int.TryParse(Console.ReadLine(), out id_vehiculo);
            //    }
            //}
            */

            // Ingreso de patente 
            //bool bucle = false;
            do
            {
                Console.Write("\nIngrese la PATENTE del vehículo a registrar (AAA000 / AA000AA): "); // Patente
                string patente = Console.ReadLine();

                if (IsPatenteUnique(patente))
                {
                    autcam.pPatente = patente;
                    //bucle = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Error. La PATENTE ingresada ya existe. Ingrese una PATENTE diferente.");
                }
            } while (true);


            Console.Write("\nIngrese los KILOMETROS del vehículo a registrar: "); // Kilómetros
            kilometros = validar.validarDoble(Console.ReadLine());
            /*
            while (!double.TryParse(Console.ReadLine(), out kilometros))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese los KILOMETROS del vehículo a registrar: ");
            }
            */
            autcam.pKilometros = kilometros;

            
            Console.Write("\nIngrese el AÑO del vehículo a registrar: "); // Año.



            while (!int.TryParse(Console.ReadLine(), out anio) || anio > fecact.Year)
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el AÑO del vehículo a registrar: ");
            }
            autcam.pAnio = anio;

            Console.Write("\n "); // ID Marca
            foreach (Marca mar in this._listaMarcas)
            {
                Console.WriteLine($"{mar.pId_marca} -> {mar.pMarca}");
            }

            Console.Write("\nIngrese el ID de la MARCA del vehiculo a registrar: "); // ID Marca
            id_marca = validar.validarEntero(Console.ReadLine());
            /*while (!int.TryParse(Console.ReadLine(), out id_marca))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la MARCA del vehículo a registrar: ");
            }*/
            autcam.pId_marca = id_marca;

            Console.Write("\nIngrese el NOMBRE del MODELO del vehiculo a registrar: "); // Nombre Modelo 
            autcam.pModelo = Console.ReadLine();
            // do
            // {
            Console.Write("\n ");
            foreach (Segmento seg in this._listaSegmentos)
            {
                Console.WriteLine($"{seg.pIdSegmento} -> {seg.pSegmento}");
            }

            Console.Write("\nIngrese el ID del SEGMENTO del vehiculo a registrar: "); // ID segmento
            id_segmento = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_segmento))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del SEGMENTO del vehículo a registrar: ");
            }
            */
            while (id_segmento > 4)
            {
                Console.WriteLine("Error. El SEGMENTO ingresado no corresponde a un Auto/Camioneta. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del SEGMENTO del vehiculo a registrar: ");
                id_segmento = int.Parse(Console.ReadLine());
            }
            autcam.pId_segmento = id_segmento;

            //} while (!int.TryParse(Console.ReadLine(), out id_segmento) || id_segmento>4);
            Console.Write("\n ");
            foreach(Combustible comb in this._listaCombustibles)
            {
                Console.WriteLine($"{comb.pIdCombustible} -> {comb.pCombustible}");
            }

            Console.Write("\nIngrese el ID del COMBUSTIBLE del vehiculo a registrar: "); // ID Combustible
            id_combustible = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_combustible))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del COMBUSTIBLE del vehículo a registrar: ");
            }
            */
            autcam.pId_combustible = id_combustible;

            Console.Write("\nIngrese el PRECIO DE VENTA del vehículo a registrar: "); // Precio Venta
            precio_vta = validar.validarEntero(Console.ReadLine());
            /*
            while (!double.TryParse(Console.ReadLine(), out precio_vta))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el PRECIO DE VENTA del vehículo a registrar: ");
            }*/
            autcam.pPrecio_vta = precio_vta;

            Console.Write("\nIngrese las OBSERVACIONES del vehículo a registrar (en caso de existir alguna): "); // Observaciones
            autcam.pObservaciones = Console.ReadLine();
            if (autcam.pObservaciones == "")
            {
                autcam.pObservaciones = "Sin observaciones";
            }

            Console.Write("\nIngrese el COLOR del vehículo a registrar: "); // color
            autcam.pColor = Console.ReadLine();

            autcam.pEstado = false;
            
            
            _listaAutoCamionetas.Add(autcam);
            _listaAutoCamionetasDisponibles.Add(autcam);
            _listaVehiculos.Add(autcam);

        } // modificar las validaciones del resto de los ingresos con el nuevo metodo 

        public void IngresarMoto()
        {
            CargarAutosCamionetas();
            CargarMotos();
            CargarCamiones();
            CargarSegmentos();
            CargarCombustibles();
            int id_vehiculo, anio, id_marca, id_combustible, id_segmento, cilindrada;
            double kilometros, precio_vta;
            DateTime fecact = DateTime.Now;
            Vehiculo vehi = new Vehiculo();
            Moto mot = new Moto();
            AutoCamioneta autcam = new AutoCamioneta();
            Camion cam = new Camion();
            Console.Write("\t\t\t*****CARGA DE MOTO*****\n\n");

            do
            {
                Console.Write("Ingrese el ID del vehículo a registrar: ");
                id_vehiculo = validar.validarEntero(Console.ReadLine());

                if (!IsIdValid(id_vehiculo))
                {
                    Console.WriteLine("Error. El ID ingresado no es válido. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!IsIdValid(id_vehiculo));
            mot.pId_vehiculo = id_vehiculo;

            /*Console.Write("Ingrese el ID del vehículo a registrar: "); // ID vehículo
            while (!int.TryParse(Console.ReadLine(), out id_vehiculo))
            {
                Console.WriteLine("Error. El ID ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del vehículo a registrar: ");
            }*/

            foreach (AutoCamioneta ac in this._listaAutoCamionetas)
            {
                while (ac.pId_vehiculo == id_vehiculo || ac.pEstado == true)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe o ya fue vendido. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del vehículo a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_vehiculo);
                }
            }

            foreach (Moto m in this._listaMotos)
            {
                while (m.pId_vehiculo == id_vehiculo || m.pEstado == true)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe o ya fue vendido. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del vehículo a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_vehiculo);
                }
            }

            foreach (Camion c in this._listaCamiones)
            {
                while (c.pId_vehiculo == id_vehiculo || c.pEstado == true)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe o ya fue vendido. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del vehículo a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_vehiculo);
                }
            }
            mot.pId_vehiculo = id_vehiculo;

            Console.Write("\nIngrese la PATENTE del vehículo a registrar (AAA000 / AA000AA): "); // Patente
            //patente = Console.ReadLine();
            mot.pPatente = Console.ReadLine();

            Console.Write("\nIngrese los KILOMETROS del vehículo a registrar: "); // Kilómetros
            kilometros = validar.validarDoble(Console.ReadLine());
            /*
            while (!double.TryParse(Console.ReadLine(), out kilometros))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese los KILOMETROS del vehículo a registrar: ");
            }
            */
            mot.pKilometros = kilometros;

            Console.Write("\nIngrese el AÑO del vehículo a registrar: "); // Año
            while (!int.TryParse(Console.ReadLine(), out anio) || anio > fecact.Year)
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el AÑO del vehículo a registrar: ");
            }
            mot.pAnio = anio;
            Console.Write("\n");
            foreach (Marca mar in this._listaMarcas)
            {
                Console.WriteLine($"{mar.pId_marca} -> {mar.pMarca}");
            }
            Console.Write("\nIngrese el ID de la MARCA del vehiculo a registrar: ");
            id_marca = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_marca))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la MARCA del vehículo a registrar: ");
            }
            */
            mot.pId_marca = id_marca;

            Console.Write("\n");
            foreach (Segmento seg in this._listaSegmentos)
            {
                Console.WriteLine($"{seg.pIdSegmento} -> {seg.pSegmento}");
            }

            Console.Write("\nIngrese el ID del SEGMENTO del vehiculo a registrar: ");
            id_segmento = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_segmento))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del segmento del vehículo a registrar: ");
            }
            */
            while (id_segmento < 5 || id_segmento > 7)
            {
                Console.WriteLine("Error. El segmento ingresado no corresponde a una Moto. Presione una tecla para continuar. ");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del segmento del vehiculo a registar: ");
                id_segmento = int.Parse(Console.ReadLine());
            }
            mot.pId_segmento = id_segmento;

            Console.Write("\nIngrese la CILINDRADA: ");
            cilindrada = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out cilindrada))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese la Cilindrada del vehículo a registrar: ");
            }
            */
            mot.pCilindrada = cilindrada;

            Console.Write("\n ");
            foreach (Combustible comb in this._listaCombustibles)
            {
                Console.WriteLine($"{comb.pIdCombustible} -> {comb.pCombustible}");
            }
            Console.Write("\nIngrese el ID del COMBUSTIBLE del vehiculo a registrar: ");
            id_combustible = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_combustible))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del COMBUSTIBLE del vehículo a registrar: ");
            }
            */
            mot.pId_combustible = id_combustible;

            Console.Write("\nIngrese el PRECIO de VENTA del vehículo a registrar: "); // Precio
            precio_vta = validar.validarEntero(Console.ReadLine());
            /*
            while (!double.TryParse(Console.ReadLine(), out precio_vta))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el PRECIO de VENTA del vehículo a registrar: ");
            }
            */
            mot.pPrecio_vta = precio_vta;

            Console.Write("\nIngrese las OBSERVACIONES del vehículo a registrar (en caso de existir alguna): "); // Observaciones
            mot.pObservaciones = Console.ReadLine();
            if (mot.pObservaciones == " ")
            {
                mot.pObservaciones = "Sin observaciones";
            }

            Console.Write("\nIngrese el COLOR del vehículo a registrar: "); // color
            mot.pColor = Console.ReadLine();

            mot.pEstado = false;
            _listaMotos.Add(mot);
            _listaMotosDisponibles.Add(mot);
            _listaVehiculos.Add(mot);
        }

        public void IngresarCamion()
        {
            CargarAutosCamionetas();
            CargarMotos();
            CargarCamiones();
            CargarSegmentos();
            CargarCombustibles();
            int id_vehiculo, anio, id_marca, id_combustible, id_segmento, dimension_caja, 
                carga_max, largocaja, anchocaja, opc;
            double kilometros, precio_vta;
            bool caja_carga;
            DateTime fecact = DateTime.Now;
            Vehiculo vehi = new Vehiculo();
            Moto mot = new Moto();
            AutoCamioneta autcam = new AutoCamioneta();
            Camion cam = new Camion();

            Console.Write("\t\t\t*****CARGA DE CAMION*****\n\n");
            do
            {
                Console.Write("Ingrese el ID del vehículo a registrar: ");
                id_vehiculo = validar.validarEntero(Console.ReadLine());

                if (!IsIdValid(id_vehiculo))
                {
                    Console.WriteLine("Error. El ID ingresado no es válido. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!IsIdValid(id_vehiculo));
            cam.pId_vehiculo = id_vehiculo;
            /*
            Console.Write("Ingrese el ID del vehículo a registrar: "); // ID vehículo
            while (!int.TryParse(Console.ReadLine(), out id_vehiculo))
            {
                Console.WriteLine("Error. El ID ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del vehículo a registrar: ");
            }
            */
            foreach (AutoCamioneta ac in this._listaAutoCamionetas)
            {
                while (ac.pId_vehiculo == id_vehiculo || ac.pEstado == true)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe o ya fue vendido. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del vehículo a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_vehiculo);
                }

            }
            foreach (Moto m in this._listaMotos)
            {
                while (m.pId_vehiculo == id_vehiculo || m.pEstado == true)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe o ya fue vendido. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del vehículo a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_vehiculo);
                }
            }
            foreach (Camion c in this._listaCamiones)
            {
                while (c.pId_vehiculo == id_vehiculo || c.pEstado == true)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe o ya fue vendido. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del vehículo a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_vehiculo);
                }
            }
            cam.pId_vehiculo = id_vehiculo;

            Console.Write("\nIngrese la PATENTE del vehículo a registrar (AAA000 / AA000AA): "); // Patente
            string patente = Console.ReadLine();
            cam.pPatente = patente;

            Console.Write("\nIngrese los KILOMETROS del vehículo a registrar: "); // Kilómetros
            kilometros = validar.validarDoble(Console.ReadLine());
            /*
            while (!double.TryParse(Console.ReadLine(), out kilometros))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese los KILOMETROS del vehículo a registrar: ");
            }
            */
            cam.pKilometros = kilometros;

            Console.Write("\nIngrese el AÑO del vehículo a registrar: "); // Año. Se puede establecer rango min-max
            anio = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out anio) || anio > fecact.Year)
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el AÑO del vehículo a registrar: ");
            }
            */
            cam.pAnio = anio;

            Console.Write("\n ");
            foreach (Marca mar in this._listaMarcas)
            {
                Console.WriteLine($"{mar.pId_marca} -> {mar.pMarca}");
            }

            Console.Write("\nIngrese el ID de la MARCA del vehiculo a registrar: ");
            id_marca = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_marca))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la MARCA del vehículo a registrar: ");
            }
            */
            cam.pId_marca = id_marca;

            Console.Write("\nIngrese el NOMBRE del MODELO del vehiculo a registrar: ");
            cam.pModelo = Console.ReadLine();


            // do
            // {
            Console.Write("\n ");
            foreach (Segmento seg in this._listaSegmentos)
            {
                Console.WriteLine($"{seg.pIdSegmento} -> {seg.pSegmento}");
            }

            Console.Write("\nIngrese el ID del SEGMENTO del vehiculo a registrar: ");
            id_segmento = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_segmento))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del segmento del vehículo a registrar: ");
            }
            */
            while (id_segmento != 8)
            {
                Console.WriteLine("Error. El segmento ingresado no corresponde a un Camion. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del segmento del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out id_segmento);
            }
            // } while (!int.TryParse(Console.ReadLine(), out id_segmento) || id_segmento != 8);
            cam.pId_segmento = id_segmento;

            string[] menucaja = { "SI", "NO" };
            /*
            int indexcaja = 0;
            ConsoleKeyInfo opccaja;
            */

            Console.WriteLine("\nIngrese si el camion tiene caja 1 -> SI\t2 -> NO: ");
            while (!int.TryParse(Console.ReadLine(), out opc) || opc > 2)
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese si el camion tiene caja 1 -> SI\t2 -> NO:");
            }
            if (opc == 1)
            {
                cam.pCaja_Carga = true;
            }
            else if (opc == 2)
            {
                cam.pCaja_Carga = false;
            }

            /*
            do
            {
                //Fondo menu
                for (int i = 0; i < menucaja.Length; i++)
                {

                    if (i == indexcaja)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    Console.WriteLine(menucaja[i]);
                }
                Console.ResetColor();
                opccaja = Console.ReadKey();

                switch (opccaja.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (indexcaja > 0)
                        {
                            indexcaja--;
                        }
                        else if (indexcaja == 0)
                        {
                            indexcaja = 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:

                        if (indexcaja < (menucaja.Length - 1))
                        {
                            indexcaja++;
                        }
                        else if (indexcaja == 1)
                        {
                            indexcaja = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        if (menucaja[indexcaja] == "SI")
                        {
                            cam.pCaja_Carga = true;

                        }
                        else if (menucaja[indexcaja] == "NO")
                        {
                            cam.pCaja_Carga = true;

                        }

                        Console.Write($"El camion {menucaja[indexcaja]} tiene caja.");
                        break;
                        
                }
            } while (opccaja.Key != ConsoleKey.Escape);
            */

            Console.Write("\nIngrese el LARGO de la caja del camion (en metros): ");
            largocaja = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out largocaja))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el Largo de la caja del camion a registrar(en mts): ");
            }
            */

            Console.Write("\nIngrese el ANCHO de la caja del camion (en metros): ");
            anchocaja = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out anchocaja))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ancho de la caja del camion a registrar(en mts): ");
            }
            */
            dimension_caja = largocaja * anchocaja;
            cam.pDimension_caja = dimension_caja;

            Console.Write("\nIngrese la CARGA MAXIMA de la caja del camion (en kg): ");
            carga_max = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out carga_max))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese la carga maxima de la caja del camion a registrar: ");
            }
            */
            cam.pCarga_max = carga_max;

            Console.Write("\n ");
            foreach (Combustible comb in this._listaCombustibles)
            {
                Console.WriteLine($"{comb.pIdCombustible} -> {comb.pCombustible}");
            }
            Console.Write("\nIngrese el ID del COMBUSTIBLE del vehiculo a registrar: ");
            id_combustible = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_combustible))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del COMBUSTIBLE del vehículo a registrar: ");
            }
            */
            cam.pId_combustible = id_combustible;

            Console.Write("\nIngrese el PRECIO de VENTA del vehículo a registrar: "); // Precio
            precio_vta = validar.validarEntero(Console.ReadLine());
            /*
            while (!double.TryParse(Console.ReadLine(), out precio_vta))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el PRECIO de VENTA del vehículo a registrar: ");
            }
            */
            cam.pPrecio_vta = precio_vta;

            Console.Write("\nIngrese las OBSERVACIONES del vehículo a registrar (en caso de existir alguna): "); // Observaciones
            cam.pObservaciones = Console.ReadLine();
            if (cam.pObservaciones == " ")
            {
                cam.pObservaciones = "Sin observaciones";
            }

            Console.Write("\nIngrese el COLOR del vehículo a registrar: "); // color
            cam.pColor = Console.ReadLine();

            cam.pEstado = false;

            _listaCamiones.Add(cam);
            _listaCamionesDisponibles.Add(cam);
            _listaVehiculos.Add(cam);
        }       

        public void MostrarVehiculos() 
        {
            CargarAutosCamionetas();
            CargarCamiones();
            CargarMotos();
            Console.WriteLine("Autos y Camionetas\n");
            
            //foreach (Vehiculo vehiculo in _listaVehiculos)
            //{
            //    vehiculo.MostrarDatos();
            //}
            
            foreach(AutoCamioneta acam in this._listaAutoCamionetasDisponibles)
            {
                acam.MostrarDatos();
            }
            Console.WriteLine("\nMotos\n");
            
            foreach (Moto mot in _listaMotosDisponibles)
            {
                mot.MostrarDatos();
            }
            Console.WriteLine("\nCamiones\n");

            foreach (Camion cam in _listaCamionesDisponibles)
            {
                cam.MostrarDatos();
            }
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        } 
    
        public void ActualizarAutoCamioneta()
        {
            arch = new FileStream("AutosCamioneta.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (AutoCamioneta autcam in this._listaAutoCamionetas)
            {
                wr.WriteLine($"{autcam.pId_vehiculo};{autcam.pPatente};{autcam.pKilometros};{autcam.pAnio};{autcam.pId_marca};{autcam.pModelo};" +
                    $"{autcam.pId_segmento};{autcam.pId_combustible};{autcam.pPrecio_vta};{autcam.pObservaciones};{autcam.pColor};{autcam.pEstado}");
            }
            wr.Close();
            arch.Close();
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void ActualizarMotos()
        {
            arch = new FileStream("Motos.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (Moto moto in this._listaMotos)
            {
                wr.WriteLine($"{moto.pId_vehiculo};{moto.pPatente};{moto.pKilometros};{moto.pAnio};{moto.pId_marca};{moto.pModelo};" +
                    $"{moto.pId_segmento};{moto.pCilindrada};{moto.pId_combustible};{moto.pPrecio_vta};{moto.pObservaciones};{moto.pColor};{moto.pEstado}");
            }
            wr.Close();
            arch.Close();
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void ActualizarCamiones()
        {
            arch = new FileStream("Camiones.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (Camion cam in this._listaCamiones)
            {
                wr.WriteLine($"{cam.pId_vehiculo};{cam.pPatente};{cam.pKilometros};{cam.pAnio};{cam.pId_marca};{cam.pModelo};" +
                    $"{cam.pId_segmento};{cam.pCaja_Carga};{cam.pDimension_caja};{cam.pCarga_max};{cam.pId_combustible};" +
                    $"{cam.pPrecio_vta};{cam.pObservaciones};{cam.pColor};{cam.pEstado}");
            }
            wr.Close();
            arch.Close();
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void BorrarVehiculo()
        {
            CargarAutosCamionetas();
            CargarCamiones();
            CargarMotos();

            int id, flag = 0, i, j , k ;
            string patente;
            //string cad;
            Console.WriteLine("Ingrese la PATENTE del Vehiculo a eliminar: ");
            patente = Console.ReadLine();
            //id = int.Parse(cad);
            //id = validar.validarEntero(Console.ReadLine());
            
            for (i = _listaAutoCamionetasDisponibles.Count() - 1; i >= 0; i--)
            {
                if (_listaAutoCamionetasDisponibles[i].pPatente.ToLower() == patente.ToLower())
                {
                    flag = 1;
                    _listaAutoCamionetasDisponibles.RemoveAt(i);
                }

            }
            for (j = _listaMotosDisponibles.Count() - 1; j >= 0; j--)
            {
                if (_listaMotosDisponibles[j].pPatente.ToLower() == patente.ToLower())
                {
                    flag = j;
                    //_listaMotosDisponibles.RemoveAt(j);
                }

            }
            for (k = _listaCamionesDisponibles.Count() - 1; k >= 0; k--)
            {
                
                
                if (_listaCamionesDisponibles[k].pPatente.ToLower() == patente.ToLower())
                {
                    flag = k;
                    //_listaCamionesDisponibles.RemoveAt(k); ;
                }
            }
            
            if (flag == 0)
            {
                Console.Write($"La PATENTE -{patente}- no existe en la lista de Vehiculos");
            }
            else
            {
                if (flag == i)
                {
                    _listaAutoCamionetasDisponibles.RemoveAt(flag);
                }
                else if (flag == j)
                {
                    _listaMotosDisponibles.RemoveAt(flag);
                }
                else if (flag == k)
                {
                    _listaCamionesDisponibles.RemoveAt(flag);
                }

                Console.Write($"El articulo la PATENTE -{patente}- fue eliminado");
            }
             
        }

        public void ModificarVehiculo()
        {
            CargarMotos();
            CargarAutosCamionetas();
            CargarCamiones();

            AutoCamioneta autoCamioneta = new AutoCamioneta();
            Camion camion = new Camion();
            Moto moto = new Moto();
            int id, flag = 0, i =_listaAutoCamionetasDisponibles.Count() - 1, j = _listaMotosDisponibles.Count() - 1, k = _listaCamionesDisponibles.Count() - 1;
            //string cad;

            Console.WriteLine("Ingrese el ID del Vehiculo a modificar:");
            id = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Error: El formato del ID ingresado no es correcto, se debe ingresar un numero. Intente Nuevamente.");
            }
            */

            foreach (AutoCamioneta autcam in _listaAutoCamionetasDisponibles)
            {
                if(autcam.pId_vehiculo == id)
                {
                    string[] menumodif = { "Patente", "Kilometros", "Año", "Id de marca",
                    "Modelo", "Id de segmento", "Id de combustible", "Precio", "Observaciones", "Color"};
                    int indexmodif = 0;
                    ConsoleKeyInfo opcmodif;
                    Console.Clear();

                    do
                    {
                        Console.WriteLine("Ingrese el dato que desea modificar\n");
                        for (i = 0; i < menumodif.Length; i++)
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
                                    indexmodif = 9;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                Console.Clear();
                                if (indexmodif < (menumodif.Length - 1))
                                {
                                    indexmodif++;
                                }
                                else if (indexmodif == 9)
                                {
                                    indexmodif = 0;
                                }
                                break;
                            case ConsoleKey.Enter:
                                Console.Clear();
                                if (menumodif[indexmodif] == "Patente")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la PATENTE que modificará la actual -{autcam.pPatente}-: ");
                                    string patentemodif = Console.ReadLine();
                                    autcam.pPatente = patentemodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Kilometros")
                                {
                                    double kilomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el Kilometraje que modificará el actual -{autcam.pKilometros}-: ");
                                    kilomodif = validar.validarDoble(Console.ReadLine());

                                    /*
                                    while (!double.TryParse(Console.ReadLine(), out kilomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el Kilometraje que modificará el actual -{autcam.pKilometros}-:  ");
                                    }
                                    */
                                    autcam.pKilometros = kilomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Año")
                                {
                                    int aniomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el AÑO que modificará el actual -{autcam.pAnio}-: ");
                                    aniomodif = validar.validarEntero(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out aniomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el AÑO que modificará el actual -{autcam.pAnio}-:  ");
                                    }
                                    */
                                    autcam.pAnio = aniomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Id de marca")
                                {
                                    int idmarcamodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el ID de MARCA que modficará el actual -{autcam.pId_marca}-: ");
                                    idmarcamodif = validar.validarEntero(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out idmarcamodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de MARCA que modficará el actual -{autcam.pId_marca}-:  ");
                                    }
                                    */
                                    autcam.pId_marca = idmarcamodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Modelo")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el MODELO que modificará el actual -{autcam.pModelo}-: ");
                                    autcam.pModelo = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Id de segmento")
                                {
                                    int idsegmentomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese ID de Segmento que modificará el actual -{autcam.pId_segmento}-: ");
                                    idsegmentomodif = validar.validarEntero(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out idsegmentomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de MARCA que modficará el actual -{autcam.pId_segmento}-:  ");
                                    }
                                    */
                                    autcam.pId_segmento = idsegmentomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Id de combustible")
                                {
                                    int idcombmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el ID de COMBUSTIBLE que modificará el actual -{autcam.pId_combustible}-: ");
                                    idcombmodif = validar.validarEntero(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out idcombmodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de MARCA que modificará el actual -{autcam.pId_combustible}-:  ");
                                    }
                                    */
                                    autcam.pId_combustible = idcombmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Precio")
                                {
                                    double preciomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el PRECIO que modificará el actual -{autcam.pPrecio_vta}-: ");
                                    preciomodif = validar.validarEntero(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!double.TryParse(Console.ReadLine(), out preciomodif))
                                    { 
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de MARCA que modificará el actual -{autcam.pPrecio_vta}-:  ");
                                    }
                                    */
                                    autcam.pPrecio_vta = preciomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Observaciones")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la Observacion que modificará la actual -{autcam.pObservaciones}-: ");
                                    autcam.pObservaciones = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Color")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el COLOR que modificará el actual -{autcam.pColor}-: ");
                                    autcam.pColor = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menu.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    } while (opcmodif.Key != ConsoleKey.Escape);
                }
            }
            foreach (Moto mot in _listaMotosDisponibles)
            {
                if (mot.pId_vehiculo == id)
                {
                    if (flag == j)
                    {
                        string[] menumodif = { "Patente", "Kilometros", "Año", "Id de marca",
                "Modelo", "Id de segmento", "Id de combustible", "Precio", "Observaciones", "Color", "Cilindrada"};
                        int indexmodif = 0;
                        ConsoleKeyInfo opcmodif;
                        Console.Clear();
                        Console.WriteLine("Ingrese el dato que desea modificar.\n");
                        do
                        {
                            for (i = 0; i < menumodif.Length; i++)
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
                                        indexmodif = 10;
                                    }
                                    break;
                                case ConsoleKey.DownArrow:
                                    Console.Clear();
                                    if (indexmodif < (menumodif.Length - 1))
                                    {
                                        indexmodif++;
                                    }
                                    else if (indexmodif == 10)
                                    {
                                        indexmodif = 0;
                                    }
                                    break;
                                case ConsoleKey.Enter:
                                    Console.Clear();
                                    if (menumodif[indexmodif] == "Patente")
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese la PATENTE que modificará la actual -{mot.pPatente}-: ");
                                        mot.pPatente = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Kilometros")
                                    {
                                        double kilomodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el Kilometraje que modificará el actual -{mot.pKilometros}-: ");
                                        kilomodif = validar.validarDoble(Console.ReadLine());
                                        /*
                                        while (!double.TryParse(Console.ReadLine(), out kilomodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese el Kilometraje que modificará el actual -{mot.pKilometros}-:  ");
                                        }
                                        */
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Año")
                                    {

                                        int aniomodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el AÑO que modificará el actual -{mot.pAnio}-: ");
                                        aniomodif = validar.validarEntero(Console.ReadLine());
                                        /*
                                        cad = Console.ReadLine();
                                        while (!int.TryParse(Console.ReadLine(), out aniomodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese el AÑO que modificará el actual -{mot.pAnio}-:  ");
                                        }
                                        */
                                        mot.pAnio = aniomodif;
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Id de marca")
                                    {
                                        int idmarcamodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el ID de MARCA que modificará el actual -{mot.pId_marca}-: ");
                                        idmarcamodif = validar.validarEntero(Console.ReadLine());
                                        /*
                                        cad = Console.ReadLine();
                                        while (!int.TryParse(Console.ReadLine(), out idmarcamodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese el ID de MARCA que modificará el actual -{mot.pId_marca}-:  ");
                                        }
                                        */
                                        mot.pId_marca = idmarcamodif;
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Modelo")
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el MODELO que modificará el actual -{mot.pModelo}-: ");
                                        mot.pModelo = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Id de segmento")
                                    {
                                        int idsegmentomodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el % de IVA que modificará el actual -{mot.pId_segmento}-: ");
                                        idsegmentomodif = validar.validarEntero(Console.ReadLine());
                                        /*
                                        cad = Console.ReadLine();
                                        while (!int.TryParse(Console.ReadLine(), out idsegmentomodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese el ID de MARCA que modificará el actual -{mot.pId_segmento}-:  ");
                                        }
                                        */
                                        mot.pId_segmento = idsegmentomodif;
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Id de combustible")
                                    {
                                        int idcombmodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el ID de COMBUSTIBLE que modificará el actual -{mot.pId_combustible}-: ");
                                        idcombmodif = validar.validarEntero(Console.ReadLine());
                                        /*
                                        cad = Console.ReadLine();
                                        while (!int.TryParse(Console.ReadLine(), out idcombmodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese el ID de MARCA que modificará el actual -{mot.pId_combustible}-:  ");
                                        }
                                        */
                                        mot.pId_combustible = idcombmodif;
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Precio")
                                    {
                                        double preciomodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el PRECIO que modificará el actual -{mot.pPrecio_vta}-: ");
                                        preciomodif = validar.validarEntero(Console.ReadLine());
                                        /*
                                        cad = Console.ReadLine();
                                        while (!double.TryParse(Console.ReadLine(), out preciomodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese el ID de MARCA que modificará el actual -{mot.pPrecio_vta}-:  ");
                                        }
                                        */
                                        mot.pPrecio_vta = preciomodif;
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Observaciones")
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese la Observacion que modificará la actual -{mot.pObservaciones}-: ");
                                        mot.pObservaciones = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Color")
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el COLOR que modificará el actual -{mot.pColor}-: ");
                                        mot.pColor = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificado correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Cilindrada")
                                    {
                                        int cilinmodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese la Cilindrada que modificará la actual -{mot.pCilindrada}-: ");
                                        cilinmodif = validar.validarEntero(Console.ReadLine());
                                        /*
                                        cad = Console.ReadLine();
                                        while (!int.TryParse(Console.ReadLine(), out cilinmodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese la Cilindrada que modficará el actual -{mot.pPrecio_vta}-: ");
                                        }
                                        */
                                        mot.pCilindrada = cilinmodif;
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                    }

                                    Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menu.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        } while (opcmodif.Key != ConsoleKey.Escape);
                    }
                }
            }
            foreach (Camion cam in _listaCamionesDisponibles)
            {
                if (cam.pId_vehiculo == id)
                {
                    string[] menumodif = { "Patente", "Kilometros", "Año", "Id de marca",
                "Modelo", "Id de segmento", "Id de combustible", "Precio", "Observaciones", "Color", "Caja de carga", "Dimensiones de caja", "Carga maxima"};
                    int indexmodif = 0;
                    ConsoleKeyInfo opcmodif;
                    Console.Clear();
                    Console.WriteLine("Ingrese el dato que desea modificar.\n");
                    do
                    {
                        for (i = 0; i < menumodif.Length; i++)
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
                                    indexmodif = 12;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                Console.Clear();
                                if (indexmodif < (menumodif.Length - 1))
                                {
                                    indexmodif++;
                                }
                                else if (indexmodif == 12)
                                {
                                    indexmodif = 0;
                                }
                                break;
                            case ConsoleKey.Enter:
                                Console.Clear();
                                if (menumodif[indexmodif] == "Patente")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la PATENTE que modificará la actual -{cam.pPatente}-: ");
                                    cam.pPatente = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Kilometros")
                                {
                                    double kilomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el Kilometraje que modificará el actual -{cam.pKilometros}-: ");
                                    kilomodif = validar.validarEntero(Console.ReadLine());

                                    /*
                                    while (!double.TryParse(Console.ReadLine(), out kilomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el Kilometraje que modficará el actual -{cam.pKilometros}-:  ");
                                    }
                                    */
                                    cam.pKilometros = kilomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Año")
                                {
                                    int aniomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el AÑO que modificará el actual -{cam.pAnio}-: ");
                                    aniomodif = validar.validarEntero(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out aniomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el AÑO que modificará el actual -{cam.pAnio}-:  ");
                                    }
                                    */
                                    cam.pAnio = aniomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Id de marca")
                                {
                                    int idmarcamodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el ID de MARCA que modificará el actual -{cam.pId_marca}-: ");
                                    idmarcamodif = validar.validarEntero(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out idmarcamodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de MARCA que modificará el actual -{cam.pId_marca}-:  ");
                                    }
                                    */
                                    cam.pId_marca = idmarcamodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Modelo")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el MODELO que modificará el actual -{cam.pModelo}-: ");
                                    cam.pModelo = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Id de segmento")
                                {
                                    int idsegmentomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el % de IVA que modificará el actual -{cam.pId_segmento}-: ");
                                    idsegmentomodif = validar.validarEntero(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out idsegmentomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de MARCA que modificará el actual -{cam.pId_segmento}-:  ");
                                    }
                                    */
                                    cam.pId_segmento = idsegmentomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Id de combustible")
                                {
                                    int idcombmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el ID de COMBUSTIBLE que modificará el actual -{cam.pId_combustible}-: ");
                                    idcombmodif = validar.validarEntero(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out idcombmodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de MARCA que modificará el actual -{cam.pId_combustible}-:  ");
                                    }
                                    */
                                    cam.pId_combustible = idcombmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Precio")
                                {
                                    double preciomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el PRECIO que modificará el actual -{cam.pPrecio_vta}-: ");
                                    preciomodif = validar.validarDoble(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!double.TryParse(Console.ReadLine(), out preciomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de MARCA que modificará el actual -{cam.pPrecio_vta}-:  ");
                                    }
                                    */
                                    cam.pPrecio_vta = preciomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Observaciones")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la Observacion que modificará la actual -{cam.pObservaciones}-: ");
                                    cam.pObservaciones = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Color")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el COLOR que modificará el actual -{cam.pColor}-: ");
                                    cam.pColor = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Caja de carga")
                                {

                                    Console.Clear();
                                    if(cam.pCaja_Carga == true)
                                    {
                                        cam.pCaja_Carga = false;
                                    }
                                    else
                                    {
                                        cam.pCaja_Carga = true;
                                    }
    
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Dimensiones de caja")
                                {
                                    int dimensionmodif;
                                    int largomodif, anchomnodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese los datos que modificaran la Dimension actual -{cam.pDimension_caja}-: ");
                                    Console.WriteLine($"\nIngrese el LARGO de la caja: ");
                                    largomodif = validar.validarEntero(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out largomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el Largo que modificará el actual: ");
                                    }
                                    */

                                    Console.WriteLine($"\nIngrese el ANCHO de la caja: ");
                                    anchomnodif = validar.validarEntero(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out anchomnodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el Ancho que modificará el actual: ");
                                    }
                                    */
                                    dimensionmodif = largomodif * anchomnodif;
                                    cam.pDimension_caja = dimensionmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Carga maxima")
                                {
                                    int cargamaxmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la CARGA MAX. que modificará la actual -{cam.pCarga_max}-: ");
                                    cargamaxmodif = validar.validarEntero(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out cargamaxmodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese la CILINDRADA que modificará el actual -{cam.pCarga_max}-: ");
                                    }
                                    */
                                    cam.pCarga_max = cargamaxmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }
                                Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menu.");
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

                if (flag == 1)
                {
                    Console.Clear();
                    Console.Write($"La ID -{id}- no existe en la lista de Vehiculos.");
                }
            }          
        }

        public void BuscarVehiculo()
        {
            CargarAutosCamionetas();
            CargarMotos();
            CargarCamiones();
            string patente;
            bool encontrado = false;

            do
            {
                Console.Write("Ingrese la PATENTE del vehiculo que desea buscar: ");
                patente = Console.ReadLine();
                foreach (AutoCamioneta ac in this._listaAutoCamionetas)
                {
                    if (patente == ac.pPatente)
                    {
                        ac.MostrarDatos();
                        encontrado = true;
                    }
                }
                foreach (Moto m in this._listaMotos)
                {
                    if (patente == m.pPatente)
                    {
                        m.MostrarDatos();
                        encontrado = true;
                    }
                }
                foreach (Camion c in this._listaCamiones)
                {
                    if (patente == c.pPatente)
                    {
                        c.MostrarDatos();
                        encontrado = true;
                    }
                }
                if (!encontrado)
                {
                    Console.Clear();
                    Console.WriteLine("Error en el ingreso. Patente no encontrada.");
                }
            }
            while (!encontrado);
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadKey();
        }

        //VENTAS----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
    
        public void CargarVenta()
        {
            CargarAutosCamionetas();
            CargarCamiones();
            CargarMotos();
            CargarClientes();
            CargarVentas();

            int id_venta, id_cliente=0, id_vehiculo = 0, iva, descuento, opc;
            DateTime fecha_compra, fecha_entrega;
            double subtotal;
            bool flag = false, opcionValida = false;

            Console.WriteLine("****CARGA DE VENTA****\n");
            Console.Write($"ID's NO disponibles: ");
            foreach (Venta ven in this._listaVentas)
            {
                Console.WriteLine($"{ven.pId_venta}\t");
            }

            id_venta = validar.validarEntero(Console.ReadLine());
            /*
            Console.Write("\nIngrese el ID de la VENTA: ");
            while (!int.TryParse(Console.ReadLine(), out id_venta))
            {
                Console.WriteLine("Error. El ID debe de ser numérico. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la VENTA: ");
            }
            */

            foreach (Venta v in this._listaVentas)
            {
                if (v.pId_venta == id_venta)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID de la VENTA a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_venta);
                }
            }

            Console.Write('\n');
            do
            {
                foreach (Cliente cl in this._listaClientes)
                {
                    Console.WriteLine($"ID: {cl.pId_cliente} Razon Social: {cl.pCliente}");
                }

                Console.Write("\nIngrese el ID del cliente: ");
                if (int.TryParse(Console.ReadLine(), out id_cliente))
                {
                    foreach (Cliente cl in _listaClientes)
                    {
                        if (id_cliente == cl.pId_cliente)
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (!flag)
                    {
                        Console.WriteLine("Error. El ID ingresado no existe. Presione una tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!flag);

            do
            {
                Console.Write("\nIngrese el número del tipo vehículo que desea vender:\n1) Auto/Camioneta\n2) Moto\n3) Camion\n\nOpción: ");

                if (int.TryParse(Console.ReadLine(), out opc) && (opc >= 1 && opc <= 3))
                {
                    opcionValida = true;
                }
                else
                {
                    Console.WriteLine("Error. La opción ingresada no es válida. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!opcionValida);

            if (opc == 1)
            {
                foreach (AutoCamioneta gen in this._listaAutoCamionetasDisponibles)
                {
                    Console.WriteLine($"ID: {gen.pId_vehiculo} Modelo: {gen.pModelo}");
                }
            }
            else if (opc == 2)
            {
                foreach (Moto moto in this._listaMotosDisponibles)
                {
                    Console.WriteLine($"ID: {moto.pId_vehiculo} Modelo: {moto.pModelo}");
                }
            }
            else if (opc == 3)
            {
                foreach (Camion camion in this._listaCamionesDisponibles)
                {
                    Console.WriteLine($"ID: {camion.pId_vehiculo} Modelo: {camion.pModelo}");
                }
            }

            flag = false;
            do
            {
                Console.Write("\nIngrese el ID del vehículo a vender: ");

                if (int.TryParse(Console.ReadLine(), out id_vehiculo))
                {
                    if (opc == 1)
                    {
                        flag = _listaAutoCamionetasDisponibles.Any(ayc => id_vehiculo == ayc.pId_vehiculo);
                    }
                    else if (opc == 2)
                    {
                        flag = _listaMotosDisponibles.Any(m => id_vehiculo == m.pId_vehiculo);
                    }
                    else if (opc == 3)
                    {
                        flag = _listaCamionesDisponibles.Any(c => id_vehiculo == c.pId_vehiculo);
                    }

                    if (!flag)
                    {
                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!flag);
  
            foreach (AutoCamioneta ac in this._listaAutoCamionetas)
            {
                if (ac.pId_vehiculo == id_vehiculo)
                {
                    ac.pEstado = true;
                }
            }
            foreach (Moto m in this._listaMotos)
            {
                if(m.pId_vehiculo == id_vehiculo)
                {
                    m.pEstado = true;
                }
            }
            foreach (Camion c in this._listaCamiones)
            {
                if (c.pId_vehiculo == id_vehiculo)
                {
                    c.pEstado = true;
                }
            }

            Console.Write("\nIngrese la FECHA DE COMPRA del vehiculo (dd/mm/aaaa): ");
            fecha_compra = validar.validarFecha(Console.ReadLine());
            /*
            while (!DateTime.TryParse(Console.ReadLine(), out fecha_compra))
            { 
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese la FECHA DE COMPRA del vehiculo (dd/mm/aaaa): ");
            }
            */

            Console.Write("\nIngrese la FECHA DE ENTREGA del vehiculo (dd/mm/aaaa): ");
            fecha_entrega = validar.validarFecha(Console.ReadLine());
            /*
            while (!DateTime.TryParse(Console.ReadLine(), out fecha_entrega))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese la FECHA DE ENTREGA del vehiculo (dd/mm/aaaa): ");
            }
            */

            Console.Write("\nIngrese el SUBTOTAL de la VENTA: ");
            subtotal = validar.validarDoble(Console.ReadLine());
            /*
            while (!double.TryParse(Console.ReadLine(), out subtotal))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el SUBTOTAL de la VENTA: ");
            }
            */
            Console.Write("\nIngrese el % de IVA: ");
            iva = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out iva))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el % de IVA: ");
            }
            */

            Console.Write("\nIngrese el % de DESCUENTO: ");
            descuento = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out descuento))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el % de DESCUENTO: ");
            }
            */
            Venta venta = new Venta(id_venta, id_cliente, id_vehiculo, fecha_compra, fecha_entrega, subtotal, iva, descuento);
            _listaVentas.Add(venta);
        }

        public void ActualizarVentas()
        {

            arch = new FileStream("Ventas.txt", FileMode.Create);
            wr = new StreamWriter(arch);

            foreach (Venta ven in this._listaVentas)
            {
                wr.WriteLine($"{ven.pId_venta};{ven.pId_cliente};{ven.pId_vehiculo};{ven.pFecha_compra};{ven.pFecha_entrega};{ven.pSubtotal};" +
                    $"{ven.pIva};{ven.pDescuento};{ven.pTotal}");
            }
            wr.Close();
            arch.Close();
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }


        //public void ModificarVenta()
        //{
        //    CargarVentas();
        //    int id;
        //    bool encontrado = false;

        //    Console.WriteLine("Ingrese el ID de la VENTA a modificar");
        //    id = validar.validarEntero(Console.ReadLine());
        //    /*
        //    while (!int.TryParse(Console.ReadLine(), out id))
        //    {
        //        Console.Write("El ID ingresado no es válido. Ingrese un ID numérico:");
        //    }
        //    */
        //    foreach (Venta ven in this._listaVentas)
        //    {
        //        if (ven.pId_venta == id)
        //        {
        //            encontrado = true;
        //            string[] menumodif = { "Cliente", "Vehiculo", "Fecha de compra", "Fecha de entrega",
        //        "Subtotal", "IVA", "Descuento", "Total" };
        //            int indexmodif = 0;
        //            ConsoleKeyInfo opcmodif;

        //            Console.Clear();
        //            Console.WriteLine("Ingrese el dato que desea modificar\n");

        //            do
        //            {
        //                for (int i = 0; i < menumodif.Length; i++)
        //                {
        //                    if (i == indexmodif)
        //                    {
        //                        Console.ForegroundColor = ConsoleColor.Black;
        //                        Console.BackgroundColor = ConsoleColor.Gray;
        //                    }
        //                    else
        //                    {
        //                        Console.ResetColor();
        //                    }
        //                    Console.WriteLine(menumodif[i]);
        //                }

        //                Console.ResetColor();
        //                Console.Write($"\n\n\t\tPresione ESCAPE para salir.");
        //                opcmodif = Console.ReadKey();

        //                switch (opcmodif.Key)
        //                {
        //                    case ConsoleKey.UpArrow:
        //                        Console.Clear();
        //                        indexmodif = indexmodif > 0 ? indexmodif - 1 : menumodif.Length - 1;
        //                        break;
        //                    case ConsoleKey.DownArrow:
        //                        Console.Clear();
        //                        indexmodif = indexmodif < menumodif.Length - 1 ? indexmodif + 1 : 0;
        //                        break;
        //                    case ConsoleKey.Enter:
        //                        Console.Clear();

        //                        switch (menumodif[indexmodif])
        //                        {
        //                            case "Cliente":
        //                                int idclmodif;
        //                                Console.WriteLine($"Ingrese el ID que modificará el actual -{ven.pId_cliente}-: ");
        //                                idclmodif = validar.validarEntero(Console.ReadLine());
        //                                /*
        //                                while (!int.TryParse(Console.ReadLine(), out idclmodif))
        //                                {
        //                                    Console.WriteLine("Error. El dato ingresado no es válido.");
        //                                }
        //                                */
        //                                ven.pId_cliente = idclmodif;
        //                                break;

        //                            case "Total":
        //                                double subtotmodif;
        //                                Console.WriteLine($"Ingrese el SUBTOTAL que modificará el actual -{ven.pSubtotal}-: ");
        //                                subtotmodif = validar.validarDoble(Console.ReadLine());
        //                                /*
        //                                while (!double.TryParse(Console.ReadLine(), out subtotmodif))
        //                                {
        //                                    Console.WriteLine("Error. El dato ingresado no es válido.");
        //                                }
        //                                */
        //                                ven.pSubtotal = subtotmodif;
        //                                break;
        //                        }

        //                        Console.ForegroundColor = ConsoleColor.DarkGreen;
        //                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
        //                        Console.ResetColor();
        //                        Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menú.");
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        break;
        //                }
        //            } while (opcmodif.Key != ConsoleKey.Escape);
        //            return;
        //        }
        //    }

        //    if (!encontrado)
        //    {
        //        Console.Clear();
        //        Console.Write($"El ID -{id}- no existe en la lista de Ventas.");
        //        Console.WriteLine("\n\nPresione una tecla para continuar.");
        //        Console.ReadKey();
        //    }
        //}

        public void ModificarVenta()
        {
            Venta venta = new Venta();
            int id, flag = 0;
            string cad;
            Console.WriteLine("Ingrese el ID de la venta a modificar");
            cad = Console.ReadLine();
            id = validar.validarEntero(Console.ReadLine());
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
                                    Console.WriteLine($"Ingrese el ID que modficara el actual -{ven.pId_cliente}-: ");
                                    idclmodif = int.Parse(Console.ReadLine());
                                    ven.pId_cliente = idclmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Vehiculo")
                                {
                                    int vehimodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el ID del vehiculo que modficara el actual -{ven.pId_vehiculo}-: ");
                                    vehimodif = int.Parse(Console.ReadLine());
                                    ven.pId_vehiculo = vehimodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Fecha de compra")
                                {

                                    DateTime feccompmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la fecha que modficara la actual -{ven.pFecha_compra}-: ");
                                    cad = Console.ReadLine();
                                    feccompmodif = DateTime.Parse(cad);
                                    ven.pFecha_compra = feccompmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }
                                else if (menumodif[indexmodif] == "Fecha de entrega")
                                {
                                    DateTime fecentmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la fecha que modficara la actual -{ven.pFecha_entrega}-: ");
                                    cad = Console.ReadLine();
                                    fecentmodif = DateTime.Parse(cad);
                                    ven.pFecha_entrega = fecentmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }
                                else if (menumodif[indexmodif] == "Subtotal")
                                {
                                    double subtotmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el subtotal que modificara el actual -{ven.pSubtotal}-: ");
                                    cad = Console.ReadLine();
                                    subtotmodif = double.Parse(cad);
                                    ven.pSubtotal = subtotmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }
                                else if (menumodif[indexmodif] == "IVA")
                                {
                                    int ivamodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el % de IVA que modificara el actual -{ven.pIva}-: ");
                                    cad = Console.ReadLine();
                                    ivamodif = int.Parse(cad);
                                    ven.pIva = ivamodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }
                                else if (menumodif[indexmodif] == "Descuento")
                                {
                                    int descmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el descuento que modificara el actual -{ven.pDescuento}-: ");
                                    cad = Console.ReadLine();
                                    descmodif = int.Parse(cad);
                                    ven.pDescuento = descmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                }
                                else if (menumodif[indexmodif] == "Total")
                                {
                                    int descmodif, ivamodif;
                                    double subtotmodif, totalmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el SUBTOTAL que modificar el actual -{ven.pSubtotal}-: ");
                                    cad = Console.ReadLine();
                                    subtotmodif = double.Parse(cad);
                                    ven.pSubtotal = subtotmodif;

                                    Console.WriteLine($"Ingrese el % DE IVA que modificar el actual -{ven.pIva}-: ");
                                    cad = Console.ReadLine();
                                    ivamodif = int.Parse(cad);
                                    ven.pIva = ivamodif;

                                    Console.WriteLine($"Ingrese el % DE DESCUENTO que modificar el actual -{ven.pDescuento}-: ");
                                    cad = Console.ReadLine();
                                    descmodif = int.Parse(cad);
                                    ven.pDescuento = descmodif;
                                    //totalmodif = (subtotmodif + ((ivamodif * subtotmodif) / 100)) - ((descmodif * subtotmodif) / 100);
                                    //ven.pTotal = totalmodif;

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
                Console.Write($"La ID -{id}- no existe en la lista de Ventas.");
            }

        }
        public void BorrarVenta()
        {
            CargarVentas();
            int id, flag = 0;
            //string cad;
            Console.WriteLine("Ingrese el ID de la VENTA a eliminar: ");
            id = validar.validarEntero(Console.ReadLine());
            /*
            cad = Console.ReadLine();
            id = int.Parse(cad);
            */
            for (int i = _listaVentas.Count() - 1; i >= 0; i--)
            {
                if (_listaVentas[i].pId_venta == id)
                {
                    _listaVentas.RemoveAt(i);
                    flag = 1;
                }

            }
            if (flag == 0)
            {
                Console.Write($"El ID -{id}- no existe en la lista de Ventas");

            }
        }

        public void ListarVentas()
        {
            CargarVentas();
            foreach (Venta venta in _listaVentas)
            {
                venta.mostrarVenta();
            }
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void BuscarVenta()
        {
            CargarClientes();
            CargarVentas();
            int idc;
            bool encontrado = false;

            foreach(Cliente c in this._listaClientes)
            {
                Console.WriteLine($"{c.pId_cliente} -> {c.pCliente}");
            }

            do
            {
                Console.Write("Ingrese el ID del cliente que desea ver sus ventas: ");
                while (!int.TryParse(Console.ReadLine(), out idc))
                {
                    Console.Write("El ID ingresado no corresponde a un cliente.\nIngrese un nuevo ID:");
                }
                Console.WriteLine($"Las ventas realizadas al cliente {idc} son: ");
                    foreach (Venta v in this._listaVentas)
                    {
                        if (v.pId_cliente == idc)
                        {
                        v.mostrarVenta();
                        encontrado = true;
                        }
                    }
                if (!encontrado)
                {
                    Console.Clear();
                    Console.WriteLine("Error en el ingreso. Venta/s no encontrada/s.");
                }
            }
            while (!encontrado);
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadKey();
        }

        //CLIENTE----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
    
        public void ModificarCliente()
        {
            CargarClientes();
            int id, flag = 0;
            string cad;
            Console.Write("Ingrese el ID del cliente a modificar: ");
            id = validar.validarEntero(Console.ReadLine());
            /*
            cad = Console.ReadLine();
            id = validar.validarEntero(cad);
            */
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
                        Console.Write($"\n\n\t\tPresione ESCAPE para salir.");
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
                                if (menumodif[indexmodif] == "Razon social")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la razon social que modificará la actual -{cl.pCliente}-:");
                                    cl.pCliente = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }
                                else if (menumodif[indexmodif] == "CUIT")
                                {
                                    long cuitmodif;
                                    Console.Clear();
                                    Console.WriteLine($"El CUIT actual del cliente -{cl.pCuit}- será modificado:");
                                    cuitmodif = validar.validarCuit();
                                    cl.pCuit = cuitmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }
                                else if (menumodif[indexmodif] == "Domicilio")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la dirección que modificará la actual -{cl.pDomicilio}-:");
                                    cl.pDomicilio = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }
                                else if (menumodif[indexmodif] == "ID Localidad")
                                {
                                    int localmodif;
                                    Console.Clear();
                                    foreach (Localidad loc in this._listaLocalidades)
                                    {
                                        Console.WriteLine($"\t{loc.pId_localidad} -> {loc.pLocalidad}");
                                    }
                                    Console.WriteLine($"Ingrese el ID de LOCALIDAD que modificará el actual -{cl.pId_localidad}-:");
                                    localmodif = validar.validarEntero(Console.ReadLine());
                                    /*
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out localmodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID que modificará el actual -{cl.pId_localidad}-:");
                                    }
                                    */
                                    cl.pId_localidad = localmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }
                                else if (menumodif[indexmodif] == "Telefono")
                                {
                                    long telmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el teléfono que modificará el actual -{cl.pTelefono}-:");
                                    cad = Console.ReadLine();
                                    telmodif = validar.validarLong(Console.ReadLine());
                                    /*
                                    while (!long.TryParse(Console.ReadLine(), out telmodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el teléfono que modificará el actual -{cl.pTelefono}-:");
                                    }
                                    */
                                    cl.pTelefono = telmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }
                                else if (menumodif[indexmodif] == "Correo")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el correo que modificará el actual -{cl.pCorreo}-:");
                                    cl.pCorreo = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menú.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    } 
                    while (opcmodif.Key != ConsoleKey.Escape);
                    return;
                }
            }

            if (flag == 1)
            {
                Console.Clear();
                Console.Write($"La ID -{id}- no existe en la lista de Clientes.");
            }
        }

        public void ActualizarClientes()
        {
            arch = new FileStream("Clientes.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (Cliente cl in this._listaClientes)
            {
                wr.WriteLine($"{cl.pId_cliente};{cl.pCliente};{cl.pCuit};{cl.pDomicilio};{cl.pId_localidad};{cl.pTelefono};{cl.pCorreo}");
            }
            wr.Close();
            arch.Close();
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void BorrarCliente()
        {
            CargarClientes();
            int id, flag = 0;
            string cad;
            Console.WriteLine("Ingrese el ID del Cliente a eliminar: ");
            id = validar.validarEntero(Console.ReadLine());
            /*
            cad = Console.ReadLine();
            id = int.Parse(cad);
            */
            for (int i = _listaClientes.Count() - 1; i >= 0; i--)
            {
                if (_listaClientes[i].pId_cliente == id)
                {
                    _listaClientes.RemoveAt(i);
                    flag = 1;
                }

            }
            if (flag == 0)
            {
                Console.Write($"El ID -{id}- no existe en la lista de Clientes.");

            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n\n\t\tCliente borrado correctamente.");
        }

        public void CargarCliente()
        {
            CargarLocalidades();
            CargarProvincias();
            int id_cliente, id_localidad;
            string cliente, correo, domicilio;
            long telefono, cuit;

            Console.WriteLine("****CARGA DE CLIENTE****\n\n");
            Console.Write($"ID's NO disponibles:");
            foreach (Cliente cli in this._listaClientes)
            {
                Console.Write($"{cli.pId_cliente}\t");
            }
            Console.Write("\nIngrese el ID del Cliente: ");
            id_cliente = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_cliente))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del Cliente: ");
            }
            */

            foreach (Cliente c in this._listaClientes)
            {
                if (c.pId_cliente == id_cliente)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del Cliente a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_cliente);
                }
            }

            Console.Write("\nIngrese la Razon Social: ");
            cliente = Console.ReadLine();

            cuit = validar.validarCuit();

            Console.Write("\nIngrese el Domicilio: ");
            domicilio = Console.ReadLine();

            Console.Write("\nIngrese el ID de la LOCALIDAD: ");
            foreach(Localidad loc in this._listaLocalidades)
            {
                Console.WriteLine($"\tID: {loc.pId_localidad} Localidad: {loc.pLocalidad}");
            }

            id_localidad = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_localidad))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la Localidad: ");
            }
            */

            telefono = validar.validarLong(Console.ReadLine());
            Console.Write("\nIngrese el Telefono del cliente: ");
            /*
            while (!long.TryParse(Console.ReadLine(), out telefono))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el Telefono del cliente: ");
            }
            */

            Console.Write("\nIngrese el Correo: ");
            correo = Console.ReadLine();

            Cliente cl = new Cliente(id_cliente, cliente, cuit, domicilio, id_localidad, telefono, correo);
            _listaClientes.Add(cl);
        }

        public void ListarClientes()
        {
            CargarClientes();
            foreach (Cliente cliente in _listaClientes)
            {
                cliente.mostrarCliente();
            }
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void BuscarCliente()
        {
            CargarClientes();
            string cad;
            bool encontrado = false;

            do
            {
                Console.Write("Ingrese la Razon Social del cliente: ");
                cad = Console.ReadLine().ToLower();

                foreach (Cliente c in this._listaClientes)
                {
                    if (c.pCliente.ToLower() == cad)
                    {
                        c.mostrarCliente();
                        encontrado  = true;
                    }
                }
                if (!encontrado)
                {
                    Console.Clear();
                    Console.WriteLine("Error en el ingreso. Cliente no encontrado.");
                }
            }
            while (!encontrado);
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadKey();
        }

        //MARCAS----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
   
        public void IngresarMarca()
        {
            int id_marca;
            string marca;

            Console.Write("****CARGA DE MARCA****\n\n");
            Console.Write("Ingrese el ID de la MARCA: ");
            id_marca = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_marca))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la MARCA: ");
            }
            */
            foreach (Marca m in this._listaMarcas)
            {
                if (m.pId_marca == id_marca)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID de la MARCA a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_marca);
                }
            }

            Console.Write("\nIngrese el NOMBRE de la MARCA: ");
            marca = Console.ReadLine();
            Marca marc = new Marca(id_marca, marca);
            _listaMarcas.Add(marc);
        }

        public void BorrarMarca()
        {
            CargarMarcas();
            int id, flag=0;
            //string cad;
            Console.WriteLine("Ingrese el ID de la MARCA a eliminar: ");
            id = validar.validarEntero(Console.ReadLine());
            /*
            cad = Console.ReadLine();
            id = int.Parse(cad);
            */
            for (int i = _listaMarcas.Count() - 1; i >= 0; i--)
            {
                if (_listaMarcas[i].pId_marca == id)
                {
                    _listaMarcas.RemoveAt(i);
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                Console.Write($"El ID -{id}- no existe en la lista de Marcas.");
            }
        }

        public void ListarMarcas()
        {
            CargarMarcas();
            foreach (Marca marca in _listaMarcas)
            {
                marca.mostrarMarca();
            }
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void ModificarMarca()
        {
            CargarMarcas();
            int id;
            //string cad;

            Console.WriteLine("Ingrese el ID de la MARCA a modificar: ");
            id = validar.validarEntero(Console.ReadLine());
            /*
            cad = Console.ReadLine();
            while (!int.TryParse(cad, out id))
            
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la MARCA a modificar: ");
                cad = Console.ReadLine();
            }
            */

            foreach (Marca marca in this._listaMarcas)
            {
                if (marca.pId_marca == id)
                {
                    string[] opcionesModif = { "ID", "Descripción" };
                    int indexmodif = 0;
                    ConsoleKeyInfo opcmodif;
                    Console.Clear();
                    Console.WriteLine("Seleccione el dato que desea modificar:\n");

                    do
                    {
                        for (int i = 0; i < opcionesModif.Length; i++)
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
                            Console.WriteLine(opcionesModif[i]);
                        }

                        Console.ResetColor();
                        Console.Write($"\n\n\t\tPresione ESC para salir.");
                        opcmodif = Console.ReadKey();
                        switch (opcmodif.Key)
                        {
                            case ConsoleKey.UpArrow:
                                Console.Clear();
                                if (indexmodif > 0)
                                {
                                    indexmodif--;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                Console.Clear();
                                if (indexmodif < opcionesModif.Length - 1)
                                {
                                    indexmodif++;
                                }
                                break;
                            case ConsoleKey.Enter:
                                Console.Clear();
                                if (opcionesModif[indexmodif] == "ID")
                                {
                                    int nuevoIdMarca;
                                    Console.Write("Ingrese el nuevo ID de la MARCA: ");
                                    nuevoIdMarca = validar.validarEntero(Console.ReadLine());
                                    /*
                                    while (!int.TryParse(Console.ReadLine(), out nuevoIdMarca))
                                    {
                                        Console.WriteLine("ID inválido. Reingrese.");
                                        Console.Write("Ingrese el nuevo ID de la MARCA: ");
                                    }
                                    */
                                    marca.pId_marca = nuevoIdMarca;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    Console.Write($"Ingrese la nueva descripción de la MARCA (actual: {marca.pMarca}): ");
                                    marca.pMarca = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tDescripción modificada correctamente.");
                                }

                                Console.ResetColor();
                                Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menú.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    } while (opcmodif.Key != ConsoleKey.Escape);
                    return;
                }
            }
            Console.Write($"El ID -{id}- no existe en la lista de Marcas.");
        }

        public void ActualizarMarcas()
        {
            arch = new FileStream("Marcas.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (Marca m in this._listaMarcas)
            {
                wr.WriteLine($"{m.pId_marca};{m.pMarca}");
            }
            wr.Close();
            arch.Close();
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void BuscarMarca()
        {
            CargarMarcas();
            string cad;
            bool encontrado = false;

            do
            {
                Console.Write("Ingrese el NOMBRE de la MARCA: ");
                cad = Console.ReadLine().ToLower();

                foreach (Marca m in this._listaMarcas)
                {
                    if (m.pMarca.ToLower() == cad)
                    {
                        m.mostrarMarca();
                        encontrado = true;
                    }
                }
            }
            while (!encontrado);
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadLine();
        }

        //LOCALIDADES----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
    
        public void CargarLocalidad()
        {
            CargarProvincias();
            int id_localidad, id_provincia;
            string localidad;

            Console.Write("****CARGA DE LOCALIDAD****\n\n");
            Console.Write("Ingrese el ID de la LOCALIDAD: ");

            id_localidad = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_localidad))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la LOCALIDAD: ");
            }
            */

            foreach (Localidad l in this._listaLocalidades)
            {
                if (l.pId_localidad == id_localidad)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID de la LOCALIDAD a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_localidad);
                }
            }

            Console.Write("\nIngrese el NOMBRE de la LOCALIDAD: ");
            localidad = Console.ReadLine();

            foreach (Provincia prov in this._listaProvincias)
            {
                Console.Write($"ID: {prov.pId_provincia} -> {prov.pProvincia}");
            }

            Console.Write("\nIngrese el ID de la PROVINCIA");
            id_provincia = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_provincia))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la PROVINCIA: ");
            }
            */
            Localidad loc = new Localidad(id_localidad, localidad, id_provincia);
            _listaLocalidades.Add(loc);
        }

        public void actualizarLocalidades()
        {
            arch = new FileStream("Localidades.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (Localidad loc in this._listaLocalidades)
            {
                wr.WriteLine($"{loc.pId_localidad};{loc.pLocalidad};{loc.pId_provincia}");
            }
            wr.Close();
            arch.Close();
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void ModificarLocalidad()
        {
            CargarLocalidades();
            int id;
            //string cad;
            Console.WriteLine("Ingrese el ID de la LOCALIDAD a modificar: ");
            id = validar.validarEntero(Console.ReadLine());
            /*
            cad = Console.ReadLine();
            while (!int.TryParse(cad, out id))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la LOCALIDAD a modificar: ");
                cad = Console.ReadLine();
            }
            */
            foreach (Localidad localidad in this._listaLocalidades)
            {
                if (localidad.pId_localidad == id)
                {
                    string[] opcionesModif = { "ID", "Descripción" };
                    int indexmodif = 0;

                    ConsoleKeyInfo opcmodif;
                    Console.Clear();
                    Console.WriteLine("Seleccione el dato que desea modificar:\n");

                    do
                    {
                        for (int i = 0; i < opcionesModif.Length; i++)
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
                            Console.WriteLine(opcionesModif[i]);
                        }

                        Console.ResetColor();
                        Console.Write($"\n\n\t\tPresione ESC para salir.");
                        opcmodif = Console.ReadKey();
                        switch (opcmodif.Key)
                        {
                            case ConsoleKey.UpArrow:
                                Console.Clear();
                                if (indexmodif > 0)
                                {
                                    indexmodif--;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                Console.Clear();
                                if (indexmodif < opcionesModif.Length - 1)
                                {
                                    indexmodif++;
                                }
                                break;
                            case ConsoleKey.Enter:
                                Console.Clear();
                                if (opcionesModif[indexmodif] == "ID")
                                {
                                    int nuevoIdLocalidad;
                                    Console.Write("Ingrese el nuevo ID de la LOCALIDAD: ");
                                    nuevoIdLocalidad = validar.validarEntero(Console.ReadLine());
                                    /*
                                    while (!int.TryParse(Console.ReadLine(), out nuevoIdLocalidad))
                                    {
                                        Console.WriteLine("ID inválido. Reingrese.");
                                        Console.Write("Ingrese el nuevo ID de la LOCALIDAD: ");
                                    }
                                    */
                                    localidad.pId_localidad = nuevoIdLocalidad;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    Console.Write($"Ingrese la nueva descripción de la LOCALIDAD (actual: {localidad.pLocalidad}): ");
                                    localidad.pLocalidad = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tDescripción modificada correctamente.");
                                }

                                Console.ResetColor();
                                Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menú.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    } while (opcmodif.Key != ConsoleKey.Escape);
                    return;
                }
            }
            Console.Write($"El ID -{id}- no existe en la lista de Localidades.");
        }

        public void BorrarLocalidad()
        {
            CargarLocalidades();
            int id, flag=0;
            //string cad;
            Console.WriteLine("Ingrese el ID de la LOCALIDAD a eliminar: ");
            id = validar.validarEntero(Console.ReadLine());
            /*
            cad = Console.ReadLine();
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la LOCALIDAD a eliminar: ");
            }
            */
            for (int i = _listaLocalidades.Count() - 1; i >= 0; i--)
            {
                if (_listaLocalidades[i].pId_localidad == id)
                {
                    _listaLocalidades.RemoveAt(i);
                    flag = 1;
                }

            }
            if (flag == 0)
            {
                Console.Write($"El ID -{id}- no existe en la lista de Localidades.");
            }
        }

        public void ListarLocalidades()
        {
            CargarLocalidades();
            foreach (Localidad loc in _listaLocalidades)
            {
                loc.mostrarLocalidad();
            }
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void BuscarLocalidad()
        {
            CargarLocalidades();
            string cad;
            bool encontrado = false;

            do
            {
                Console.Write("Ingrese el NOMBRE de la LOCALIDAD: ");
                cad = Console.ReadLine().ToLower();

                foreach (Localidad l in this._listaLocalidades)
                {
                    if (l.pLocalidad.ToLower() == cad)
                    {
                        l.mostrarLocalidad();
                        encontrado  = true;
                    }
                }
            }
            while (!encontrado);
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadLine();
        }

        //PROVINCIAS----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
    
        public void CargarProvincia()
        {
            int id_provincia;
            string provincia;

            Console.Write("****CARGA DE PROVINCIA****\n\n");
            Console.Write("Ingrese el ID de la PROVINCIA: ");
            id_provincia = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_provincia))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la PROVINCIA: ");
            }
            */
            foreach (Provincia p in this._listaProvincias)
            {
                if (p.pId_provincia == id_provincia)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID de la PROVINCIA a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_provincia);
                }
            }
            Console.Write("\nIngrese el NOMBRE de la PROVINCIA: ");
            provincia = Console.ReadLine();
            Provincia prov = new Provincia(id_provincia, provincia);
            _listaProvincias.Add(prov);
        }

        public void actualizarProvincias()
        {
            arch = new FileStream("Provincias.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (Provincia prov in this._listaProvincias)
            {
                wr.WriteLine($"{prov.pId_provincia};{prov.pProvincia}");
            }
            wr.Close();
            arch.Close();
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void ModificarProvincia()
        {
            CargarProvincias();
            int id;
            //string cad;

            Console.WriteLine("Ingrese el ID de la PROVINCIA a modificar: ");
            id = validar.validarEntero(Console.ReadLine());
            /*
            cad = Console.ReadLine();
            while (!int.TryParse(cad, out id))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la PROVINCIA a modificar: ");
                cad = Console.ReadLine();
            }
            */
            foreach (Provincia provincia in this._listaProvincias)
            {
                if (provincia.pId_provincia == id)
                {
                    string[] opcionesModif = { "ID", "Descripción" };
                    int indexmodif = 0;
                    ConsoleKeyInfo opcmodif;
                    Console.Clear();
                    Console.WriteLine("Seleccione el dato que desea modificar:\n");

                    do
                    {
                        for (int i = 0; i < opcionesModif.Length; i++)
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
                            Console.WriteLine(opcionesModif[i]);
                        }

                        Console.ResetColor();
                        Console.Write($"\n\n\t\tPresione ESC para salir.");
                        opcmodif = Console.ReadKey();

                        switch (opcmodif.Key)
                        {
                            case ConsoleKey.UpArrow:
                                Console.Clear();
                                if (indexmodif > 0)
                                {
                                    indexmodif--;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                Console.Clear();
                                if (indexmodif < opcionesModif.Length - 1)
                                {
                                    indexmodif++;
                                }
                                break;
                            case ConsoleKey.Enter:
                                Console.Clear();
                                if (opcionesModif[indexmodif] == "ID")
                                {
                                    int nuevoIdProvincia;
                                    Console.Write("Ingrese el nuevo ID de la PROVINCIA: ");
                                    nuevoIdProvincia = validar.validarEntero(Console.ReadLine());
                                    /*
                                    while (!int.TryParse(Console.ReadLine(), out nuevoIdProvincia))
                                    {
                                        Console.WriteLine("ID inválido. Reingrese.");
                                        Console.Write("Ingrese el nuevo ID de la PROVINCIA: ");
                                    }
                                    */
                                    provincia.pId_provincia = nuevoIdProvincia;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    Console.Write($"Ingrese la nueva descripción de la PROVINCIA (actual: {provincia.pProvincia}): ");
                                    provincia.pProvincia = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tDescripción modificada correctamente.");
                                }

                                Console.ResetColor();
                                Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menú.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    } while (opcmodif.Key != ConsoleKey.Escape);
                    return;
                }
            }
            Console.Write($"El ID -{id}- no existe en la lista de Provincias.");
        }

        public void BorrarProvincia()
        {
            CargarProvincias();
            int id, flag=0;
            //string cad;

            Console.WriteLine("Ingrese el ID de la PROVINCIA a eliminar: ");
            id = validar.validarEntero(Console.ReadLine());
            /*cad = Console.ReadLine();
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la PROVINCIA a eliminar: ");
            }
            */
            for (int i = _listaProvincias.Count() - 1; i >= 0; i--)
            {
                if (_listaProvincias[i].pId_provincia == id)
                {
                    _listaProvincias.RemoveAt(i);
                    flag = 1;
                }

            }
            if (flag == 0)
            {
                Console.Write($"El ID -{id}- no existe en la lista de Provincias.");
            }
        }

        public void ListarProvincias()
        {
            CargarProvincias();
            foreach (Provincia prov in _listaProvincias)
            {
                prov.mostrarProvincia();
            }
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void BuscarProvincia()
        {
            CargarProvincias();
            string cad;
            bool encontrado = false;

            do
            {
                Console.Write("Ingrese el NOMBRE de la PROVINCIA: ");
                cad = Console.ReadLine().ToLower();

                foreach (Provincia p in this._listaProvincias)
                {
                    if (p.pProvincia.ToLower() == cad)
                    {
                        p.mostrarProvincia();
                        encontrado  = true;
                    }
                }
            }
            while (!encontrado);
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadLine();
        }

        //COMBUSTIBLES----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
        
        public void IngresarNuevoCombustible()
        {
            int id_combustible;
            string combustible;

            Console.Write("****CARGA DE COMBUSTIBLE****\n\n");
            Console.Write("Ingrese el ID del COMBUSTIBLE: ");
            id_combustible = validar.validarEntero(Console.ReadLine());

            /*
            while (!int.TryParse(Console.ReadLine(), out id_combustible))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del COMBUSTIBLE: ");
            }
            */
            foreach (Combustible c in this._listaCombustibles)
            {
                if (c.pIdCombustible == id_combustible)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del COMBUSTIBLE a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_combustible);
                }
            }
            Console.Write("\nIngrese el NOMBRE del COMBUSTIBLE: ");
            combustible = Console.ReadLine();

            Combustible comb = new Combustible(id_combustible, combustible);
            _listaCombustibles.Add(comb);
        }

        public void actualizarCombustibles()
        {
            arch = new FileStream("Combustibles.txt", FileMode.Create);
            wr = new StreamWriter(arch);

            foreach (Combustible comb in this._listaCombustibles)
            {
                wr.WriteLine($"{comb.pIdCombustible};{comb.pCombustible}");
            }
            wr.Close();
            arch.Close();
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void BorrarCombustible()
        {
            CargarCombustibles();
            int id, flag=0;
            string cad;

            Console.WriteLine("Ingrese el ID del COMBUSTIBLE a eliminar: ");
            id= validar.validarEntero(Console.ReadLine());

            /*
            cad = Console.ReadLine();
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del COMBUSTIBLE a eliminar: ");
            }
            */
            for (int i = _listaCombustibles.Count() - 1; i >= 0; i--)
            {
                if (_listaCombustibles[i].pIdCombustible == id)
                {
                    _listaCombustibles.RemoveAt(i);
                    flag = 1;
                }

            }
            if (flag == 0)
            {
                Console.Write($"El ID -{id}- no existe en la lista de Combustibles.");
            }
        }

        public void ListarCombustibles()
        {
            CargarCombustibles();
            foreach (Combustible comb in _listaCombustibles)
            {
                comb.mostrarCombustible();
            }
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void ModificarCombustible()
        {
            CargarCombustibles();
            int id;
            //string cad;

            Console.WriteLine("Ingrese el ID del COMBUSTIBLE a modificar: ");
            id = validar.validarEntero(Console.ReadLine());

            /*
            cad = Console.ReadLine();
            while (!int.TryParse(cad, out id))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del COMBUSTIBLE a modificar: ");
                cad = Console.ReadLine();
            }
            */
            foreach (Combustible combustible in this._listaCombustibles)
            {
                if (combustible.pIdCombustible == id)
                {
                    string[] opcionesModif = { "ID", "Descripción" };
                    int indexmodif = 0;
                    ConsoleKeyInfo opcmodif;
                    Console.Clear();
                    Console.WriteLine("Seleccione el dato que desea modificar:\n");

                    do
                    {
                        for (int i = 0; i < opcionesModif.Length; i++)
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
                            Console.WriteLine(opcionesModif[i]);
                        }

                        Console.ResetColor();
                        Console.Write($"\n\n\t\tPresione ESC para salir.");
                        opcmodif = Console.ReadKey();

                        switch (opcmodif.Key)
                        {
                            case ConsoleKey.UpArrow:
                                Console.Clear();
                                if (indexmodif > 0)
                                {
                                    indexmodif--;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                Console.Clear();
                                if (indexmodif < opcionesModif.Length - 1)
                                {
                                    indexmodif++;
                                }
                                break;
                            case ConsoleKey.Enter:
                                Console.Clear();
                                if (opcionesModif[indexmodif] == "ID")
                                {
                                    int nuevoIdCombustible;

                                    Console.Write("Ingrese el nuevo ID del COMBUSTIBLE: ");                                    
                                    nuevoIdCombustible = validar.validarEntero(Console.ReadLine());
                                    /*
                                    while (!int.TryParse(Console.ReadLine(), out nuevoIdCombustible))
                                    {
                                        Console.WriteLine("ID inválido. Reingrese.");
                                        Console.Write("Ingrese el nuevo ID del COMBUSTIBLE: ");
                                    }
                                    */
                                    combustible.pIdCombustible = nuevoIdCombustible;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    Console.Write($"Ingrese la nueva descripción del COMBUSTIBLE (actual: {combustible.pCombustible}): ");
                                    combustible.pCombustible = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tDescripción modificada correctamente.");
                                }

                                Console.ResetColor();
                                Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menú.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    } while (opcmodif.Key != ConsoleKey.Escape);
                    return;
                }
            }
            Console.Write($"El ID -{id}- no existe en la lista de Combustibles.");
        }

        public void BuscarCombustible()
        {
            CargarCombustibles();
            string cad;
            bool encontrado = false;

            do
            {
                Console.Write("Ingrese el NOMBRE del COMBUSTIBLE: ");
                cad = Console.ReadLine().ToLower();

                foreach (Combustible c in this._listaCombustibles)
                {
                    if (c.pCombustible.ToLower() == cad)
                    {
                        c.mostrarCombustible();
                        encontrado = true;
                    }
                }
            }
            while (!encontrado);
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadLine();
        }

        //SEGMENTOS----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
        
        public void CargarSegmento()
        {
            int id_segmento;
            string segmento;

            Console.Write("****CARGA DE SEGMENTO****\n\n");
            Console.Write("Ingrese el ID del SEGMENTO: ");
            id_segmento = validar.validarEntero(Console.ReadLine());
            /*
            while (!int.TryParse(Console.ReadLine(), out id_segmento))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del SEGMENTO: ");
            }
            */
            foreach (Segmento s in this._listaSegmentos)
            {
                if (s.pIdSegmento == id_segmento)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del SEGMENTO a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_segmento);
                }
            }
            Console.Write("\nIngrese el NOMBRE del SEGMENTO: ");
            segmento = Console.ReadLine();

            Segmento seg = new Segmento(id_segmento, segmento);
            _listaSegmentos.Add(seg);

        }

        public void ModificarSegmento()
        {
            CargarSegmentos();
            int id;
            string cad;

            Console.WriteLine("Ingrese el ID del SEGMENTO a modificar: ");
            id = validar.validarEntero(Console.ReadLine());
            /*
            cad = Console.ReadLine();
            while (!int.TryParse(cad, out id))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del SEGMENTO a modificar: ");
                cad = Console.ReadLine();
            }
            */

            foreach (Segmento segmento in this._listaSegmentos)
            {
                if (segmento.pIdSegmento == id)
                {
                    string[] opcionesModif = { "ID", "Descripción" };
                    int indexmodif = 0;
                    ConsoleKeyInfo opcmodif;
                    Console.Clear();
                    Console.WriteLine("Seleccione el dato que desea modificar:\n");

                    do
                    {
                        for (int i = 0; i < opcionesModif.Length; i++)
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
                            Console.WriteLine(opcionesModif[i]);
                        }

                        Console.ResetColor();
                        Console.Write($"\n\n\t\tPresione ESC para salir.");
                        opcmodif = Console.ReadKey();

                        switch (opcmodif.Key)
                        {
                            case ConsoleKey.UpArrow:
                                Console.Clear();
                                if (indexmodif > 0)
                                {
                                    indexmodif--;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                Console.Clear();
                                if (indexmodif < opcionesModif.Length - 1)
                                {
                                    indexmodif++;
                                }
                                break;
                            case ConsoleKey.Enter:
                                Console.Clear();
                                if (opcionesModif[indexmodif] == "ID")
                                {
                                    int nuevoIdSegmento;
                                    Console.Write("Ingrese el nuevo ID del SEGMENTO: ");
                                    nuevoIdSegmento = validar.validarEntero(Console.ReadLine());
                                    /*
                                    while (!int.TryParse(Console.ReadLine(), out nuevoIdSegmento))
                                    {
                                        Console.WriteLine("ID inválido. Reingrese.");
                                        Console.Write("Ingrese el nuevo ID del SEGMENTO: ");
                                    }
                                    */
                                    segmento.pIdSegmento = nuevoIdSegmento;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    Console.Write($"Ingrese la nueva descripción del SEGMENTO (actual: {segmento.pSegmento}): ");
                                    segmento.pSegmento = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tDescripción modificada correctamente.");
                                }

                                Console.ResetColor();
                                Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menú.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    } while (opcmodif.Key != ConsoleKey.Escape);
                    return;
                }
            }
            Console.Write($"El ID -{id}- no existe en la lista de Segmentos.");
        }

        public void actualizarSegmentos()
        {
            arch = new FileStream("Segmentos.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (Segmento seg in this._listaSegmentos)
            {
                wr.WriteLine($"{seg.pIdSegmento};{seg.pSegmento}");
            }
            wr.Close();
            arch.Close();
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void BorrarSegmento()
        {
            CargarSegmentos();
            int id, flag=0;
            string cad;
            Console.WriteLine("Ingrese el ID del SEGMENTO a eliminar: ");
            id = validar.validarEntero(Console.ReadLine());

            /*
            cad = Console.ReadLine();
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del SEGMENTO a eliminar: ");
            }
            */
            for (int i = _listaSegmentos.Count() - 1; i >= 0; i--)
            {
                if (_listaSegmentos[i].pIdSegmento == id)
                {
                    _listaSegmentos.RemoveAt(i);
                    flag = 1;
                }

            }
            if (flag == 0)
            {
                Console.Write($"El ID -{id}- no existe en la lista de Segmentos.");
            }
        }

        public void ListarSegmentos()
        {
            CargarSegmentos();
            foreach (Segmento seg in _listaSegmentos)
            {
                seg.mostrarSegmento();
            }
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void BuscarSegmento()
        {
            CargarSegmentos();
            string cad;
            bool encontrado = false;

            do
            {
                Console.Write("Ingrese el NOMBRE del SEGMENTO: ");
                cad = Console.ReadLine().ToLower();

                foreach (Segmento s in this._listaSegmentos)
                {
                    if (s.pSegmento.ToLower() == cad)
                    {
                        s.mostrarSegmento();
                        encontrado = true;
                    }
                }
            }
            while (!encontrado);
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadLine();
        }

        // VALIDACIONES

        private bool IsIdValid(int id_vehiculo)
        {
            foreach (AutoCamioneta autoCamioneta in this._listaAutoCamionetas)
            {
                if (autoCamioneta.pId_vehiculo == id_vehiculo || autoCamioneta.pEstado == true)
                {
                    return false;
                }
            }

            foreach (Moto moto in this._listaMotos)
            {
                if (moto.pId_vehiculo == id_vehiculo || moto.pEstado == true)
                {
                    return false;
                }
            }

            foreach (Camion camion in this._listaCamiones)
            {
                if (camion.pId_vehiculo == id_vehiculo || camion.pEstado == true)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPatenteUnique (string patente)
        {
            //asegura que la patente sea unica
            foreach (Vehiculo vehiculo in _listaVehiculos)
            {
                if (vehiculo.pPatente == patente)
                {
                    return false;
                }
                return true;
            }
            /*foreach (AutoCamioneta autocam in _listaAutoCamionetas)
            //{
            //    if (autocam.pPatente == patente)
            //    {
            //        return false;
            //    }
            //}

            //foreach (Moto moto in _listaMotos)
            //{
            //    if (moto.pPatente == patente)
            //    {
            //        return false;
            //    }
            //}

            //foreach (Camion camion in _listaCamiones)
            //{
            //    if (camion.pPatente == patente)
            //    {
            //        return false;
            //    }
            //}
            */
            return true;
        }
    }
}

