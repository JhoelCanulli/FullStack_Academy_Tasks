using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ASP_WEB_impiegati.Models
{
    [Table("Impiegato")]
    public class Impiegato
    {
        public int ImpiegatoID { get; set; }
        public string Matricola { get; set; } = Guid.NewGuid().ToString().ToUpper();
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public string Dnascita { get; set; } = null!;
        public string Ruolo { get; set; } = null!;

        public int? ResidenzaRIF { get; set; }
        [JsonIgnore]
        public Residenza? Residenza { get; set; }

        public int? RepartoRIF { get; set; }
        [JsonIgnore]
        public Reparto? Reparto { get; set; }
    }
}
