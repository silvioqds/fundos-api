using Fundos.API.App.DTO;
using Fundos.API.App.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundos.API.App.Interface
{
    public interface IAppTipoFundo
    {
        TipoFundoDTO GetTipoFundo(int codigo);
        IEnumerable<TipoFundoDTO> GetAllTiposFundo();
        void GravarTipoFundo(TipoFundoDTO fundo);
        void UpdateTipoFundo(TipoFundoDTO fundo);
        void DeleteTipoFundo(int codigo);      
    }
}
