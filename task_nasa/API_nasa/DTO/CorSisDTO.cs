using API_nasa.Models;
using System.Text.Json.Serialization;

namespace API_nasa.DTO
{
    public class CorSisDTO
    {
        [JsonIgnore]
        public CorpoCeleste co { get; set; } = null!;
        public Sistema si { get; set; } = null!;

        [JsonIgnore]
        public int CoRIF { get; set; }
        public int SiRIF{ get; set; }
    }
}
