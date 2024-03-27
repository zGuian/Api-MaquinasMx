using ControleMaquinasMx_DomainShared.PermissaoDtos;

namespace ControleMaquinasMx_DomainShared.UsuarioDtos
{
    public class UsuarioViewDto
    {
        public string? Login { get; set; }
        public ICollection<PermissaoViewDto> Permissao { get; set; }
    }
}
