using Microsoft.Extensions.Logging;
using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_Manager.Interfaces;
using ControleMaquinasMx_CoreShared.PacotesDtos;

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

        public async Task<IEnumerable<ReadPacotesDto>> SearchPacotesAsync()
        {
            _logger.LogInformation($"BUSCANDO TODOS PACOTES");
            return await _pacotesRepository.SearchAllPacotesAsync();
        }

        public async Task<ReadPacotesDto> SearchPacotesIdAsync(int id)
        {
            return await _pacotesRepository.SearchPacotesByIdAsync(id);
        }

        public async Task<Pacotes> InsertPacotesAsync(CreatePacotesDto pacoteDto)
        {
            return await _pacotesRepository.InsertPacotesAsync(pacoteDto);
        }

        public async Task<Pacotes> UpdatePacotesAsync(UpdatePacotesDto pacoteDto, int id)
        {
            return await _pacotesRepository.UpdatePacotesAsync(pacoteDto, id);
        }

        public async Task<bool> DeletePacoteAsync(int id)
        {
            return await _pacotesRepository.DeletePacotesAsync(id);
        }
    }
}
