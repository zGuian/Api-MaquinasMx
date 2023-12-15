using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;

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
        public async Task<IActionResult> AdicionarMaquinas(CreateMaquinasDto maquinaDto)
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
        public async Task<IActionResult> AtualizarMaquina([FromBody] UpdateMaquinasDto maquinasDto, int id)
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
