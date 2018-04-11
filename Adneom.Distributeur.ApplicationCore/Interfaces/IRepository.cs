using Adneom.Distributeur.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adneom.Distributeur.ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(string id);
        IEnumerable<T> ListAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> AddList(List<T> entity);
        void UpdateList(List<T> entity);
    }
}
