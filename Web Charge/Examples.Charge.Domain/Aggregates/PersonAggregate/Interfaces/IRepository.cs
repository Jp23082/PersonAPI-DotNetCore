using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IRepository<TEntity>:IDisposable where TEntity : class
    {
        TEntity Create(TEntity model);
        TEntity Find(Expression<Func<TEntity, bool>> where);
        bool Update(TEntity model);
        bool Delete(PersonPhone model);

    }
}
