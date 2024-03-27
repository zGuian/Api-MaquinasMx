using ControleMaquinasMx_Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace ControleMaquinasMx_Domain.Entities
{
    public class Maquina
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Inventario Obrigatorio")]
        public string? Inventario { get; set; }

        [Required(ErrorMessage = "Hostname obrigatoria")]
        public string? Hostname { get; set; }

        [Required(ErrorMessage = "Informação obrigatoria")]
        public bool Ondeso { get; set; }

        [Required(ErrorMessage = "Defina uma criticidade para maquina")]
        public Criticidade Criticidade { get; set; }

        [DisplayFormat(DataFormatString = "{0:/dd/MM/yyyy HH:mm}")]
        [DataType(DataType.DateTime)]
        public DateTime? DataCadastro { get; set; }

        [DisplayFormat(DataFormatString = "{0:/dd/MM/yyyy HH:mm}")]
        [DataType(DataType.DateTime)]
        public DateTime? UltimaAtualizacao { get; set; }
        public virtual ICollection<Pacote>? Pacotes { get; set; }
    }
}
