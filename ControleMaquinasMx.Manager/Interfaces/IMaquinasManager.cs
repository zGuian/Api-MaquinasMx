using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IMaquinasManager
    {
        Task<IEnumerable<ReadMaquinasDto>> SearchMaquinasAsync();
        Task<ReadMaquinasDto> SearchMaquinasIdAsync(int id);
        Task<Maquinas> InsertMaquinasAsync(CreateMaquinasDto maquinas);
        Task<Maquinas> UpdateMaquinasAsync(UpdateMaquinasDto maquinas, int id);
        Task<bool> DeleteMaquinasAsync(int id);
    }
}
