using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_DomainShared.UsuarioDtos;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IUsuarioManager
    {
        Task<IEnumerable<UsuarioViewDto>> GetAsync();
        Task<UsuarioViewDto> GetAsync(string login);
        Task<UsuarioViewDto> InsertAsync(NovoUsuarioDto novoUsuario);
        Task<UsuarioViewDto> UpdateAsync(Usuario usuario);
        Task<UsuarioLogadoDto> ValidaUserGeraTokenAsync(Usuario usuario);
        Task<AtualizaUsuarioDto> RecuperaSenhaAsync(AtualizaUsuarioDto usuario);
    }
}
