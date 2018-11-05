using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Proceso
    {
        List<TareaInf> Global = new List<TareaInf>();
        List<TareaInf> Pendiente = new List<TareaInf>();
        List<TareaInf> EnProceso = new List<TareaInf>(); //Inicializan las listas que se utilizaran
        List<TareaInf> Terminada = new List<TareaInf>();
        int id = 0;

        public void DespliegueDeListas() // En este metodo desplegara la lista que desee
        {
            int opc = 0;
            Console.Write("Estas son las listas que se encuentran actualmente disponibles: \n1.- Global \n2.- Pendiente \n3.- En proceso \n4.- Terminadas \nTeclee el numero de la opcion que desee: "); opc = Convert.ToInt32(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    foreach (var item in Global)
                    {
                        Console.WriteLine("ID: " + item.ID);
                        Console.WriteLine("Nombre: " + item.Nombre);
                        Console.WriteLine("Fecha en que inicio: " + item.FechaDeInicio);  //Despliegue de la lista global
                        Console.WriteLine("Descripcion: " + item.Descripcion);
                        Console.WriteLine("Estatus: " + item.Estatus + "\n");
                    }
                    Console.ReadKey(); break;
                case 2:
                    foreach (var item in Pendiente)
                    {
                        Console.WriteLine("ID: " + item.ID);
                        Console.WriteLine("Nombre: " + item.Nombre);
                        Console.WriteLine("Fecha en que inicio: " + item.FechaDeInicio);  // Despliegue de la lista de pendientes
                        Console.WriteLine("Descripcion: " + item.Descripcion);
                        Console.WriteLine("Estatus: " + item.Estatus + "\n");
                    }
                    Console.ReadKey(); break;
                case 3:
                    foreach (var item in EnProceso)
                    {
                        Console.WriteLine("ID: " + item.ID);
                        Console.WriteLine("Nombre: " + item.Nombre);
                        Console.WriteLine("Fecha en que inicio: " + item.FechaDeInicio);  //Despligue de las que estan en proceso
                        Console.WriteLine("Descripcion: " + item.Descripcion);
                        Console.WriteLine("Estatus: " + item.Estatus + "\n");
                    }
                    Console.ReadKey(); break;
                case 4:
                    foreach (var item in Terminada)
                    {
                        Console.WriteLine("ID: " + item.ID);
                        Console.WriteLine("Nombre: " + item.Nombre);
                        Console.WriteLine("Fecha en que inicio: " + item.FechaDeInicio);  // Despliegue de las que ya se terminaron
                        Console.WriteLine("Descripcion: " + item.Descripcion);
                        Console.WriteLine("Estatus: " + item.Estatus + "\n");
                    }
                    Console.ReadKey(); break;
                default: Console.WriteLine("La opcion que introdujo no se encuentra en el menu"); break; // Saldra este mensaje cuando se elija un opcion que no se encuentra dentrod el menu
            }
        }
        public void AñadirTarea (int opc, int IDA, string fecha) // Este metodo es para identifica si es una tarea nueva o se corregira alguna tarea para cambiar el ID si es necesario
        {
            TareaInf NewTarea = new TareaInf();
            switch (opc)
            {
                case 1:  id = 1 + id; break;
            }
            NewTarea.ID = id;
            Console.Write("Nombre de la tarea: "); NewTarea.Nombre = Console.ReadLine();
            Console.Write("Descripcion de la tarea: "); NewTarea.Descripcion = Console.ReadLine();
            Console.Write("Fecha en que se inicio: "); NewTarea.FechaDeInicio = Console.ReadLine();
            NewTarea.FechaEntrega = fecha;
            switch (opc)
            {
                case 1:
                    NewTarea.Estatus = "Pendiente";
                    Pendiente.Add(NewTarea); Global.Add(NewTarea); break;
                case 2:
                    NewTarea.Estatus = "En proceso";
                    NewTarea.ID = IDA;
                    EnProceso.Add(NewTarea); Global.Add(NewTarea); break;
            }
        }
        public void TareaInciada() // Este metodo es para iniciar una tarea y cambiar el estatus de la misma a que se encuentra en proceso y muestra las tareas que puede realizar
        {
            int hacertarea = 0;
            Console.WriteLine("Esta es la lista de tareas que tienes disponibles para iniciar");
            foreach  (TareaInf tarea in Pendiente)
            {
                Console.Write("ID: " + tarea.ID + "  ");
                Console.WriteLine(tarea.Nombre);
                Console.WriteLine(tarea.Descripcion + "\n");
            }
            Console.Write("Ingrese el ID de la tarea que desea realizar: "); hacertarea = Convert.ToInt32(Console.ReadLine());
            var Trae = (from buscar in Pendiente where hacertarea == buscar.ID select buscar).ToList();
            foreach (var item in Trae)
            {
                Global.Remove(item);
                item.Estatus = "En proceso";
                EnProceso.Add(item); Global.Add(item);
                Pendiente.Remove(item);
            }
            Trae.Clear();
        }
        public void TareaTerminada() // Este metodo es para terminar alguna tarea que esten en el estatus de "En proceso" y muestra las mismas que estan en proceso para elegir
        {
            string Fecha = "";
            int hacertarea = 0;
            Console.WriteLine("Esta es la lista de tareas no terminadas: ");
            foreach (TareaInf tarea in EnProceso)
            {
                Console.Write("ID: " + tarea.ID + "  ");
                Console.WriteLine(tarea.Nombre);
                Console.WriteLine(tarea.Descripcion + "\n");
            }
            Console.Write("Ingrese el ID de la tarea que desea terminar: "); hacertarea = Convert.ToInt32(Console.ReadLine());
            var Trae = (from buscar in EnProceso where hacertarea == buscar.ID select buscar).ToList();
            Console.Write("Ingresa la fecha en que finalizaste la tarea: "); Fecha = Console.ReadLine();
            foreach (var item in Trae)
            {
                Global.Remove(item);
                item.Estatus = "Terminada";
                item.FechaEntrega = Fecha;
                Terminada.Add(item); Global.Add(item);
                EnProceso.Remove(item);
            }
            Trae.Clear();
        }
        public void Correcion() // Este metodo es para hacer correcciones a las tareas que estan terminadas
        {
            int hacertarea = 0;
            Console.WriteLine("Esta es las lista de tareas que se pueden corregir: ");
            foreach (TareaInf tarea in Terminada)
            {
                Console.Write("ID: " + tarea.ID + "  ");
                Console.WriteLine(tarea.Nombre);
                Console.WriteLine(tarea.Descripcion + "\n");
            }
            Console.Write("Ingrese el ID de la tarea que desea hacer alguba correccion: "); hacertarea = Convert.ToInt32(Console.ReadLine());
            var Trae = (from buscar in Terminada where hacertarea == buscar.ID select buscar).ToList();
            foreach (var item in Trae)
            {
                Global.Remove(item); Terminada.Remove(item);
            }
            Console.Clear(); Trae.Clear();
            AñadirTarea(2, hacertarea, "~~~~~~~");
        }
        public void Inicio() // Este es el inicio del programa donde se encuentra las opciones a elegir
        {
            int opc = 0;
            do
            {
                try
                {
                    Console.Clear();
                    Console.Write("Estas son las opciones que tenemos disponibles en nuestro menu: \n1.- Añadir una tarea nueva \n2.- Iniciar una tarea \n3.- Terminar una tarea \n4.- Correcion de una tarea \n5.- Despliegue de las listas disponibles \n6.- Cerrar programa +" +
                        "\nTeclee la opcion que desee realizar"); opc = Convert.ToInt32(Console.ReadLine());
                    switch (opc)
                    {
                        case 1:
                            AñadirTarea(opc, 0, "~~~~~"); break;
                        case 2:
                            TareaInciada(); break;
                        case 3:
                            TareaTerminada(); break;
                        case 4:
                            Correcion(); break;
                        case 5:
                            DespliegueDeListas(); break;
                        case 6:
                            opc = 9; break;
                        default: Console.WriteLine("La opcion que introdujo no se encuentra en nuestro menu"); break;
                    }
                }
                catch(Exception e) { Console.WriteLine(e.Message); Console.ReadLine(); } // Para atrapar errores que se ejecuten durante la ejecucion del programa
            }
            while (opc !=9);
        }
    }
}
