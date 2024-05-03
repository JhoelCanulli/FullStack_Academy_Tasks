using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestore_prestiti_libri.Models
{
    internal class Utente 
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Email { get; set; }
        public string? Codice { get; set; }

        public List<Prestito>? ElencoPrestiti { get; set; } = new List<Prestito>();

        public Utente()
        {

        }
        public Utente(int id, string? nome, string? cognome, string? email)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Email = email;
        }
    }
}
