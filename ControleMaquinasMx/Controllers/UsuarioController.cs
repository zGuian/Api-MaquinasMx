using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_DomainShared.UsuarioDtos;
using ControleMaquinasMx_Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleMaquinasMx.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices userServices;

        public UsuarioController(IUsuarioServices manager)
        {
            this.userServices = manager;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var usuarioLogado = await userServices.ValidaUserGeraTokenAsync(usuario);
            if (usuarioLogado != null)
            {
                return Ok(usuarioLogado);
            }
            return Unauthorized();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Comum, Visualizador")]
        public async Task<IActionResult> GetUser()
        {
            string login = User.Identity.Name;
            var usuario = await userServices.GetAsync(login);
            return Ok(usuario);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PostUser(NovoUsuarioDto user)
        {
            var userInsert = await userServices.InsertAsync(user);
            return CreatedAtAction(nameof(GetUser), new { login = user.Login }, userInsert);
        }

        [HttpPut]
        [Authorize(Roles = "Administrator, Comum, Visualizador")]
        public async Task<IActionResult> PutUser(Usuario usuario)
        {
            var userUpdate = await userServices.UpdateAsync(usuario);
            return Ok(userUpdate);
        }

        /// <summary>
        /// NÃO TÁ FUNCIONANDO -> REVISAR CODIGO
        /// </summary>
        [HttpPut("Recupera")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RecuperaSenha([FromBody] AtualizaUsuarioDto usuario)
        {
            var userRecuperado = await userServices.RecuperaSenhaAsync(usuario);
            return Ok(userRecuperado);
        }
    }
}
