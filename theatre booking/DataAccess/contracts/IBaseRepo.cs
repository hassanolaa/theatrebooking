
using System.Collections.Generic;
using System;

namespace theatre_booking.DataAccess.contracts
{
    public interface IBaseRepo<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity FindById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
