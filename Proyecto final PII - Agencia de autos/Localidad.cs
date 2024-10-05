using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Localidad
    {
        private int id_localidad, id_provincia;
        private string localidad;

        public Localidad(int id_localidad, string localidad, int id_provincia)
        {
            this.pId_localidad = id_localidad;
            this.pLocalidad = localidad;
            this.pId_provincia = id_provincia;
        }

        public Localidad()
        {
            this.pId_localidad = 0;
            this.pLocalidad = "";
            this.pId_provincia = 0;
        }

        public void mostrarLocalidad()
        {
            Console.Write($"ID Provincia: {this.pId_provincia} - ID Localidad:{this.pId_localidad} - {this.pLocalidad} ");
        }

        //GETTERS Y WSETTERS
        public int pId_localidad
        {
            get { return id_localidad; }
            set { id_localidad = value; }
        }
        public string pLocalidad
        {
            get { return localidad; }
            set { localidad = value; }
        }
        public int pId_provincia
        {
            get { return id_provincia; }
            set { id_provincia = value; }
        }
    }
}
