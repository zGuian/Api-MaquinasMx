using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_DomainShared.MaquinasDtos;

namespace ControleMaquinasMx_Domain.Interfaces
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
