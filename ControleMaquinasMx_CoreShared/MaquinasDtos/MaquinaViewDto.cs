using ControleMaquinasMx_Domain.Entities.Enum;
using ControleMaquinasMx_DomainShared.PacotesDtos;

namespace ControleMaquinasMx_DomainShared.MaquinasDtos
{
    /// <summary>
    /// Objeto utilizado para visualizar maquina
    /// </summary>
    public class MaquinaViewDto : ICloneable
    {
        public int Id { get; set; }
        public string? Inventario { get; set; }
        public string? Hostname { get; set; }
        public bool Ondeso { get; set; }
        public Criticidade Criticidade { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }
        public ICollection<PacoteViewDto>? Pacotes { get; set; }

        public object Clone()
        {
            var maquina = (MaquinaViewDto)MemberwiseClone();
            var pacotes = new List<PacoteViewDto>();
            maquina.Pacotes.ToList().ForEach(x => pacotes.Add((PacoteViewDto)x.Clone()));
            maquina.Pacotes = pacotes;
            return maquina;
        }

        public MaquinaViewDto CloneTipado()
        {
            return (MaquinaViewDto)Clone();
        }
    }
}
