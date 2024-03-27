using System.ComponentModel.DataAnnotations;

namespace ControleMaquinasMx_Domain.Entities
{
    public class Usuario
    {
        [Key]
        public string Login { get; set; }
        public string Senha { get; set; }
        public ICollection<Permissao> Permissao { get; set; }

        public Usuario()
        {
            Permissao = new HashSet<Permissao>();
        }
    }
}
