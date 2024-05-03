using API_nasa.Models;

namespace API_nasa.DTO
{
    public class SistemaDTO
    {
        public string? Code { get; set; } = null!;
        public string? Name { get; set; } = null!;
        public string? Type { get; set; } = null!;
        public IEnumerable<CorSisDTO> List { get; set; } = new List<CorSisDTO>();
    }
}
