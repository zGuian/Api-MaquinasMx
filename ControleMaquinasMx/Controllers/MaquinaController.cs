using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;
using ControleMaquinasMx_Manager.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleMaquinasMx.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MaquinaController : Controller
    {
        private readonly IMaquinasManager _maquinasManager;
        private readonly ILogger<MaquinaController> _logger;

        public MaquinaController(IMaquinasManager maquinasManager, ILogger<MaquinaController> logger)
        {
            _maquinasManager = maquinasManager;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Comum, Visualizador")]
        [ProducesResponseType(typeof(MaquinaViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscaTodasMaquinas()
        {
            _logger.LogInformation("Foi solicitado um request de todas as maquinas cadastradas ");
            var result = await _maquinasManager.SearchMaquinasAsync();
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetId/{id}")]
        [Authorize(Roles = "Administrator, Comum, Visualizador")]
        [ProducesResponseType(typeof(MaquinaViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarMaquinaPorId(int id)
        {
            _logger.LogInformation($"Foi solicitado um request da máquina com seguinte ID: {id}");
            var result = await _maquinasManager.SearchMaquinasAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Comum")]
        [ProducesResponseType(typeof(MaquinaViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarMaquinas(NovaMaquinaDto maquinaDto)
        {
            _logger.LogInformation("Foi requisitado um novo cadastro de maquinas.");
            var result = await _maquinasManager.InsertMaquinasAsync(maquinaDto);
            if (result == null)
            {
                return BadRequest("Não foi possivel cadastrar a maquina. Consulte os paramentros enviados: " + maquinaDto);
            }
            var resp = CreatedAtAction(nameof(BuscarMaquinaPorId), new { id = result.Id }, result);
            return Ok(resp);
        }

        [HttpPut("Update/{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(MaquinaViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarMaquina([FromBody] AlteraMaquinaDto maquinasDto, int id)
        {
            _logger.LogInformation("Solicitado atualização de maquinas");
            var result = await _maquinasManager.UpdateMaquinasAsync(maquinasDto, id);
            if (result == null)
            {
                return NotFound($"Não foi possivel atualizar a maquina. Id não encontrado:\nId enviado: {id}");
            }
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(MaquinaViewDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _maquinasManager.DeleteMaquinasAsync(id);
            if (result == false)
            {
                return NotFound("Não foi possivel deletar a maquina. Id não encontrado");
            }
            return Ok("Maquina excluida com sucesso");
        }
    }
}
