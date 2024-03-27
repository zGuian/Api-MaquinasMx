using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleMaquinasMx_Domain.Entities
{
    public class Pacote
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? NomeKb { get; set; }

        [ForeignKey("MaquinasId")]
        public int? MaquinasId { get; set; }
        public virtual Maquina? Maquinas { get; set; }
        public DateTime? DataInstalacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
