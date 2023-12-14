using ControleMaquinasMx_Core.Models.Enum;
using ControleMaquinasMx_CoreShared.PacotesDtos;

namespace ControleMaquinasMx_CoreShared.MaquinasDtos
{
    public class AlteraMaquinaDto
    {
        public string? Inventario { get; set; }
        public string? Hostname { get; set; }
        public bool Ondeso { get; set; }
        public Criticidade Criticidade { get; set; }
        public DateTime? UltimaAtualizacao => DateTime.Now;
        public virtual ICollection<AlteraPacoteDto>? Pacotes { get; set; }
    }
}
