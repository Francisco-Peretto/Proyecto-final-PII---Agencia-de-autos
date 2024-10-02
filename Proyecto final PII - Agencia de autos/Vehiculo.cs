using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Vehiculo
    {   
        private int id_vehiculo, id_marca, id_segmento, id_combustible;
        private string patente;
        private double kilometros;
        private int anio;
        private string modelo;
        private double precio_vta;
        private string observaciones;
        private string color;

        public Vehiculo(int id_vehiculo, string patente, double kilometros, int anio, int id_marca,
            string modelo, int id_segmento, int id_combustible, double precio_vta, string observaciones,
            string color)
        {
            this.pId_vehiculo = id_vehiculo;
            this.pPatente = patente;
            this.pKilometros = kilometros;
            this.pAnio = anio;
            this.pId_marca = id_marca;
            this.pModelo = modelo;
            this.pId_segmento = id_segmento;
            this.pId_combustible = id_combustible;
            this.pPrecio_vta = precio_vta;
            this.pObservaciones = observaciones;
            this.pColor = color;
        }
        public Vehiculo()
        {
            this.pId_vehiculo = 0;
            this.pPatente = "";
            this.pKilometros = 0;
            this.pAnio = 0;
            this.pId_marca = 0;
            this.pModelo = "";
            this.pId_segmento = 0;
            this.pId_combustible = 0;
            this.pPrecio_vta = 0;
            this.pObservaciones = "";
            this.pColor = "";
        }


        //GETTERS Y SETTERS
        public int pId_vehiculo
        {
            get
            {
                return id_vehiculo;
            }
            set
            {
                id_vehiculo = value;
            }
        }
        public int pId_marca
        {
            get
            {
                return id_marca;
            }
            set
            {
                id_marca = value;
            }
        }
        public int pId_segmento
        {
            get
            {
                return id_segmento;
            }
            set
            {
                id_segmento = value;
            }
        }
        public int pId_combustible
        {
            get
            {
                return id_combustible;
            }
            set
            {
                id_combustible = value;
            }
        }
        public string pPatente
        {
            get
            {
                return patente;
            }
            set
            {
                patente = value;
            }
        }
        public double pKilometros
        {
            get { return kilometros; }
            set
            {
                kilometros = value;
            }
        }
        public int pAnio
        {
            get { return anio; }
            set { anio = value; }
        }
        public string pModelo
        {
            get { return modelo; }
            set
            {
                modelo = value;
            }
        }
        public double pPrecio_vta
        {
            get { return precio_vta; }
            set
            {
                precio_vta = value;
            }
        }
        public string pObservaciones
        {
            get { return observaciones; }
            set
            {
                observaciones = value;
            }
        }
        public string pColor
        {
            get { return color; }
            set
            {
                color = value;
            }
        }
        public virtual string MostrarDatos() // Los IDS tienen que ser reemplazados por el nombre al mostrar
        {
            return $"ID Vehículo: {pId_vehiculo}\n" +
               $"Patente: {pPatente}\n" +
               $"Kilómetros: {pKilometros}\n" +
               $"Año: {pAnio}\n" +
               $"ID Marca: {pId_marca}\n" +
               $"Modelo: {pModelo}\n" +
               $"ID Segmento: {pId_segmento}\n" +
               $"ID Combustible: {pId_combustible}\n" +
               $"Precio de Venta: {pPrecio_vta}\n" +
               $"Observaciones: {pObservaciones}\n" +
               $"Color: {pColor}";
            Console.Write($"Id Vehículo: {this.pId_vehiculo} - Patente: {this.pPatente} - Kilómetros: {this.pKilometros} " +
                $"- Año: {this.pAnio} - Marca: {this.pId_marca} - modelo: {this.pModelo} " +
                $"- Segmento: {this.pId_segmento} - combustible: {this.pId_combustible} - Precio de venta: {this.pPrecio_vta} " +
                $"- Observaciones: {this.pObservaciones} - Color: {this.pColor} ");
        }
    }
}
