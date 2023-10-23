using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleMaquinasMx.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MaquinaController : Controller
    {
        private readonly IMaquinasManager _maquinasManager;

        public MaquinaController(IMaquinasManager maquinasManager)
        {
            _maquinasManager = maquinasManager;
        }

        [HttpGet]
        public async Task<ActionResult> BuscaTodasMaquinas()
        {
            var result = await _maquinasManager.SearchMaquinasAsync();
            if (result == null)
            {
                return NotFound("Não encontrado nenhuma maquina");
            }
            return Ok(result);
        }

        [HttpGet("GetId/{id}")]
        public async Task<ActionResult> BuscarMaquinaPorId(int id)
        {
            var result = await _maquinasManager.SearchMaquinasIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarMaquinas([FromBody] Maquinas maquinaDto)
        {
            var result = await _maquinasManager.InsertMaquinasAsync(maquinaDto);
            if (result == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(BuscarMaquinaPorId), result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> AtualizarMaquina([FromBody] Maquinas maquinasDto, int id)
        {
            var result = await _maquinasManager.UpdateMaquinasAsync(id, maquinasDto);
            if (result == null)
            {
                return NotFound(id);
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _maquinasManager.DeleteMaquinasAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("Maquina excluida com sucesso");
        }
    }
}
