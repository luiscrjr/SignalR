using Projeto.Data.Contracts;
using Projeto.Data.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly string connectionString;

        protected BaseRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void SaveOrUpdate(TEntity obj)
        {
            using (var session = HibernateUtil.SessionFactory(connectionString).OpenSession())
            {
                var transaction = session.BeginTransaction();
                session.SaveOrUpdate(obj);
                transaction.Commit();
            }
        }

        public void Remove(TEntity obj)
        {
            using (var session = HibernateUtil.SessionFactory(connectionString).OpenSession())
            {
                var transaction = session.BeginTransaction();
                session.Delete(obj);
                transaction.Commit();
            }
            
        }

        public List<TEntity> GetAll()
        {
            using (var session = HibernateUtil.SessionFactory(connectionString).OpenSession())
            {
                return session.Query<TEntity>().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (var session = HibernateUtil.SessionFactory(connectionString).OpenSession())
            {
                return session.Get<TEntity>(id);
            }
        }
    }
}
