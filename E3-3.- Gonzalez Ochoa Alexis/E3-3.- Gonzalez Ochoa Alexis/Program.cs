

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_3.__Gonzalez_Ochoa_Alexis
{
    class Program
    {
        static void Main(string[] args)
        {
            Procesos BlackJack = new Procesos();   // El objeto es creado // Se manda a llamar el metodo que inicia los demas
            try { BlackJack.Comenzar(); }           
            catch (Exception e) { Console.WriteLine(e.Message); }  //Y el mensaje de error por si las moscas
            Console.ReadKey();
        }
    }
}
