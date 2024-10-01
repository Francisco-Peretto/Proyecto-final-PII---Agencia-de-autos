using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Camion : Vehiculo
    {
        private int _caja_carga;
        private int _dimension_caja;
        private int _carga_max;

        public Camion(int id_vehiculo, string patente, double kilometros, int anio, int id_marca,
            string modelo, int id_segmento, int id_combustible, double precio_vta, string observaciones,
            string color, int caja_carga, int dimension_caja, int carga_max)
            : base(id_vehiculo, patente, kilometros, anio, id_marca, modelo, id_segmento, id_combustible,
                 precio_vta, observaciones, color)
        {
            this.Caja_Carga = carga_max;
            this.Dimension_caja = dimension_caja;
            this.Carga_max = carga_max;
        }
        public int Caja_Carga { get { return _caja_carga; } set { _caja_carga = value; } }

        public int Dimension_caja { get { return _dimension_caja; } set { _dimension_caja = value; } }

        public int Carga_max { get { return _carga_max; } set { _carga_max = value; } }

        public override void MostrarDatos()
        {
            base.MostrarDatos();
            Console.WriteLine($"Caja de carga: {this.Caja_Carga} - Dimensión de caja: {this.Dimension_caja} - Carga máxima: {this.Dimension_caja}");
        }
    }
}