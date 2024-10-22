using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Segmento
    {
        // prop privadas
        private int _id_segmento;
        private string _segmento;
        public Segmento()
        {
            this.pIdSegmento = 0;
            this.pSegmento = string.Empty;
        }

        public Segmento(int id_segmento, string segmento)
        {
            this.pIdSegmento = id_segmento;
            this.pSegmento = segmento;
        }

        public void mostrarSegmento()
        {
            Console.WriteLine($"ID Segmento:{this.pIdSegmento} - {this.pSegmento}");
        }
        // prop publicas
        public int pIdSegmento
        {
            get { return this._id_segmento; }
            set { this._id_segmento = value; }
        }

        public string pSegmento
        {
            get { return this._segmento; }
            set { this._segmento = value; }
        }


    }
}
