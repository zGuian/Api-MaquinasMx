using System.ComponentModel.DataAnnotations;

namespace ControleMaquinasMx.Core.Models
{
    public class Maquinas
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

        [Range(1, 3)]
        [MaxLength(1)]
        public char Criticidade { get; set; }

        [DisplayFormat(DataFormatString = "{0:/dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime? DataCadastro { get; set; }

        [DisplayFormat(DataFormatString = "{0:/dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime? UltimaAtualizacao { get; set; }
    }
}
