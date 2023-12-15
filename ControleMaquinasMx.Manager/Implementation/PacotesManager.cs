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

<<<<<<< HEAD
        public async Task<Pacote> UpdatePacotesAsync(AlteraPacoteDto pacoteDto, int id)
=======
        public async Task<Pacote> UpdatePacotesAsync(UpdatePacotesDto pacoteDto, int id)
>>>>>>> 794a33a3b7cfbc18145de5b9a53a2f8c0ec6efad
        {
            return await _pacotesRepository.UpdatePacotesAsync(pacoteDto, id);
        }

        public async Task<bool> DeletePacoteAsync(int id)
        {
            return await _pacotesRepository.DeletePacotesAsync(id);
        }
    }
}
