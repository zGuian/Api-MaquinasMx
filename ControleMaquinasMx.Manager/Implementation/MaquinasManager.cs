using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_Core.Interfaces;
using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;
using ControleMaquinasMx_Manager.Interfaces;

namespace ControleMaquinasMx_Manager.Implementation
{
    public class MaquinasManager : IMaquinasManager
    {
        private readonly IMaquinasRepository _maquinasRepository;

        public MaquinasManager(IMaquinasRepository maquinasRepository)
        {
            _maquinasRepository = maquinasRepository;
        }

        public async Task<IEnumerable<ReadMaquinasDto>> SearchMaquinasAsync()
        {
            return await _maquinasRepository.SearchAllMaquinasAsync();
        }

        public async Task<ReadMaquinasDto> SearchMaquinasIdAsync(int id)
        {
            return await _maquinasRepository.SearchMaquinasByIdAsync(id);
        }

        public async Task<Maquinas> InsertMaquinasAsync(CreateMaquinasDto maquinas)
        {
            return await _maquinasRepository.InsertMaquinasAsync(maquinas);
        }

        public async Task<Maquinas> UpdateMaquinasAsync(UpdateMaquinasDto maquinasDto, int id)
        {
            return await _maquinasRepository.UpdateMaquinasAsync(maquinasDto, id);
        }

        public async Task<bool> DeleteMaquinasAsync(int id)
        {
            return await _maquinasRepository.DeleteMaquinasAsync(id);
        }
    }
}
