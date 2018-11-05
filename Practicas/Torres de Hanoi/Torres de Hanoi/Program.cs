using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("La unica accion que usted realizara sera precionar la teclaa enter para que los movimientos se ejecuten \nIntrodusca la cantidad de discos con la que desee jugar: ");
            Proceso Hanoi = new Proceso(Convert.ToInt32(Console.ReadLine())); Console.ReadKey();
        }
    }
}
