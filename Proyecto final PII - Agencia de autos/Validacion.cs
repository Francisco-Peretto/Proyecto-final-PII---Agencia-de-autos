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

        public DateTime validarFecha(string mensaje)
        {
            int FechaError = 0;
            DateTime FechaValida = new DateTime();

            Console.Write(mensaje);
            string fecha = Console.ReadLine();

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
                while (!DateTime.TryParse(fecha, out FechaValida) || FechaValida.ToString("dd/MM/yyyy") != fecha)
                {
                    Console.Write("\nLa fecha ingresada no es válida. Presione una tecla para continuar: ");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write(mensaje);

                    fecha = Console.ReadLine();
                }
                return FechaValida;
            }
        }


        public int validarEntero(string mensaje)
        {
            int enteroparse;
            Console.Write(mensaje);
            string entero = Console.ReadLine();

            while (!int.TryParse(entero, out enteroparse))
            {
                Console.WriteLine("El número ingresado no es válido. Presione una tecla para continuar:");
                Console.ReadKey();
                Console.Clear();
                Console.Write(mensaje);
                entero = Console.ReadLine();
            }
            return enteroparse;
        }

        public double validarDoble(string mensaje)
        {
            double dobleparse;
            Console.Write(mensaje);
            string doble = Console.ReadLine();

            while (!double.TryParse(doble, out dobleparse))
            {
                Console.WriteLine("El número ingresado no es válido. Presione una tecla para continuar:");
                Console.ReadKey();
                Console.Clear();
                Console.Write(mensaje);
                doble = Console.ReadLine();
            }
            return dobleparse;
        }

        public long validarLong(string mensaje)
        {
            long longparse;
            Console.Write(mensaje);
            string longp = Console.ReadLine();

            while (!long.TryParse(longp, out longparse))
            {
                Console.WriteLine("El número ingresado no es válido. Presione una tecla para continuar:");
                Console.ReadKey();
                Console.Clear();
                Console.Write(mensaje);
                longp = Console.ReadLine();
            }
            return longparse;
        }

        public string validarStr(string mensaje)
        {
            string str;
            Console.Write(mensaje);
            str = Console.ReadLine();
            while (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("El campo no puede estar vacío. Presione una tecla para continuar:");
                Console.ReadKey();
                Console.Clear();
                Console.Write(mensaje);
                str = Console.ReadLine();
            }
            return str;
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
