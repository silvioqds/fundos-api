using Fundos.Api.Domain.Entity;
using Fundos.API.Domain.Core.Repository;
using Fundos.API.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fundos.API.Infra.Repo
{
    public class RepositoryBase<T> : IDisposable, IBaseRepository<T> where T : Base
    {

        private readonly ContextSQLLite _context;

        public RepositoryBase(ContextSQLLite context)
        {
            this._context = context;
        }

        public T Get(int ID)
        {
            return _context.Set<T>().Find(ID);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Save(T obj)
        {
            try
            {
                _context.Set<T>().Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(T obj)
        {
            try
            {
                _context.Set<T>().Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
