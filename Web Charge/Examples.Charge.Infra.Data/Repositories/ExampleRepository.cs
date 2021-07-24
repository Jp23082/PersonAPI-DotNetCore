using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class ExampleRepository<TEntity> : IExampleRepository<TEntity> where TEntity: class
    {
        protected readonly ExampleContext _context;

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        public ExampleRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Example>> FindAllAsync() => await Task.Run(() => _context.Example);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> Query()
        {
            try
            {
                return DbSet;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
