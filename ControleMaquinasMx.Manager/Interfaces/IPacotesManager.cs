using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.PacotesDtos;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IPacotesManager
    {
        Task<IEnumerable<PacoteViewDto>> SearchPacotesAsync();
        Task<PacoteViewDto> SearchPacotesIdAsync(int id);
        Task<Pacote> InsertPacotesAsync(NovoPacoteDto pacotesDto);
        Task<Pacote> UpdatePacotesAsync(UpdatePacotesDto pacotesDto, int id);
        Task<bool> DeletePacoteAsync(int id);
    }
}
