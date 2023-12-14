using AutoMapper;
using ControleMaquinasMx.Data.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_Core.Interfaces;
using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;

namespace ControleMaquinasMx_Data.Repository
{
    public class MaquinasRepository : IMaquinasRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<MaquinasRepository> _logger;
        private readonly IMapper _mapper;

        public MaquinasRepository(AppDbContext context, ILogger<MaquinasRepository> 
            logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaquinaViewDto>> SearchAllMaquinasAsync()
        {
            var maquinas = await _context.Maquinas.Include(x => x.Pacotes)
                .AsNoTracking().ToListAsync();
            var contagem = maquinas.Count;
            if (contagem == 0)
            {
                return null!;
            }
            var maquinasDto = _mapper.Map<List<MaquinaViewDto>>(maquinas);
            _logger.LogInformation($"Encontrado {contagem} maquinas");
            _logger.LogInformation("Retornado maquinas a controller");
            return maquinasDto;
        }

        public async Task<MaquinaViewDto> SearchMaquinasByIdAsync(int id)
        {
            var maquinaId = await _context.Maquinas.Include(x => x.Pacotes)
                .SingleOrDefaultAsync(x => x.Id == id);
            if (maquinaId == null)
            {
                return null!;
            }
            var maquinaDto = _mapper.Map<MaquinaViewDto>(maquinaId);
            _logger.LogInformation($"Retornando maquina do ID {id} a controller");
            return maquinaDto;
        }

        public async Task<Maquina> InsertMaquinasAsync(Maquina maquina)
        {
            await _context.Maquinas.AddAsync(maquina);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Registrado com sucesso no banco de dados");
            return maquina;
        }

        public async Task<Maquina> UpdateMaquinasAsync(AlteraMaquinaDto maquinaDto, int id)
        {
            var maquinaId = await _context.Maquinas.FirstOrDefaultAsync(x => x.Id == id);
            if (maquinaId == null)
            {
                return null!;
            }
            _mapper.Map(maquinaDto, maquinaId);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Atualizado com sucesso");
            return maquinaId;
        }

        public async Task<bool> DeleteMaquinasAsync(int id)
        {
            var maquinaId = await _context.Maquinas.FirstOrDefaultAsync(x => x.Id == id);
            if (maquinaId == null)
            {
                return false;
            }
            _context.Maquinas.Remove(maquinaId);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Maquina {maquinaId.Hostname} deletada com sucesso");
            return true;
        }
    }
}
