using Core.Entities;
using DataAccess.DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAcces.Entityframework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         // tekrardan kullanılalir bir yapı
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        public void Add(TEntity entity)//ıdisposible pattern implementation c#
                                       //obje mantığından bahsetmiyor
        {
            using (TContext context = new TContext())//garbage collector işi biitikten sonra silsin diye yazılan kod     
            {
                var addedEntitiy = context.Entry(entity);
                addedEntitiy.State = EntityState.Added;//EntityState statik class mı?
                context.SaveChanges();


            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())//garbage collector işi biitikten sonra silsin diye yazılan kod     
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();


            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)//???
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList()//buysa birinci satırı değilse ikinci satırı calıstır
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())//garbage collector işi biitikten sonra silsin diye yazılan kod     
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
