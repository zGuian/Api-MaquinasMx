using ControleMaquinasMx_DomainShared.PermissaoDtos;

namespace ControleMaquinasMx_DomainShared.UsuarioDtos
{
    public class UsuarioLogadoDto
    {
        public string Login { get; set; }
        public ICollection<PermissaoViewDto> Permissao { get; set; }
        public string Token { get; set; }
    }
}
