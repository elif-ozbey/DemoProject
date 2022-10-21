using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //context :Db tablolari ile proje classlarini baglamak
    public class NorthwindContext:DbContext
    {//Veri tabanimizin yerini soyluyoruz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectModels;Database=Northwind;Trusted_Connection=true"); //Burada sql server kullanacagimizi belirtmis olduk, nasil baglanacagimizi, sql serverin yerini  parantez icine yaziyoruz
        }
        public DbSet<Product>? Products { get; set; } 
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Order>? Orders { get; set; }

        //hangi nesnenin hangi tabloyla iliskilendirilecegini DbSet ile yapiyoruz
    }
}
