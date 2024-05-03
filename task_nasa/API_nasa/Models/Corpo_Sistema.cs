using System.Text.Json.Serialization;

namespace API_nasa.Models
{
    public class Corpo_Sistema
    {
        [JsonIgnore]
        public CorpoCeleste cor { get; set; } = null!;
        public Sistema sis { get; set; } = null!;

        [JsonIgnore]
        public int CorpoRIF { get; set; }
        public int SistemaRIF { get; set; }
    }
}
