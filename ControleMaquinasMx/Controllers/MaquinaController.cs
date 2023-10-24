using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;
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
        public async Task<IActionResult> BuscaTodasMaquinas()
        {
            var result = await _maquinasManager.SearchMaquinasAsync();
            if (result == null)
            {
                return NotFound("Não encontrado nenhuma maquina");
            }
            return Ok(result);
        }

        [HttpGet("GetId/{id}")]
        public async Task<IActionResult> BuscarMaquinaPorId(int id)
        {
            var result = await _maquinasManager.SearchMaquinasIdAsync(id);
            if (result == null)
            {
                return NotFound($"Maquina não encontrada \nconsulte o ID: {id} enviado");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarMaquinas(CreateMaquinasDto maquinaDto)
        {
            var result = await _maquinasManager.InsertMaquinasAsync(maquinaDto);
            if (result == null)
            {
                return NotFound("Não foi possivel cadastrar a maquina. Consulte os paramentros enviados: " + maquinaDto);
            }
            return CreatedAtAction(nameof(AdicionarMaquinas), result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> AtualizarMaquina([FromBody] UpdateMaquinasDto maquinasDto, int id)
        {
            var result = await _maquinasManager.UpdateMaquinasAsync(maquinasDto, id);
            if (result == null)
            {
                return NotFound($"Não foi possivel atualizar a maquina. Id não encontrado: \nId enviado: {id}");
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
