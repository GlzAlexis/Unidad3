using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_1Mejorando_la_Clase
{
    class Proceso
    {
        public void Ingresion(int NoClases)
        {
            ArrayList Clases = new ArrayList(); // Lista para las clases //
            ArrayList NoAlumnos = new ArrayList(); // Lista para el numero de alumnos que habra dentro de las clases //
            for (int i = 0; i < NoClases; i++)
            {   // En este for se pide que se ingrese el nombre de la clase y cuantos alumno contendra dicha clase//
                Console.Write("\nIngrese el nombre de la clase no.-{0}: ", (i + 1)); Clases.Add(Console.ReadLine());
                Console.Write("\nIngrese la cantidad de alumnos que hay en la clase de {0}: ", Clases.ToArray().ElementAt(i)); NoAlumnos.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Console.Clear();

            ArrayList Calificaciones = new ArrayList(); // Lista para las calificaciones de cada alumno //

            int Clase; //En este for se le pide al usuario que ingrese la calificacion que se le dara a cada alumno de su respectiva clase//
            for (Clase = 0; Clase < NoClases; Clase++) //Se usa doble for para desplegar el nombre de la clase donde se almacenara la calificacion del respectivo alumno// 
            {
                for (int i = 0; i < Convert.ToInt16(NoAlumnos.ToArray().ElementAt(Clase)); i++)
                {
                    Console.Write("\nIngrese la calificacion del alumno no.-{0} de la clase {1}: ", (i + 1), Clases.ToArray().ElementAt(Clase)); Calificaciones.Add(Console.ReadLine());
                }
            }
            Console.Clear();
            int Calificacion = 0;  //Aqui se desplegara la informacion de de cada clase con los alumnos y sus respectivas calificaciones con el foreach//
            Console.WriteLine("--Despliegue de informacion de la clase con las calificaciones de sus respectivos alumnos--");
            foreach (object item in Clases)
            {
                Console.WriteLine("\nClase de {0}:", item);
                for (int i = 0; i < Convert.ToInt32(NoAlumnos.ToArray().ElementAt(Clases.IndexOf(item))); i++)
                {
                    Console.WriteLine("Alumno no.-{0}  Calificacion de: {1}", (i + 1), Calificaciones.ToArray().ElementAt(Calificacion)); Calificacion++;
                }
            }
        }
    }
}
