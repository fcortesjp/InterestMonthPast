using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestMonthPast
{
    class Program
    {
        public struct valores
        {
            public double kapital;
            public int months;
        }

        public static valores obtenerValores()
        //Nombre del estudiante: Francisco Cortes
        //Grupo: 
        //Número y Texto del programa
        //Código Fuente: autoría propia

        {   //struct para guardar valores iniciales
            valores values = new valores();
            //Capture capital
            while (true)
            {
                Console.WriteLine("Este Programa Calcula Valores de rendimiento con base en\na) un capital\nb) tiempo(meses) y\nc) una tasa de 0.07%");
                Console.Write("Ingrese capital: ");
                string kapitalStr = Console.ReadLine();

                // revise si el precio esta en blanco o nulo
                if (string.IsNullOrWhiteSpace(kapitalStr))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El capital no puede estar en blanco");
                    //regrese al inicio del loop
                    continue;
                }
                // revise si el precio puede ser un numero double
                values.kapital = 0.0;
                bool canBeDouble = double.TryParse(kapitalStr, out values.kapital);
                if (canBeDouble == false)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El dato ingresado no es valido");
                    //regrese al inicio del loop
                    continue;
                }
                //revise si el capita es negativo o cero
                if (values.kapital <= 0)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El dato ingresado no puede ser negativo o cero");
                    //regrese al inicio del loop
                    continue;
                }

                // si no hay problemas con la captura salga del loop
                break;
            }
            //Console.WriteLine("values.kapital: " + values.kapital);

            //obtener mes
            while (true)
            {
                Console.Write("Ingrese meses: ");
                string monthsStr = Console.ReadLine();

                // revise si el precio esta en blanco o nulo
                if (string.IsNullOrWhiteSpace(monthsStr))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: los meses no puede estar en blanco");
                    //regrese al inicio del loop
                    continue;
                }
                // revise si el precio puede ser un numero double
                values.months = 0;
                bool canBeInt = int.TryParse(monthsStr, out values.months);
                if (canBeInt == false)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El dato ingresado no es valido");
                    //regrese al inicio del loop
                    continue;
                }
                //revise si los meses son negativos o cero 
                if (values.months <= 0)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El dato ingresado no puede ser negativo o cero");
                    //regrese al inicio del loop
                    continue;
                }

                // si no hay problemas con la captura salga del loop
                break;
            }
            //Console.WriteLine("values.months: " + values.months);
            return values;
        }

        public static double[] calcularValoresProyectados(double kapital, int months)
        {
            //array para guardar valores proyectados durante la iteracion
            double[] kapitalPlusInterestAccrued = new double[months];
            int i = 0;

            while (i < months)
            {
                kapitalPlusInterestAccrued[i] = kapital * Math.Pow((1 + 0.0007), (i + 1));
                i++;
            }

            return kapitalPlusInterestAccrued;
        }

        public static void mostrarValoresProyectados(double[] valoresProyectados)
        {
            int j = 1;
            foreach (double valor in valoresProyectados)
            {
                Console.WriteLine("Mes " + j + ": " + valor);
                j++;
            }
        }


        static void Main(string[] args)
        {
            //obtener los valores del usuario
            var values = obtenerValores();

            //calcular valores proyectados
            double[] valoresProyectados = calcularValoresProyectados(values.kapital, values.months);

            //mostrar valores proyectados
            mostrarValoresProyectados(valoresProyectados);

            Console.WriteLine("Presione enter para finalizar...");
            Console.ReadLine();
        }
    }
}

