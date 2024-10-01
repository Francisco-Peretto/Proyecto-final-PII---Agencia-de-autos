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
            this.Cilindrada = cilindrada;
        }

        public int Cilindrada {  get { return _cilindrada; } set { _cilindrada = value; } }

        public override void MostrarDatos()
        {
            base.MostrarDatos();
            Console.WriteLine($"Cilindrada: {this.Cilindrada}");
        }
    }
}
