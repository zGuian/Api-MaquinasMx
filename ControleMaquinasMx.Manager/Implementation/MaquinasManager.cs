using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_Core.Interfaces;
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

        public async Task<IEnumerable<Maquinas>> SearchMaquinasAsync()
        {
            return await _maquinasRepository.SearchAllMaquinasAsync();
        }

        public async Task<Maquinas> SearchMaquinasIdAsync(int id)
        {
            return await _maquinasRepository.SearchMaquinasByIdAsync(id);
        }

        public async Task<Maquinas> InsertMaquinasAsync(Maquinas maquinas)
        {
            return await _maquinasRepository.InsertMaquinasAsync(maquinas);
        }

        public async Task<Maquinas> UpdateMaquinasAsync(int id, Maquinas maquinas)
        {
            return await _maquinasRepository.UpdateMaquinasAsync(id, maquinas);
        }

        public async Task<bool> DeleteMaquinasAsync(int id)
        {
            return await _maquinasRepository.DeleteMaquinasAsync(id);
        }
    }
}
