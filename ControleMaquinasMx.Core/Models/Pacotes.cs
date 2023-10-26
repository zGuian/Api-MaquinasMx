using ControleMaquinasMx.Core.Models;

namespace ControleMaquinasMx_Core.Models
{
    public class Pacotes
    {
        public int Id { get; set; }
        public string? NomeKb { get; set; }
        public int MaquinasId { get; set; }
        public Maquinas? Maquinas { get; set; }
        public DateTime DataInstalacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
