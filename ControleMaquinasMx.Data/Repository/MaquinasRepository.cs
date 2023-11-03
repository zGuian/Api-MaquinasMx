using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx.Data.Data;
using ControleMaquinasMx_Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleMaquinasMx_Data.Repository
{
    public class MaquinasRepository : IMaquinasRepository
    {
        private readonly AppDbContext _context;

        public MaquinasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Maquinas>> SearchAllMaquinasAsync()
        {
            var maquinas = await _context.Maquinas.AsNoTracking()
                                                  .ToListAsync();
            int contagem = maquinas.Count;
            if (contagem == 0)
            {
                return null!;
            }
            return maquinas;
        }

        public async Task<Maquinas> SearchMaquinasByIdAsync(int id)
        {
            var maquinaId = await _context.Maquinas.SingleOrDefaultAsync(x => x.Id == id);
            if (maquinaId == null)
            {
                return null!;
            }
            return maquinaId;
        }

        public async Task<Maquinas> InsertMaquinasAsync(Maquinas maquina)
        {
            await _context.Maquinas.AddAsync(maquina);
            await _context.SaveChangesAsync();
            return maquina;
        }

        public async Task<Maquinas> UpdateMaquinasAsync(Maquinas maquina, int id)
        {
            var maquinaId = await _context.Maquinas.FirstOrDefaultAsync(x => x.Id == id);
            if (maquinaId == null)
            {
                return null!;
            }
            await _context.SaveChangesAsync();
            return maquinaId;
        }

        public async Task<bool> DeleteMaquinasAsync(int id)
        {
            var maquinaId = await _context.Maquinas.FirstOrDefaultAsync(x => x.Id == id);
            if (maquinaId == null)
            {
                return false;
            }
            _context.Remove(maquinaId);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
