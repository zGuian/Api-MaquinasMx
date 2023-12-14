using Microsoft.AspNetCore.Mvc;
using ControleMaquinasMx_Manager.Interfaces;
using ControleMaquinasMx_CoreShared.PacotesDtos;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> BuscaPacotesPorId(int id)
        {
            var result = await _pacotesManager.SearchPacotesIdAsync(id);
            if (result == null)
            {
                return NotFound($"Maquina não encontrada \nconsulte o ID: {id} enviado");
            }
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
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

        [Authorize(Roles = "Administrator")]
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> AtualizarPacote([FromBody] UpdatePacotesDto pacoteDto, int id)
        {
            var result = await _pacotesManager.UpdatePacotesAsync(pacoteDto, id);
            if (result == null)
            {
                return NotFound($"Não foi possivel atualizar a maquina. Id não encontrado: \nId enviado: {id}");
            }
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete]
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
