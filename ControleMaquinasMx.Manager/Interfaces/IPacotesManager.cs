using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.PacotesDtos;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IPacotesManager
    {
        Task<IEnumerable<ReadPacotesDto>> SearchPacotesAsync();
        Task<ReadPacotesDto> SearchPacotesIdAsync(int id);
        Task<Pacotes> InsertPacotesAsync(CreatePacotesDto pacotesDto);
        Task<Pacotes> UpdatePacotesAsync(UpdatePacotesDto pacotesDto, int id);
        Task<bool> DeletePacoteAsync(int id);
    }
}
