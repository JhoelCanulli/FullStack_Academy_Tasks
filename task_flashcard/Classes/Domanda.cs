using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flashcard_colloquio.Classes
{
    using System;

    public class Domanda
    {
        public int Id { get; set; }
        public string? Testo { get; set; }
        public string? Genere { get; set; }

        public Domanda(int id, string? testo, string? genere)
        {
            Id = id;
            Testo = testo;
            Genere = genere;
        }
    }

}
