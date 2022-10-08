using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PruductManager : IProductService
    {
        IProductDal _productDal;

        public PruductManager(IProductDal productDal) //injection yapiyoruz
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
           return _productDal.GetAll();
        }

        public List<Product> GetByCategoryid(int categoryid)
        {
            return _productDal.GetAll(p=> p.CategoryId == categoryid);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=> p.UnitPrice>=min && p.UnitPrice<=max);
        }
    }
}
