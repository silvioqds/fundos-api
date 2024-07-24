using Fundos.Api.Domain.Entity;
using Fundos.API.Domain.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundos.API.Domain.Core.Service
{
    public abstract class ServiceBase<T> : IDisposable, IBaseService<T> where T : Base
    {

        private readonly IBaseRepository<T> _repository;


        public ServiceBase(IBaseRepository<T> repository)
        {
            this._repository = repository;
        }

        public virtual T Get(int ID)
        {
            return _repository.Get(ID);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Remove(T obj)
        {
            _repository.Remove(obj);
        }

        public void Save(T obj)
        {
            _repository.Save(obj);
        }

        public void Update(T obj)
        {
            _repository.Update(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
