﻿namespace ControleMaquinasMx_DomainShared.PacotesDtos
{
    public class PacoteViewDto : ICloneable
    {
        public int Id { get; set; }
        public string? NomeKb { get; set; }
        public int? MaquinasId { get; set; }
        public DateTime? DataInstalacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public PacoteViewDto CloneTipado()
        {
            return (PacoteViewDto)Clone();
        }
    }
}
