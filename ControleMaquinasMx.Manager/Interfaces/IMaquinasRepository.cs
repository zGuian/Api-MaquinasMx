using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;

namespace ControleMaquinasMx_Core.Interfaces
{
    public interface IMaquinasRepository
    {
        Task<IEnumerable<ReadMaquinasDto>> SearchAllMaquinasAsync();
        Task<ReadMaquinasDto> SearchMaquinasByIdAsync(int id);
        Task<Maquinas> InsertMaquinasAsync(CreateMaquinasDto maquinaDto);
        Task<Maquinas> UpdateMaquinasAsync(UpdateMaquinasDto maquinaDto, int id);
        Task<bool> DeleteMaquinasAsync(int id);
    }
}
