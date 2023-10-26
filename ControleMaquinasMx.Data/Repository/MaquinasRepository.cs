using AutoMapper;
using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx.Data.Data;
using ControleMaquinasMx_Core.Interfaces;
using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;
using Microsoft.EntityFrameworkCore;

namespace ControleMaquinasMx_Data.Repository
{
    public class MaquinasRepository : IMaquinasRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MaquinasRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadMaquinasDto>> SearchAllMaquinasAsync()
        {
            var maquinas = await _context.Maquinas.Include(x => x.Pacotes)
                                                  .AsNoTracking()
                                                  .ToListAsync();
            int contagem = maquinas!.Count;
            if (contagem == 0)
            {
                return null!;
            }
            var maquinaDto = _mapper.Map<List<ReadMaquinasDto>>(maquinas);
            return maquinaDto;
        }

        public async Task<ReadMaquinasDto> SearchMaquinasByIdAsync(int id)
        {
            var maquinaId = await _context.Maquinas.Include(x => x.Pacotes)
                                                   .SingleOrDefaultAsync(x => x.Id == id);
            if (maquinaId == null)
            {
                return null!;
            }
            var maquinaDto = _mapper.Map<ReadMaquinasDto>(maquinaId);
            return maquinaDto;
        }

        public async Task<Maquinas> InsertMaquinasAsync(CreateMaquinasDto maquinaDto)
        {
            var maquina = _mapper.Map<Maquinas>(maquinaDto);
            maquina.Pacotes = maquinaDto.Pacotes.Select(x => _mapper.Map<Pacotes>(x)).ToList();
            await _context.Maquinas.AddAsync(maquina);
            await _context.SaveChangesAsync();
            return maquina;
        }

        public async Task<Maquinas> UpdateMaquinasAsync(UpdateMaquinasDto maquinaDto, int id)
        {
            var maquina = await _context.Maquinas.FirstOrDefaultAsync(x => x.Id == id);
            if (maquina == null)
            {
                return null!;
            }   
            _mapper.Map(maquinaDto, maquina);
            await _context.SaveChangesAsync();
            return maquina;
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
