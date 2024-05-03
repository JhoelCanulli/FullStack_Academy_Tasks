using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestore_prestiti_libri.Models
{
    internal class Libro : Prestito
    {
        public int Id { get; set; }
        public string? Titolo { get; set; }
        public DateTime AnnoPubblicazione { get; set; }

        public bool HasStatoDisponibilita { get; set; }
        public string? Isbn { get; set; }

        public List<Prestito>? ElencoPrestiti { get; set; } = new List<Prestito>();

        public Libro() { }
        public Libro(int id, string? titolo, DateTime annoPubblicazione, bool hasStatoDisponibilita)
        {
            Id = id;
            Titolo = titolo;
            AnnoPubblicazione= annoPubblicazione;
            HasStatoDisponibilita = hasStatoDisponibilita;
        }
    }
}
