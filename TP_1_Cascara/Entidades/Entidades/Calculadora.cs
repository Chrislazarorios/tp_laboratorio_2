using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double returnValue;

            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "-":
                    {
                        returnValue = num1 - num2;
                        break;
                    }
                case "*":
                    { 
                        returnValue = num1 * num2;
                        break;
                    }
                case "/":
                    { 
                        returnValue = num1 / num2;
                        break;
                    }
                default:
                    { 
                        returnValue = num1 + num2;
                        break;
                    }
            }

            return returnValue;
        }

        private static string ValidarOperador(string operador)
        {
            string returnValue = "+";
            if(!(operador is null))
            {
                if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                {
                    returnValue = operador;
                }
            }
            

            return returnValue;
        }
    }
}
