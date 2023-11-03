using ControleMaquinasMx.Data.Data;
using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleMaquinasMx_Data.Repository
{
    public class PacotesRepository : IPacotesRepository
    {
        private readonly AppDbContext _context;

        public PacotesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pacotes>> SearchAllPacotesAsync()
        {
            var pacote = await _context.Pacotes.AsNoTracking()
                                                .ToListAsync();
            int contagem = pacote!.Count;
            if (contagem == 0)
            {
                return null!;
            }
            return pacote;
        }

        public async Task<Pacotes> SearchPacotesByIdAsync(int id)
        {
            var pacoteId = await _context.Pacotes.SingleOrDefaultAsync(x => x.Id == id);
            if (pacoteId == null)
            {
                return null!;
            }
            return pacoteId;
        }

        public async Task<Pacotes> InsertPacotesAsync(Pacotes pacote)
        {
            await _context.Pacotes.AddAsync(pacote);
            await _context.SaveChangesAsync();
            return pacote;
        }

        public async Task<Pacotes> UpdatePacotesAsync(Pacotes pacote, int id)
        {
            var pacoteId = await _context.Pacotes.FirstOrDefaultAsync(x => x.Id == id);
            if (pacoteId == null)
            {
                return null!;
            }
            _context.Update(pacoteId);
            await _context.SaveChangesAsync();
            return pacoteId;
        }

        public async Task<bool> DeletePacotesAsync(int id)
        {
            var pacoteId = await _context.Pacotes.FirstOrDefaultAsync(x => x.Id == id);
            if (pacoteId == null)
            {
                return false;
            }
            _context.Remove(pacoteId);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
