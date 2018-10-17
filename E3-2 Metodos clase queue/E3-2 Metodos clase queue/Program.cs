using System;
using System.Collections;

namespace E3_2_Metodos_clase_queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue Cola = new Queue();
            Cola.Enqueue("Nintendo");       // Este metodo permite agregar elementos como el push en la pila
            Cola.Enqueue("Playstation");
            Cola.Enqueue("Xbox");
            Cola.Enqueue("PCMaster");

            Console.WriteLine(Cola.Count);  // Este metodo te dice la cantidad de elemento que tienes en tu cola actualmente que son 4
            Cola.TrimToSize();              // Este limita la cola con la cantidad de elementos que se encuentran dentro de la misma
            Console.ReadKey();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(Cola.Dequeue()); // Aqui se van desplegando cada elemento conforme se va eliminando, como el pop
            }
            Console.WriteLine("\n{0}",Cola.Count); // Volvemos a verificar cuantos elementos se encuentran en la cola que serian 0
            Console.ReadKey();

        }
    }
}
