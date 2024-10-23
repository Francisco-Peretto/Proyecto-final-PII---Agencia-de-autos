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

        // constructores
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
                Console.WriteLine($"Archivo no encontrado: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos: {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Se ha producido un error.");
            }
        }
        public void CargarMotos()
        {
            try
            {
                _listaMotos.Clear();
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
                    int id_combustible = int.Parse(split[7]);
                    double precio_vta = double.Parse(split[8]);
                    string observaciones = split[9];
                    string color = split[10];
                    int cilindrada = int.Parse(split[11]);
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
                }
                archivo.Close();
                reader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontrado: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos: {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Se ha producido un error.");
            }
        } 
        public void CargarAutosCamionetas()
        {
            
            try
            {
                _listaAutoCamionetas.Clear();
                FileStream archivo = new FileStream("AutosCamioneta.txt", FileMode.Open);
                StreamReader reader = new StreamReader(archivo);
                while (reader.EndOfStream == false)
                {
                    string cadena = reader.ReadLine();
                    string[] split = cadena.Split(';');

                    int id_vehiculo = int.Parse(split[0]);
                    string patente = split[0];
                    double kilometros = double.Parse(split[0]);
                    int anio = int.Parse(split[0]);
                    int id_marca = int.Parse(split[0]);
                    string modelo = split[0];
                    int id_segmento = int.Parse(split[0]);
                    int id_combustible = int.Parse(split[0]);
                    double precio_venta = double.Parse(split[0]);
                    string observaciones = split[0];
                    string color = split[0];
                    bool estado = bool.Parse(split[0]);

                    AutoCamioneta ac = new AutoCamioneta(id_vehiculo, patente, kilometros, anio, id_marca, modelo, id_segmento, id_combustible, precio_venta, observaciones, color, estado);

                    if (bool.Parse(split[11]) == true)
                    {
                        this._listaAutoCamionetasVendidos.Add(ac);
                    }
                    else
                    {
                        this._listaAutoCamionetasDisponibles.Add(ac);
                    }

                    _listaAutoCamionetas.Add(ac);
                    
                }
                reader.Close();
                archivo.Close();              
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontrado: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos: {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Se ha producido un error.");
            }
        } 
        public void CargarCamiones()
        {
            try
            {
                _listaCamiones.Clear();
                FileStream archivo = new FileStream("Camiones.txt", FileMode.Open);
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
                    int id_combustible = int.Parse(split[7]);
                    double precio_vta = double.Parse(split[8]);
                    string observaciones = split[9];
                    string color = split[10];
                    bool caja_carga = bool.Parse(split[11]);
                    int dimension_caja = int.Parse(split[12]);
                    int carga_max = int.Parse(split[13]);
                    bool estado = bool.Parse(split[14]);

                    Camion cam = new Camion(id_vehiculo, patente, kilometros, anio, id_marca, modelo, id_segmento, 
                        id_combustible, precio_vta, observaciones, color, caja_carga, dimension_caja, 
                        carga_max, estado);


                    if (bool.Parse(split[14]) == true)
                    {
                        this._listaCamionesVendidos.Add(cam);
                    }
                    else
                    {
                        this._listaCamionesDisponibles.Add(cam);
                    }

                    
                    _listaCamiones.Add(cam);
                }
                archivo.Close();
                reader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Archivo no encontrado: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos: {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Se ha producido un error.");
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
                Console.WriteLine($"Archivo no encontrado: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos: {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Se ha producido un error.");
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
                Console.WriteLine($"Archivo no encontrado: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos: {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Se ha producido un error.");
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
                Console.WriteLine($"Archivo no encontrado: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos: {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Se ha producido un error.");
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
                Console.WriteLine($"Archivo no encontrado: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos: {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Se ha producido un error.");
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
                Console.WriteLine($"Archivo no encontrado: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos: {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Se ha producido un error.");
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
                Console.WriteLine($"Archivo no encontrado: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos: {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Se ha producido un error.");
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
                Console.WriteLine($"Archivo no encontrado: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error al parsear datos: {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Se ha producido un error.");
            }
        }


        //VEHICULOS----------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
        public void IngresarAutoCamioneta()
        {

            int id_vehiculo, anio, id_marca, id_combustible, id_segmento;
            double kilometros, precio_vta;
            Vehiculo vehi = new Vehiculo();
            Moto mot = new Moto();
            AutoCamioneta autcam = new AutoCamioneta();
            Camion cam = new Camion();
            

            Console.Write("\t\t\t*****CARGA DE AUTO/CAMIONETA*****\n\n");
            Console.Write("Ingrese el ID del vehículo a registrar: "); // ID vehículo
            while (!int.TryParse(Console.ReadLine(), out id_vehiculo) || !IsIdValid(id_vehiculo)) // se podria llamar al metodo de validacion - ya esta
            {
                
                Console.WriteLine("Error. El ID ingresado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out id_vehiculo); // ya esta en el while?

            }
            autcam.pId_vehiculo = id_vehiculo;

            //foreach (AutoCamioneta ac in this._listaAutoCamionetas)
            //{

            //    while (ac.pId_vehiculo == id_vehiculo || ac.pEstado == true)
            //    {
            //        Console.WriteLine("Error. El ID ingrsado ya existe o ya fue vendido. Presione una tecla para continuar");
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
            //        Console.WriteLine("Error. El ID ingrsado ya existe o ya fue vendido. Presione una tecla para continuar");
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
            //        Console.WriteLine("Error. El ID ingrsado ya existe o ya fue vendido. Presione una tecla para continuar");
            //        Console.ReadKey();
            //        Console.Clear();
            //        Console.Write("Ingrese el ID del vehículo a registrar: ");
            //        int.TryParse(Console.ReadLine(), out id_vehiculo);
            //    }
            //}



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
                    Console.WriteLine("Error. La Patente ingresada ya existe. Ingrese una patente diferente.");
                }

            } while (true);


            // Ingreso de los Kilometros
            Console.Write("\nIngrese los KILOMETROS del vehículo a registrar: "); // Kilómetros
            while (!double.TryParse(Console.ReadLine(), out kilometros))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese los Kilometros del vehículo a registrar: ");
                double.TryParse(Console.ReadLine(), out kilometros);

            }
            autcam.pKilometros = kilometros;

            Console.Write("\nIngrese el AÑO del vehículo a registrar: "); // Año. Se puede establecer rango min-max
            while (!int.TryParse(Console.ReadLine(), out anio))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el Año del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out anio);

            }
            autcam.pAnio = anio;

            Console.Write("\nIngrese el ID de la MARCA del vehiculo a registrar: "); // ID Marca
            while (!int.TryParse(Console.ReadLine(), out id_marca))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la marca del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out id_marca);

            }
            autcam.pId_marca = id_marca;

            Console.Write("\nIngrese el nombre del MODELO del vehiculo a registrar: "); // Nombre Modelo 
            autcam.pModelo = Console.ReadLine();
            // do
            // {
            Console.Write("\nIngrese el ID del SEGMENTO del vehiculo a registrar: "); // ID segmento
            while (!int.TryParse(Console.ReadLine(), out id_segmento))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del segmento del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out id_segmento);

            }
            while (id_segmento > 4)
            {
                Console.WriteLine("Error. El segmento ingresado no corresponde a un Auto/Camioneta. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del segmento del vehiculo a registrar");
                id_segmento = int.Parse(Console.ReadLine());
            }
            autcam.pId_segmento = id_segmento;

            //} while (!int.TryParse(Console.ReadLine(), out id_segmento) || id_segmento>4);

            Console.Write("\nIngrese el ID del COMBUSTIBLE del vehiculo a registrar: "); // ID Combustible
            while (!int.TryParse(Console.ReadLine(), out id_combustible))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del combustible del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out id_combustible);

            }
            autcam.pId_combustible = id_combustible;


            Console.Write("\nIngrese el precio de venta del vehículo a registrar: "); // Precio Venta
            while (!double.TryParse(Console.ReadLine(), out precio_vta))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el precio de venta del vehículo a registrar: ");
                double.TryParse(Console.ReadLine(), out precio_vta);

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
            _listaAutoCamionetasDisponibles.Add(autcam);
        } // modificar las validaciones del resto de los ingresos con el nuevo metodo 
        public void IngresarMoto()
        {
            int id_vehiculo, anio, id_marca, id_combustible, id_segmento, cilindrada;
            double kilometros, precio_vta;
            Vehiculo vehi = new Vehiculo();
            Moto mot = new Moto();
            AutoCamioneta autcam = new AutoCamioneta();
            Camion cam = new Camion();


            Console.Write("\t\t\t*****CARGA DE MOTO*****\n\n");
            Console.Write("Ingrese el ID del vehículo a registrar: "); // ID vehículo
            while (!int.TryParse(Console.ReadLine(), out id_vehiculo))
            {
                Console.WriteLine("Error. El ID ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out id_vehiculo);

            }

            
            foreach (AutoCamioneta ac in this._listaAutoCamionetas)
            {

                while (ac.pId_vehiculo == id_vehiculo || ac.pEstado == true)
                {
                    Console.WriteLine("Error. El ID ingrsado ya existe o ya fue vendido. Presione una tecla para continuar");
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
                    Console.WriteLine("Error. El ID ingrsado ya existe o ya fue vendido. Presione una tecla para continuar");
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
                    Console.WriteLine("Error. El ID ingrsado ya existe o ya fue vendido. Presione una tecla para continuar");
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
            while (!double.TryParse(Console.ReadLine(), out kilometros))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese los Kilometros del vehículo a registrar: ");
                double.TryParse(Console.ReadLine(), out kilometros);

            }
            mot.pKilometros = kilometros;

            Console.Write("\nIngrese el AÑO del vehículo a registrar: "); // Año. Se puede establecer rango min-max
            while (!int.TryParse(Console.ReadLine(), out anio))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el Año del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out anio);

            }
            mot.pAnio = anio;

            Console.Write("\nIngrese el ID de la MARCA del vehiculo a registrar: ");
            while (!int.TryParse(Console.ReadLine(), out id_marca))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la marca del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out id_marca);

            }
            mot.pId_marca = id_marca;

            Console.Write("\nIngrese el ID del SEGMENTO del vehiculo a registrar: ");
            while (!int.TryParse(Console.ReadLine(), out id_segmento))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del segmento del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out id_segmento);

            }
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
            while (!int.TryParse(Console.ReadLine(), out cilindrada))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese la Cilindrada del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out cilindrada);

            }
            mot.pCilindrada = cilindrada;

            Console.Write("\nIngrese el ID del COMBUSTIBLE del vehiculo a registrar: ");
            while (!int.TryParse(Console.ReadLine(), out id_combustible))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del combustible del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out id_combustible);

            }
            mot.pId_combustible = id_combustible;


            Console.Write("\nIngrese el precio de venta del vehículo a registrar: "); // Precio
            while (!double.TryParse(Console.ReadLine(), out precio_vta))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el precio de venta del vehículo a registrar: ");
                double.TryParse(Console.ReadLine(), out precio_vta);

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
            _listaMotosDisponibles.Add(mot);
        }
        public void IngresarCamion()
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
            while (!int.TryParse(Console.ReadLine(), out id_vehiculo))
            {
                Console.WriteLine("Error. El ID ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out id_vehiculo);

            }
            foreach (AutoCamioneta ac in this._listaAutoCamionetas)
            {

                while (ac.pId_vehiculo == id_vehiculo || ac.pEstado == true)
                {
                    Console.WriteLine("Error. El ID ingrsado ya existe o ya fue vendido. Presione una tecla para continuar");
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
                    Console.WriteLine("Error. El ID ingrsado ya existe o ya fue vendido. Presione una tecla para continuar");
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
                    Console.WriteLine("Error. El ID ingrsado ya existe o ya fue vendido. Presione una tecla para continuar");
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
            while (!double.TryParse(Console.ReadLine(), out kilometros))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese los Kilometros del vehículo a registrar: ");
                double.TryParse(Console.ReadLine(), out kilometros);

            }
            cam.pKilometros = kilometros;


            Console.Write("\nIngrese el AÑO del vehículo a registrar: "); // Año. Se puede establecer rango min-max
            while (!int.TryParse(Console.ReadLine(), out anio))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el Año del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out anio);

            }
            cam.pAnio = anio;


            Console.Write("\nIngrese el ID de la MARCA del vehiculo a registrar: ");
            while (!int.TryParse(Console.ReadLine(), out id_marca))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la marca del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out id_marca);

            }
            cam.pId_marca = id_marca;


            Console.Write("\nIngrese el nombre del MODELO del vehiculo a registrar: ");
            cam.pModelo = Console.ReadLine();


            // do
            // {
            Console.Write("\nIngrese el ID del SEGMENTO del vehiculo a registrar: ");
            while (!int.TryParse(Console.ReadLine(), out id_segmento))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del segmento del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out id_segmento);

            }
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
            int indexcaja = 0;
            ConsoleKeyInfo opccaja;

            Console.WriteLine("\nIngrese si el camion tiene caja 1 -> SI\t2 -> NO: ");
            int opc = int.Parse(Console.ReadLine());
            while(opc > 2)
            {
                Console.WriteLine("\nEl dato ingresado no es correcto.\nIngrese si el camion tiene caja 1 -> SI\t2 -> NO: ");
                opc = int.Parse(Console.ReadLine());
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
            while (!int.TryParse(Console.ReadLine(), out largocaja))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el Largo de la caja del camion a registrar(en mts): ");
                int.TryParse(Console.ReadLine(), out largocaja);

            }

            Console.Write("\nIngrese el ANCHO de la caja del camion (en metros): ");
            while (!int.TryParse(Console.ReadLine(), out anchocaja))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ancho de la caja del camion a registrar(en mts): ");
                int.TryParse(Console.ReadLine(), out anchocaja);

            }
            dimension_caja = largocaja * anchocaja;
            cam.pDimension_caja = dimension_caja;


            Console.Write("\nIngrese la CARGA MAXIMA de la caja del camion (en kg): ");
            while (!int.TryParse(Console.ReadLine(), out carga_max))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese la carga maxima de la caja del camion a registrar: ");
                int.TryParse(Console.ReadLine(), out carga_max);

            }
            cam.pCarga_max = carga_max;


            Console.Write("\nIngrese el ID del COMBUSTIBLE del vehiculo a registrar: ");
            while (!int.TryParse(Console.ReadLine(), out id_combustible))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del combustible del vehículo a registrar: ");
                int.TryParse(Console.ReadLine(), out id_combustible);

            }
            cam.pId_combustible = id_combustible;


            Console.Write("\nIngrese el precio de venta del vehículo a registrar: "); // Precio
            while (!double.TryParse(Console.ReadLine(), out precio_vta))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el precio de venta del vehículo a registrar: ");
                double.TryParse(Console.ReadLine(), out precio_vta);

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
            _listaCamionesDisponibles.Add(cam);
        }       
        public void MostrarVehiculos() // muestra distintas listas de las que se cargan al inicio de la consola, por eso no muestra ningun vehiculo
        {
            CargarAutosCamionetas();
            CargarCamiones();
            CargarMotos();

            Console.WriteLine("Autos y Camionetas\n");
            
            foreach (Vehiculo vehiculo in _listaVehiculos)
            {
                vehiculo.MostrarDatos();
            }
            
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
                wr.WriteLine($"{autcam.pId_vehiculo};{autcam.pPatente};{autcam.pKilometros};{autcam.pAnio};" +
                    $"{autcam.pId_marca};{autcam.pModelo};{autcam.pId_segmento};{autcam.pId_combustible};" +
                    $"{autcam.pPrecio_vta};{autcam.pObservaciones};{autcam.pColor};{autcam.pEstado}");
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
                wr.WriteLine($"{moto.pId_vehiculo};{moto.pPatente};{moto.pKilometros};{moto.pAnio};" +
                    $"{moto.pId_marca};{moto.pModelo};{moto.pId_segmento};{moto.pId_combustible};" +
                    $"{moto.pPrecio_vta};{moto.pObservaciones};{moto.pColor};{moto.pCilindrada};{moto.pEstado}");
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
                wr.WriteLine($"{cam.pId_vehiculo};{cam.pPatente};{cam.pKilometros};{cam.pAnio};" +
                    $"{cam.pId_marca};{cam.pModelo};{cam.pId_segmento};{cam.pId_combustible};" +
                    $"{cam.pPrecio_vta};{cam.pObservaciones};{cam.pColor};{cam.pCaja_Carga};" +
                    $"{cam.pDimension_caja};{cam.pCarga_max};{cam.pEstado}");
            }
            wr.Close();
            arch.Close();
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }
        public void BorrarVehiculo()
        {
            int id, flag = 0, i, j , k ;
            string cad;
            Console.WriteLine("Ingrese el ID del Vehiculo a eliminar: ");
            cad = Console.ReadLine();
            id = int.Parse(cad);
            
            
            for (i = _listaAutoCamionetasDisponibles.Count() - 1; i >= 0; i--)
            {
                if (_listaAutoCamionetasDisponibles[i].pId_vehiculo == id)
                {
                    flag = 1;
                    _listaAutoCamionetasDisponibles.RemoveAt(i);
                }

            }
            for (j = _listaMotosDisponibles.Count() - 1; j >= 0; j--)
            {
                if (_listaMotosDisponibles[j].pId_vehiculo == id)
                {
                    flag = 1;
                    _listaMotosDisponibles.RemoveAt(j);
                }

            }
            for (k = _listaCamionesDisponibles.Count() - 1; k >= 0; k--)
            {
                if (_listaCamionesDisponibles[k].pId_vehiculo == id)
                {
                    flag = 1;
                    _listaCamionesDisponibles.RemoveAt(k); ;
                }

            }
            
            if (flag == 0)
            {
                Console.Write($"El ID -{id}- no existe en la lista de Vehiculos");

            }
            else
            {
                Console.Write($"El articulo con ID -{id}- fue eliminado");
            }
            /*
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
            */
  
        }
        public void ModificarVehiculo()
        {
            AutoCamioneta autoCamioneta = new AutoCamioneta();
            Camion camion = new Camion();
            Moto moto = new Moto();
            int id, flag = 0, i=_listaAutoCamionetasDisponibles.Count() - 1, j= _listaMotosDisponibles.Count() - 1,
                k= _listaCamionesDisponibles.Count() - 1;
            string cad;
            Console.WriteLine("Ingrese el ID del vehiculo a modificar");
            cad = Console.ReadLine();
            id = int.Parse(cad);
            foreach(AutoCamioneta autcam in _listaAutoCamionetasDisponibles)
            {
                if(autcam.pId_vehiculo == id)
                {
                    string[] menumodif = { "Patente", "Kilometros", "Año", "Id de marca",
                "Modelo", "Id de segmento", "Id de combustible", "Precio", "Observaciones", "Color"};
                    int indexmodif = 0;
                    ConsoleKeyInfo opcmodif;
                    Console.Clear();
                    Console.WriteLine("Ingrese el dato que desea modificar\n");
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
                                    Console.WriteLine($"Ingrese la patente que modficara la actual -{autcam.pPatente}-: ");
                                    autcam.pPatente = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Kilometros")
                                {
                                    double kilomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el Kilometraje que modficara el actual -{autcam.pKilometros}-: ");
                                    while (!double.TryParse(Console.ReadLine(), out kilomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el Kilometraje que modficara el actual -{autcam.pKilometros}-:  ");
                                        double.TryParse(Console.ReadLine(), out kilomodif);

                                    }
                                    autcam.pKilometros = kilomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Año")
                                {
                                    int aniomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el AÑO que modficara el actual -{autcam.pAnio}-: ");
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out aniomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el Año que modficara el actual -{autcam.pAnio}-:  ");
                                        int.TryParse(Console.ReadLine(), out aniomodif);

                                    }
                                    autcam.pAnio = aniomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Id de marca")
                                {
                                    int idmarcamodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el ID de Marca que modficara el actual -{autcam.pId_marca}-: ");
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out idmarcamodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de marca que modficara el actual -{autcam.pId_marca}-:  ");
                                        int.TryParse(Console.ReadLine(), out idmarcamodif);

                                    }
                                    autcam.pId_marca = idmarcamodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Modelo")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el MODELO que modificara el actual -{autcam.pModelo}-: ");
                                    autcam.pModelo = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Id de segmento")
                                {
                                    int idsegmentomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el % de IVA que modificara el actual -{autcam.pId_segmento}-: ");
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out idsegmentomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de marca que modficara el actual -{autcam.pId_segmento}-:  ");
                                        int.TryParse(Console.ReadLine(), out idsegmentomodif);

                                    }
                                    autcam.pId_segmento = idsegmentomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Id de combustible")
                                {
                                    int idcombmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el ID de Combustible que modificara el actual -{autcam.pId_combustible}-: ");
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out idcombmodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de marca que modficara el actual -{autcam.pId_combustible}-:  ");
                                        int.TryParse(Console.ReadLine(), out idcombmodif);

                                    }
                                    autcam.pId_combustible = idcombmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Precio")
                                {
                                    double preciomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el Precio que modificara el actual -{autcam.pPrecio_vta}-: ");
                                    cad = Console.ReadLine();
                                    while (!double.TryParse(Console.ReadLine(), out preciomodif))
                                    { 
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de marca que modficara el actual -{autcam.pPrecio_vta}-:  ");
                                        double.TryParse(Console.ReadLine(), out preciomodif);

                                    }
                                    autcam.pPrecio_vta = preciomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Observaciones")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la Observacion que modificara la actual -{autcam.pObservaciones}-: ");
                                    autcam.pObservaciones = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Color")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el Color que modificara el actual -{autcam.pColor}-: ");
                                    autcam.pColor = Console.ReadLine();
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
                        Console.WriteLine("Ingrese el dato que desea modificar\n");
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
                                        Console.WriteLine($"Ingrese la patente que modficara la actual -{mot.pPatente}-: ");
                                        mot.pPatente = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                    }
                                    else if (menumodif[indexmodif] == "Kilometros")
                                    {
                                        double kilomodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el Kilometraje que modficara el actual -{mot.pKilometros}-: ");
                                        while (!double.TryParse(Console.ReadLine(), out kilomodif))
                                        {
                                            Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese el Kilometraje que modficara el actual -{mot.pKilometros}-:  ");
                                            double.TryParse(Console.ReadLine(), out kilomodif);

                                        }
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                    }
                                    else if (menumodif[indexmodif] == "Año")
                                    {

                                        int aniomodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el AÑO que modficara el actual -{mot.pAnio}-: ");
                                        cad = Console.ReadLine();
                                        while (!int.TryParse(Console.ReadLine(), out aniomodif))
                                        {
                                            Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese el Año que modficara el actual -{mot.pAnio}-:  ");
                                            int.TryParse(Console.ReadLine(), out aniomodif);

                                        }
                                        mot.pAnio = aniomodif;
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");


                                    }
                                    else if (menumodif[indexmodif] == "Id de marca")
                                    {
                                        int idmarcamodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el ID de Marca que modficara el actual -{mot.pId_marca}-: ");
                                        cad = Console.ReadLine();
                                        while (!int.TryParse(Console.ReadLine(), out idmarcamodif))
                                        {
                                            Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese el ID de marca que modficara el actual -{mot.pId_marca}-:  ");
                                            int.TryParse(Console.ReadLine(), out idmarcamodif);

                                        }
                                        mot.pId_marca = idmarcamodif;
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                    }
                                    else if (menumodif[indexmodif] == "Modelo")
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el MODELO que modificara el actual -{mot.pModelo}-: ");
                                        mot.pModelo = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                    }
                                    else if (menumodif[indexmodif] == "Id de segmento")
                                    {
                                        int idsegmentomodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el % de IVA que modificara el actual -{mot.pId_segmento}-: ");
                                        cad = Console.ReadLine();
                                        while (!int.TryParse(Console.ReadLine(), out idsegmentomodif))
                                        {
                                            Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese el ID de marca que modficara el actual -{mot.pId_segmento}-:  ");
                                            int.TryParse(Console.ReadLine(), out idsegmentomodif);

                                        }
                                        mot.pId_segmento = idsegmentomodif;
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                    }
                                    else if (menumodif[indexmodif] == "Id de combustible")
                                    {
                                        int idcombmodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el ID de Combustible que modificara el actual -{mot.pId_combustible}-: ");
                                        cad = Console.ReadLine();
                                        while (!int.TryParse(Console.ReadLine(), out idcombmodif))
                                        {
                                            Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese el ID de marca que modficara el actual -{mot.pId_combustible}-:  ");
                                            int.TryParse(Console.ReadLine(), out idcombmodif);

                                        }
                                        mot.pId_combustible = idcombmodif;
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                    }
                                    else if (menumodif[indexmodif] == "Precio")
                                    {
                                        double preciomodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el Precio que modificara el actual -{mot.pPrecio_vta}-: ");
                                        cad = Console.ReadLine();
                                        while (!double.TryParse(Console.ReadLine(), out preciomodif))
                                        {
                                            Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese el ID de marca que modficara el actual -{mot.pPrecio_vta}-:  ");
                                            double.TryParse(Console.ReadLine(), out preciomodif);

                                        }
                                        mot.pPrecio_vta = preciomodif;
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                    }
                                    else if (menumodif[indexmodif] == "Observaciones")
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese la Observacion que modificara la actual -{mot.pObservaciones}-: ");
                                        mot.pObservaciones = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                    }
                                    else if (menumodif[indexmodif] == "Color")
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese el Color que modificara el actual -{mot.pColor}-: ");
                                        mot.pColor = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                    }
                                    else if (menumodif[indexmodif] == "Cilindrada")
                                    {
                                        int cilinmodif;
                                        Console.Clear();
                                        Console.WriteLine($"Ingrese la Cilindrada que modificara la actual -{mot.pCilindrada}-: ");
                                        cad = Console.ReadLine();
                                        while (!int.TryParse(Console.ReadLine(), out cilinmodif))
                                        {
                                            Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.Write($"Ingrese la Cilindrada que modficara el actual -{mot.pPrecio_vta}-:  ");
                                            int.TryParse(Console.ReadLine(), out cilinmodif);

                                        }
                                        mot.pCilindrada = cilinmodif;
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
                    Console.WriteLine("Ingrese el dato que desea modificar\n");
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
                                    Console.WriteLine($"Ingrese la patente que modficara la actual -{cam.pPatente}-: ");
                                    cam.pPatente = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Kilometros")
                                {
                                    double kilomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el Kilometraje que modficara el actual -{cam.pKilometros}-: ");
                                    while (!double.TryParse(Console.ReadLine(), out kilomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el Kilometraje que modficara el actual -{cam.pKilometros}-:  ");
                                        double.TryParse(Console.ReadLine(), out kilomodif);

                                    }
                                    cam.pKilometros = kilomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Año")
                                {
                                    int aniomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el AÑO que modficara el actual -{cam.pAnio}-: ");
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out aniomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el Año que modficara el actual -{cam.pAnio}-:  ");
                                        int.TryParse(Console.ReadLine(), out aniomodif);

                                    }
                                    cam.pAnio = aniomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Id de marca")
                                {
                                    int idmarcamodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el ID de Marca que modficara el actual -{cam.pId_marca}-: ");
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out idmarcamodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de marca que modficara el actual -{cam.pId_marca}-:  ");
                                        int.TryParse(Console.ReadLine(), out idmarcamodif);

                                    }
                                    cam.pId_marca = idmarcamodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Modelo")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el MODELO que modificara el actual -{cam.pModelo}-: ");
                                    cam.pModelo = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Id de segmento")
                                {
                                    int idsegmentomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el % de IVA que modificara el actual -{cam.pId_segmento}-: ");
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out idsegmentomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de marca que modficara el actual -{cam.pId_segmento}-:  ");
                                        int.TryParse(Console.ReadLine(), out idsegmentomodif);

                                    }
                                    cam.pId_segmento = idsegmentomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Id de combustible")
                                {
                                    int idcombmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el ID de Combustible que modificara el actual -{cam.pId_combustible}-: ");
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out idcombmodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de marca que modficara el actual -{cam.pId_combustible}-:  ");
                                        int.TryParse(Console.ReadLine(), out idcombmodif);

                                    }
                                    cam.pId_combustible = idcombmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Precio")
                                {
                                    double preciomodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el Precio que modificara el actual -{cam.pPrecio_vta}-: ");
                                    cad = Console.ReadLine();
                                    while (!double.TryParse(Console.ReadLine(), out preciomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID de marca que modficara el actual -{cam.pPrecio_vta}-:  ");
                                        double.TryParse(Console.ReadLine(), out preciomodif);

                                    }
                                    cam.pPrecio_vta = preciomodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Observaciones")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la Observacion que modificara la actual -{cam.pObservaciones}-: ");
                                    cam.pObservaciones = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Color")
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese el Color que modificara el actual -{cam.pColor}-: ");
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
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out largomodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el Largo que modficara el actual:  ");
                                        int.TryParse(Console.ReadLine(), out largomodif);

                                    }
                                    Console.WriteLine($"\nIngrese el ANCHO de la caja: ");
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out anchomnodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el Ancho que modficara el actual:  ");
                                        int.TryParse(Console.ReadLine(), out anchomnodif);

                                    }
                                    dimensionmodif = largomodif * anchomnodif;
                                    cam.pDimension_caja = dimensionmodif;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Carga maxima")
                                {
                                    int cargamaxmodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese la CARGA MAX. que modificara la actual -{cam.pCarga_max}-: ");
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out cargamaxmodif))
                                    {
                                        Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese la Cilindrada que modficara el actual -{cam.pCarga_max}-:  ");
                                        int.TryParse(Console.ReadLine(), out cargamaxmodif);

                                    }
                                    cam.pCarga_max = cargamaxmodif;
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
        public void CargarVenta() // modificar validaciones (foreach) con el mismo metodo como en los ingresos
        {

            int id_venta, id_cliente, id_vehiculo = 0, iva, descuento;
            DateTime fecha_compra, fecha_entrega;
            double subtotal;
            Console.WriteLine("****CARGA DE VENTA****\n\n");


            Console.Write("Ingrese el ID de la Venta: "); // automatizar? cada id es unico 

            while(!int.TryParse(Console.ReadLine(), out id_venta))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la venta: ");
                int.TryParse(Console.ReadLine(), out id_venta);
            }
            
            foreach (Venta v in this._listaVentas)
            {
                if (v.pId_venta == id_venta)
                {
                    Console.WriteLine("Error. El ID ingrsado ya existe. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID de la Venta a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_venta);
                }
            }


            Console.Write("Ingrese el ID del cliente: ");
            foreach (Cliente cl in this._listaClientes)
            {
                Console.WriteLine($"ID: {cl.pId_cliente} Razon Social: {cl.pCliente}");
            }
            id_cliente = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese el numero del tipo vehiculo que desea vender:\n 1) Auto/Camioneta\n2) Moto\n3) Camion\n\nOpcion: ");
            int opc = int.Parse(Console.ReadLine());

            if (opc == 1)
            {
                foreach (AutoCamioneta gen in this._listaAutoCamionetasDisponibles)
                {
                    Console.WriteLine($"ID: {gen.pId_vehiculo} Modelo: {gen.pModelo}");
                }
                Console.Write("\nIngrese el ID del vehiculo a vender: ");

                while (!int.TryParse(Console.ReadLine(), out id_vehiculo))
                {
                    Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del vehículo a vender: ");
                    int.TryParse(Console.ReadLine(), out id_vehiculo);

                }

            }
            else if (opc == 2)
            {
                foreach (Moto moto in this._listaMotosDisponibles)
                {
                    Console.WriteLine($"ID: {moto.pId_vehiculo} Modelo: {moto.pModelo}");
                }
                Console.Write("\nIngrese el ID del vehiculo a vender: ");
                while (!int.TryParse(Console.ReadLine(), out id_vehiculo))
                {
                    Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del vehículo a vender: ");
                    int.TryParse(Console.ReadLine(), out id_vehiculo);

                }

            }
            else if (opc == 3)
            {
                foreach (Camion camion in this._listaCamionesDisponibles)
                {
                    Console.WriteLine($"ID: {camion.pId_vehiculo} Modelo: {camion.pModelo}");
                }
                Console.Write("\nIngrese el ID del vehiculo a vender: ");

                while (!int.TryParse(Console.ReadLine(), out id_vehiculo))
                {
                    Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del vehículo a vender: ");
                    int.TryParse(Console.ReadLine(), out id_vehiculo);

                }

            }
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
            Console.Write("\nIngrese la FECHA DE COMPRA del vehiculo: ");
            while (!DateTime.TryParse(Console.ReadLine(), out fecha_compra))
            { 
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese la Fecha de compra del vehiculo: ");
                DateTime.TryParse(Console.ReadLine(), out fecha_compra);

            }

            Console.Write("\nIngrese la FECHA DE ENTREGA del vehiculo: ");
            while (!DateTime.TryParse(Console.ReadLine(), out fecha_entrega))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese la Fecha de entrega del vehiculo: ");
                DateTime.TryParse(Console.ReadLine(), out fecha_entrega);

            }

            Console.Write("\nIngrese el SUBTOTAL de la venta: ");
            while (!double.TryParse(Console.ReadLine(), out subtotal))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el Subtotal de la venta: ");
                double.TryParse(Console.ReadLine(), out subtotal);

            }

            Console.Write("\nIngrese el % de IVA: ");
            while (!int.TryParse(Console.ReadLine(), out iva))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el % de IVA: ");
                int.TryParse(Console.ReadLine(), out iva);

            }

            Console.Write("\nIngrese el % de DESCUENTO: ");
            while (!int.TryParse(Console.ReadLine(), out descuento))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el % de Descuento: ");
                int.TryParse(Console.ReadLine(), out descuento);

            }


            Venta venta = new Venta(id_venta, id_cliente, id_vehiculo, fecha_compra, fecha_entrega, subtotal, iva, descuento);
            _listaVentas.Add(venta);

        }
        public void ActualizarVentas()
        {
            arch = new FileStream("Ventas.txt", FileMode.Create);
            wr = new StreamWriter(arch);
            foreach (Venta ven in this._listaVentas)
            {
                wr.WriteLine($"{ven.pId_venta};{ven.pId_cliente};{ven.pId_vehiculo}" +
                    $";{ven.pFecha_compra};{ven.pFecha_entrega};{ven.pSubtotal};{ven.pIva};" +
                    $"{ven.pDescuento};{ven.pTotal}");
            }
            wr.Close();
            arch.Close();
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }
        public void ModificarVenta()
        {
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
                                indexmodif = indexmodif > 0 ? indexmodif - 1 : menumodif.Length - 1;
                                break;
                            case ConsoleKey.DownArrow:
                                Console.Clear();
                                indexmodif = indexmodif < menumodif.Length - 1 ? indexmodif + 1 : 0;
                                break;
                            case ConsoleKey.Enter:
                                Console.Clear();

                                switch (menumodif[indexmodif])
                                {
                                    case "Cliente":
                                        int idclmodif;
                                        Console.WriteLine($"Ingrese el ID que modificará el actual -{ven.pId_cliente}-: ");
                                        while (!int.TryParse(Console.ReadLine(), out idclmodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido.");
                                            Console.Write($"Ingrese el ID que modificará el actual -{ven.pId_cliente}-: ");
                                        }
                                        ven.pId_cliente = idclmodif;
                                        break;

                                    case "Vehiculo":
                                        int vehimodif;
                                        Console.WriteLine($"Ingrese el ID del vehículo que modificará el actual -{ven.pId_vehiculo}-: ");
                                        while (!int.TryParse(Console.ReadLine(), out vehimodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido.");
                                            Console.Write($"Ingrese el ID que modificará el actual -{ven.pId_vehiculo}-: ");
                                        }
                                        ven.pId_vehiculo = vehimodif;
                                        break;

                                    case "Fecha de compra":
                                        DateTime feccompmodif;
                                        Console.WriteLine($"Ingrese la fecha que modificará la actual -{ven.pFecha_compra}-: ");
                                        while (!DateTime.TryParse(Console.ReadLine(), out feccompmodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido.");
                                            Console.Write($"Ingrese la fecha que modificará la actual -{ven.pFecha_compra}-: ");
                                        }
                                        ven.pFecha_compra = feccompmodif;
                                        break;

                                    case "Fecha de entrega":
                                        DateTime fecentmodif;
                                        Console.WriteLine($"Ingrese la fecha que modificará la actual -{ven.pFecha_entrega}-: ");
                                        while (!DateTime.TryParse(Console.ReadLine(), out fecentmodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido.");
                                            Console.Write($"Ingrese la fecha que modificará la actual -{ven.pFecha_entrega}-: ");
                                        }
                                        ven.pFecha_entrega = fecentmodif;
                                        break;

                                    case "Subtotal":
                                        double subtotmodif;
                                        Console.WriteLine($"Ingrese el subtotal que modificará el actual -{ven.pSubtotal}-: ");
                                        while (!double.TryParse(Console.ReadLine(), out subtotmodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido.");
                                            Console.Write($"Ingrese el subtotal que modificará el actual -{ven.pSubtotal}-: ");
                                        }
                                        ven.pSubtotal = subtotmodif;
                                        break;

                                    case "IVA":
                                        int ivamodif;
                                        Console.WriteLine($"Ingrese el % de IVA que modificará el actual -{ven.pIva}-: ");
                                        while (!int.TryParse(Console.ReadLine(), out ivamodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido.");
                                            Console.Write($"Ingrese el % de IVA que modificará el actual -{ven.pIva}-: ");
                                        }
                                        ven.pIva = ivamodif;
                                        break;

                                    case "Descuento":
                                        int descmodif;
                                        Console.WriteLine($"Ingrese el descuento que modificará el actual -{ven.pDescuento}-: ");
                                        while (!int.TryParse(Console.ReadLine(), out descmodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido.");
                                            Console.Write($"Ingrese el descuento que modificará el actual -{ven.pDescuento}-: ");
                                        }
                                        ven.pDescuento = descmodif;
                                        break;

                                    case "Total":
                                        double totalmodif;
                                        Console.WriteLine($"Ingrese el SUBTOTAL que modificará el actual -{ven.pSubtotal}-: ");
                                        while (!double.TryParse(Console.ReadLine(), out subtotmodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido.");
                                            Console.Write($"Ingrese el subtotal que modificará el actual -{ven.pSubtotal}-: ");
                                        }
                                        ven.pSubtotal = subtotmodif;

                                        Console.WriteLine($"Ingrese el % de IVA que modificará el actual -{ven.pIva}-: ");
                                        while (!int.TryParse(Console.ReadLine(), out ivamodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido.");
                                            Console.Write($"Ingrese el % de IVA que modificará el actual -{ven.pIva}-: ");
                                        }
                                        ven.pIva = ivamodif;

                                        Console.WriteLine($"Ingrese el % de DESCUENTO que modificará el actual -{ven.pDescuento}-: ");
                                        while (!int.TryParse(Console.ReadLine(), out descmodif))
                                        {
                                            Console.WriteLine("Error. El dato ingresado no es válido.");
                                            Console.Write($"Ingrese el % de descuento que modificará el actual -{ven.pDescuento}-: ");
                                        }
                                        ven.pDescuento = descmodif;

                                        totalmodif = (subtotmodif + ((ivamodif * subtotmodif) / 100)) - ((descmodif * subtotmodif) / 100);
                                        //ven.pTotal = totalmodif;
                                        break;
                                }

                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                Console.ResetColor();

                                Console.WriteLine("\n\n\tPresione cualquier tecla para volver al menú");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    } while (opcmodif.Key != ConsoleKey.Escape);

                    return;
                }
                else
                {
                    flag = 1;
                }
            }

            if (flag == 1)
            {
                Console.Clear();
                Console.Write($"El ID -{id}- no existe en la lista de Ventas.");
            }
        }
        public void BorrarVenta()
        {
            int id, flag = 0;
            string cad;
            Console.WriteLine("Ingrese el ID de la Venta a eliminar: ");
            cad = Console.ReadLine();
            id = int.Parse(cad);
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
                                    Console.WriteLine($"Ingrese el ID de localidad que modificará el actual -{cl.pId_localidad}-:");
                                    cad = Console.ReadLine();
                                    while (!int.TryParse(Console.ReadLine(), out localmodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el ID que modificará el actual -{cl.pId_localidad}-:");
                                    }
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
                                    while (!long.TryParse(Console.ReadLine(), out telmodif))
                                    {
                                        Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Write($"Ingrese el teléfono que modificará el actual -{cl.pTelefono}-:");
                                    }
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
                    } while (opcmodif.Key != ConsoleKey.Escape);


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
                wr.WriteLine($"{cl.pId_cliente};{cl.pCliente}" +
                    $";{cl.pCuit};{cl.pDomicilio};{cl.pId_localidad};{cl.pTelefono};" +
                    $"{cl.pCorreo}");
            }
            wr.Close();
            arch.Close();
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }
        public void BorrarCliente()
        {
            int id, flag = 0;
            string cad;
            Console.WriteLine("Ingrese el ID del Cliente a eliminar: ");
            cad = Console.ReadLine();
            id = int.Parse(cad);
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
                Console.Write($"El ID -{id}- no existe en la lista de Clientes");

            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n\n\t\tCliente borrado correctamente.");
        }
        public void CargarCliente()
        {
            int id_cliente, id_localidad;
            string cliente, correo, domicilio;
            long telefono, cuit;

            Console.WriteLine("****CARGA DE CLIENTE****\n\n");

            Console.Write("Ingrese el ID del Cliente: ");
            while (!int.TryParse(Console.ReadLine(), out id_cliente))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del Cliente: ");
                int.TryParse(Console.ReadLine(), out id_cliente);

            }
            foreach (Cliente c in this._listaClientes)
            {
                if (c.pId_cliente == id_cliente)
                {
                    Console.WriteLine("Error. El ID ingrsado ya existe. Presione una tecla para continuar");
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

            Console.Write("\nIngrese el ID de la Localidad: ");
            foreach(Localidad loc in this._listaLocalidades)
            {
                Console.WriteLine($"\tID: {loc.pId_localidad} Localidad: {loc.pLocalidad}");
            }
            while (!int.TryParse(Console.ReadLine(), out id_localidad))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la Localidad: ");
                int.TryParse(Console.ReadLine(), out id_localidad);

            }

            Console.Write("\nIngrese el Telefono del cliente: ");
            while (!long.TryParse(Console.ReadLine(), out telefono))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el Telefono del cliente: ");
                long.TryParse(Console.ReadLine(), out telefono);

            }

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
            Console.Write("Ingrese el ID de la Marca: ");
            while (!int.TryParse(Console.ReadLine(), out id_marca))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la Marca: ");
                int.TryParse(Console.ReadLine(), out id_marca);

            }
            foreach (Marca m in this._listaMarcas)
            {
                if (m.pId_marca == id_marca)
                {
                    Console.WriteLine("Error. El ID ingrsado ya existe. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID de la Marca a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_marca);
                }
            }
            Console.Write("\nIngrese el NOMBRE de la Marca: ");
            marca = Console.ReadLine();

            Marca marc = new Marca(id_marca, marca);
            _listaMarcas.Add(marc);

        }
        public void BorrarMarca()
        {
            int id, flag=0;
            string cad;
            Console.WriteLine("Ingrese el ID de la Marca a eliminar: ");
            cad = Console.ReadLine();
            id = int.Parse(cad);
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
                Console.Write($"El ID -{id}- no existe en la lista de Marcas");

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
            int id;
            string cad;

            Console.WriteLine("Ingrese el ID de la marca a modificar: ");
            cad = Console.ReadLine();
            while (!int.TryParse(cad, out id))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la Marca a modificar: ");
                cad = Console.ReadLine();
            }

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
                                    Console.Write("Ingrese el nuevo ID de la marca: ");
                                    while (!int.TryParse(Console.ReadLine(), out nuevoIdMarca))
                                    {
                                        Console.WriteLine("ID inválido. Reingrese.");
                                        Console.Write("Ingrese el nuevo ID de la marca: ");
                                    }
                                    marca.pId_marca = nuevoIdMarca;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    Console.Write($"Ingrese la nueva descripción de la marca (actual: {marca.pMarca}): ");
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
                Console.Write("Ingrese el nombre de la Marca: ");
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
            int id_localidad, id_provincia;
            string localidad;
            Console.Write("****CARGA DE LOCALIDAD****\n\n");
            Console.Write("Ingrese el ID de la Localidad: ");
            while (!int.TryParse(Console.ReadLine(), out id_localidad))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la Localidad: ");
                int.TryParse(Console.ReadLine(), out id_localidad);

            }
            foreach (Localidad l in this._listaLocalidades)
            {
                if (l.pId_localidad == id_localidad)
                {
                    Console.WriteLine("Error. El ID ingrsado ya existe. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID de la Localidad a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_localidad);
                }
            }

            Console.Write("\nIngrese el NOMBRE de la localidad: ");
            localidad = Console.ReadLine();

            foreach (Provincia prov in this._listaProvincias)
            {
                Console.Write($"ID: {prov.pId_provincia} -> {prov.pProvincia}");
            }
            Console.Write("\nIngrese el ID de la Provincia");
            while (!int.TryParse(Console.ReadLine(), out id_provincia))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la Provincia: ");
                int.TryParse(Console.ReadLine(), out id_provincia);

            }

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
            int id;
            string cad;
            Console.WriteLine("Ingrese el ID de la localidad a modificar: ");
            cad = Console.ReadLine();
            while (!int.TryParse(cad, out id))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la localidad a modificar: ");
                cad = Console.ReadLine();
            }

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
                                    Console.Write("Ingrese el nuevo ID de la localidad: ");
                                    while (!int.TryParse(Console.ReadLine(), out nuevoIdLocalidad))
                                    {
                                        Console.WriteLine("ID inválido. Reingrese.");
                                        Console.Write("Ingrese el nuevo ID de la localidad: ");
                                    }
                                    localidad.pId_localidad = nuevoIdLocalidad;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    Console.Write($"Ingrese la nueva descripción de la localidad (actual: {localidad.pLocalidad}): ");
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
            int id, flag=0;
            string cad;
            Console.WriteLine("Ingrese el ID de la Localidad a eliminar: ");
            cad = Console.ReadLine();
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la localidad a eliminar: ");
                int.TryParse(Console.ReadLine(), out id);

            }
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
                Console.Write($"El ID -{id}- no existe en la lista de Localidades");
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
                Console.Write("Ingrese el nombre de la Localidad: ");
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
            Console.Write("Ingrese el ID de la Provincia: ");
            while (!int.TryParse(Console.ReadLine(), out id_provincia))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la Provincia: ");
                int.TryParse(Console.ReadLine(), out id_provincia);

            }
            foreach (Provincia p in this._listaProvincias)
            {
                if (p.pId_provincia == id_provincia)
                {
                    Console.WriteLine("Error. El ID ingrsado ya existe. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID de la Provincia a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_provincia);
                }
            }
            Console.Write("\nIngrese el NOMBRE de la Provincia: ");
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
            int id;
            string cad;

            Console.WriteLine("Ingrese el ID de la provincia a modificar: ");
            cad = Console.ReadLine();
            while (!int.TryParse(cad, out id))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la provincia a modificar: ");
                cad = Console.ReadLine();
            }

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
                                    Console.Write("Ingrese el nuevo ID de la provincia: ");
                                    while (!int.TryParse(Console.ReadLine(), out nuevoIdProvincia))
                                    {
                                        Console.WriteLine("ID inválido. Reingrese.");
                                        Console.Write("Ingrese el nuevo ID de la provincia: ");
                                    }
                                    provincia.pId_provincia = nuevoIdProvincia;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    Console.Write($"Ingrese la nueva descripción de la provincia (actual: {provincia.pProvincia}): ");
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
            int id, flag=0;
            string cad;
            Console.WriteLine("Ingrese el ID de la Provincia a eliminar: ");
            cad = Console.ReadLine();
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID de la Provincia a eliminar: ");
                int.TryParse(Console.ReadLine(), out id);

            }
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
                Console.Write($"El ID -{id}- no existe en la lista de Provincias");
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
            BuscarProvincia();
            string cad;
            bool encontrado = false;

            do
            {
                Console.Write("Ingrese el nombre de la Provincia: ");
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
            Console.Write("Ingrese el ID del Combustible: ");
            while (!int.TryParse(Console.ReadLine(), out id_combustible))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del Combustible: ");
                int.TryParse(Console.ReadLine(), out id_combustible);

            }
            foreach (Combustible c in this._listaCombustibles)
            {
                if (c.pIdCombustible == id_combustible)
                {
                    Console.WriteLine("Error. El ID ingrsado ya existe. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del Combustible a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_combustible);
                }
            }
            Console.Write("\nIngrese el NOMBRE del Combustible: ");
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
            int id, flag=0;
            string cad;
            Console.WriteLine("Ingrese el ID del Combustible a eliminar: ");
            cad = Console.ReadLine();
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del Combustible a eliminar: ");
                int.TryParse(Console.ReadLine(), out id);

            }
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
                Console.Write($"El ID -{id}- no existe en la lista de Combustibles");
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
            int id;
            string cad;

            Console.WriteLine("Ingrese el ID del combustible a modificar: ");
            cad = Console.ReadLine();
            while (!int.TryParse(cad, out id))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del combustible a modificar: ");
                cad = Console.ReadLine();
            }

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
                                    Console.Write("Ingrese el nuevo ID del combustible: ");
                                    while (!int.TryParse(Console.ReadLine(), out nuevoIdCombustible))
                                    {
                                        Console.WriteLine("ID inválido. Reingrese.");
                                        Console.Write("Ingrese el nuevo ID del combustible: ");
                                    }
                                    combustible.pIdCombustible = nuevoIdCombustible;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    Console.Write($"Ingrese la nueva descripción del combustible (actual: {combustible.pCombustible}): ");
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
                Console.Write("Ingrese el nombre del Combustible: ");
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
            Console.Write("Ingrese el ID del Segmento: ");
            while (!int.TryParse(Console.ReadLine(), out id_segmento))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del Segmento: ");
                int.TryParse(Console.ReadLine(), out id_segmento);

            }
            foreach (Segmento s in this._listaSegmentos)
            {
                if (s.pIdSegmento == id_segmento)
                {
                    Console.WriteLine("Error. El ID ingrsado ya existe. Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Ingrese el ID del Segmento a registrar: ");
                    int.TryParse(Console.ReadLine(), out id_segmento);
                }
            }
            Console.Write("\nIngrese el NOMBRE del Segmento: ");
            segmento = Console.ReadLine();

            Segmento seg = new Segmento(id_segmento, segmento);
            _listaSegmentos.Add(seg);

        }
        public void ModificarSegmento()
        {
            int id;
            string cad;

            Console.WriteLine("Ingrese el ID del segmento a modificar: ");
            cad = Console.ReadLine();
            while (!int.TryParse(cad, out id))
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del segmento a modificar: ");
                cad = Console.ReadLine();
            }

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
                                    Console.Write("Ingrese el nuevo ID del segmento: ");
                                    while (!int.TryParse(Console.ReadLine(), out nuevoIdSegmento))
                                    {
                                        Console.WriteLine("ID inválido. Reingrese.");
                                        Console.Write("Ingrese el nuevo ID del segmento: ");
                                    }
                                    segmento.pIdSegmento = nuevoIdSegmento;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    Console.Write($"Ingrese la nueva descripción del segmento (actual: {segmento.pSegmento}): ");
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
            int id, flag=0;
            string cad;
            Console.WriteLine("Ingrese el ID del Segmento a eliminar: ");
            cad = Console.ReadLine();
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Error. El dato ingrsado no es valido. Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el ID del Segmento a eliminar: ");
                int.TryParse(Console.ReadLine(), out id);

            }
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
                Console.Write($"El ID -{id}- no existe en la lista de Segmentos");

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
                Console.Write("Ingrese el nombre del Segmento: ");
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
            //foreach (AutoCamioneta autocam in _listaAutoCamionetas)
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

            return true;
        }
    }
}

