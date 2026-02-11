using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MultiShop.Order.Application.Interfaces
{
    internal interface IRepository<T> 
        where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByFilterAsync(Expression<Func<T,bool>> expression);

    }
}
