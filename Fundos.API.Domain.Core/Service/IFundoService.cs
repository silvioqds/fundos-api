using Fundos.API.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Fundos.API.Domain.Core.Service
{
    public interface IFundoService : IBaseService<Fundo>
    {
        Fundo GetFundoByCodigo(string codigo);
        void UpdateFundo(Fundo fundo);
        void RemoveFundo(Fundo fundo);

        Fundo GetFundoByCNPJ(string cnPJ);
        List<Fundo> GetAllFundos();
    }
}
