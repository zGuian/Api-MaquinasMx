using AutoMapper;
using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_Core.Interfaces;
using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_Manager.Interfaces;
using ControleMaquinasMx_CoreShared.MaquinasDtos;

namespace ControleMaquinasMx_Manager.Implementation
{
    public class MaquinasManager : IMaquinasManager
    {
        private readonly IMaquinasRepository _maquinasRepository;
        private readonly IMapper _mapper;

        public MaquinasManager(IMaquinasRepository maquinasRepository, IMapper mapper)
        {
            _maquinasRepository = maquinasRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadMaquinasDto>> SearchMaquinasAsync()
        {
            return _mapper.Map<List<ReadMaquinasDto>>(
                await _maquinasRepository.SearchAllMaquinasAsync());
        }

        public async Task<ReadMaquinasDto> SearchMaquinasIdAsync(int id)
        {
            var maquinaId = await _maquinasRepository.SearchMaquinasByIdAsync(id);
            return _mapper.Map<ReadMaquinasDto>(maquinaId);
        }

        public async Task<Maquinas> InsertMaquinasAsync(CreateMaquinasDto maquinaDto)
        {
            var maquina = _mapper.Map<Maquinas>(maquinaDto);
            return await _maquinasRepository.InsertMaquinasAsync(maquina);
        }

        public async Task<Maquinas> UpdateMaquinasAsync(UpdateMaquinasDto maquinaDto, int id)
        {
            var maquina = _mapper.Map<Maquinas>(maquinaDto);
            return await _maquinasRepository.UpdateMaquinasAsync(maquina, id);
        }

        public async Task<bool> DeleteMaquinasAsync(int id)
        {
            return await _maquinasRepository.DeleteMaquinasAsync(id);
        }
    }
}
