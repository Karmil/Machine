using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Adneom.Distributeur.ApplicationCore.Entities;
using Adneom.Distributeur.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Adneom.Distributeur.Infrastucture.Data
{
    public class EfRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly DistruputionContext _dbContext;

        public EfRepository(DistruputionContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(string id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        
        public IEnumerable<T> ListAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }


        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        #region  Save liste  
        // update and add list async 
        public async Task<List<T>> UpdateListAsync(List<T> entity)
        {
            foreach (var item in entity)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<List<T>> AddListAsync(List<T> entity)
        {
            foreach (var item in entity)
            {
                _dbContext.Set<T>().Add(item);
            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public void UpdateList(List<T> entity)
        {
            foreach (var item in entity)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();

        }
        public List<T> AddList(List<T> entity)
        {
            foreach (var item in entity)
            {
                _dbContext.Set<T>().Add(item);
            }
            _dbContext.SaveChanges();
            return entity;
        }
        #endregion

    }
}
