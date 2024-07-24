using Fundos.Api.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundos.API.Domain.Core.Repository
{
    public interface IBaseRepository<T> where T : Base
    {
        T Get(int ID);

        IEnumerable<T> GetAll();

        void Save(T obj);

        void Update(T obj);

        void Remove(T obj);

        void Dispose();

    }
}
