using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_DomainShared.PacotesDtos;

namespace ControleMaquinasMx_Application.Interfaces
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
