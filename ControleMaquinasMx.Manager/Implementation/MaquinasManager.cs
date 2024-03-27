using AutoMapper;
using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_Domain.Interfaces;
using ControleMaquinasMx_DomainShared.MaquinasDtos;
using ControleMaquinasMx_Manager.Interfaces;
using Microsoft.Extensions.Logging;

namespace ControleMaquinasMx_Manager.Implementation
{
    public class MaquinasManager : IMaquinasManager
    {
        private readonly IMaquinasRepository _maquinasRepository;
        private readonly ILogger<MaquinasManager> _logger;
        private readonly IMapper _mapper;

        public MaquinasManager(IMaquinasRepository maquinasRepository, IMapper mapper, ILogger<MaquinasManager> logger)
        {
            _maquinasRepository = maquinasRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<MaquinaViewDto>> SearchMaquinasAsync()
        {
            _logger.LogInformation("Realizando busca de todas maquinas");
            return await _maquinasRepository.SearchAllMaquinasAsync();
        }

        public async Task<MaquinaViewDto> SearchMaquinasAsync(int id)
        {
            _logger.LogInformation($"Iniciado busca do id {id} no banco de dados");
            return await _maquinasRepository.SearchMaquinasByIdAsync(id);
        }

        public async Task<MaquinaViewDto> InsertMaquinasAsync(NovaMaquinaDto maquinaDto)
        {
            _logger.LogInformation($"Realizando incerção no banco de dados");
            var maquina = _mapper.Map<Maquina>(maquinaDto);
            return _mapper.Map<MaquinaViewDto>(await _maquinasRepository.InsertMaquinasAsync(maquina));
        }

        public async Task<MaquinaViewDto> UpdateMaquinasAsync(AlteraMaquinaDto maquinaDto, int id)
        {
            _logger.LogInformation($"Iniciando processo para atualização de informações no banco de dados");
            _mapper.Map<Maquina>(maquinaDto);
            return _mapper.Map<MaquinaViewDto>(await _maquinasRepository.UpdateMaquinasAsync(maquinaDto, id));
        }

        public async Task<bool> DeleteMaquinasAsync(int id)
        {
            _logger.LogInformation($"Deletando id {id} no banco de dados");
            return await _maquinasRepository.DeleteMaquinasAsync(id);
        }
    }
}
