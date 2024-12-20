using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

        // CARGAR LISTAS

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
                    int dimension_caja, carga_max;
                    int id_vehiculo = int.Parse(split[0]);
                    string patente = split[1];
                    double kilometros = double.Parse(split[2]);
                    int anio = int.Parse(split[3]);
                    int id_marca = int.Parse(split[4]);
                    string modelo = split[5];
                    int id_segmento = int.Parse(split[6]);
                    bool caja_carga = bool.Parse(split[7]);
                    if (bool.Parse(split[7]) == true)
                    {
                        dimension_caja = int.Parse(split[8]);
                        carga_max = int.Parse(split[9]);
                    }
                    else
                    {
                        dimension_caja = 0;
                        carga_max = 0;
                    }
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

        // ACTUALIZAR LISTAS

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

        // VEHICULOS

        public void IngresarAutoCamioneta()
        {
            CargarAutosCamionetas();
            CargarMotos();
            CargarCamiones();
            CargarSegmentos();
            CargarCombustibles();
            CargarMarcas();
            int anio;
            string[] arraySegmentos, arrayMarcas, arrayCombustibles;
            DateTime fecact = DateTime.Now;
            AutoCamioneta autcam = new AutoCamioneta();

            Console.Write("\t\t\t*****CARGA DE AUTO/CAMIONETA*****\n\n");
            List<int> idsExistentes = this._listaAutoCamionetas.Select(ac => ac.pId_vehiculo).Concat(this._listaMotos.Select(m => m.pId_vehiculo))
            .Concat(this._listaCamiones.Select(c => c.pId_vehiculo)).ToList();
            autcam.pId_vehiculo = idsExistentes.Count > 0 ? idsExistentes.Max() + 1 : 1;

            do
            {
                string patente = validar.validarStr("\nIngrese la PATENTE del vehículo a registrar (AAA000 / AA000AA): "); // Patente.
                if (IsPatenteUnique(patente))
                {
                    autcam.pPatente = patente;
                    break;
                }
                else
                {
                    Console.WriteLine("Error. La PATENTE ingresada ya existe. Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (true); // Patente.

            autcam.pKilometros = validar.validarDoble("\nIngrese los KILOMETROS del vehículo a registrar: "); // Kilómetros.

            Console.Write("\nIngrese el AÑO del vehículo a registrar: "); // Año.
            while (!int.TryParse(Console.ReadLine(), out anio) || anio > fecact.Year)
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el AÑO del vehículo a registrar: ");
            }
            autcam.pAnio = anio;

            arrayMarcas = this._listaMarcas.Select(seg => seg.pMarca).ToArray();
            autcam.pId_marca = MenuReutilizable(arrayMarcas, "Ingrese la MARCA del vehiculo a registrar ");

            autcam.pModelo = validar.validarStr("\nIngrese el NOMBRE del MODELO del vehiculo a registrar: "); // Modelo.

            arraySegmentos = this._listaSegmentos.Where(seg => seg.pIdSegmento >= 1 && seg.pIdSegmento <= 4).Select(seg => seg.pSegmento).ToArray();
            autcam.pId_segmento = MenuReutilizable(arraySegmentos, "Ingrese el SEGMENTO del vehiculo a registrar");
            arrayCombustibles = this._listaCombustibles.Select(seg => seg.pCombustible).ToArray();
            autcam.pId_combustible = MenuReutilizable(arrayCombustibles, "Ingrese el tipo de COMBUSTIBLE del vehiculo a registrar ");

            autcam.pPrecio_vta = validar.validarEntero("\nIngrese el PRECIO DE VENTA del vehículo a registrar: "); // Precio de venta.

            Console.Write("\nIngrese las OBSERVACIONES del vehículo a registrar (en caso de existir alguna): "); // Observaciones.
            string input = Console.ReadLine();
            autcam.pObservaciones = string.IsNullOrEmpty(input) ? "Sin observaciones" : input;

            autcam.pColor = validar.validarStr("\nIngrese el COLOR del vehículo a registrar: "); // Color.

            autcam.pEstado = false; // Estado.            

            _listaAutoCamionetas.Add(autcam);
            _listaAutoCamionetasDisponibles.Add(autcam);
            _listaVehiculos.Add(autcam);
        }

        public void IngresarMoto()
        {
            CargarAutosCamionetas();
            CargarMotos();
            CargarCamiones();
            CargarSegmentos();
            CargarCombustibles();
            CargarMarcas();
            int anio;
            string[] arraySegmentos, arrayMarcas, arrayCombustibles;
            DateTime fecact = DateTime.Now;
            Moto mot = new Moto();

            Console.Write("\t\t\t*****CARGA DE MOTO*****\n\n");

            List<int> idsExistentes = this._listaAutoCamionetas.Select(ac => ac.pId_vehiculo).Concat(this._listaMotos.Select(m => m.pId_vehiculo))
            .Concat(this._listaCamiones.Select(c => c.pId_vehiculo)).ToList();
            mot.pId_vehiculo = idsExistentes.Count > 0 ? idsExistentes.Max() + 1 : 1;

            do
            {
                string patente = validar.validarStr("\nIngrese la PATENTE de la moto a registrar (AAA000 / AA000AA): "); // Patente.
                if (IsPatenteUnique(patente))
                {
                    mot.pPatente = patente;
                    break;
                }
                else
                {
                    Console.WriteLine("Error. La PATENTE ingresada ya existe. Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (true); // Patente.

            mot.pKilometros = validar.validarDoble("\nIngrese los KILOMETROS de la moto a registrar: "); // Kilómetros.

            Console.Write("\nIngrese el AÑO de la moto a registrar: "); // Año.
            while (!int.TryParse(Console.ReadLine(), out anio) || anio > fecact.Year)
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el AÑO de la moto a registrar: ");
            }
            mot.pAnio = anio;

            arrayMarcas = this._listaMarcas.Select(seg => seg.pMarca).ToArray();
            mot.pId_marca = MenuReutilizable(arrayMarcas, "Ingrese la MARCA de la moto a registrar");

            mot.pModelo = validar.validarStr("\nIngrese el NOMBRE del MODELO de la moto a registrar: "); // Modelo.

            arraySegmentos = this._listaSegmentos.Where(seg => seg.pIdSegmento >= 5 && seg.pIdSegmento <= 7).Select(seg => seg.pSegmento).ToArray();
            mot.pId_segmento = MenuReutilizable(arraySegmentos, "Ingrese el SEGMENTO de la moto a registrar") + 4;

            mot.pCilindrada = validar.validarEntero("\nIngrese la CILINDRADA de la moto a registrar: ");

            arrayCombustibles = this._listaCombustibles.Select(seg => seg.pCombustible).ToArray();
            mot.pId_combustible = MenuReutilizable(arrayCombustibles, "Ingrese el tipo de COMBUSTIBLE de la moto a registrar");

            mot.pPrecio_vta = validar.validarEntero("\nIngrese el PRECIO DE VENTA de la moto a registrar: "); // Precio de venta.
            
            Console.Write("\nIngrese las OBSERVACIONES de la moto a registrar (en caso de existir alguna): "); // Observaciones.
            string input = Console.ReadLine();
            mot.pObservaciones = string.IsNullOrEmpty(input) ? "Sin observaciones" : input;

            mot.pColor = validar.validarStr("\nIngrese el COLOR de la moto a registrar: "); // Color.

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
            CargarMarcas();
            int anio, largocaja, anchocaja, opc;
            string[] arrayMarcas, arrayCombustibles, arrayOpc = { "Sí", "No"};
            DateTime fecact = DateTime.Now;
            Camion cam = new Camion();

            Console.Write("\t\t\t*****CARGA DE CAMION*****\n\n");

            List<int> idsExistentes = this._listaAutoCamionetas.Select(ac => ac.pId_vehiculo).Concat(this._listaMotos.Select(m => m.pId_vehiculo))
            .Concat(this._listaCamiones.Select(c => c.pId_vehiculo)).ToList();
            cam.pId_vehiculo = idsExistentes.Count > 0 ? idsExistentes.Max() + 1 : 1;

            do
            {
                string patente = validar.validarStr("\nIngrese la PATENTE del camión a registrar (AAA000 / AA000AA): "); // Patente.
                if (IsPatenteUnique(patente))
                {
                    cam.pPatente = patente;
                    break;
                }
                else
                {
                    Console.WriteLine("Error. La PATENTE ingresada ya existe. Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (true); // Patente.

            cam.pKilometros = validar.validarDoble("\nIngrese los KILOMETROS del camión a registrar: "); // Kilómetros.

            Console.Write("\nIngrese el AÑO del vehículo a registrar: "); // Año.
            while (!int.TryParse(Console.ReadLine(), out anio) || anio > fecact.Year)
            {
                Console.WriteLine("Error. El dato ingresado no es válido. Presione una tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Ingrese el AÑO del vehículo a registrar: ");
            }
            cam.pAnio = anio;

            arrayMarcas = this._listaMarcas.Select(seg => seg.pMarca).ToArray();
            cam.pId_marca = MenuReutilizable(arrayMarcas, "Seleccione la MARCA del camión a registrar");

            cam.pModelo = validar.validarStr("\nIngrese el NOMBRE del MODELO del camión a registrar: "); // Modelo.

            cam.pId_segmento = 8;

            opc = MenuReutilizable(arrayOpc, "Ingrese si el camion tiene caja");

            if (opc == 1)
            {
                cam.pCaja_Carga = true;
                largocaja = validar.validarEntero("\nIngrese el LARGO de la caja del camion (en metros): ");
                anchocaja = validar.validarEntero("\nIngrese el ANCHO de la caja del camion (en metros): ");
                cam.pDimension_caja = largocaja * anchocaja;
                cam.pCarga_max = validar.validarEntero("\nIngrese la CARGA MAXIMA de la caja del camion (en kg): ");
            }
            else if (opc == 2)
            {
                cam.pCaja_Carga = false;
            }

            arrayCombustibles = this._listaCombustibles.Select(seg => seg.pCombustible).ToArray();
            cam.pId_combustible = MenuReutilizable(arrayCombustibles, "Seleccione el tipo de COMBUSTIBLE del camión a registrar ");

            cam.pPrecio_vta = validar.validarEntero("\nIngrese el PRECIO DE VENTA del vehículo a registrar: "); // Precio de venta.

            Console.Write("\nIngrese las OBSERVACIONES del vehículo a registrar (en caso de existir alguna): "); // Observaciones.
            string input = Console.ReadLine();
            cam.pObservaciones = string.IsNullOrEmpty(input) ? "Sin observaciones" : input;

            cam.pColor = validar.validarStr("\nIngrese el COLOR del vehículo a registrar: "); // Color.

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
            CargarSegmentos();
            CargarMarcas();
            CargarCombustibles();
            
            Console.WriteLine("Autos y Camionetas\n");
            if (_listaAutoCamionetasDisponibles.Count() == 0)
            {
                Console.Write("No hay Autos o Camionetas registradas.\n");
            }
            else
            {
                foreach (AutoCamioneta acam in this._listaAutoCamionetasDisponibles)
                {
                    acam.MostrarDatos();
                }
            }
            
            Console.WriteLine("\nMotos\n");
            if (_listaMotosDisponibles.Count() == 0)
            {
                Console.Write("No hay Motos registradas.\n");
            }
            else
            {
                foreach (Moto mot in _listaMotosDisponibles)
                {
                    mot.MostrarDatos();
                }
            }
            
            Console.WriteLine("\nCamiones\n");
            if (_listaCamionesDisponibles.Count() == 0)
            {
                Console.Write("No hay Camiones registrados.\n");
            }
            else
            {
                foreach (Camion cam in _listaCamionesDisponibles)
                {
                    cam.MostrarDatos();
                }
            }
            
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        } 
    
        public void ModificarVehiculo()
        {
            CargarMotos();
            CargarAutosCamionetas();
            CargarCamiones();
            CargarSegmentos();
            CargarCombustibles();
            CargarMarcas();
            int flag = 0, i;
            string patente;

            Console.WriteLine("Ingrese la PATENTE del Vehiculo a modificar:");
            patente = Console.ReadLine();

            foreach (AutoCamioneta autcam in _listaAutoCamionetasDisponibles)
            {
                if(autcam.pPatente.ToLower() == patente.ToLower())
                {
                    string[] menumodif = { "Patente", "Kilometros", "Año", "Marca",
                    "Modelo", "Segmento", "Combustible", "Precio", "Observaciones", "Color"};
                    int indexmodif = 0;
                    ConsoleKeyInfo opcmodif;
                    Console.Clear();

                    do
                    {
                        Console.WriteLine("Seleccione el dato que desea modificar\n");
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
                                    autcam.pPatente = validar.validarStr($"Ingrese la PATENTE que modificará la actual -{autcam.pPatente}-: ");
                                    
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificada correctamente.");
                                    Console.ResetColor();
                                }

                                else if (menumodif[indexmodif] == "Kilometros")
                                {
                                    Console.Clear();
                                    autcam.pKilometros = validar.validarDoble($"Ingrese el Kilometraje que modificará el actual -{autcam.pKilometros}-: ");
                                    
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificados correctamente.");
                                    Console.ResetColor();
                                }

                                else if (menumodif[indexmodif] == "Año")
                                {
                                    Console.Clear();
                                    autcam.pAnio = validar.validarEntero($"Ingrese el AÑO que modificará el actual -{autcam.pAnio}-: ");
                                    
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                    Console.ResetColor();
                                }

                                else if (menumodif[indexmodif] == "Marca")
                                {
                                    string[] arrayMarcas;
                                    Console.Clear();

                                    arrayMarcas = this._listaMarcas.Select(seg => seg.pMarca).ToArray();
                                    autcam.pId_marca = MenuReutilizable(arrayMarcas, $"Seleccione la MARCA que modficará el actual -{autcam.pId_marca}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificada correctamente.");
                                    Console.ResetColor();
                                }

                                else if (menumodif[indexmodif] == "Modelo")
                                {
                                    Console.Clear();
                                    autcam.pModelo = validar.validarStr($"Ingrese el MODELO que modificará el actual -{autcam.pModelo}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                    Console.ResetColor();
                                }

                                else if (menumodif[indexmodif] == "Segmento")
                                {
                                    string[] arraySegmentos;
                                    Console.Clear();

                                    arraySegmentos = this._listaSegmentos.Where(seg => seg.pIdSegmento >= 1 && seg.pIdSegmento <= 4).Select(seg => seg.pSegmento).ToArray();
                                    autcam.pId_segmento = MenuReutilizable(arraySegmentos, $"Seleccione el Segmento que modificará el actual -{autcam.pId_segmento}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                    Console.ResetColor();
                                }

                                else if (menumodif[indexmodif] == "Combustible")
                                {
                                    string[] arrayCombustibles;
                                    Console.Clear();

                                    arrayCombustibles = this._listaCombustibles.Select(seg => seg.pCombustible).ToArray();
                                    autcam.pId_combustible = MenuReutilizable(arrayCombustibles, $"Seleccione el COMBUSTIBLE que modificará el actual -{autcam.pId_combustible}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                    Console.ResetColor();
                                }

                                else if (menumodif[indexmodif] == "Precio")
                                {
                                    Console.Clear();
                                    autcam.pPrecio_vta = validar.validarEntero($"Ingrese el PRECIO que modificará el actual -{autcam.pPrecio_vta}-: ");
                                    
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                    Console.ResetColor();
                                }

                                else if (menumodif[indexmodif] == "Observaciones")
                                {
                                    Console.Clear();
                                    Console.Write($"Ingrese la Observacion que modificará la actual -{autcam.pObservaciones}-: ");
                                    string input = Console.ReadLine();
                                    autcam.pObservaciones = string.IsNullOrEmpty(input) ? "Sin observaciones" : input;

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificadas correctamente.");
                                    Console.ResetColor();
                                }

                                else if (menumodif[indexmodif] == "Color")
                                {
                                    Console.Clear();
                                    Console.Write($"Ingrese el COLOR que modificará el actual -{autcam.pColor}-: ");
                                    autcam.pColor = Console.ReadLine();

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                    Console.ResetColor();
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
            }
            foreach (Moto mot in _listaMotosDisponibles)
            {
                if (mot.pPatente.ToLower() == patente.ToLower())
                {
                    
                    string[] menumodif = { "Patente", "Kilometros", "Año", "Marca",
                    "Modelo", "Segmento", "Combustible", "Precio", "Observaciones", "Color", "Cilindrada"};
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
                                    mot.pPatente = validar.validarStr($"Ingrese la PATENTE que modificará la actual -{mot.pPatente}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Kilometros")
                                {
                                    Console.Clear();
                                    mot.pKilometros = validar.validarDoble($"Ingrese el Kilometraje que modificará el actual -{mot.pKilometros}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificados correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Año")
                                {
                                    Console.Clear();
                                    mot.pAnio = validar.validarEntero($"Ingrese el AÑO que modificará el actual -{mot.pAnio}-: ");
                                    
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Marca")
                                {
                                    string[] arrayMarcas;
                                    Console.Clear();

                                    arrayMarcas = this._listaMarcas.Select(seg => seg.pMarca).ToArray();
                                    mot.pId_marca = MenuReutilizable(arrayMarcas, $"Seleccione la MARCA que modficará el actual -{mot.pId_marca}-: "); // Listado de marcas.

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Modelo")
                                {
                                    Console.Clear();
                                    mot.pModelo = validar.validarStr($"Ingrese el MODELO que modificará el actual -{mot.pModelo}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Segmento")
                                {
                                    string[] arraySegmentos;
                                    Console.Clear();

                                    arraySegmentos = this._listaSegmentos.Where(seg => seg.pIdSegmento >= 5 && seg.pIdSegmento <= 7).Select(seg => seg.pSegmento).ToArray();
                                    mot.pId_segmento = MenuReutilizable(arraySegmentos, $"Seleccione el Segmento que modificará el actual -{mot.pId_segmento}-: ") + 4;

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Combustible")
                                {
                                    string[] arrayCombustibles;
                                    Console.Clear();

                                    arrayCombustibles = this._listaCombustibles.Select(seg => seg.pCombustible).ToArray();
                                    mot.pId_combustible = MenuReutilizable(arrayCombustibles, $"Seleccione el COMBUSTIBLE que modificará el actual -{mot.pId_combustible}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Precio")
                                {
                                    Console.Clear();
                                    mot.pPrecio_vta = validar.validarEntero($"Ingrese el PRECIO que modificará el actual -{mot.pPrecio_vta}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Observaciones")
                                {
                                    Console.Clear();
                                    Console.Write($"Ingrese la Observacion que modificará la actual -{mot.pObservaciones}-: ");
                                    string input = Console.ReadLine();
                                    mot.pObservaciones = string.IsNullOrEmpty(input) ? "Sin observaciones" : input;

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} Modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Color")
                                {
                                    Console.Clear();
                                    mot.pColor = validar.validarStr($"Ingrese el COLOR que modificará el actual -{mot.pColor}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Cilindrada")
                                {
                                    Console.Clear();
                                    mot.pCilindrada = validar.validarEntero($"Ingrese la Cilindrada que modificará la actual -{mot.pCilindrada}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificada correctamente.");
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
            }
            foreach (Camion cam in _listaCamionesDisponibles)
            {
                if (cam.pPatente.ToLower() == patente.ToLower())
                {
                    string[] menumodif = { "Patente", "Kilometros", "Año", "Marca", "Modelo", "Combustible", 
                        "Precio", "Observaciones", "Color", "Caja de carga", "Dimensiones de caja", "Carga maxima"};
                    int indexmodif = 0;
                    ConsoleKeyInfo opcmodif;
                    Console.Clear();
                    Console.WriteLine("Ingrese el dato que desea modificar.");
                    Console.WriteLine("nota: No es posible cambiar el segmento ya que sólo disponemos de un tipo en la categoría.\n");

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
                                    cam.pPatente = validar.validarStr($"Ingrese la PATENTE que modificará la actual -{cam.pPatente}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificada correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Kilometros")
                                {
                                    Console.Clear();
                                    cam.pKilometros = validar.validarDoble($"Ingrese el Kilometraje que modificará el actual -{cam.pKilometros}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificados correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Año")
                                {
                                    Console.Clear();
                                    cam.pAnio = validar.validarEntero($"Ingrese el AÑO que modificará el actual -{cam.pAnio}-: ");
                                    
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Marca")
                                {
                                    string[] arrayMarcas;
                                    Console.Clear();

                                    arrayMarcas = this._listaMarcas.Select(seg => seg.pMarca).ToArray();
                                    cam.pId_marca = MenuReutilizable(arrayMarcas, $"Ingrese la MARCA que modficará la actual -{cam.pId_marca}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Modelo")
                                {
                                    Console.Clear();
                                    cam.pModelo = validar.validarStr($"Ingrese el MODELO que modificará el actual -{cam.pModelo}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Combustible")
                                {
                                    string[] arrayCombustibles;
                                    Console.Clear();

                                    arrayCombustibles = this._listaCombustibles.Select(seg => seg.pCombustible).ToArray();
                                    cam.pId_combustible = MenuReutilizable(arrayCombustibles, $"Seleccione el COMBUSTIBLE que modificará el actual -{cam.pId_combustible}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Precio")
                                {
                                    Console.Clear();
                                    cam.pPrecio_vta = validar.validarDoble($"Ingrese el PRECIO que modificará el actual -{cam.pPrecio_vta}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Observaciones")
                                {
                                    Console.Clear();
                                    Console.Write($"Ingrese la Observacion que modificará la actual -{cam.pObservaciones}-: ");
                                    string input = Console.ReadLine();
                                    cam.pObservaciones = string.IsNullOrEmpty(input) ? "Sin observaciones" : input;

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificadas correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Color")
                                {
                                    Console.Clear();
                                    cam.pColor = validar.validarStr($"Ingrese el COLOR que modificará el actual -{cam.pColor}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");

                                }
                                else if (menumodif[indexmodif] == "Caja de carga")
                                {
                                    Console.Clear();
                                    cam.pCaja_Carga = !cam.pCaja_Carga;

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Dimensiones de caja")
                                {
                                    int largomodif, anchomnodif;
                                    Console.Clear();
                                    Console.WriteLine($"Ingrese los datos que modificará la Dimension actual -{cam.pDimension_caja}-: ");
                                    largomodif = validar.validarEntero($"\nIngrese el LARGO de la caja: ");
                                    anchomnodif = validar.validarEntero($"\nIngrese el ANCHO de la caja: ");
                                    cam.pDimension_caja = largomodif * anchomnodif;

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificada correctamente.");
                                }

                                else if (menumodif[indexmodif] == "Carga maxima")
                                {
                                    Console.Clear();
                                    cam.pCarga_max = validar.validarEntero($"Ingrese la CARGA MAX. que modificará la actual -{cam.pCarga_max}-: ");

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificada correctamente.");
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

                
            }
            if (flag == 1)
            {
                Console.Clear();
                Console.Write($"La PATENTE -{patente}- no existe en la lista de Vehiculos. Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void BuscarVehiculo()
        {
            CargarAutosCamionetas();
            CargarMotos();
            CargarCamiones();

            var listaVehiculos = GetVehiculos().ToList();

            var opciones = listaVehiculos.Select(v => v.pPatente).ToArray();

            int selectedIndex = MenuReutilizable(opciones, "Seleccione un vehículo por su patente:") - 1;

            string selectedPatente = opciones[selectedIndex];
            var selectedVehiculo = listaVehiculos.FirstOrDefault(v => v.pPatente == selectedPatente);

            if (selectedVehiculo != null)
            {
                selectedVehiculo.MostrarDatos();
            }
            else
            {
                Console.WriteLine("Vehículo no encontrado.");
            }

            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadKey();
        }

        public void BorrarVehiculo()
        {
            CargarAutosCamionetas();
            CargarCamiones();
            CargarMotos();

            int flag = 0, i, j, k;
            string patente;

            patente = validar.validarStr("\nIngrese la PATENTE del vehículo a eliminar: "); // Patente.
            for (i = _listaAutoCamionetasDisponibles.Count() - 1; i >= 0; i--)
            {
                if (_listaAutoCamionetasDisponibles[i].pPatente.ToLower() == patente.ToLower())
                {
                    _listaAutoCamionetasDisponibles.RemoveAt(i);
                    _listaAutoCamionetas.RemoveAt(i);
                    flag = 1;
                }

            }
            for (j = _listaMotosDisponibles.Count() - 1; j >= 0; j--)
            {
                if (_listaMotosDisponibles[j].pPatente.ToLower() == patente.ToLower())
                {
                    _listaMotosDisponibles.RemoveAt(j);
                    _listaMotos.RemoveAt(j);
                    flag = 1;
                }

            }
            for (k = _listaCamionesDisponibles.Count() - 1; k >= 0; k--)
            {


                if (_listaCamionesDisponibles[k].pPatente.ToLower() == patente.ToLower())
                {
                    _listaCamionesDisponibles.RemoveAt(k);
                    _listaCamiones.RemoveAt(k);
                    flag = 1;
                }
            }

            if (flag == 0)
            {
                Console.Write($"La PATENTE -{patente}- no existe en la lista de Vehiculos");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"\n\tEl vehiculo con la PATENTE -{patente}- fue eliminado.");
                Console.ResetColor();
                Console.Write("\n\tPresione una tecla para continuar.");
                Console.ReadKey();
            }
        }

        // VENTAS

        public void CargarVenta()
        {
            CargarAutosCamionetas();
            CargarCamiones();
            CargarMotos();
            CargarClientes();
            CargarVentas();

            string[] arrayClientes, arrayTipos = { "Auto/Camioneta", "Moto", "Camión" }, arrayVehiculos;
            string mensaje;
            int id_venta, id_cliente = 0, id_vehiculo = 0, iva, descuento, opc;
            DateTime fecha_compra, fecha_entrega;
            double subtotal = 0;

            Console.WriteLine("****CARGA DE VENTA****\n");

            List<int> idsExistentes = this._listaVentas.Select(ven => ven.pId_venta).ToList();
            id_venta = idsExistentes.Count > 0 ? idsExistentes.Max() + 1 : 1;

            arrayClientes = this._listaClientes.Select(cli => cli.pCliente).ToArray();
            mensaje = "Seleccione el cliente de la venta a registrar";
            id_cliente = MenuReutilizable(arrayClientes, mensaje);

            mensaje = "Seleccione el tipo de vehículo que desea vender";
            opc = MenuReutilizable(arrayTipos, mensaje);

            switch (opc) // Mostrar patentes por tipo vehículo, seleccionar id y subtotal
            {
                case 1: // Auto/Camioneta
                    arrayVehiculos = this._listaAutoCamionetasDisponibles.Select(autcam => autcam.pPatente).ToArray();
                    mensaje = "Ingrese la matrícula del auto o camioneta a vender";
                    id_vehiculo = ObtenerIdPorPatente(arrayVehiculos, mensaje, this._listaAutoCamionetasDisponibles);
                    subtotal = this._listaAutoCamionetasDisponibles.First(autcam => autcam.pId_vehiculo == id_vehiculo).pPrecio_vta;
                    break;

                case 2: // Moto
                    arrayVehiculos = this._listaMotosDisponibles.Select(m => m.pPatente).ToArray();
                    mensaje = "Ingrese la matrícula de la moto a vender";
                    id_vehiculo = ObtenerIdPorPatente(arrayVehiculos, mensaje, this._listaMotosDisponibles);
                    subtotal = this._listaMotosDisponibles.First(m => m.pId_vehiculo == id_vehiculo).pPrecio_vta;
                    break;

                case 3: // Camión
                    arrayVehiculos = this._listaCamionesDisponibles.Select(c => c.pPatente).ToArray();
                    mensaje = "Ingrese la matrícula del camión a vender";
                    id_vehiculo = ObtenerIdPorPatente(arrayVehiculos, mensaje, this._listaCamionesDisponibles);
                    subtotal = this._listaCamionesDisponibles.First(c => c.pId_vehiculo == id_vehiculo).pPrecio_vta;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Cancelando venta.");
                    return;
            }

            foreach (var ac in this._listaAutoCamionetas.Where(ac => ac.pId_vehiculo == id_vehiculo))
            {
                ac.pEstado = true;
            }
            foreach (var moto in this._listaMotos.Where(m => m.pId_vehiculo == id_vehiculo))
            {
                moto.pEstado = true;
            }
            foreach (var camion in this._listaCamiones.Where(c => c.pId_vehiculo == id_vehiculo))
            {
                camion.pEstado = true;
            } // Marcar como vendido

            fecha_compra = validar.validarFecha("\nIngrese la FECHA DE COMPRA del vehiculo (dd/mm/aaaa): ");
            fecha_entrega = validar.validarFecha("\nIngrese la FECHA DE ENTREGA del vehiculo (dd/mm/aaaa): ");
            iva = validar.validarEntero("\nIngrese el % de IVA: ");
            descuento = validar.validarEntero("\nIngrese el % de DESCUENTO: ");

            Venta venta = new Venta(id_venta, id_cliente, id_vehiculo, fecha_compra, fecha_entrega, subtotal, iva, descuento);
            _listaVentas.Add(venta);
        }

        private int ObtenerIdPorPatente(string[] arrayVehiculos, string mensaje, IEnumerable<dynamic> listaVehiculos)
        {
            int idVehiculo = 0;
            bool patenteValida = false;

            do
            {
                int vehiculoSeleccionado = MenuReutilizable(arrayVehiculos, mensaje);
                string patenteSeleccionada = arrayVehiculos[vehiculoSeleccionado];

                var vehiculo = listaVehiculos.FirstOrDefault(v => v.pPatente == patenteSeleccionada);

                if (vehiculo != null)
                {
                    idVehiculo = vehiculo.pId_vehiculo;
                    patenteValida = true;
                }
                else
                {
                    Console.WriteLine("Error. La matrícula ingresada no es válida. Presione una tecla para continuar.");
                    Console.ReadKey();
                }
            } while (!patenteValida);
            return idVehiculo;
        }

        public void ModificarVenta()
        {
            string[] placasVentas = _listaVentas
                .Select(ven => GetVehiculos().FirstOrDefault(v => v.pId_vehiculo == ven.pId_vehiculo)?.pPatente)
                .Where(placa => placa != null).ToArray();

            if (placasVentas.Length == 0)
            {
                Console.WriteLine("No hay ventas registradas para modificar.");
                return;
            }

            int indiceSeleccionado = MenuReutilizable(placasVentas, "Seleccione el vehículo por su matrícula: ");
            string placaSeleccionada = placasVentas[indiceSeleccionado];

            Venta ventaSeleccionada = _listaVentas.FirstOrDefault(ven =>
                GetVehiculos().Any(v => v.pPatente == placaSeleccionada && v.pId_vehiculo == ven.pId_vehiculo));

            if (ventaSeleccionada == null)
            {
                Console.WriteLine($"No se encontró una venta asociada con la matrícula {placaSeleccionada}.");
                return;
            }

            string[] menumodif = { "Cliente", "Vehiculo", "Fecha de compra", "Fecha de entrega", "IVA", "Descuento" };
            int indexmodif = 0;
            ConsoleKeyInfo opcmodif;

            do
            {
                Console.Clear();
                Console.WriteLine("Seleccione el dato que desea modificar:\n");

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
                        indexmodif = (indexmodif > 0) ? indexmodif - 1 : menumodif.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        indexmodif = (indexmodif < menumodif.Length - 1) ? indexmodif + 1 : 0;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (menumodif[indexmodif])
                        {
                            case "Cliente":
                                ventaSeleccionada.pId_cliente = validar.validarEntero($"Ingrese el nuevo ID de cliente (actual: {ventaSeleccionada.pId_cliente}): ");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\nCliente modificado correctamente.");
                                break;

                            case "Vehiculo":
                                string[] placas = GetVehiculos().Select(v => v.pPatente).ToArray();

                                int nuevoVehiculoIndex = MenuReutilizable(placas, "Seleccione el nuevo vehículo por matrícula:");
                                string nuevaPlacaSeleccionada = placas[nuevoVehiculoIndex];

                                var nuevoVehiculo = GetVehiculos().FirstOrDefault(v => v.pPatente == nuevaPlacaSeleccionada);

                                if (nuevoVehiculo != null)
                                {
                                    ventaSeleccionada.pId_vehiculo = nuevoVehiculo.pId_vehiculo;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\nVehículo modificado correctamente.");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nError al seleccionar el vehículo.");
                                }
                                break;

                            case "Fecha de compra":
                                ventaSeleccionada.pFecha_compra = validar.validarFecha($"Ingrese la nueva fecha de compra (actual: {ventaSeleccionada.pFecha_compra}): ");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\nFecha de compra modificada correctamente.");
                                break;

                            case "Fecha de entrega":
                                ventaSeleccionada.pFecha_entrega = validar.validarFecha($"Ingrese la nueva fecha de entrega (actual: {ventaSeleccionada.pFecha_entrega}): ");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\nFecha de entrega modificada correctamente.");
                                break;

                            case "IVA":
                                ventaSeleccionada.pIva = validar.validarEntero($"Ingrese el nuevo porcentaje de IVA (actual: {ventaSeleccionada.pIva}%): ");
                                Console.WriteLine($"\nNuevo total calculado: {ventaSeleccionada.pTotal}");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\nIVA modificado correctamente.");
                                break;

                            case "Descuento":
                                ventaSeleccionada.pDescuento = validar.validarEntero($"Ingrese el nuevo porcentaje de descuento (actual: {ventaSeleccionada.pDescuento}%): ");
                                Console.WriteLine($"\nNuevo total calculado: {ventaSeleccionada.pTotal}");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\nDescuento modificado correctamente.");
                                break;
                        }

                        Console.ResetColor();
                        Console.WriteLine("\nPresione cualquier tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            } while (opcmodif.Key != ConsoleKey.Escape);
        }

        public void BorrarVenta()
        {
            CargarVentas();
            int id, flag = 0;

            id = validar.validarEntero("Ingrese el ID de la VENTA a eliminar: ");
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

            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"\n\tLa venta con el ID -{id}- fue eliminada.");
                Console.ResetColor();
                Console.Write("\n\tPresione una tecla para continuar.");
                Console.ReadKey();
            }
        }

        public void ListarVentas()
        {
            CargarVentas();
            CargarClientes();

            if (_listaVentas.Count == 0)
            {
                Console.WriteLine("No hay ventas registradas.");
            }
            else
            {
                foreach (Venta venta in _listaVentas)
                {
                    venta.mostrarVenta();
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        } // Falta arreglar

        public void BuscarVenta()
        {
            CargarClientes();
            CargarVentas();
            int idc;
            bool encontrado = false;

            foreach (Cliente c in this._listaClientes)
            {
                Console.WriteLine($"{c.pId_cliente} -> {c.pCliente}");
            }

            do
            {
                Console.Write("Ingrese el ID del cliente que desea ver sus ventas: ");
                while (!int.TryParse(Console.ReadLine(), out idc))
                {
                    Console.Write("El ID ingresado no corresponde a un cliente.\nIngrese un nuevo ID: ");
                }

                Console.WriteLine($"Las ventas realizadas al cliente {idc} son: ");

                foreach (Venta v in this._listaVentas)
                {
                    if (v.pId_cliente == idc)
                    {
                        var vehiculo = GetVehiculos().FirstOrDefault(veh => veh.pId_vehiculo == v.pId_vehiculo);
                        string placa = vehiculo != null ? vehiculo.pPatente : "Sin asignar";

                        Console.WriteLine($"Venta ID: {v.pId_venta} - Vehículo: {placa} - Fecha de compra: {v.pFecha_compra} - Fecha de entrega: {v.pFecha_entrega} - Total: {v.pTotal}");
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
        } // Falta arreglar



        // CLIENTE

        public void CargarCliente()
        {
            CargarClientes();
            CargarLocalidades();
            CargarProvincias();
            string[] arrayLocalidades;
            int id_cliente, id_localidad;
            string cliente, correo, domicilio;
            long telefono, cuit;

            Console.WriteLine("****CARGA DE CLIENTE****\n\n");

            List<int> idsExistentes = this._listaClientes.Select(cli => cli.pId_cliente).ToList();
            id_cliente = idsExistentes.Count > 0 ? idsExistentes.Max() + 1 : 1;

            cliente = validar.validarStr("\nIngrese el nombre o la Razón Social: ");

            cuit = ValidarCuitUnico();

            domicilio = validar.validarStr("\nIngrese el Domicilio: ");

            arrayLocalidades = this._listaLocalidades.Select(loc => loc.pLocalidad).ToArray();
            id_localidad = MenuReutilizable(arrayLocalidades, "Seleccione la localidad del cliente");

            telefono = validar.validarLong("\nIngrese el TELÉFONO del cliente: ");

            correo = validar.validarStr("\nIngrese el Correo: ");

            Cliente cl = new Cliente(id_cliente, cliente, cuit, domicilio, id_localidad, telefono, correo);
            _listaClientes.Add(cl);
        }

        public void ModificarCliente()
        {
            CargarClientes();
            int id, opc;
            string[] arrayClientes, arrayLocalidades, arrayOpciones = { "Sí", "No" };
            bool flag = false;

            while (_listaClientes.Count() != 0)
            {
                flag = true;
                arrayClientes = this._listaClientes.Select(cli => cli.pCliente).ToArray();
                id = MenuReutilizable(arrayClientes, "Seleccione el cliente a modificar: ");

                foreach (Cliente cl in this._listaClientes)
                {
                    if (cl.pId_cliente == id)
                    {
                        string[] menumodif = { "Nombre o Razón social", "CUIT", "Domicilio", "Localidad",
                "Teléfono", "Correo"};
                        int indexmodif = 0;
                        ConsoleKeyInfo opcmodif;
                        Console.Clear();
                        Console.WriteLine("Seleccione el dato que desea modificar\n");
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
                                    if (menumodif[indexmodif] == "Nombre o Razón social")
                                    {
                                        Console.Clear();
                                        cl.pCliente = validar.validarStr($"Ingrese el nombre la razón social que modificará la actual -{cl.pCliente}-: ");

                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "CUIT")
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"El CUIT actual del cliente -{cl.pCuit}- será modificado:");
                                        cl.pCuit = ValidarCuitUnico();

                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Domicilio")
                                    {
                                        Console.Clear();
                                        cl.pDomicilio = validar.validarStr($"Ingrese la dirección que modificará la actual -{cl.pDomicilio}-: ");

                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Localidad")
                                    {
                                        Console.Clear();
                                        arrayLocalidades = this._listaLocalidades.Select(loc => loc.pLocalidad).ToArray();
                                        cl.pId_localidad = MenuReutilizable(arrayLocalidades, $"Seleccione la localidad del cliente ");

                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificada correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Teléfono")
                                    {
                                        Console.Clear();
                                        cl.pTelefono = validar.validarLong($"Ingrese el teléfono que modificará el actual -{cl.pTelefono}-: ");

                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
                                    }

                                    else if (menumodif[indexmodif] == "Correo")
                                    {
                                        Console.Clear();
                                        cl.pCorreo = validar.validarStr($"Ingrese el correo que modificará el actual -{cl.pCorreo}-:");

                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"\n\n\t\t{menumodif[indexmodif]} modificado correctamente.");
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
            }

            if (!flag)
            {
                opc = MenuReutilizable(arrayOpciones, "No hay clientes registrados. ¿Desea registrar un cliente?");
                if (opc == 1)
                {
                    CargarCliente();
                }
                else
                {
                    Console.WriteLine("Saliendo.");
                }
            }
        }

        public void BorrarCliente()
        {
            CargarClientes();
            int id;
            string[] arrayClientes;

            arrayClientes = this._listaClientes.Select(cli => cli.pCliente).ToArray();
            id = MenuReutilizable(arrayClientes, "Seleccione el cliente a eliminar: ");

            for (int i = _listaClientes.Count() - 1; i >= 0; i--)
            {
                if (_listaClientes[i].pId_cliente == id)
                {
                    _listaClientes.RemoveAt(i);
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"\n\tEl cliente fue eliminado.");
            Console.ResetColor();
            Console.Write("\n\tPresione una tecla para continuar.");
            Console.ReadKey();
        }

        public void ListarClientes()
        {
            CargarClientes();
            CargarLocalidades();
            if (_listaClientes.Count() == 0)
            {
                Console.Write("No hay Clientes registrados.\n");
            }
            else
            {
                foreach (Cliente cliente in _listaClientes)
                {
                    cliente.mostrarCliente();
                }
            }
            
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void BuscarCliente()
        {
            CargarClientes();
            string[] arrayClientes;
            int id;

            arrayClientes = this._listaClientes.Select(cli => cli.pCliente).ToArray();
            id = MenuReutilizable(arrayClientes, "Seleccione el cliente a modificar: ");

                foreach (Cliente c in this._listaClientes)
                {
                    if (c.pId_cliente == id)
                    {
                        c.mostrarCliente();
                    }
                }
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadKey();
        }

        //MARCAS
   
        public void IngresarMarca()
        {
            CargarMarcas();
            int id_marca;
            string marca;

            Console.Write("****CARGA DE MARCA****\n\n");
            List<int> idsExistentes = this._listaClientes.Select(cli => cli.pId_cliente).ToList();
            id_marca = idsExistentes.Count > 0 ? idsExistentes.Max() + 1 : 1;
            marca = validar.validarStr("\nIngrese el NOMBRE de la MARCA: ");
            Marca marc = new Marca(id_marca, marca);
            _listaMarcas.Add(marc);
        }

        public void BorrarMarca()
        {
            CargarMarcas();
            int id;
            string[] arrayMarcas;

            arrayMarcas = this._listaMarcas.Select(m => m.pMarca).ToArray();
            id = MenuReutilizable(arrayMarcas, "Seleccione la marca a eliminar: ");

            for (int i = _listaMarcas.Count() - 1; i >= 0; i--)
            {
                if (_listaMarcas[i].pId_marca == id)
                {
                    _listaMarcas.RemoveAt(i);
                }
            }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"\n\tLa marca fue eliminada.");
                Console.ResetColor();
                Console.Write("\n\tPresione una tecla para continuar.");
                Console.ReadKey();
        }

        public void ListarMarcas()
        {
            CargarMarcas();
            if (_listaMarcas.Count() == 0)
            {
                Console.Write("No hay Marcas registradas.\n");
            }
            else
            {
                foreach (Marca marca in _listaMarcas)
                {
                    marca.mostrarMarca();
                }
            }
            
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public void ModificarMarca()
        {
            CargarMarcas();
            int id;
            string[] arrayMarcas;

            arrayMarcas = this._listaMarcas.Select(m => m.pMarca).ToArray();
            id = MenuReutilizable(arrayMarcas, "Seleccione la marca a modificar: ");
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
                                    Console.Write("Ingrese el nuevo ID de la MARCA: ");
                                    marca.pId_marca = validar.validarEntero(Console.ReadLine());
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    marca.pMarca = validar.validarStr($"Ingrese la nueva descripción de la MARCA (actual: {marca.pMarca}): ");
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
        }

        // LOCALIDADES
    
        public void CargarLocalidad()
        {
            CargarProvincias();
            CargarLocalidades();
            int id_localidad, id_provincia;
            string localidad;

            Console.Write("****CARGA DE LOCALIDAD****\n\n");
            Console.Write($"IDs NO disponibles:");
            foreach (Localidad l in this._listaLocalidades)
            {
                Console.Write($"{l.pId_localidad}, ");
            }

            id_localidad = validar.validarEntero("\nIngrese el ID de la LOCALIDAD: ");
            foreach (Localidad l in this._listaLocalidades)
            {
                if (l.pId_localidad == id_localidad)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    id_localidad = validar.validarEntero("\nIngrese el ID de la LOCALIDAD: ");
                }
            }

            localidad = validar.validarStr("\nIngrese el NOMBRE de la LOCALIDAD: ");

            Console.WriteLine("Ingrese el ID de la provincia.");
            foreach (Provincia prov in this._listaProvincias)
            {
                Console.Write($"ID: {prov.pId_provincia} -> {prov.pProvincia}");
            }

            id_provincia = validar.validarEntero("\nIngrese el ID de la PROVINCIA");

            Localidad loc = new Localidad(id_localidad, localidad, id_provincia);
            _listaLocalidades.Add(loc);
        }

        public void ModificarLocalidad()
        {
            CargarLocalidades();
            CargarProvincias();
            int id;

            Console.WriteLine($"Lista de localidades");
            foreach (Localidad l in this._listaLocalidades)
            {
                Console.WriteLine($"{l.pId_localidad} -> {l.pLocalidad} ");
            }
            Console.Write("\n\n");

            id = validar.validarEntero("Ingrese el ID de la LOCALIDAD a modificar: ");
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
                                    localidad.pId_localidad = validar.validarEntero($"Ingrese el nuevo ID de la LOCALIDAD (actual: {localidad.pId_localidad}: ");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    localidad.pLocalidad = validar.validarStr($"Ingrese la nueva descripción de la LOCALIDAD (actual: {localidad.pLocalidad}): ");
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

            Console.WriteLine($"Lista de localidades");
            foreach (Localidad l in this._listaLocalidades)
            {
                Console.WriteLine($"{l.pId_localidad} -> {l.pLocalidad} ");
            }
            Console.Write("\n\n");

            id = validar.validarEntero("Ingrese el ID de la LOCALIDAD a eliminar: ");
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
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"\n\tLa localidad con el ID -{id}- fue eliminada.");
                Console.ResetColor();
                Console.Write("\n\tPresione una tecla para continuar.");
                Console.ReadKey();
            }
        }

        public void ListarLocalidades()
        {
            CargarProvincias();
            CargarLocalidades();
            if (_listaLocalidades.Count() == 0)
            {
                Console.Write("No hay Localidades registradas.\n");
            }
            else
            {
                foreach (Localidad loc in _listaLocalidades)
                {
                    loc.mostrarLocalidad();
                }
            }
            
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        // PROVINCIAS
    
        public void CargarProvincia()
        {
            CargarProvincias();
            int id_provincia;
            string provincia;

            List<int> idsExistentes = this._listaProvincias.Select(p => p.pId_provincia).ToList();
            id_provincia = idsExistentes.Count > 0 ? idsExistentes.Max() + 1 : 1;
            provincia = validar.validarStr("\nIngrese el NOMBRE de la PROVINCIA: ");

            Provincia prov = new Provincia(id_provincia, provincia);
            _listaProvincias.Add(prov);
        }

        public void ModificarProvincia()
        {
            CargarProvincias();
            int id;
            string[] arrayProvincias;

            arrayProvincias = this._listaProvincias.Select(p => p.pProvincia).ToArray();
            id = MenuReutilizable(arrayProvincias, "Seleccione la provincia a modificar: ");

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
                                    Console.Write("Ingrese el nuevo ID de la PROVINCIA: ");
                                    provincia.pId_provincia = validar.validarEntero(Console.ReadLine());

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificado correctamente.");
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
        }

        public void BorrarProvincia()
        {
            CargarProvincias();
            int id;
            string[] arrayProvincias;

            arrayProvincias = this._listaProvincias.Select(p => p.pProvincia).ToArray();
            id = MenuReutilizable(arrayProvincias, "Seleccione la provincia a eliminar: ");

            for (int i = _listaProvincias.Count() - 1; i >= 0; i--)
            {
                if (_listaProvincias[i].pId_provincia == id)
                {
                    _listaProvincias.RemoveAt(i);
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"\n\tLa Provincia fue eliminada.");
            Console.ResetColor();
            Console.Write("\n\tPresione una tecla para continuar.");
            Console.ReadKey();
        }

        public void ListarProvincias()
        {
            CargarProvincias();
            CargarLocalidades();
            if (_listaProvincias.Count() == 0)
            {
                Console.Write("No hay Provincias registradas.\n");
            }
            else
            {
                foreach (Provincia prov in _listaProvincias)
                {
                    prov.mostrarProvincia();
                }
            }
            
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        // COMBUSTIBLES

        public void IngresarNuevoCombustible()
        {
            CargarCombustibles();
            int id_combustible;
            string combustible;

            Console.Write("****CARGA DE COMBUSTIBLE****\n\n");
            Console.Write($"IDs NO disponibles:");
            foreach (Combustible cb in this._listaCombustibles)
            {
                Console.Write($"{cb.pIdCombustible}, ");
            }

            id_combustible = validar.validarEntero("\nIngrese el ID del COMBUSTIBLE: ");
            foreach (Combustible c in this._listaCombustibles)
            {
                if (c.pIdCombustible == id_combustible)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    id_combustible = validar.validarEntero("\nIngrese el ID del COMBUSTIBLE: ");
                }
            }

            combustible = validar.validarStr("\nIngrese el NOMBRE del COMBUSTIBLE: ");

            Combustible comb = new Combustible(id_combustible, combustible);
            _listaCombustibles.Add(comb);
        }

        public void ModificarCombustible()
        {
            CargarCombustibles();
            int id;

            Console.WriteLine($"Lista de combustibles");
            foreach (Combustible c in this._listaCombustibles)
            {
                Console.WriteLine($"{c.pIdCombustible} -> {c.pCombustible} ");
            }
            Console.Write("\n\n");

            id = validar.validarEntero("Ingrese el ID del combustible a eliminar: ");
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
                                    Console.Write("Ingrese el nuevo ID del COMBUSTIBLE: ");                                    
                                    combustible.pIdCombustible = validar.validarEntero(Console.ReadLine());
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    combustible.pCombustible = validar.validarStr($"Ingrese la nueva descripción del COMBUSTIBLE (actual: {combustible.pCombustible}): ");
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

        public void BorrarCombustible()
        {
            CargarCombustibles();
            int id, flag=0;

            Console.WriteLine($"Lista de combustibles");
            foreach (Combustible c in this._listaCombustibles)
            {
                Console.WriteLine($"{c.pIdCombustible} -> {c.pCombustible} ");
            }
            Console.Write("\n\n");

            id = validar.validarEntero("Ingrese el ID del combustible a eliminar: ");
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
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"\n\tEl combustible con el ID -{id}- fue eliminado.");
                Console.ResetColor();
                Console.Write("\n\tPresione una tecla para continuar.");
                Console.ReadKey();
            }
        }

        public void ListarCombustibles()
        {
            CargarCombustibles();
            if (_listaCombustibles.Count() == 0)
            {
                Console.Write("No hay Combustibles registrados.\n");
            }
            else
            {
                foreach (Combustible comb in _listaCombustibles)
                {
                    comb.mostrarCombustible();
                }
            }
            
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        // SEGMENTOS
    
        public void CargarSegmento()
        {
            int id_segmento;
            string segmento;

            Console.Write("****CARGA DE SEGMENTO****\n\n");
            Console.Write($"IDs NO disponibles:");
            foreach (Segmento s in this._listaSegmentos)
            {
                Console.Write($"{s.pIdSegmento}, ");
            }

            id_segmento = validar.validarEntero("\nIngrese el ID del SEGMENTO: ");
            foreach (Segmento s in this._listaSegmentos)
            {
                if (s.pIdSegmento == id_segmento)
                {
                    Console.WriteLine("Error. El ID ingresado ya existe. Presione una tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    id_segmento = validar.validarEntero("\nIngrese el ID del SEGMENTO: ");
                }
            }

            segmento = validar.validarStr("\nIngrese el NOMBRE del SEGMENTO: ");

            Segmento seg = new Segmento(id_segmento, segmento);
            _listaSegmentos.Add(seg);
        }

        public void ModificarSegmento()
        {
            CargarSegmentos();
            int id;

            Console.WriteLine($"Lista de segmentos");
            foreach (Segmento s in this._listaSegmentos)
            {
                Console.WriteLine($"{s.pIdSegmento} -> {s.pSegmento} ");
            }
            Console.Write("\n\n");

            id = validar.validarEntero("Ingrese el ID del segmento a modificar: ");
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
                                    segmento.pIdSegmento = validar.validarEntero("Ingrese el nuevo ID del SEGMENTO: ");                                    
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("\n\n\t\tID modificada correctamente.");
                                }
                                else if (opcionesModif[indexmodif] == "Descripción")
                                {
                                    segmento.pSegmento = validar.validarStr($"Ingrese la nueva descripción del SEGMENTO (actual: {segmento.pSegmento}): ");
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

        public void BorrarSegmento()
        {
            CargarSegmentos();
            int id, flag=0;

            Console.WriteLine($"Lista de segmentos");
            foreach (Segmento s in this._listaSegmentos)
            {
                Console.WriteLine($"{s.pIdSegmento} -> {s.pSegmento} ");
            }
            Console.Write("\n\n");

            id = validar.validarEntero("Ingrese el ID del segmento a borrar: ");
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
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"\n\tEl Segmento con el ID -{id}- fue eliminado.");
                Console.ResetColor();
                Console.Write("\n\tPresione una tecla para continuar.");
                Console.ReadKey();
            }
        }

        public void ListarSegmentos()
        {
            CargarSegmentos();
            if (_listaSegmentos.Count() == 0)
            {
                Console.Write("No hay Segmentos registrados.\n");
            }
            else
            {
                foreach (Segmento seg in _listaSegmentos)
                {
                    seg.mostrarSegmento();
                }
            }
            
            Console.Write("\n\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        // VALIDACIONES

        public bool IsPatenteUnique (string patente)
        {
            //asegura que la patente sea unica
            foreach (AutoCamioneta acam in _listaAutoCamionetas)
            {
                if (acam.pPatente == patente)
                {
                    return false;
                }
            }

            foreach (Moto moto in _listaMotos)
            {
                if (moto.pPatente == patente)
                {
                    return false;
                }
            }

            foreach (Camion camion in _listaCamiones)
            {
                if (camion.pPatente == patente)
                {
                    return false;
                }
            }           
            return true;
        }

        public string getCombustible(int id)
        {
            CargarCombustibles();
            for (int i = 0; i < this._listaCombustibles.Count() ; i++)
            {

                if (id == this._listaCombustibles[i].pIdCombustible)
                {
                    return this._listaCombustibles[i].pCombustible;
                }
            }
            return "No encontrado";
        }

        public string getSegmento(int id)
        {
            CargarSegmentos();
            for (int i = 0; i < this._listaSegmentos.Count(); i++)
            {

                if (id == this._listaSegmentos[i].pIdSegmento)
                {
                    
                    return this._listaSegmentos[i].pSegmento;
                }
            }
            return "No encontrado";
        }

        public string getLocalidad(int id)
        {
            CargarLocalidades();
            for (int i = 0; i < this._listaLocalidades.Count(); i++)
            {

                if (id == this._listaLocalidades[i].pId_localidad)
                {
                    return this._listaLocalidades[i].pLocalidad;
                }
            }
            return "No encontrado";
        }

        public string getProvincia(int id)
        {
            CargarProvincias();
            for (int i = 0; i < this._listaProvincias.Count(); i++)
            {

                if (id == this._listaProvincias[i].pId_provincia)
                {
                    return this._listaProvincias[i].pProvincia;
                }
            }
            return "No encontrado";


        }

        public string getMarca(int id)
        {
            CargarMarcas();
            for (int i = 0; i < this._listaMarcas.Count(); i++)
            {
                if (id == this._listaMarcas[i].pId_marca)
                {
                    return this._listaMarcas[i].pMarca;
                }
            }
            return "No encontrado";
        }

        public string getCliente(int id)
        {
            CargarClientes();
            for (int i = 0; i < this._listaClientes.Count(); i++)
            {
                if (id == this._listaClientes[i].pId_cliente)
                {
                    return this._listaClientes[i].pCliente;
                }
            }
            return "No encontrado";
        }

        public int MenuReutilizable(string[] opciones, string mensaje)
        {
            int posicionActual = 0;
            bool seleccionRealizada = false;
            Console.CursorVisible = false;

            while (!seleccionRealizada)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine(mensaje);
                Console.WriteLine("Seleccione una opción con las flechas \u2191 y \u2193, y presione Enter:");
                Console.WriteLine("-----------------------------------------------------");

                for (int i = 0; i < opciones.Length; i++)
                {
                    if (i == posicionActual)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (char)62 + " ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }

                    Console.WriteLine(opciones[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.UpArrow:
                        posicionActual = (posicionActual == 0) ? opciones.Length - 1 : posicionActual - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = (posicionActual == opciones.Length - 1) ? 0 : posicionActual + 1;
                        break;

                    case ConsoleKey.Enter:
                        seleccionRealizada = true;
                        break;

                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }

            Console.CursorVisible = true;
            return posicionActual+1;
        }

        public IEnumerable<Vehiculo> GetVehiculos()
        {
            return _listaAutoCamionetas.Cast<Vehiculo>()
                .Concat(_listaMotos)
                .Concat(_listaCamiones);
        }

        public long ValidarCuitUnico()
        {
            long cuit;
            bool esUnico;

            do
            {
                cuit = validar.validarCuit();
                esUnico = true;

                foreach (Cliente cli in _listaClientes)
                {
                    if (cli.pCuit == cuit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nEl CUIT ingresado ya está registrado. Reintente.");
                        Console.ResetColor();
                        esUnico = false;
                        break;
                    }
                }
            }
            while (!esUnico);

            return cuit;
        }


        // BUSCAR PARÁMETROS NO USADOS

        /*public void BuscarMarca()
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
}*/

        /*public void BuscarLocalidad()
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
}*/

        /*public void BuscarProvincia()
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
        }*/

        /*public void BuscarCombustible()
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
}*/

        /*public void BuscarSegmento()
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
}*/

        /*public void CargarVehiculos(string nombreArchivo)
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
}*/

        /* private bool IsIdValid(int id_vehiculo)
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
        } */
    }
}

