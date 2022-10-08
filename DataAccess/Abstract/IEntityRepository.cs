using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //generic constraint
    //burada ki class referanstip olacagini gosterir
    //generic costraint ile t yi sinirlandirdik once T referans tip olsun dedik hem de bu referans tip IEntity veya IEntity implemente eden class olabilir
    //new lenebilir olmali yani soyut bir class degil somut bir class kullanilabilmeli
    public interface IEntityRepository<T> where T : class,IEntity, new() //T icin IEntityi implemente eden newlenebilir(somut) bir referans tip olmali dedik
    {
        List<T> GetAll(Expression<Func<T,bool>> ?filter=null);
        T Get(Expression<Func<T,bool>> filter); //Yukaridakinde ve bu ikisinde oyle bir yapi tasarlayacagiz ki filtre vererek belli bir kismin listelenmesi saglanacak. BU yapi expressin ile gelmekte
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
