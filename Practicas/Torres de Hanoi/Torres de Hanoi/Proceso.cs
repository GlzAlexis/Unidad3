using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Proceso
    {
        Stack Torre1 = new Stack();
        Stack Torre2 = new Stack(); // Se inicializan las 3 torres que se utilizaran
        Stack Torre3 = new Stack();
        int Movimientos = 0, Discos = 0;  // Axiliares, contador de movimientos y el otro es la cantidad de discos

        public void Turnos(string Principio, string Final) // Son los movimientos que se ejecutaran
        {
            if (Principio == "1" && Final == "2")
            {
                Console.WriteLine("Mover Disco " + Torre1.Peek() + " de " + Principio + " a " + Final); Torre2.Push(Torre1.Pop());
            }
            else if (Principio == "1" && Final == "3")
            {
                Console.WriteLine("Mover Disco " + Torre1.Peek() + " de " + Principio + " a " + Final); Torre3.Push(Torre1.Pop());
            }
            else if (Principio == "2" && Final == "1")
            {
                Console.WriteLine("Mover Disco " + Torre2.Peek() + " de " + Principio + " a " + Final); Torre1.Push(Torre2.Pop());
            }
            else if (Principio == "2" && Final == "3")
            {
                Console.WriteLine("Mover Disco " + Torre2.Peek() + " de " + Principio + " a " + Final); Torre3.Push(Torre2.Pop());
            }
            else if (Principio == "3" && Final == "1")
            {
                Console.WriteLine("Mover Disco " + Torre3.Peek() + " de " + Principio + " a " + Final); Torre1.Push(Torre3.Pop());
            }
            else
            {
                Console.WriteLine("Mover Disco " + Torre3.Peek() + " de " + Principio + " a " + Final); Torre2.Push(Torre3.Pop());
            }
        }
        public void MovimintoTorre(int NoDiscos, string Principio, string Final, string Temporal) // Metodo recursivo
        {
            if (NoDiscos >= 1)
            {
                MovimintoTorre(NoDiscos - 1, Principio, Temporal, Final);
                Movimientos = Movimientos + 1;
                Turnos(Principio, Final); Console.ReadKey();
                MovimintoTorre(NoDiscos - 1, Temporal, Final, Principio);
            }
        }
        public void Pila() // Con este metodo se llena la pila
        {
            for (int i = Discos; i > 0; i--) { Torre1.Push(i); }
        }
        public Proceso(int NoDiscos)
        {
            Discos = NoDiscos;
            Pila();
            MovimintoTorre(NoDiscos, "1", "2", "3");
            Console.WriteLine("Movimientos: " + Movimientos);
        }
    }
}
