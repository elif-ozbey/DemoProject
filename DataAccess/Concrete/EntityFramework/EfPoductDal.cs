using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPoductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of c#
            using (NorthwindContext contex = new NorthwindContext())
            {
                var addedEntity = contex.Entry(entity);//referansi yakala
                addedEntity.State = EntityState.Added;//o eklenecek bir nesne
                contex.SaveChanges();//ekle ve kaydet
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext contex = new NorthwindContext())
            {
                var deletedEntity = contex.Entry(entity);//referansi yakala
                deletedEntity.State = EntityState.Deleted;//o silinecek bir nesne
                contex.SaveChanges();//ekle ve kaydet
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
           using(NorthwindContext context =new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
                
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> ?filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext contex = new NorthwindContext())
            {
                var updatedEntity = contex.Entry(entity);//referansi yakala
                updatedEntity.State = EntityState.Modified;//o eklenecek bir nesne
                contex.SaveChanges();//ekle ve kaydet
            }
        }
    }
}
