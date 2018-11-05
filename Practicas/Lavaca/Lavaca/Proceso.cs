using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavaca
{
    class Proceso
    {
        Queue Nombre = new Queue();
        Queue Velocidad = new Queue(); // Se inlicializan las colas para almacenar los datos
        int Time = 0, Turno = 0;

        public Proceso() // Aqui se asignan los nombres y las velocidades de las vacas
        {
            Nombre.Enqueue("Mazie");  Velocidad.Enqueue(2);
            Nombre.Enqueue("Daisy");  Velocidad.Enqueue(4);
            Nombre.Enqueue("Crazy");  Velocidad.Enqueue(10);
            Nombre.Enqueue("Lazy");   Velocidad.Enqueue(20);
        }
        public void Cruce() // En este metodo se envian a las dos primeras vacas
        {
            Console.WriteLine("Bob lleva a las vacas {0} y {1}", Nombre.ToArray().ElementAt(0), Nombre.ToArray().ElementAt(1));
            Time = Time + Convert.ToInt32(Velocidad.ToArray().ElementAt(1));
            Console.WriteLine("Tiempo de duracion: {0}", Time);
            Turno = Turno + 1;
            if (Time < 34)
            {
                Regreso();
                if (Turno == 2)
                {
                    Velocidad.Dequeue();
                    Nombre.Dequeue();
                    Nombre.Enqueue("Mazie"); Velocidad.Enqueue(2);
                    Nombre.Enqueue("Daisy"); Velocidad.Enqueue(4);
                }
                Cruce(); // Se llama al metodo para que se sigan enviando vacas
            }
        }
        public void Regreso() // En este proceso se regresan las vacas
        {
            Console.WriteLine("Bob se regresa con la vaca: {0}", Nombre.ToArray().ElementAt(Velocidad.ToArray().ToList().IndexOf(Velocidad.ToArray().Min())));
            Time = Time + Convert.ToInt32(Velocidad.ToArray().Min());
            if(Turno == 1)
            {
                Nombre.Enqueue("Daisy");  Velocidad.Enqueue(4);
            }
            Velocidad.Dequeue();
            Nombre.Dequeue();  Nombre.Dequeue();
            Velocidad.Dequeue();
        }
    }
}
