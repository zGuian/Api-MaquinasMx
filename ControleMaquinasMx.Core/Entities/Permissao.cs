namespace ControleMaquinasMx_Domain.Entities
{
    public class Permissao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}