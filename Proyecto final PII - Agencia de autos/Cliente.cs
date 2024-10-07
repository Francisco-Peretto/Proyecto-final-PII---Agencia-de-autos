using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Cliente
    {
        private int id_cliente, id_localidad;
        private string cliente;
        private long cuit;
        private string domicilio;
        private long telefono;
        private string correo;

        public Cliente(int id_cliente, string cliente, long cuit, string domicilio, int id_localidad,
            long telefono, string correo)
        {
            this.pId_cliente = id_cliente;
            this.pCliente = cliente;
            this.pCuit = cuit;
            this.pDomicilio = domicilio;
            this.pId_localidad = id_localidad;
            this.pTelefono = telefono;
            this.pCorreo = correo;
        }

        public Cliente()
        {
            this.pId_cliente = 0;
            this.pCliente = "";
            this.pCuit = 0;
            this.pDomicilio = "";
            this.pId_localidad = 0;
            this.pTelefono = 0;
            this.pCorreo = "";
        }

        public void mostrarCliente()
        {
            Console.Write($"ID Cliente:{this.pId_cliente} - Razon Social: {this.pCliente} - CUIT: {this.pCuit} - Domicilio: {this.pDomicilio} - " +
                $"ID Localidad: {this.pId_localidad} - Telefono: {this.pTelefono} - Correo: {this.pCorreo}");
        }   
        //GETTERS Y SETTERS
        public int pId_cliente { get { return id_cliente; } set { id_cliente = value; } }
        public string pCliente { get { return cliente; } set { cliente = value; } }
        public long pCuit { get { return cuit; } set { cuit = value; } }
        public string pDomicilio { get { return domicilio; } set { domicilio = value; } }
        public int pId_localidad { get { return id_localidad; } set { id_localidad = value; } }
        public long pTelefono { get { return telefono; } set { telefono = value; } }
        public string pCorreo { get { return correo; } set { correo = value; } }

    }
}
