using gest_paninoteca.Models;

namespace gest_paninoteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorePanino gest = new GestorePanino();

            bool risultato = gest.insert(new Panino()
            {
                Nome = "ER BONACCIONE",
                Descrizione = "Bono fracico",
                Prezzo = 15.4f,
                IsVegan = false
            });

            if (risultato)
                Console.WriteLine("Inserirto");
            else Console.WriteLine("Errore");

            List<Panino> menu = gest.findAll();

            /*
            var paniniVegani = from panino in menu
                               where panino.IsVegan == true
                               select panino;
            */
            var paniniVegani = menu.Where(p => p.IsVegan == true);

            Console.WriteLine(menu.Count);

            foreach(Panino p in menu)
            {
                Console.WriteLine(p);
            }
        }
    }
}
