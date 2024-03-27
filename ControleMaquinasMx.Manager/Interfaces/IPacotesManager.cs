using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_DomainShared.PacotesDtos;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IPacotesManager
    {
        Task<IEnumerable<PacoteViewDto>> SearchPacotesAsync();
        Task<PacoteViewDto> SearchPacotesIdAsync(int id);
        Task<Pacote> InsertPacotesAsync(NovoPacoteDto pacotesDto);
        Task<Pacote> UpdatePacotesAsync(AlteraPacoteDto pacotesDto, int id);
        Task<bool> DeletePacoteAsync(int id);
    }
}
