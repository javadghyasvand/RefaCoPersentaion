using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop_Framework.Domain
{
    public interface IRepository<in TKey, TValue> where TValue : class
    {
        TValue Get(TKey id);
        List<TValue> Get();
        void Create(TValue value);
        bool Exists(Expression<Func<TValue, bool>> expression);
        void SaveChanges();
    }
}
