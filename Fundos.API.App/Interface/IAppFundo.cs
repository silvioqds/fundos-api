using Fundos.API.App.DTO;
using Fundos.API.App.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundos.API.App.Interface
{
    public interface IAppFundo
    {
        FundoDTOView GetFundo(string codigo);
        IEnumerable<FundoDTOView> GetAllFundo();
        void GravarFundo(FundoDTO fundo);
        void UpdateFundo(FundoDTO fundo);
        void DeleteFundo(string codigo);
        FundoDTO MovimentarPatrimonio(string codigo, MovimentacaoDTO movimentacao);


    }
}
