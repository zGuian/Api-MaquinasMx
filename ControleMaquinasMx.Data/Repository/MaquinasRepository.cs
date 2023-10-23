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
            var maquinas = await _context.Maquinas.AsNoTracking().ToListAsync();
            var contagem = maquinas!.Count;
            if (contagem == 0)
            {
                return null!;
            }
            return maquinas;
        }

        public async Task<Maquinas> SearchMaquinasByIdAsync(int id)
        {
            var maquinaId = await _context.Maquinas.FindAsync(id);
            if (maquinaId == null)
            {
                return null!;
            }
                return maquinaId;
        }

        public async Task<Maquinas> InsertMaquinasAsync(Maquinas maquinas)
        {
            await _context.Maquinas.AddAsync(maquinas);
            await _context.SaveChangesAsync();
            return maquinas;
        }

        public async Task<Maquinas> UpdateMaquinasAsync(int id, Maquinas maquinas)
        {
            var maquinaId = _context.Maquinas.FirstOrDefaultAsync(x=> x.Id == id);
            if (maquinaId  == null)
            {
                return null!;
            }
            await _context.Maquinas.AddAsync(maquinas);
            await _context.SaveChangesAsync();
            return maquinas;
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
