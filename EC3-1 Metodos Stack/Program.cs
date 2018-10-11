using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC3_1_Metodos_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack Pila = new Stack();
            Pila.Push("Nintendo");
            Pila.Push("Playstation");
            Pila.Push("Xbox");
            Pila.Push("PCMaster");

            if (Pila.Contains("Nintendo")) { Console.WriteLine("Si se encontro Nintendo\n"); } // Este se utiliza para saber si el elemento que buscas
            else { Console.WriteLine("El elemento no esta"); }                                 // Se encuentra dentro de la pila

            if(Pila.GetType() == typeof(Stack)) { Console.WriteLine("Si es"); }                // Este se utiliza para determinar que tipo de objeto
            else { Console.WriteLine("No es"); }                                               // Se esta utilizando

            Console.WriteLine("\n{0}",Pila.ToString());                                        // Devuelve el string del objeto que se ha seleccionado
            Console.WriteLine("\n{0}",Pila.ToArray().ElementAt(2) +"\n");                      // Este convierte nuestra pila en un arreglo

            IEnumerator Numero = Pila.GetEnumerator();                                         // Este consigue el numerador de nuestra pila
            while (Numero.MoveNext())
            {
                Object Obj = Numero.Current;
                Console.WriteLine(Obj);
            }
            Console.ReadKey();
        }
    }
}
