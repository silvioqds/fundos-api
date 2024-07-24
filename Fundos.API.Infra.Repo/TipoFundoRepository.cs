using Fundos.Api.Domain.Entity;
using Fundos.API.Domain.Core.Repository;
using Fundos.API.Domain.Entity;
using Fundos.API.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundos.API.Infra.Repo
{
    public class TipoFundoRepository : RepositoryBase<TipoFundo>, ITipoFundoRepository
    {
        private readonly ContextSQLLite _context;
        public TipoFundoRepository(ContextSQLLite context) 
            : base(context)
        {
            this._context = context;
        }
    }
}
