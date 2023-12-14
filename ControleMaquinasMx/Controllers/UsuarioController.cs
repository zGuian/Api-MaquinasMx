using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.UsuarioDtos;
using ControleMaquinasMx_Manager.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleMaquinasMx.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioManager _manager;

        public UsuarioController(IUsuarioManager manager)
        {
            _manager = manager;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var usuarioLogado = await _manager.ValidaUserGeraTokenAsync(usuario);
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
            var usuario = await _manager.GetAsync(login);
            return Ok(usuario);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PostUser(NovoUsuarioDto usuario)
        {
            var usuarioInsert = await _manager.InsertAsync(usuario);
            return CreatedAtAction(nameof(GetUser), new { login = usuario.Login }, usuarioInsert);
        }

        [HttpPut]
        [Authorize(Roles = "Administrator, Comum, Visualizador")]
        public async Task<IActionResult> PutUser(Usuario usuario)
        {
            var userUpdate = await _manager.UpdateAsync(usuario);
            return Ok(userUpdate);
        }

        /// <summary>
        /// NÃO TÁ FUNCIONANDO -> REVISAR CODIGO
        /// </summary>
        [HttpPut("Recupera")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RecuperaSenha([FromBody] AtualizaUsuarioDto usuario)
        {
            var userRecuperado = await _manager.RecuperaSenhaAsync(usuario);
            return Ok(userRecuperado);
        }
    }
}
