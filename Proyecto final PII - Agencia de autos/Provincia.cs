using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Provincia 
    {
        private int id_provincia;
        private string provincia;

        public Provincia(int id_provincia, string provincia)
        {
            this.pId_provincia = id_provincia;
            this.pProvincia = provincia;

        }
        public Provincia()
        {
            this.pId_provincia = 0;
            this.pProvincia = "";

        }

        public void mostrarProvincia()
        {
            Console.Write($"ID Provincia:{this.pId_provincia} - {this.pProvincia}");
        }

        //GETTERS Y SETTERS
        public int pId_provincia
        {
            get { return id_provincia; }
            set { id_provincia = value; }
        }
        public string pProvincia
        {
            get { return provincia; }
            set { provincia = value; }
        }
    }
}
