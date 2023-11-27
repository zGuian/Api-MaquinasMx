using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.PacotesDtos;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IPacotesRepository
    {
        Task<IEnumerable<ReadPacotesDto>> SearchAllPacotesAsync();
        Task<ReadPacotesDto> SearchPacotesByIdAsync(int id);
        Task<Pacotes> InsertPacotesAsync(CreatePacotesDto pacoteDto);
        Task<Pacotes> UpdatePacotesAsync(UpdatePacotesDto pacoteDto, int id);
        Task<bool> DeletePacotesAsync(int id);
    }
}
