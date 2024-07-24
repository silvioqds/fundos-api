using Fundos.API.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fundos.API.Domain.Core.Repository
{
    public interface IFundoRepository : IBaseRepository<Fundo>
    {
        Fundo GetFundoByCNPJ(string CNPJ);
        Fundo GetFundoByCodigo(string codigo);
        void UpdateFundo(Fundo fundo);
        void RemoveFundo(Fundo fundo);
        List<Fundo> GetAllFundos();
    }
}
