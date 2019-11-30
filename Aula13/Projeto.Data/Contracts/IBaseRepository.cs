using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Contracts
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        void SaveOrUpdate(TEntity obj);
        void Remove(TEntity obj);

        List<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
