using AutoMapper;
using ControleMaquinasMx.Data.Data;
using ControleMaquinasMx_Domain.Entities;
<<<<<<< HEAD
using ControleMaquinasMx_Application.Interfaces;
=======
using ControleMaquinasMx_Manager.Interfaces;
>>>>>>> 308e5005a50f7d6fde5093bb06843c7b21726ab4
using Microsoft.EntityFrameworkCore;

namespace ControleMaquinasMx_Data.Services
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Usuario>> GetUsersAsync()
        {
            var users = await _context.Usuarios.AsNoTracking().ToListAsync();
            if (!users.Any())
            {
                return Enumerable.Empty<Usuario>();
            }
            return users;
        }

        public async Task<Usuario> GetUsersAsync(string login)
        {
            var user = await _context.Usuarios.AsNoTracking().Include(x => x.Permissao)
                .SingleOrDefaultAsync(x => x.Login == login);
            if (user == null)
            {
                return null!;
            }
            return user;
        }

        public async Task<Usuario> CreateUserAsync(Usuario user)
        {
            await InsertUserFunction(user);
            await _context.Usuarios.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private async Task InsertUserFunction(Usuario user)
        {
            var funcaoConsultas = new List<Permissao>();
            foreach (var funcao in user.Permissao)
            {
                var funcaoConsultada = await _context.Permissoes.FindAsync(funcao.Id);
                funcaoConsultas.Add(funcaoConsultada);
            }
            user.Permissao = funcaoConsultas;
        }

        public async Task<Usuario> UpdateUserAsync(Usuario user)
        {
            var userData = await _context.Usuarios.FindAsync(user.Login);
            if (userData == null)
            {
                return null!;
            }
            _context.Entry(userData).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return userData;
        }

        public async Task<Usuario> RecuperaUserAsync(Usuario user)
        {
            var userData = await _context.Usuarios.FindAsync(user.Login);
            if (userData == null)
            {
                return null!;
            }
            _context.Entry(userData.Senha).CurrentValues.SetValues(user.Senha);
            await _context.SaveChangesAsync();
            return userData;
        }
    }
}
