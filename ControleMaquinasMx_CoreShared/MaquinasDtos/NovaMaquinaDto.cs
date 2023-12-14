using ControleMaquinasMx_Core.Models.Enum;
using ControleMaquinasMx_CoreShared.PacotesDtos;
using System.ComponentModel.DataAnnotations;

namespace ControleMaquinasMx_CoreShared.Dtos
{
    /// <summary>
    /// Objeto utilizado para adicionar nova maquina
    /// </summary>
    public class NovaMaquinaDto
    {
        /// <summary>
        /// Inventario do equipamento
        /// </summary>
        /// <example>J0000000</example>
        [Required(ErrorMessage = "Inventario Obrigatorio")]
        public string? Inventario { get; set; }

        /// <summary>
        /// Hostname do equipamento
        /// </summary>
        /// <exemple>M154DSX00000</exemple>
        [Required(ErrorMessage = "Hostname obrigatoria")]
        public string? Hostname { get; set; }

        /// <summary>
        /// Informação se tem Ondeso
        /// </summary>
        /// <example>true</example>
        [Required(ErrorMessage = "Informação obrigatoria")]
        public bool Ondeso { get; set; }

        /// <summary>
        /// Criticidade do equipamento
        /// </summary>
        /// <example>C</example>
        [Required(ErrorMessage = "Defina uma criticidade para maquina")]
        public Criticidade Criticidade { get; set; }
        public DateTime DataCadastro => DateTime.Now;
        public ICollection<NovoPacoteDto> Pacotes { get; set; }
    }
}
