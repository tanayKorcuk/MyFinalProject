using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal1
    {
        public void Add(Product entity)//ıdisposible pattern implementation c#
            //obje mantığından bahsetmiyor
        {
            using (NorthwindContext context = new NorthwindContext())//garbage collector işi biitikten sonra silsin diye yazılan kod     
            {
                var addedEntitiy = context.Entry(entity);
                addedEntitiy.State = EntityState.Added;//EntityState statik class mı?
                context.SaveChanges();


            }
        }
            public void Delete(Product entity)
            {
            using (NorthwindContext context = new NorthwindContext())//garbage collector işi biitikten sonra silsin diye yazılan kod     
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();


            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)//???
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

            public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
            {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList()//buysa birinci satırı değilse ikinci satırı calıstır
                    : context.Set<Product>().Where(filter).ToList();
            }
                    
                    
                    }

            public void Update(Product entity)
            {
            using (NorthwindContext context = new NorthwindContext())//garbage collector işi biitikten sonra silsin diye yazılan kod     
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();


            }
        }



        }
        
    }
