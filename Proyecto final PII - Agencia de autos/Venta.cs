using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Venta
    {
        private int id_cliente, id_vehiculo;
        private DateTime fecha_compra, fecha_entrega;
        private double subtotal;
        private int iva;
        private int descuento;
        private double total;


        public Venta(int id_cliente, int id_vehiculo, DateTime fecha_compra, DateTime fecha_entrega,
            double subtotal, int iva, int descuento, double total)
        {
            this.pId_cliente = id_cliente;
            this.pId_vehiculo = id_vehiculo;
            this.pFecha_compra = fecha_compra;
            this.pFecha_entrega = fecha_entrega;
            this.pSubtotal = subtotal;
            this.pId_vehiculo = iva;
            this.pDescuento = descuento;
            this.pTotal = total;
        }
        public Venta()
        {
            this.pId_cliente = 0;
            this.pId_vehiculo = 0;
            this.pFecha_compra = new DateTime(01 / 01 / 2000);
            this.pFecha_entrega = new DateTime(01 / 01 / 2000);
            this.pSubtotal = 0;
            this.pId_vehiculo = 0;
            this.pDescuento = 0;
            this.pTotal = 0;
        }
        //GETTERS Y SETTERS
        public int pId_cliente
        {
            get { return id_cliente; }
            set
            {
                id_cliente = value;
            }
        }
        public int pId_vehiculo
        {
            get { return id_vehiculo; }
            set
            {
                id_vehiculo = value;
            }
        }
        public DateTime pFecha_compra
        {
            get { return fecha_compra; }
            set
            {
                fecha_compra = value;
            }
        }
        public DateTime pFecha_entrega
        {
            get
            {
                return fecha_entrega;
            }
            set
            {
                fecha_entrega = value;
            }
        }
        public double pSubtotal
        {
            get
            {
                return subtotal;

            }
            set
            {
                subtotal = value;
            }
        }
        public int pIva
        {
            get
            {
                return iva;
            }
            set
            {
                iva = value;
            }
        }
        public int pDescuento
        {
            get
            {
                return descuento;

            }
            set
            {
                descuento = value;
            }
        }
        public double pTotal
        {
            get { return total; }
            set
            {
                total = value;
            }
        }
    }
}
