using API_torneo_Mario.Models;

namespace API_torneo_Mario.DTO
{
    public class SquadraDTO
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Budg { get; set; }
        public ICollection<PersonaggioDTO> ElPe { get; set; } = new List<PersonaggioDTO>();
    }
}
