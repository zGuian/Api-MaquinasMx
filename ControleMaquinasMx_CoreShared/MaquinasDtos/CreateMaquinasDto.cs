using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_Core.Models.Enum;
using ControleMaquinasMx_CoreShared.PacotesDtos;
using System.ComponentModel.DataAnnotations;

namespace ControleMaquinasMx_CoreShared.Dtos
{
    public class CreateMaquinasDto
    {
        [Required(ErrorMessage = "Inventario Obrigatorio")]
        public string? Inventario { get; set; }

        [Required(ErrorMessage = "Hostname obrigatoria")]
        public string? Hostname { get; set; }

        [Required(ErrorMessage = "Informação obrigatoria")]
        public bool Ondeso { get; set; }

        [Required(ErrorMessage = "Defina uma criticidade para maquina")]
        public Criticidade Criticidade { get; set; }
        public DateTime DataCadastro => DateTime.Now;
    }
}
