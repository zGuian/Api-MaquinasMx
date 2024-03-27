using Bogus;
using ControleMaquinasMx_Domain.Entities.Enum;
using ControleMaquinasMx_DomainShared.MaquinasDtos;
using ControleMaquinasMx_FakeData.HostnameData;

namespace ControleMaquinasMx_FakeData.ClienteData
{
    public class MaquinaViewFaker : Faker<MaquinaViewDto>
    {
        public MaquinaViewFaker()
        {
            var id = new Faker().Random.Number(1, 200);
            RuleFor(x => x.Id, x => id);
            RuleFor(x => x.Inventario, x => x.Random.Word());
            RuleFor(x => x.Hostname, x => x.Random.Word());
            RuleFor(x => x.Ondeso, x => x.PickRandom(new[] { true, false }));
            RuleFor(x => x.Criticidade, x => x.PickRandom<Criticidade>());
            RuleFor(x => x.DataCadastro, x => x.Date.Past());
            RuleFor(x => x.UltimaAtualizacao, x => x.Date.Past());
            RuleFor(x => x.Pacotes, x => new PacoteViewFaker().Generate(5));
        }
    }
}
