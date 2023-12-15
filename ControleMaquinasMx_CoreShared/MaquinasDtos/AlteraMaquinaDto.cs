using ControleMaquinasMx_Core.Models.Enum;
<<<<<<< HEAD
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
=======
using ControleMaquinasMx_CoreShared.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ControleMaquinasMx_CoreShared.MaquinasDtos
{
    public class AlteraMaquinaDto : NovaMaquinaDto
    {
        public int Id { get; set; }
        public DateTime? UltimaAtualizacao => DateTime.Now;
>>>>>>> 794a33a3b7cfbc18145de5b9a53a2f8c0ec6efad
    }
}
