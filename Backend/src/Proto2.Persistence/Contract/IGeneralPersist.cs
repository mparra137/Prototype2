using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proto2.Persistence.Contract
{
    public interface IGeneralPersist
    {
        void Insert<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T entity) where T: class;
        Task<bool> SaveChangesAsync();

    }
}