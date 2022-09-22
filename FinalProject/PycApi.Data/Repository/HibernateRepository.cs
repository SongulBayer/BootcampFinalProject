using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PycApi.Data
{
    //methods are filled.
    public class HibernateRepository<Entity> : IHibernateRepository<Entity> where Entity : class
    {
        private readonly ISession session;
        private ITransaction transaction;

        public HibernateRepository(ISession session)
        {
            this.session = session;
        }

        public IQueryable<Entity> Entities => session.Query<Entity>();

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        public void Save(Entity entity)
        {
            session.Save(entity);
        }

        public void Update(Entity entity)
        {
            session.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                session.Delete(entity);
            }
        }

        public List<Entity> GetAll()
        {
            return session.Query<Entity>().ToList();
        }

        public Entity GetById(int id)
        {
            var entity = session.Get<Entity>(id);
            return entity;
        }

        public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> where)
        {
            return session.Query<Entity>().Where(where).AsQueryable();
        }

        public IEnumerable<Entity> Find(Expression<Func<Entity, bool>> expression)
        {
            return session.Query<Entity>().Where(expression).ToList();
        }

        public Entity GetByMail(string mail)
        {
            var entity = session.Get<Entity>(mail);
            return entity;
        }
    }
}