using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Marca
    {
        private int id_marca;
        private string marca;

        public Marca(int id_marca, string marca)
        {
            this.pId_marca = id_marca;
            this.pMarca = marca;
        }
        public Marca()
        {
            this.pId_marca = id_marca;
            this.pMarca = marca;
        }

        public void mostrarMarca()
        {
            Console.WriteLine($"ID Marca:{this.pId_marca} - {this.pMarca}");
        }
        //GETTERS Y SETTERS
        public int pId_marca
        {
            get { return id_marca; }
            set { id_marca = value; }
        }
        public string pMarca
        {
            get { return marca; }
            set { marca = value; }
        }
    }
}
