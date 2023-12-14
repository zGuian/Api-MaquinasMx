using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;

namespace ControleMaquinasMx_Core.Interfaces
{
    public interface IMaquinasRepository
    {
        Task<IEnumerable<MaquinaViewDto>> SearchAllMaquinasAsync();
        Task<MaquinaViewDto> SearchMaquinasByIdAsync(int id);
        Task<Maquina> InsertMaquinasAsync(Maquina maquina);
        Task<Maquina> UpdateMaquinasAsync(AlteraMaquinaDto maquinaDto, int id);
        Task<bool> DeleteMaquinasAsync(int id);
    }
}
