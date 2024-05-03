using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestore_prestiti_libri.Models
{
    internal class Prestito
    {
        public int Id { get; set; } 
        public DateTime DataPrestito { get; set; }
        public DateTime DataRitorno { get; set; }
        public string? codice { get; set; }
        public Utente? UtenteRIF { get; set; }
        public Libro? LibroRIF { get; set; }    //nullable perchè nel momento della creazione non hanno ancora un valore assegnato dal database

        public Prestito() { }

        public Prestito(int id, DateTime dataPrestito, DateTime dataRitorno, Utente utenteRIF, Libro libroRIF)
        {
            Id = id;
            DataPrestito = dataPrestito;
            DataRitorno = dataRitorno;
            UtenteRIF = utenteRIF;
            LibroRIF = libroRIF;
        }
    }
}
