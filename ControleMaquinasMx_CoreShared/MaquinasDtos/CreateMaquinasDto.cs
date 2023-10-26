using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.PacotesDtos;
using System.ComponentModel.DataAnnotations;

namespace ControleMaquinasMx_CoreShared.Dtos
{
    public class CreateMaquinasDto
    {
        /// <summary>
        /// Inventario do equipamento que deseja cadastrar
        /// </summary>
        [Required(ErrorMessage = "Inventario Obrigatorio")]
        public string? Inventario { get; set; }

        /// <summary>
        /// Hostname do equipamento que deseja cadastrar
        /// </summary>
        [Required(ErrorMessage = "Hostname obrigatoria")]
        public string? Hostname { get; set; }

        /// <summary>
        /// Informe se o equipamento possui ondeso atualizado
        /// </summary>
        [Required(ErrorMessage = "Informação obrigatoria")]
        public bool Ondeso { get; set; }

        [Required]
        public byte Criticidade { get; set; }
        public DateTime DataCadastro => DateTime.Now;
        public ICollection<CreatePacotesDto>? Pacotes { get; set; }
    }
}
