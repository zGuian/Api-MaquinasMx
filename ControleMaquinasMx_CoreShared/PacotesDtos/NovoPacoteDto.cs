using System.ComponentModel.DataAnnotations;

namespace ControleMaquinasMx_DomainShared.PacotesDtos
{
    public class NovoPacoteDto
    {

        [Required]
        public string? NomeKb { get; set; }
        public int? MaquinasId { get; set; }
        public DateTime DataInstalacao = DateTime.Now;
    }
}
