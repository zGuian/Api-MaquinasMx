using ControleMaquinasMx_CoreShared.PermissaoDtos;

namespace ControleMaquinasMx_CoreShared.UsuarioDtos
{
    public class UsuarioViewDto
    {
        public string? Login { get; set; }
        public ICollection<PermissaoViewDto> Permissao { get; set; }
    }
}
