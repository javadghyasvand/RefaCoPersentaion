
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace My_Shop_Framework.Infrastructure
{
    public class RepositoryBase<TKey, TValue> : IRepository<TKey, TValue> where TValue : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public void Create(TValue value)
        {
            _context.Add(value);
        }

        public bool Exists(Expression<Func<TValue, bool>> expression)
        {
            return _context.Set<TValue>().Any(expression);
        }

        public TValue Get(TKey id)
        {

            var value = _context.Find<TValue>(id);
            return value;
        }

        public List<TValue> Get()
        {
            return _context.Set<TValue>().ToList();
        }

        public void SaveChanges()
        {
             _context.SaveChanges();
        }
    }
}
