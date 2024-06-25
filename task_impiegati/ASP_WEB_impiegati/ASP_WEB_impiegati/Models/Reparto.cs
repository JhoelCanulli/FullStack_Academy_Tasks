using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_WEB_impiegati.Models
{
    [Table("Reparto")]
    public class Reparto
    {
        public int RepartoID { get; set; }
        public string Codice { get; set; } = Guid.NewGuid().ToString().ToUpper();
        public string Nome { get; set; } = null!;
        public List<Impiegato>? Impiegati { get; set; } = new List<Impiegato>();

    }
}
