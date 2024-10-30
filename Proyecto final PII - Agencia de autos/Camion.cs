using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Camion : Vehiculo
    {
        private bool _caja_carga;
        private int _dimension_caja;
        private int _carga_max;
        Concesionaria con = new Concesionaria();
        public Camion(int id_vehiculo, string patente, double kilometros, int anio, int id_marca,
            string modelo, int id_segmento,int id_combustible, double precio_vta, string observaciones,
            string color, bool _caja_carga, int _dimension_caja, int _carga_max, bool estado) : base(id_vehiculo, patente, kilometros, anio, id_marca, modelo, id_segmento, id_combustible,
                 precio_vta, observaciones, color, estado)
        {
            this.pCaja_Carga = _caja_carga;
            this.pDimension_caja = _dimension_caja;
            this.pCarga_max = _carga_max;
        }
        public Camion()
        {
            this.pCaja_Carga = true;
            this.pDimension_caja = 0;
            this.pCarga_max = 0;
        }


        public override void MostrarDatos()
        {

            Console.WriteLine($"\nId Vehículo: {this.pId_vehiculo} - Patente: {this.pPatente} - Kilómetros: {this.pKilometros} " +
                $"- Año: {this.pAnio} - Marca: {con.getMarca(this.pId_marca)} - Modelo: {this.pModelo} " +
                $"- Segmento: {con.getSegmento(this.pId_segmento)} - Caja de carga: {this.pCaja_Carga} - Dimensión de caja: {this.pDimension_caja} -" +
                $" Carga máxima: {this.pCarga_max} - combustible: {con.getCombustible(this.pId_combustible)} - Precio de venta: {this.pPrecio_vta} " +
                $"- Observaciones: {this.pObservaciones} - Color: {this.pColor}\n ");

        }
        //GETTERS Y SETTERS
        public bool pCaja_Carga { get { return _caja_carga; } set { _caja_carga = value; } }

        public int pDimension_caja { get { return _dimension_caja; } set { _dimension_caja = value; } }

        public int pCarga_max { get { return _carga_max; } set { _carga_max = value; } }
    }
}