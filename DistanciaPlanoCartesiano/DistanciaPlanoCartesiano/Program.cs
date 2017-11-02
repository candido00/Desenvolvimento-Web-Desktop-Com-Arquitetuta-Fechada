using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanciaPlanoCartesiano
{
    class Program
    {
        static void Main(string[] args)
        {
            float XA;
            float XB;
            float YA;
            float YB;
            double D2;
            double Distancia;

            Console.WriteLine("Informe o primeiro valor de XA: ");
            XA = float.Parse(Console.ReadLine());

            Console.WriteLine("Informe o primeiro valor de XB: ");
            XB = float.Parse(Console.ReadLine());

            Console.WriteLine("Informe o primeiro valor de YA: ");
            YA = float.Parse(Console.ReadLine());

            Console.WriteLine("Informe o primeiro valor de YB: ");
            YB = float.Parse(Console.ReadLine());

           
            D2 = Math.Pow(XB - XA, 2)  + Math.Pow(YB - YA,2);
            Distancia = Math.Sqrt(D2);
            Console.WriteLine("A distancia entre os dois pontos é: " + Distancia);
            Console.ReadKey();

            
        }
    }
}
