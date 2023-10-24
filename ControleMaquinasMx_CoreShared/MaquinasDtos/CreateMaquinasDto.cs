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

        [Required]
        public byte Criticidade { get; set; }
        public DateTime? DataCadastro => DateTime.Now.Date;
    }
}
