using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.PacotesDtos;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IPacotesRepository
    {
        Task<IEnumerable<PacoteViewDto>> SearchAllPacotesAsync();
        Task<PacoteViewDto> SearchPacotesByIdAsync(int id);
        Task<Pacote> InsertPacotesAsync(NovoPacoteDto pacoteDto);
        Task<Pacote> UpdatePacotesAsync(AlteraPacoteDto pacoteDto, int id);
        Task<bool> DeletePacotesAsync(int id);
    }
}
