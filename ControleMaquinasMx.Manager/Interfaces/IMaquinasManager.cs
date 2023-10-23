using ControleMaquinasMx.Core.Models;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IMaquinasManager
    {
        Task<bool> DeleteMaquinasAsync(int id);
        Task<Maquinas> InsertMaquinasAsync(Maquinas maquinas);
        Task<IEnumerable<Maquinas>> SearchMaquinasAsync();
        Task<Maquinas> SearchMaquinasIdAsync(int id);
        Task<Maquinas> UpdateMaquinasAsync(int id, Maquinas maquinas);
    }
}
