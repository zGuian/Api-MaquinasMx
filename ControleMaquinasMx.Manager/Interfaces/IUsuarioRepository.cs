using ControleMaquinasMx_Domain.Entities;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsersAsync();
        Task<Usuario> GetUsersAsync(string login);
        Task<Usuario> CreateUserAsync(Usuario user);
        Task<Usuario> UpdateUserAsync(Usuario user);
        Task<Usuario> RecuperaUserAsync(Usuario user);
    }
}
