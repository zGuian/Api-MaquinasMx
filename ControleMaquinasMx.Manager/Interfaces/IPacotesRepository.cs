using ControleMaquinasMx_Core.Models;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IPacotesRepository
    {
        Task<IEnumerable<Pacotes>> SearchAllPacotesAsync();
        Task<Pacotes> SearchPacotesByIdAsync(int id);
        Task<Pacotes> InsertPacotesAsync(Pacotes pacote);
        Task<Pacotes> UpdatePacotesAsync(Pacotes pacote, int id);
        Task<bool> DeletePacotesAsync(int id);
    }
}
