using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_nasa.Models
{
    [Table("Sistema")]
    public class Sistema
    {
        public int SistemaID { get; set; }
        public string? Codice_sistema { get; set; } = null!;
        public string? Nome_sistema { get; set; } = null!;
        public string? Tipo_sistema { get; set; } = null!;
        public IEnumerable<Corpo_Sistema> ElencoCorSis { get; set; } = new List<Corpo_Sistema>();

    }

}
