using Fundos.API.Domain.Core.Repository;
using Fundos.API.Domain.Entity;
using Fundos.API.Infra.Data.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundos.API.Infra.Repo
{
    public class FundoRepository : RepositoryBase<Fundo>, IFundoRepository
    {
        private readonly ContextSQLLite _context;

        public FundoRepository(ContextSQLLite context)
            : base(context)
        {
            this._context = context;
        }

        public Fundo GetFundoByCNPJ(string CNPJ)
        {
            try
            {
                return _context.Fundo.Include(c => c.TipoFundo).Where(x => x.Cnpj == CNPJ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void RemoveFundo(Fundo fundo)
        {
            var existingEntity = _context.Fundo.Find(fundo.Codigo);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public Fundo GetFundoByCodigo(string codigo)
        {
            try
            {
                return _context.Fundo.Include(c => c.TipoFundo).Where(x => x.Codigo == codigo).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Fundo> GetAllFundos()
        {
            try
            {
                return _context.Fundo.Include(c => c.TipoFundo).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateFundo(Fundo fundo)
        {
            try
            {
                string sql = "UPDATE Fundo SET nome = @Nome, CNPJ = @CNPJ, CODIGO_TIPO = @Codigo_Tipo, Patrimonio = @Patrimonio WHERE Codigo = @Codigo";

                _context.Database.ExecuteSqlRaw(sql,
                        new Microsoft.Data.Sqlite.SqliteParameter("@Nome", fundo.Nome),
                        new Microsoft.Data.Sqlite.SqliteParameter("@CNPJ", fundo.Cnpj),
                        new Microsoft.Data.Sqlite.SqliteParameter("@Codigo_Tipo", fundo.Codigo_Tipo),
                        new Microsoft.Data.Sqlite.SqliteParameter("@Codigo", fundo.Codigo),
                        new Microsoft.Data.Sqlite.SqliteParameter("@Patrimonio", fundo.Patrimonio));
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
