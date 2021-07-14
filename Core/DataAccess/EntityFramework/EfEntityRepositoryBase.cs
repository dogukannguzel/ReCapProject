using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Core.DataAccess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity,TContext>
                                   where TEntity:class,IEntity,new()
                                   where TContext:DbContext,new()
    {

        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var AddedEntity = context.Entry(entity);
                AddedEntity.State = EntityState.Added;
                context.SaveChanges();
            }

        }
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var DeleteEntity = context.Entry(entity);
                DeleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }
        public void Uptade(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var UptadetEntity = context.Entry(entity);
                UptadetEntity.State = EntityState.Modified;
                context.SaveChanges();
            }

        }
        public TEntity Get(Expression<Func<TEntity,bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }

        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter=null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                     ? context.Set<TEntity>().ToList()
                     : context.Set<TEntity>().Where(filter).ToList();
            }

        }
    }
}
