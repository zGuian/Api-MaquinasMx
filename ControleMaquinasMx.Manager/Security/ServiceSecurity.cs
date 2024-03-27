using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_Manager.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ControleMaquinasMx_Application.Security
{
    public static class ServiceSecurity
    {
        private static readonly IUsuarioServices manager;

        public static void ConvertSenhaEmHash(Usuario usuario)
        {
            var senhaHasher = new PasswordHasher<Usuario>();
            usuario.Senha = senhaHasher.HashPassword(usuario, usuario.Senha);
        }

        public static async Task<bool> ValidaAtualizaHashAsync(Usuario usuario, string hash)
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
                    await manager.UpdateAsync(usuario);
                    return true;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
