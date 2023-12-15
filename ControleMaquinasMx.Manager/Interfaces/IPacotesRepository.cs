using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.PacotesDtos;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IPacotesRepository
    {
        Task<IEnumerable<PacoteViewDto>> SearchAllPacotesAsync();
        Task<PacoteViewDto> SearchPacotesByIdAsync(int id);
        Task<Pacote> InsertPacotesAsync(NovoPacoteDto pacoteDto);
<<<<<<< HEAD
        Task<Pacote> UpdatePacotesAsync(AlteraPacoteDto pacoteDto, int id);
=======
        Task<Pacote> UpdatePacotesAsync(UpdatePacotesDto pacoteDto, int id);
>>>>>>> 794a33a3b7cfbc18145de5b9a53a2f8c0ec6efad
        Task<bool> DeletePacotesAsync(int id);
    }
}
