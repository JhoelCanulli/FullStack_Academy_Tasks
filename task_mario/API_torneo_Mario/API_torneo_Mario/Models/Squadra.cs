using System.ComponentModel.DataAnnotations.Schema;

namespace API_torneo_Mario.Models
{
    [Table("Squadra")]
    public class Squadra
    {
        public int SquadraID { get; set; }
        public string CodiceS { get; set; } = Guid.NewGuid().ToString().ToUpper();
        public string NomeS { get; set; } = null!;
        public int Budget { get; set; } = 10;
        public List<Personaggio> Personaggi { get; set;  } = new List<Personaggio>();
    }
}