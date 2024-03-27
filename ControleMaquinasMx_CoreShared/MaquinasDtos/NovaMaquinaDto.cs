using ControleMaquinasMx_Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace ControleMaquinasMx_DomainShared.MaquinasDtos
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

        /// <summary>
        /// Data que cadastrou a maquina
        /// </summary>
        /// <value>Sera sera a data atual</value>
        public DateTime DataCadastro => DateTime.Now;
    }
}
