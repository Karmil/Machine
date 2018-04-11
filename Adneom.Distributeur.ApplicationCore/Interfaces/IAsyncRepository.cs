using Adneom.Distributeur.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adneom.Distributeur.ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(string id);
        Task<List<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        // update and add list async 
        Task<List<T>> UpdateListAsync(List<T> entity);
        Task<List<T>> AddListAsync(List<T> entity);
    }
}
