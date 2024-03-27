namespace ControleMaquinasMx_DomainShared.UsuarioDtos
{
    public class NovoUsuarioDto
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public ICollection<ReferenciaPermissaoDto> Permissao { get; set; }
    }
}
