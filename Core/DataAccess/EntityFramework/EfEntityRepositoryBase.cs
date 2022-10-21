﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity> 
        where TEntity : class,IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext contex = new TContext())
            {
                var addedEntity = contex.Entry(entity);//referansi yakala
                addedEntity.State = EntityState.Added;//o eklenecek bir nesne
                contex.SaveChanges();//ekle ve kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext contex = new TContext())
            {
                var deletedEntity = contex.Entry(entity);//referansi yakala
                deletedEntity.State = EntityState.Deleted;//o silinecek bir nesne
                contex.SaveChanges();//ekle ve kaydet
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter)!;

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext contex = new TContext())
            {
                var updatedEntity = contex.Entry(entity);//referansi yakala
                updatedEntity.State = EntityState.Modified;//o eklenecek bir nesne
                contex.SaveChanges();//ekle ve kaydet
            }
        }
    }
}
