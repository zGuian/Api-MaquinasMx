using ControleMaquinasMx_Domain.Entities;
using GraphQL.Types;

namespace ControleMaquinasMx.GraphQL
{
    public class MaquinasType : ObjectGraphType<Maquina>
    {
        public MaquinasType()
        {
            Field(x => x.Id);
            Field(x => x.Inventario);
            Field(x => x.Hostname);
            Field(x => x.Ondeso);
            Field(x => x.Criticidade);
            Field(x => x.DataCadastro);
            Field(x => x.UltimaAtualizacao);
            Field(x => x.Pacotes);

            Field<ListGraphType<MaquinasType>>("maquinas");
        }
    }
}
