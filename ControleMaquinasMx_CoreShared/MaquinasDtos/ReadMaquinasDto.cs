using ControleMaquinasMx_CoreShared.PacotesDtos;

namespace ControleMaquinasMx_CoreShared.MaquinasDtos
{
    public class ReadMaquinasDto
    {
        public int Id { get; set; }
        public string? Inventario { get; set; }
        public string? Hostname { get; set; }
        public bool Ondeso { get; set; }
        public byte Criticidade { get; set; }
        public DateTime? UltimaAtualizacao { get; }
        public IEnumerable<ReadPacotesDto>? PacotesDto { get; set; }
    }
}
