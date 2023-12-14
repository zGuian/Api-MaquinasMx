using ControleMaquinasMx_Core.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleMaquinasMx_Core.Models
{
    public class Permissao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}