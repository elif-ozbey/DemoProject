using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {//adi uzerinde servis ben bu metodlari servis ediyorum
        List<Product> GetAll();
        List<Product> GetByCategoryid(int categoryid);
        List<Product> GetByUnitPrice(decimal min, decimal max);
    }
}
