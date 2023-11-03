using ControleMaquinasMx.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace ControleMaquinasMx_Core.Models
{
    public class Pacotes
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? NomeKb { get; set; }
        public int? MaquinasId { get; set; }
        public Maquinas? Maquinas { get; set; }
        public DateTime DataInstalacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
