using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        private string SetNumero
        {
            set
            {
                double buffer;
                if (ValidarNumero(value) != 0)
                {
                    buffer = ValidarNumero(value);
                    this.numero = buffer;
                }
            }
        }

        // Constructores
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        
        public Numero(double numero) : this(numero.ToString())
        {

        }

        public Numero() : this(0)
        {
            //this.numero = 0;
        }

        // Metodos
        public static string BinarioDecimal(string binario)
        {
            double decimalAux;
            char[] arrayChar = binario.ToCharArray();
            Array.Reverse(arrayChar);
            int size;
            string bufferAux = "";


            if (double.TryParse(binario, out decimalAux))
            {
                size = arrayChar.Length;
                decimalAux = 0;

                for (int i = 0; i < size; i++)
                {
                    if(arrayChar[i] != '1' && arrayChar[i] != '0')
                    {
                        bufferAux = "valor inválido";
                    }
                    else if(arrayChar[i] == '1')
                    {
                        decimalAux += (int)Math.Pow(2, i);
                    }
                }

                bufferAux = decimalAux.ToString();
            }
            else
            {
                bufferAux = "valor inválido";
            }

            return bufferAux;
        }

        public static string DecimalBinario(double numero)
        {
            string binarioAux = "";

            //int bufferInt = (int)Math.Abs(numero);

            if(numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        binarioAux += "0"; // Si es numero par, equivale a cero
                    }
                    else
                    {
                        binarioAux += "1"; // Si es numero impar, equivale a uno
                    }
                    numero = (int)numero / 2;
                }
            }
            else if(numero == 0)
            {
                binarioAux = "0";
            }
            else
            {
                binarioAux = "Valor inválido";
            }
            char[] arrayChar = binarioAux.ToCharArray();
            Array.Reverse(arrayChar);
            

            return new string(arrayChar);
        }

        public static string DecimalBinario(string numero)
        {
            string bufferAux;
            double decimalAux;

            if(double.TryParse(numero, out decimalAux))
            {
                bufferAux = DecimalBinario(decimalAux);
            }
            else
            {
                bufferAux = "Valor inválido";
            }

            return bufferAux;
        }

        private double ValidarNumero(string strNumero)
        {
            double returnValue = 0, num;

            if(double.TryParse(strNumero, out num))
            {
                returnValue = num;
            }

            return returnValue;
        }

        // Sobrecarga de operadores
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }

    }
}
