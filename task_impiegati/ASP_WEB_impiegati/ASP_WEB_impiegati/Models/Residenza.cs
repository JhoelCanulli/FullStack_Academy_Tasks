using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_WEB_impiegati.Models
{
    [Table("Residenza")]
    public class Residenza
    {
        public int ResidenzaID { get; set; }
        public string Codice { get; set; } = Guid.NewGuid().ToString().ToUpper();
        public string Citta { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Via { get; set; } = null!;
        public List<Impiegato>? Impiegati { get; set; } = new List<Impiegato>();
    }
}
