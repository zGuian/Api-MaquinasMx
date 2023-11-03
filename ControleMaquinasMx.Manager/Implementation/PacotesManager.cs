using AutoMapper;
using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_Manager.Interfaces;
using ControleMaquinasMx_CoreShared.PacotesDtos;

namespace ControleMaquinasMx_Manager.Implementation
{
    public class PacotesManager : IPacotesManager
    {
        private readonly IPacotesRepository _pacotesRepository;
        private readonly IMapper _mapper;

        public PacotesManager(IPacotesRepository pacotesRepository, IMapper mapper)
        {
            _pacotesRepository = pacotesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadPacotesDto>> SearchPacotesAsync()
        {
            return _mapper.Map<List<ReadPacotesDto>>(
                await _pacotesRepository.SearchAllPacotesAsync());
        }

        public async Task<ReadPacotesDto> SearchPacotesIdAsync(int id)
        {
            var pacoteId = await _pacotesRepository.SearchPacotesByIdAsync(id);
            return _mapper.Map<ReadPacotesDto>(pacoteId);
        }

        public async Task<Pacotes> InsertPacotesAsync(CreatePacotesDto pacotesDto)
        {
            var pacote = _mapper.Map<Pacotes>(pacotesDto);
            return await _pacotesRepository.InsertPacotesAsync(pacote);
        }

        public async Task<Pacotes> UpdatePacotesAsync(UpdatePacotesDto pacotesDto, int id)
        {
            var pacote = _mapper.Map<Pacotes>(pacotesDto);
            return await _pacotesRepository.UpdatePacotesAsync(pacote, id);
        }

        public async Task<bool> DeletePacoteAsync(int id)
        {
            return await _pacotesRepository.DeletePacotesAsync(id);
        }
    }
}
