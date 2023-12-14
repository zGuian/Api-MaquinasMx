using ControleMaquinasMx_CoreShared.PermissaoDtos;

namespace ControleMaquinasMx_CoreShared.UsuarioDtos
{
    public class UsuarioLogadoDto
    {
        public string Login { get; set; }
        public ICollection<PermissaoViewDto> Permissao { get; set; }
        public string Token { get; set; }
    }
}
