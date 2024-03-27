using ControleMaquinasMx_DomainShared.PacotesDtos;
using ControleMaquinasMx_Manager.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleMaquinasMx.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PacoteController : Controller
    {
        private readonly IPacotesManager _pacotesManager;

        public PacoteController(IPacotesManager pacotesManager)
        {
            _pacotesManager = pacotesManager;
        }

        [HttpGet]
        //[Authorize(Roles = "Administrator, Comum, Visualizador")]
        [ProducesResponseType(typeof(PacoteViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscaTodosPacotes()
        {
            var result = await _pacotesManager.SearchPacotesAsync();
            if (result == null)
            {
                return NotFound("Não encontrado nenhum pacote");
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetId/{id}")]
        //[Authorize(Roles = "Administrator, Comum, Visualizador")]
        [ProducesResponseType(typeof(PacoteViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscaPacotesPorId(int id)
        {
            var result = await _pacotesManager.SearchPacotesIdAsync(id);
            if (result == null)
            {
                return NotFound($"Maquina não encontrada \nconsulte o ID: {id} enviado");
            }
            return Ok(result);
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> AdicionaPacote([FromBody] NovoPacoteDto pacoteDto)
        {
            var result = await _pacotesManager.InsertPacotesAsync(pacoteDto);
            if (result == null)
            {
                return NotFound("Não foi possivel cadastrar a maquina. Consulte os paramentros enviados: " + pacoteDto.NomeKb);
            }
            var resp = CreatedAtAction(nameof(BuscaPacotesPorId), new { id = result.Id }, result);
            return Ok(resp);
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(PacoteViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarPacote([FromBody] AlteraPacoteDto pacoteDto, int id)
        {
            var result = await _pacotesManager.UpdatePacotesAsync(pacoteDto, id);
            if (result == null)
            {
                return NotFound($"Não foi possivel atualizar a maquina. Id não encontrado: \nId enviado: {id}");
            }
            return Ok(result);
        }

        [HttpDelete]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(PacoteViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePacote(int id)
        {
            var result = await _pacotesManager.DeletePacoteAsync(id);
            if (result == false)
            {
                return NotFound("Não foi possivel deletar a maquina. Id não encontrado");
            }
            return Ok("Maquina excluida com sucesso");
        }
    }
}
