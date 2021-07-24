using Abp.Domain.Entities;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : ExampleRepository<PersonPhone>, IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context):base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);


        //Retorna os PersonPhone cadastrados
        public IEnumerable<PersonPhone> GetAll()
        {
            try
            {
                return Query();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Insere um PersonPhone
        public PersonPhone Create(PersonPhone model)
        {
            try
            {
                _context.PersonPhone.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public PersonPhone Find(Expression<Func<PersonPhone, bool>> where)
        {
            try
            {
                return DbSet.AsNoTracking().FirstOrDefault(where);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool Update(PersonPhone model)
        {
            try
            {
                EntityEntry<PersonPhone> entry = NewMethod(model);

                DbSet.Attach(model);

                entry.State = EntityState.Modified;

                return Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(List<PersonPhone> models)
        {
            try
            {
                foreach (PersonPhone register in models)
                {
                    EntityEntry<PersonPhone> entry = _context.Entry(register);
                    DbSet.Attach(register);
                    entry.State = EntityState.Modified;
                }

                return Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private EntityEntry<PersonPhone> NewMethod(PersonPhone model)
        {
            return _context.Entry(model);
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(PersonPhone model)
        {
            try
            {
                if (model is Entity)
                {
                    EntityEntry<PersonPhone> _entry = _context.Entry(model);

                    DbSet.Attach(model);

                    _entry.State = EntityState.Modified;
                }
                else
                {
                    EntityEntry<PersonPhone> _entry = _context.Entry(model);
                    DbSet.Attach(model);
                    _entry.State = EntityState.Deleted;
                }

                return Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Expression<Func<PersonPhone, bool>> where)
        {
            try
            {
                PersonPhone model = DbSet.Where<PersonPhone>(where).FirstOrDefault<PersonPhone>();

                return (model != null) && Delete(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
