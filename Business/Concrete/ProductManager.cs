using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal) //injection yapiyoruz
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Masseges.ProductNameInvalid);
            }
            //business kodlar buraya yazilir
            _productDal.Add(product);
            return new SuccessResult(Masseges.ProductAdded); //bunu boyle yapabilmenin yolu konstraktir eklemektir. Konstraktir eklemeden Result a parametre gonderemeyiz.
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Product>>(Masseges.MaintenanceTime);
            }
           return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Masseges.ProductsListed); //DataResult icinde data da olan sabit sinif
        }

        public IDataResult<List<Product>> GetByCategoryid(int categoryid)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryid));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=> p.ProductId==productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> ( _productDal.GetAll(p=> p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {

            if (DateTime.Now.Hour == 2)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Masseges.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
