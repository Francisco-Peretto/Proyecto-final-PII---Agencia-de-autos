using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Validacion
    {
        Concesionaria concesionaria;
        public Validacion() 
        {

        }

       

        public DateTime validarFecha(string fecha)
        {
         
            int FechaError = 0;
            DateTime FechaValida = new DateTime();

            try
            {
                FechaValida = DateTime.Parse(fecha);

                if (FechaValida.ToString("dd/MM/yyyy") == fecha)
                {
                    FechaError = 0;
                }
                else
                {
                    FechaValida = new DateTime();
                    FechaError = 2;
                }
            }
            catch
            {
                FechaError = 2;
            }

            if (FechaError == 0)
            {
                return FechaValida;
            }
            else
            {
                while (DateTime.TryParse(fecha, out FechaValida) == false)
                {
                    Console.Clear();
                    Console.Write("\nEl dato ingresado no es valido, por favor reingreselo: ");
                    fecha = Console.ReadLine();
                }
                return FechaValida;
            }
        }
        public int validarEntero(string entero)
        {
            int enteroparse;
            while (int.TryParse(entero, out enteroparse) == false)
            {
                Console.Clear();
                Console.Write("\nEl dato ingresado no es valido, por favor reingreselo: ");
                entero = Console.ReadLine();
            }

            return enteroparse;
        }
        public double validarDouble(string doble)
        {
            double dobleparse;
            while (double.TryParse(doble, out dobleparse) == false)
            {
                Console.Clear();
                Console.Write("\nEl dato ingresado no es valido, por favor reingreselo: ");
                doble = Console.ReadLine();
            }

            return dobleparse;
        }


    }
}
