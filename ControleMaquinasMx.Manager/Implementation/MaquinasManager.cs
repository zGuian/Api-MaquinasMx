using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_Core.Interfaces;
using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;
using ControleMaquinasMx_Manager.Interfaces;
using Microsoft.Extensions.Logging;

namespace ControleMaquinasMx_Manager.Implementation
{
    public class MaquinasManager : IMaquinasManager
    {
        private readonly IMaquinasRepository _maquinasRepository;
        private readonly ILogger<MaquinasManager> _logger;

        public MaquinasManager(IMaquinasRepository maquinasRepository, ILogger<MaquinasManager> logger)
        {
            _maquinasRepository = maquinasRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<ReadMaquinasDto>> SearchMaquinasAsync()
        {
            _logger.LogInformation("Realizando busca de todas maquinas");
            return await _maquinasRepository.SearchAllMaquinasAsync();
        }

        public async Task<ReadMaquinasDto> SearchMaquinasIdAsync(int id)
        {
            _logger.LogInformation($"Iniciado busca do id {id} no banco de dados");
            return await _maquinasRepository.SearchMaquinasByIdAsync(id);
        }

        public async Task<Maquinas> InsertMaquinasAsync(CreateMaquinasDto maquinaDto)
        {
            _logger.LogInformation($"Realizando incerção no banco de dados");
            return await _maquinasRepository.InsertMaquinasAsync(maquinaDto);
        }

        public async Task<Maquinas> UpdateMaquinasAsync(UpdateMaquinasDto maquinaDto, int id)
        {
            _logger.LogInformation($"Iniciando processo para atualização de informações no banco de dados");
            return await _maquinasRepository.UpdateMaquinasAsync(maquinaDto, id);
        }

        public async Task<bool> DeleteMaquinasAsync(int id)
        {
            _logger.LogInformation($"Deletando id {id} no banco de dados");
            return await _maquinasRepository.DeleteMaquinasAsync(id);
        }
    }
}
