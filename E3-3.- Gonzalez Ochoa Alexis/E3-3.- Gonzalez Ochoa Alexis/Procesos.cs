using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_3.__Gonzalez_Ochoa_Alexis
{
    class Procesos
    {
        Stack PilaDeCartas = new Stack();                                        // Se inician las listas y pilas
        Cartas NuevaCarta;                                                       // Tambien se encuentran las variables aux
        List<Cartas> Lista = new List<Cartas>();
        int Victoria = 0, Perdidas = 0, NoDeAs = 0, NoDeCartas = 0, Suma = 0;
        string Sigue = "A";
        public void Aleatorio()
        {
            Random random = new Random();
            int Azar = random.Next(0, Lista.Count);
            PilaDeCartas.Push(Lista.ElementAt(Azar));                           //Se obtiene el valor aleatorio y este es guardado en la pila
            NoDeCartas = NoDeCartas + 1;
            Lista = (from cartas in Lista where cartas.ID != Lista.ElementAt(Azar).ID select cartas).ToList();
        }
        public void Llenar()
        {
            int NoValor = 0, NoDibujo = 0;
            char[] Dibujo = new char[4] { '♥', '♦', '♣', '♠' };                 // Simbolos y litras que se les asignaran a las cartas
            char[] Letras = new char[3] { 'J', 'Q', 'K' };
            for (NoDibujo = 0; NoDibujo < 4; NoDibujo++)
            {
                for (NoValor = 1; NoValor < 14; NoValor++)
                {
                    NuevaCarta = new Cartas();
                    if (NoValor > 10)                                           //Llena la lista con las letras puestas con anterioridad
                    {
                        NuevaCarta.ID = Convert.ToString(Letras[NoValor - 11]) + Convert.ToString(Dibujo[NoDibujo]);
                        NuevaCarta.Valor = 10;
                    }
                    else if (NoValor == 1)                                      //En lugar de que aparesca como 1 se cambia por un 'As'
                    {
                        NuevaCarta.ID = "As" + Convert.ToString(Dibujo[NoDibujo]); 
                        NuevaCarta.Valor = 0;
                    }
                    else                                                        // Ingresa valores del 2 al 10
                    {
                        NuevaCarta.ID = Convert.ToString(NoValor) + Convert.ToString(Dibujo[NoDibujo]);
                        NuevaCarta.Valor = NoValor;
                    }
                    Lista.Add(NuevaCarta);                                     // Agrega lo anterior a la lista
                }
            }
        }
        public void Comproacion()
        {
            Suma = 0;
            foreach(Cartas item in PilaDeCartas)
            {
                if (item.Valor >= 2 && item.Valor <= 10) { Suma = Suma + item.Valor; }  //Su suma los que no sean As
                else { NoDeAs = NoDeAs + 1; }                                            //Guarda la cantidad de As
            }
            for (NoDeAs = NoDeAs; NoDeAs > 0; NoDeAs--)                                  //Aqui repite el numero de As
            {
                if (Suma <= 10) { Suma = Suma + 11; }
                else if (Suma > 10) { Suma = Suma + 1; }
            }
        }
        public void AlzarMano()
        {
            foreach ( Cartas item in PilaDeCartas) { Console.Write("{0}      ",item.ID); }  //Muestra las cartas que tenemos hasta el momento
        }
        public void Volver()   //Limpia los valores
        {
            Lista.Clear();
            PilaDeCartas.Clear();
            Suma = 0;
            NoDeAs = 0;
            NoDeCartas = 0;
            Console.Clear();
            Llenar();
        }
        public void Comenzar()
        {
            Console.OutputEncoding = Encoding.Unicode;                                       // Sirve para mostrar las figuras
            string opc = "A";
            Llenar();
            while (Sigue == "A")
            {
                Aleatorio();
                do
                {
                    Console.Clear();                                                       // Los metodos se llaman para comenzar
                    Aleatorio();
                    AlzarMano();
                    Comproacion();
                    Console.WriteLine("\nSuma de la cartas: {0} \n", Suma);
                    if (Suma < 21 && NoDeCartas < 5)                                       //Las condiciones que se ponen al juego para ganar o perder
                    {
                        Console.Write("Quiere tomar otra carta? \nPresione la tecla A para tomar la carta y cualquier otra para salir: ");
                        opc = Console.ReadLine().ToUpper();
                        if (opc != "A") { Perdidas = Perdidas + 1; Console.WriteLine("Usted Perdio"); }
                    }
                    else if (NoDeCartas == 5)
                    {
                        if (Suma <= 21) { Console.WriteLine("Usted Gano"); Victoria = Victoria + 1; }
                        else { Console.WriteLine("Usted perdio"); Perdidas = Perdidas + 1; }
                    }
                    else if (Suma == 21) { Console.WriteLine("Usted Gano"); Victoria = Victoria + 1; }
                    else { Console.WriteLine("Usted Perdio"); Perdidas = Perdidas + 1; }
                }
                while (opc == "A" && Suma < 21 && NoDeCartas < 5);

                Console.WriteLine("Quiere jugar de nuevo? \nPresione la tecla A para si y cualquier otra tecla para no"); Sigue = Console.ReadLine().ToUpper();
                Volver();                                                                //Limpia los datos
                }
            Console.WriteLine("Marcador: \n Partidas ganadas: {0}       Partidas perdidas: {1}", Victoria, Perdidas);  //Despliega la cantidad de derrotas y ganadas totales
            }
        }
}
