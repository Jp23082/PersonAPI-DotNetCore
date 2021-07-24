using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces
{
    public interface IExampleRepository<TEntity>: IDisposable where TEntity: class
    {
        Task<IEnumerable<Example>> FindAllAsync();
    }
}
