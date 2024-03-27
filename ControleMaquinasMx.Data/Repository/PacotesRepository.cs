using AutoMapper;
using ControleMaquinasMx.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleMaquinasMx_Data.Repository
{
    public class PacotesRepository : IPacotesRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PacotesRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PacoteViewDto>> SearchAllPacotesAsync()
        {
            var pacote = await _context.Pacotes.AsNoTracking()
                                                .ToListAsync();
            int contagem = pacote!.Count;
            if (contagem == 0)
            {
                return null!;
            }
            var pacoteDto = _mapper.Map<List<PacoteViewDto>>(pacote);
            return pacoteDto;
        }

        public async Task<PacoteViewDto> SearchPacotesByIdAsync(int id)
        {
            var pacoteId = await _context.Pacotes.SingleOrDefaultAsync(x => x.Id == id);
            if (pacoteId == null)
            {
                return null!;
            }
            var pacoteDto = _mapper.Map<PacoteViewDto>(pacoteId);
            return pacoteDto;
        }

        public async Task<Pacote> InsertPacotesAsync(NovoPacoteDto pacoteDto)
        {
            var pacote = _mapper.Map<Pacote>(pacoteDto);
            await _context.Pacotes.AddAsync(pacote);
            await _context.SaveChangesAsync();
            return pacote;
        }

        public async Task<Pacote> UpdatePacotesAsync(AlteraPacoteDto pacoteDto, int id)
        {
            var pacoteId = await _context.Pacotes.FirstOrDefaultAsync(x => x.Id == id);
            if (pacoteId == null)
            {
                return null!;
            }
            _mapper.Map(pacoteId, pacoteDto);
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
