using API_nasa.Models;

namespace API_nasa.DTO
{
    public class CorpoDTO
    {

        public string? Code { get; set; } = null!;
        public string? Name { get; set; } = null!;
        public string? Type { get; set; } = null!;
        public string? Disc {  get; set; }
        public DateOnly? DDis { get; set; }
        public decimal? Dist { get; set; }
        public decimal? Radi { get; set; }
        public decimal? Angu { get; set; }
        public IEnumerable<CorSisDTO> List { get; set; } = new List<CorSisDTO>();
    }
}
