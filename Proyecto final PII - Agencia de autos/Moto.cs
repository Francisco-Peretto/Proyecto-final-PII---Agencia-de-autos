using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Moto : Vehiculo
    {
        private int _cilindrada;

        public Moto(int id_vehiculo, string patente, double kilometros, int anio, int id_marca,
            string modelo, int id_segmento, int id_combustible, double precio_vta, string observaciones,
            string color, int cilindrada)
            : base(id_vehiculo, patente, kilometros, anio, id_marca, modelo, id_segmento, id_combustible,
                 precio_vta, observaciones, color)
        { 
            this.pCilindrada = cilindrada;
        }
        public Moto()     
        {
            this.pCilindrada = 0;
        }

        public int Cilindrada {  get { return _cilindrada; } set { _cilindrada = value; } }
        /*
        public override void MostrarDatos()
        {
            base.MostrarDatos();
            Console.WriteLine($"Cilindrada: {this.Cilindrada}");
        }
        */
        public override string MostrarDatos() // Los IDS tienen que ser reemplazados por el nombre al mostrar
        {
            return base.MostrarDatos() + $"\nCilindrada: {pCilindrada}";
            Console.Write($"Id Vehículo: {this.pId_vehiculo} - Patente: {this.pPatente} - Kilómetros: {this.pKilometros} " +
                $"- Año: {this.pAnio} - Marca: {this.pId_marca} - modelo: {this.pModelo} " +
                $"- Segmento: {this.pId_segmento} - Cilindrada: {this.pCilindrada} - combustible: {this.pId_combustible} - Precio de venta: {this.pPrecio_vta} " +
                $"- Observaciones: {this.pObservaciones} - Color: {this.pColor} ");
        }

        //GETTERS Y SETTERS
        public int pCilindrada
        {
            get { return _cilindrada; }
            set { _cilindrada = value; }
        }
    }
}
