using ControleMaquinasMx_Core.Models.Enum;
using ControleMaquinasMx_CoreShared.PacotesDtos;

namespace ControleMaquinasMx_CoreShared.MaquinasDtos
{
    public class ReadMaquinasDto
    {
        public int Id { get; set; }
        public string? Inventario { get; set; }
        public string? Hostname { get; set; }
        public bool Ondeso { get; set; }
        public Criticidade Criticidade { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }
        public ICollection<ReadPacotesDto>? Pacotes { get; set; }
    }
}
