using AutoMapper;
using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_Domain.Interfaces;
using ControleMaquinasMx_DomainShared.MaquinasDtos;
using ControleMaquinasMx_Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace ControleMaquinasMx_Application.Services
{
    public class MaquinaServices : IMaquinasServices
    {
        private readonly IMaquinasRepository maquinasRepository;
        private readonly ILogger<MaquinaServices> logger;
        private readonly IMapper mapper;

        public MaquinaServices(IMaquinasRepository maquinasRepository, IMapper mapper, ILogger<MaquinaServices> logger)
        {
            this.maquinasRepository = maquinasRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<IEnumerable<MaquinaViewDto>> SearchMaquinasAsync()
        {
            logger.LogInformation("Realizando busca de todas maquinas");
            return await maquinasRepository.SearchAllMaquinasAsync();
        }

        public async Task<MaquinaViewDto> SearchMaquinasAsync(int id)
        {
            logger.LogInformation($"Iniciado busca do id {id} no banco de dados");
            return await maquinasRepository.SearchMaquinasByIdAsync(id);
        }

        public async Task<MaquinaViewDto> InsertMaquinasAsync(NovaMaquinaDto maquinaDto)
        {
            logger.LogInformation($"Realizando incerção no banco de dados");
            var maquina = mapper.Map<Maquina>(maquinaDto);
            return mapper.Map<MaquinaViewDto>(await maquinasRepository.InsertMaquinasAsync(maquina));
        }

        public async Task<MaquinaViewDto> UpdateMaquinasAsync(AlteraMaquinaDto maquinaDto, int id)
        {
            logger.LogInformation($"Iniciando processo para atualização de informações no banco de dados");
            mapper.Map<Maquina>(maquinaDto);
            return mapper.Map<MaquinaViewDto>(await maquinasRepository.UpdateMaquinasAsync(maquinaDto, id));
        }

        public async Task<bool> DeleteMaquinasAsync(int id)
        {
            logger.LogInformation($"Deletando id {id} no banco de dados");
            return await maquinasRepository.DeleteMaquinasAsync(id);
        }
    }
}
