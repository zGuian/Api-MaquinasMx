using ControleMaquinasMx_DomainShared.MaquinasDtos;

namespace ControleMaquinasMx_Application.Interfaces
{
    public interface IMaquinasServices
    {
        Task<IEnumerable<MaquinaViewDto>> SearchMaquinasAsync();
        Task<MaquinaViewDto> SearchMaquinasAsync(int id);
        Task<MaquinaViewDto> InsertMaquinasAsync(NovaMaquinaDto maquinas);
        Task<MaquinaViewDto> UpdateMaquinasAsync(AlteraMaquinaDto maquinas, int id);
        Task<bool> DeleteMaquinasAsync(int id);
    }
}
