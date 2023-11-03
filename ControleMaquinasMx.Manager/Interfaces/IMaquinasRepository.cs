using ControleMaquinasMx.Core.Models;

namespace ControleMaquinasMx_Core.Interfaces
{
    public interface IMaquinasRepository
    {
        Task<IEnumerable<Maquinas>> SearchAllMaquinasAsync();
        Task<Maquinas> SearchMaquinasByIdAsync(int id);
        Task<Maquinas> InsertMaquinasAsync(Maquinas maquinaDto);
        Task<Maquinas> UpdateMaquinasAsync(Maquinas maquina, int id);
        Task<bool> DeleteMaquinasAsync(int id);
    }
}
