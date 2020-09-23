using System;
using System.Collections.Generic;
using TP_Domain.Entities;

namespace TP_Domain.Commands
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}