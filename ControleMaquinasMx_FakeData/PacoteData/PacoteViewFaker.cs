using Bogus;
using ControleMaquinasMx_DomainShared.PacotesDtos;

namespace ControleMaquinasMx_FakeData.HostnameData
{
    public class PacoteViewFaker : Faker<PacoteViewDto>
    {
        public PacoteViewFaker()
        {
            var id = new Faker().Random.Number(1, 500);
            RuleFor(x => x.Id, x => id);
            RuleFor(x => x.NomeKb, x => x.Name.Random.Word());
            RuleFor(x => x.MaquinasId, x => x.Random.Number(1, 20));
            RuleFor(x => x.DataInstalacao, x => x.Date.Past());
            RuleFor(x => x.DataAtualizacao, x => x.Date.Past());
        }
    }
}
