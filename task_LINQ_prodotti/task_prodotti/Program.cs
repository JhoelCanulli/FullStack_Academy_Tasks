using System.Text.RegularExpressions;
using task_prodotti.Classes;

namespace task_prodotti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Creare una lista di prodotti caratterizzati da :
             * - Nome
             * - Descrizione
             * - Prezzo
             * - Categoria
             * - Quantità
             * 
             * Inserire un numero n di prodotti:
             * - Mandare in output tutti i prodotti di una certa categoria
             * - Calcolare il prezzo medio dei prodotti
             * - Riepilogare le quantità numeriche per categoria di prodotto
             * - Creare un report del valore del negozio calcolato come "quantità x prezzo" di ogni prodotto
             */

            List<Prodotto> elenco = new List<Prodotto>()
            {
                new Prodotto(){Nome = "Penna", Descrizione = "Nere", Prezzo = 3.50f, Categoria = "Cartoleria", Quantita = 2},
                new Prodotto(){Nome = "Acquario", Descrizione = "Piccolo", Prezzo = 35.20f, Categoria = "Animali", Quantita = 5},
                new Prodotto(){Nome = "Telefono", Descrizione = "Cinese", Prezzo = 110.50f, Categoria = "Elettronica", Quantita = 6},
                new Prodotto(){Nome = "Matita", Descrizione = "Normale", Prezzo = 1.00f, Categoria = "Cartoleria", Quantita = 8}
            };

            #region PRODOTTI PER CATEGORIA
            /*
            var risultato = from oggetto in elenco
                            where oggetto.Categoria == "Cartoleria"
                            select oggetto;
            
            // var risultato = elenco.Where(p => p.Categoria == "Cartoleria"); -> versione alternativa
            foreach (var p in risultato)
            {
                Console.WriteLine(p.stampaProdotto());
            }
            */
            #endregion

            #region PREZZO MEDIO
            /*
            var risultato = from oggetto in elenco
                            select oggetto.Prezzo;

            Console.WriteLine($"Prezzo medio {elenco.Average(s => s.Prezzo)}");
            */
            #endregion

            #region QUANTITA CATEGORIA
            /*
            int somma_quantita;
            var risultato = from oggetto in elenco
                            group oggetto by oggetto.Categoria into contenitoreGenere
                            select contenitoreGenere;

            foreach (var genere in risultato)
            {
                somma_quantita = 0;
                Console.WriteLine(genere.Key);
                foreach (Prodotto p in genere)
                {
                    Console.WriteLine(p.stampaProdotto());
                    somma_quantita = somma_quantita + p.Quantita;
                }
                Console.WriteLine($"quantita : {somma_quantita}\n");
            }

            */
            #endregion
            /*
            #region QUANTITA PRODOTTO E VALORE NEGOZIO
           
            var total = from prod in elenco
                        where prod.Quantita > 0
                        select new { prod.Prezzo, prod.Quantita };
            Console.WriteLine(total.Sum(p => p.Quantita * p.Prezzo));
            */
            #endregion
        }
    }
}
