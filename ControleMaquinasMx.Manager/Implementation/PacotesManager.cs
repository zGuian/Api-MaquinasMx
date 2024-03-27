using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_DomainShared.PacotesDtos;
using ControleMaquinasMx_Manager.Interfaces;
using Microsoft.Extensions.Logging;

namespace ControleMaquinasMx_Manager.Implementation
{
    public class PacotesManager : IPacotesManager
    {
        private readonly IPacotesRepository _pacotesRepository;
        private readonly ILogger<PacotesManager> _logger;

        public PacotesManager(IPacotesRepository pacotesRepository, ILogger<PacotesManager> logger)
        {
            _pacotesRepository = pacotesRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<PacoteViewDto>> SearchPacotesAsync()
        {
            _logger.LogInformation($"BUSCANDO TODOS PACOTES");
            return await _pacotesRepository.SearchAllPacotesAsync();
        }

        public async Task<PacoteViewDto> SearchPacotesIdAsync(int id)
        {
            return await _pacotesRepository.SearchPacotesByIdAsync(id);
        }

        public async Task<Pacote> InsertPacotesAsync(NovoPacoteDto pacoteDto)
        {
            return await _pacotesRepository.InsertPacotesAsync(pacoteDto);
        }

        public async Task<Pacote> UpdatePacotesAsync(AlteraPacoteDto pacoteDto, int id)

        {
            return await _pacotesRepository.UpdatePacotesAsync(pacoteDto, id);
        }

        public async Task<bool> DeletePacoteAsync(int id)
        {
            return await _pacotesRepository.DeletePacotesAsync(id);
        }
    }
}
