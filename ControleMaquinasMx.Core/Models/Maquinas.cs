using ControleMaquinasMx_Core.Models;
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

        [Required(ErrorMessage = "Defina uma criticidade para maquina")]
        public byte Criticidade { get; set; }

        [DisplayFormat(DataFormatString = "{0:/dd/MM/yyyy HH:mm}")]
        [DataType(DataType.DateTime)]
        public DateTime? DataCadastro { get; set; }

        [DisplayFormat(DataFormatString = "{0:/dd/MM/yyyy HH:mm}")]
        [DataType(DataType.DateTime)]
        public DateTime? UltimaAtualizacao { get; set; }
        public int PacotesId { get; set; }
        public ICollection<Pacotes> Pacotes { get; set; }
    }
}
