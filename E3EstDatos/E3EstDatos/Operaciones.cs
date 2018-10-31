using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3EstDatos
{
    class Clase
    {
        public string Maestro { get; set; }
        public string Alumno { get; set; }
        public string NombreClase { get; set; }
        public int Calificacion { get; set; }

        public Clase()
        {

        }
    }
    class Operaciones
    {
        public void Principal()
        {
        }

        public void Ejercicio1()
        {
            Stack Lista = new Stack();
            Lista.Push(5);
            Lista.Push(3);
            Console.Write(Lista.Pop() + "\t");
            Lista.Push(2);
            Lista.Push(8);
            Console.Write(Lista.Pop() + "\t");
            Console.Write(Lista.Pop() + "\t");
            Lista.Push(9);
            Lista.Push(1);
            Console.Write(Lista.Pop() + "\t");
            Lista.Push(7);
            Lista.Push(6);
            Console.Write(Lista.Pop() + "\t");
            Console.Write(Lista.Pop() + "\t");
            Lista.Push(4);
            Console.Write(Lista.Pop() + "\t");
            Console.Write(Lista.Pop() + "\t");
            Console.ReadLine();
            //¿Qué valores se devuelven durante la siguiente serie de operaciones de pila,
            //si se ejecutan en una pila inicialmente vacía ?
            //push(5), push(3), pop(), push(2), push(8),
            //pop(), pop(), push(9), push(1), pop(), push(7), push(6), pop(), pop(), push(4),
            //pop(), pop()
        }

        public void Ejercicio2()
        {
            //Escriba en este metodo un modulo que pueda leer  y almacenar palabras reservadas en una lista enlazada 
            //e identificadores y literales en Otra lista enlazada.
            //Cuando el programa haya terminado de leer la entrada, mostrar
            //Los contenidos de cada lista enlazada.
            //Revise que es un Identificador y que es un literal
        }

        public void Ejercicio3()
        {
            //mida el tiempo entre Un lista ligada y una lista normal en el tiempo de ejecucion de 9876 elementos agregados.
            LinkedList<int> Ligada = new LinkedList<int>();
            List<int> Listo = new List<int>();
            const int max = 9876;

            Console.WriteLine("Valores de la lista");
            var Time1 = Stopwatch.StartNew();
            for (int i = 0; i < max; i++)
            {
                Listo.Add(i);
            }
            Time1.Stop();

            var Time2 = Stopwatch.StartNew();
            for (int i = 0; i < max; i++)
            {
                Ligada.AddFirst(i);
            }
            Time2.Stop();
            Console.WriteLine("Lista: " + ((double)(Time1.Elapsed.TotalMilliseconds * 1000000) / max).ToString("0.00 ns"));//Imprimimos los tiempos
            Console.WriteLine("Lista ligada: " + ((double)(Time2.Elapsed.TotalMilliseconds * 1000000) / max).ToString("0.00 ns"));
            Console.ReadKey();
        }

        public int NoAlumnos { get; set; }
        List<int> Clase = new List<int>();
        public void Ejercicio4()
        {
            Console.Write("Ingrese el nombre del maestro: "); string Maestro = Console.ReadLine();
            Console.Write("Ingrese el nombre de la materia que imparte: "); string Materia = Console.ReadLine();
            Console.Write("Ingrese la cantidad de alumnos que hay en la clase: "); NoAlumnos = int.Parse(Console.ReadLine());
            int calif = 0;
            if (NoAlumnos >= 30)
            {
                for (int i = 0; i < NoAlumnos; i++)
                {
                    Console.Write("Ingrese la calificacion del alumno {0}: ", i + 1);
                    calif = int.Parse(Console.ReadLine());
                    Clase.Add(calif);
                }
            }
            else
            {
                Console.Write("La cantidad de alumnos tiene que ser igual o mayor a 30 alumnos"); Console.ReadLine();
            }

            Clase.Sort();
            Console.Write("La calificacion mas alta es de: " + Clase.Max() + "/t La califcacion mas baja es de: " + Clase.Min());
            var Resultado = Clase.Sum();
            int Media = Resultado / NoAlumnos;
            Console.Write("La claficacion media del salon es de: " + Media); Console.ReadLine();
            // Diseñar e implementar una clase que le permita a un maestro hacer un seguimiento de las calificaciones
            // en un solo curso.Incluir métodos que calculen la nota media, la
            //calificacion más alto, y el calificacion más bajo. Escribe un programa para poner a prueba tu clase.
            //implementación. Minimo 30 Calificaciones, de 30 alumnos.
        }
    }
}
