using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.PacotesDtos;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IPacotesManager
    {
        Task<IEnumerable<PacoteViewDto>> SearchPacotesAsync();
        Task<PacoteViewDto> SearchPacotesIdAsync(int id);
        Task<Pacote> InsertPacotesAsync(NovoPacoteDto pacotesDto);
<<<<<<< HEAD
        Task<Pacote> UpdatePacotesAsync(AlteraPacoteDto pacotesDto, int id);
=======
        Task<Pacote> UpdatePacotesAsync(UpdatePacotesDto pacotesDto, int id);
>>>>>>> 794a33a3b7cfbc18145de5b9a53a2f8c0ec6efad
        Task<bool> DeletePacoteAsync(int id);
    }
}
