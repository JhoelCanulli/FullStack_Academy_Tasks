using API_torneo_Mario.Models;

namespace API_torneo_Mario.DTO
{
    public class PersonaggioDTO
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Cate { get; set; } = null!;
        public int Cred { get; set; }
        public SquadraDTO? Squa { get; set; }
    }

}
