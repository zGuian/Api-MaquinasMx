using Microsoft.AspNetCore.Mvc;

namespace ControleMaquinasMx.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MaquinaController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> BuscaTodasMaquinas()
        {
            return NotFound();
        }

        [HttpGet("GetId/{id}")]
        public async Task<ActionResult> BuscarMaquinaPorId(int id)
        {
            return NotFound(id);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarMaquinas([FromBody] string maquinaDto)
        {
            return NotFound();
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> AtualizarMaquina([FromBody] string maquinasDto, int id)
        {
            return NotFound();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            return NotFound();
        }
    }
}
