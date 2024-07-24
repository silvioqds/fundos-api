using Fundos.Api.Domain.Entity;
using Fundos.API.Domain.Core.Repository;
using Fundos.API.Domain.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundos.API.Domain.Service
{
    public class TipoFundoService : BaseService<TipoFundo>, ITipoFundoService
    {
        public readonly ITipoFundoRepository _repository;

        public TipoFundoService(ITipoFundoRepository repo)
            : base(repo)
        {
            _repository = repo;
        }
    }
}
