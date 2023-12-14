using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_Manager.Interfaces;
using ControleMaquinasMx_CoreShared.UsuarioDtos;

namespace ControleMaquinasMx_Manager.Implementation
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly IJWTService _jwt;

        public UsuarioManager(IUsuarioRepository repository, IMapper mapper, IJWTService jwtService)
        {
            _repository = repository;
            _mapper = mapper;
            _jwt = jwtService;
        }

        public async Task<IEnumerable<UsuarioViewDto>> GetAsync()
        {
            return _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewDto>>(await _repository.GetUsersAsync());
        }

        public async Task<UsuarioViewDto> GetAsync(string login)
        {
            return _mapper.Map<UsuarioViewDto>(await _repository.GetUsersAsync(login));
        }

        public async Task<UsuarioViewDto> InsertAsync(NovoUsuarioDto novoUsuario)
        {
            var user = _mapper.Map<Usuario>(novoUsuario);
            ConvertSenhaEmHash(user);
            user = await _repository.CreateUserAsync(user);
            return _mapper.Map<UsuarioViewDto>(user);
        }

        public void ConvertSenhaEmHash(Usuario usuario)
        {
            var senhaHasher = new PasswordHasher<Usuario>();
            usuario.Senha = senhaHasher.HashPassword(usuario, usuario.Senha);
        }

        public async Task<UsuarioViewDto> UpdateAsync(Usuario usuario)
        {
            ConvertSenhaEmHash(usuario);
            return _mapper.Map<UsuarioViewDto>(await _repository.UpdateUserAsync(usuario));
        }

        public async Task<UsuarioLogadoDto> ValidaUserGeraTokenAsync(Usuario usuario)
        {
            var userConsultado = await _repository.GetUsersAsync(usuario.Login);
            if (userConsultado == null)
            {
                return null!;
            }
            var temp = await ValidaAtualizaHashAsync(usuario, userConsultado.Senha);
            if (temp)
            {
                var userLogado = _mapper.Map<UsuarioLogadoDto>(userConsultado);
                userLogado.Token = _jwt.GerarToken(userConsultado);
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
            var userConvert = _mapper.Map<Usuario>(usuario);
            await _repository.RecuperaUserAsync(userConvert);
            return _mapper.Map<AtualizaUsuarioDto>(userConvert);
        }
    }
}
