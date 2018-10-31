using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3EstDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            Operaciones operacion = new Operaciones();
            Console.WriteLine("Elije la opcion que desees ejecutar \n1.- Ejercicio 1 \n2.- Ejercicio 2 \n3.- Ejercicio 3 \n4.- Ejercicio 4");
            int opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        operacion.Ejercicio1(); break;
                    case 2:
                        operacion.Ejercicio2(); break;
                    case 3:
                        operacion.Ejercicio3(); break;
                    case 4:
                        operacion.Ejercicio4(); break;
                }
        }
    }
}
