using AutoMapper;
using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_DomainShared.UsuarioDtos;
using ControleMaquinasMx_Application.Interfaces;
using ControleMaquinasMx_Application.Security;
using Microsoft.AspNetCore.Identity;

namespace ControleMaquinasMx_Application.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository repository;
        private readonly IMapper mapper;
        private readonly IJWTService jwt;

        public UsuarioServices(IUsuarioRepository repository, IMapper mapper, IJWTService jwtService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.jwt = jwtService;
        }

        public async Task<IEnumerable<UsuarioViewDto>> GetAsync()
        {
            return mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewDto>>(await repository.GetUsersAsync());
        }

        public async Task<UsuarioViewDto> GetAsync(string login)
        {
            return mapper.Map<UsuarioViewDto>(await repository.GetUsersAsync(login));
        }

        public async Task<UsuarioViewDto> InsertAsync(NovoUsuarioDto novoUsuario)
        {
            var user = mapper.Map<Usuario>(novoUsuario);
            ServiceSecurity.ConvertSenhaEmHash(user);
            user = await repository.CreateUserAsync(user);
            return mapper.Map<UsuarioViewDto>(user);
        }

        public async Task<UsuarioViewDto> UpdateAsync(Usuario usuario)
        {
            ServiceSecurity.ConvertSenhaEmHash(usuario);
            return mapper.Map<UsuarioViewDto>(await repository.UpdateUserAsync(usuario));
        }

        public async Task<UsuarioLogadoDto> ValidaUserGeraTokenAsync(Usuario usuario)
        {
            var userConsultado = await repository.GetUsersAsync(usuario.Login);
            if (userConsultado == null)
            {
                return null!;
            }
            var temp = await ServiceSecurity.ValidaAtualizaHashAsync(usuario, userConsultado.Senha);
            if (temp)
            {
                var userLogado = mapper.Map<UsuarioLogadoDto>(userConsultado);
                userLogado.Token = jwt.GerarToken(userConsultado);
                return userLogado;
            }
            return null!;
        }

        public async Task<bool> ValidaAtualizaHashAsync(Usuario usuario, string hash)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            var status = passwordHasher.VerifyHashedPassword(usuario, hash, usuario.Senha);
            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    await UpdateAsync(usuario);
                    return true;
                default:
                    throw new InvalidOperationException();
            }
        }

        public async Task<AtualizaUsuarioDto> RecuperaSenhaAsync(AtualizaUsuarioDto usuario)
        {
            var userConvert = mapper.Map<Usuario>(usuario);
            await repository.RecuperaUserAsync(userConvert);
            await ValidaUserGeraTokenAsync(userConvert);
            return mapper.Map<AtualizaUsuarioDto>(userConvert);
        }
    }
}
