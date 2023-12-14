using ControleMaquinasMx_Core.Models.Enum;
using ControleMaquinasMx_CoreShared.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ControleMaquinasMx_CoreShared.MaquinasDtos
{
    public class AlteraMaquinaDto : NovaMaquinaDto
    {
        public int Id { get; set; }
        public DateTime? UltimaAtualizacao => DateTime.Now;
    }
}
