using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_1Mejorando_la_Clase
{
    class Program
    {
        static void Main(string[] args)
        {
            int NoClases;
            try
            {
                Console.Write("Ingrese el numero de clases que desee capturar: "); NoClases = Convert.ToInt32(Console.ReadLine()); // Se le pide al usuario que ingrese el numero de clases que desea//
                Proceso proceso = new Proceso(); //Aqui se crea el objeto de la clase proceso//
                proceso.Ingresion(NoClases); Console.ReadKey(); //Se manda llamar el metodo donde se ingresaran mas datos y se desplegaran los mismos//
            }
            catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
        }
    }
}
