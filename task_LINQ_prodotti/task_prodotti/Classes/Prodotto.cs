using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_prodotti.Classes
{
    internal class Prodotto
    {
        public string? Nome { get; set; }
        public string? Descrizione { get; set; }
        public float Prezzo { get; set; }
        public string? Categoria { get; set; }
        public int Quantita { get; set; }

        public string? stampaProdotto()
        {
            return $"{Nome} {Descrizione} {Prezzo} {Categoria} {Quantita}";
        }
    }
}
