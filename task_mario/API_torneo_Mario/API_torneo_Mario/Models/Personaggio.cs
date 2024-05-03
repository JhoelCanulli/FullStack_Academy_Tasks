using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_torneo_Mario.Models
{
    [Table("Personaggio")]
    public class Personaggio
    {
        public int PersonaggioID { get; set; }
        public string CodiceP { get; set; } = Guid.NewGuid().ToString().ToUpper();
        public string NomeP { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public int Crediti { get; set; }
        public int? SquadraRIF { get; set; }
        [JsonIgnore]
        public Squadra? Squadra { get; set; }
    }
}


