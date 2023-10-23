using ControleMaquinasMx.Core.Models;

namespace ControleMaquinasMx_Core.Interfaces
{
    public interface IMaquinasRepository
    {
        Task<IEnumerable<Maquinas>> SearchAllMaquinasAsync();
        Task<Maquinas> SearchMaquinasByIdAsync(int id);
        Task<Maquinas> InsertMaquinasAsync(Maquinas maquinas);
        Task<Maquinas> UpdateMaquinasAsync(int id, Maquinas maquinas);
        Task<bool> DeleteMaquinasAsync(int id);
    }
}
