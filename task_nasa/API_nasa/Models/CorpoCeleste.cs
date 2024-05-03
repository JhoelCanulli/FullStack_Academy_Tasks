using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_nasa.Models
{
    [Table("CorpoCeleste")]
    public class CorpoCeleste
    {
        public int CorpoID { get; set; }
        public string? Codice_corpo { get; set; } = null!;
        public string? Nome_corpo { get; set; } = null!;
        public string? Tipo_corpo { get; set; } = null!;
        public string? Scopritore { get; set; } = "Sconosciuto";
        public DateOnly? Data_scoperta { get; set; }
        public decimal? Distanza_da_terra { get; set; }
        public decimal? CoordinataRadiale { get; set; }
        public decimal? CoordinataAngolare { get; set; }
        public IEnumerable<Corpo_Sistema> ElencoCorSis { get; set; } = new List<Corpo_Sistema>();
    }
}
