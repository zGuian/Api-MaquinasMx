using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_DomainShared.PacotesDtos;
using ControleMaquinasMx_Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace ControleMaquinasMx_Application.Services
{
    public class PacotesServices : IPacotesServices
    {
        private readonly IPacotesRepository pacotesRepository;
        private readonly ILogger<PacotesServices> logger;

        public PacotesServices(IPacotesRepository pacotesRepository, ILogger<PacotesServices> logger)
        {
            this.pacotesRepository = pacotesRepository;
            this.logger = logger;
        }

        public async Task<IEnumerable<PacoteViewDto>> SearchPacotesAsync()
        {
            logger.LogInformation($"BUSCANDO TODOS PACOTES");
            return await pacotesRepository.SearchAllPacotesAsync();
        }

        public async Task<PacoteViewDto> SearchPacotesIdAsync(int id)
        {
            return await pacotesRepository.SearchPacotesByIdAsync(id);
        }

        public async Task<Pacote> InsertPacotesAsync(NovoPacoteDto pacoteDto)
        {
            return await pacotesRepository.InsertPacotesAsync(pacoteDto);
        }

        public async Task<Pacote> UpdatePacotesAsync(AlteraPacoteDto pacoteDto, int id)

        {
            return await pacotesRepository.UpdatePacotesAsync(pacoteDto, id);
        }

        public async Task<bool> DeletePacoteAsync(int id)
        {
            return await pacotesRepository.DeletePacotesAsync(id);
        }
    }
}
