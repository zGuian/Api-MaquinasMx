using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;
using ControleMaquinasMx_Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleMaquinasMx.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MaquinaController : ControllerBase
    {
        private readonly IMaquinasServices maquinasManager;
        private readonly ILogger<MaquinaController> logger;

        public MaquinaController(IMaquinasServices maquinasManager, ILogger<MaquinaController> logger)
        {
            this.maquinasManager = maquinasManager;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> BuscaTodasMaquinas()
        {
            logger.LogInformation("Foi solicitado um request de todas as maquinas cadastradas ");
            var result = await maquinasManager.SearchMaquinasAsync();
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetId/{id}")]
        public async Task<IActionResult> BuscarMaquinaPorId(int id)
        {
            logger.LogInformation($"Foi solicitado um request da máquina com seguinte ID: {id}");
            var result = await maquinasManager.SearchMaquinasAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarMaquinas(NovaMaquinaDto maquinaDto)
        {
            logger.LogInformation("Foi requisitado um novo cadastro de maquinas.");
            var result = await maquinasManager.InsertMaquinasAsync(maquinaDto);
            if (result == null)
            {
                return BadRequest("Não foi possivel cadastrar a maquina. Consulte os paramentros enviados: " + maquinaDto);
            }
            return CreatedAtAction(nameof(BuscarMaquinaPorId), new { id = result.Id }, result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> AtualizarMaquina([FromBody] AlteraMaquinaDto maquinasDto, int id)
        {
            logger.LogInformation("Solicitado atualização de maquinas");
            var result = await maquinasManager.UpdateMaquinasAsync(maquinasDto, id);
            if (result == null)
            {
                return NotFound($"Não foi possivel atualizar a maquina. Id não encontrado\nId enviado: {id}");
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Solicitando delete de maquina");
            var result = await maquinasManager.DeleteMaquinasAsync(id);
            if (result == false)
            {
                return NotFound($"Não foi possivel deletar a maquina. Id não encontrado\nId enviado: {id}");
            }
            return Ok("Maquina excluida com sucesso");
        }
    }
}
