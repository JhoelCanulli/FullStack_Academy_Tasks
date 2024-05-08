using flashcard_colloquio.Classes;
using System;
using System.Collections.Generic;

namespace flashcard_colloquio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("|-------------------|");
            Console.WriteLine("| Domande Colloquio |");
            Console.WriteLine("|-------------------|\n\n");

            Menu menu = new Menu();
            menu.MostraMenu();
        }
    }

}
