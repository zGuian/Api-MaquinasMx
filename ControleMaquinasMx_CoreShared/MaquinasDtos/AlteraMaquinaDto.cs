using ControleMaquinasMx_Core.Models.Enum;

namespace ControleMaquinasMx_CoreShared.MaquinasDtos
{
    /// <summary>
    /// Objeto utilizado para alterar valores da maquina
    /// </summary>
    public class AlteraMaquinaDto
    {
        public string? Inventario { get; set; }
        public string? Hostname { get; set; }
        public bool Ondeso { get; set; }
        public Criticidade Criticidade { get; set; }
        public DateTime? UltimaAtualizacao => DateTime.Now;
    }
}
