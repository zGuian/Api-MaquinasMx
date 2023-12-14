using ControleMaquinasMx.Core.Models;
using System.Text.Json.Serialization;

namespace ControleMaquinasMx_CoreShared.PacotesDtos
{
    public class PacoteViewDto : ICloneable
    {
        public int Id { get; set; }
        public string? NomeKb { get; set; }
        public int? MaquinasId { get; set; }
        public DateTime? DataInstalacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        [JsonIgnore]
        public Maquina? Maquinas { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
