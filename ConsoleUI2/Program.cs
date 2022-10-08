// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

PruductManager productManager = new PruductManager(new EfPoductDal());
foreach (var product in productManager.GetByCategoryid(2))
{
    Console.WriteLine(product.ProductName);
}

foreach (var product in productManager.GetByUnitPrice(40,100))
{
    Console.WriteLine(product.ProductName);
}