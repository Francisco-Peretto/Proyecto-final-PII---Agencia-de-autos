using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final_PII___Agencia_de_autos
{
    internal class Validacion
    {
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
                    Console.Write("\n La fecha ingresada no es válida, por favor reingrésela: ");
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
                Console.Write("\nEl número ingresado no es válido, por favor reingréselo: ");
                entero = Console.ReadLine();
            }
            return enteroparse;
        }

        public double validarDoble(string doble)
        {
            double dobleparse;
            while (double.TryParse(doble, out dobleparse) == false)
            {
                Console.Clear();
                Console.Write("\nEl número ingresado no es valido, por favor reingreselo: ");
                doble = Console.ReadLine();
            }

            return dobleparse;
        }

        public int validarLong(string longp)
        {
            int longparse;
            while (int.TryParse(longp, out longparse) == false)
            {
                Console.Clear();
                Console.Write("\nEl número ingresado no es válido, por favor reingréselo: ");
                longp = Console.ReadLine();
            }
            return longparse;
        }

        public long validarCuit()
        {
            int prefijo;
            string  dni, sexo;
            while (true)
            {
                Console.Write("Ingrese el DNI o CI de empresa sin puntos: ");
                dni = Console.ReadLine();

                if (dni.Length == 8 && int.TryParse(dni, out _))
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El DNI o CI debe tener exactamente 8 digitos numericos. Intente nuevamente.");
                    Console.WriteLine("Presione cualquiera tecla para continuar...");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.Write("Ingrese si es hombre, mujer o empresa: ");
                sexo = Console.ReadLine().ToLower();
                Console.Clear();

                if (sexo == "hombre" || sexo == "mujer" || sexo == "empresa")
                {
                    switch (sexo)
                    {
                        case "hombre":
                            prefijo = 20;
                            break;
                        case "mujer":
                            prefijo = 27;
                            break;
                        case "empresa":
                            prefijo = 30;
                            break;
                        default:
                            prefijo = 0;
                            break;
                    }
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Sexo Invalido. Debe de ser 'hombre', 'mujer', 'empresa'. Intente nuevamente.");
                    Console.WriteLine("Presione cualquiera tecla para continuar...");
                    Console.ReadKey();
                }
            }

            string cuilBase = prefijo.ToString() + dni;
            int[] multiplicadores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int suma = 0;

            for (int i = 0; i < cuilBase.Length; i++)
            {
                suma = suma + int.Parse(cuilBase[i].ToString()) * multiplicadores[i];
            }

            int z = suma / 11;
            int resto = suma - (z * 11);
            int digitoVerificador = 11 - resto;
            return long.Parse(prefijo + dni + digitoVerificador);
        }
    }
}
