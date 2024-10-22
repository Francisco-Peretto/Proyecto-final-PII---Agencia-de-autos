using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Combustible
    {
        // prop privadas
        private int _id_combustible;
        private string combustible;

        // constructores
        public Combustible()
        {
            this.pIdCombustible = 0;
            this.pCombustible = string.Empty;
        }

        public Combustible(int idCombustible, string combustible)
        {
            this.pIdCombustible = idCombustible;
            this.pCombustible = combustible;
        }

        public void mostrarCombustible()
        {
            Console.WriteLine($"ID Combustible:{this.pIdCombustible} - {this.pCombustible}");
        }
        // prop publicas
        public int pIdCombustible
        {
            get { return this._id_combustible; }
            set { this._id_combustible = value; }
        }

        public string pCombustible
        {
            get { return this.combustible; }
            set { this.combustible = value; }
        }


    }
}

