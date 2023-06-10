using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETLDados.Data
{
    public class RepositoryBase : IRepositoryBase
    {
        
        public DefaultContext Context { get; }
        
        public RepositoryBase(DefaultContext _context)
        {
            Context = _context;
        }

        

        public void Add<T>(T entity) where T : class
        {
            Context.AddAsync(entity);
        }

        public void AddRange<T>(IEnumerable<T> entities) where T : class
        {
            Context.AddRangeAsync(entities);
        }

        public void Delete<T>(T entity) where T : class
        {
            Context.Remove(entity);
        }

        public void DeleteRange<T>(IEnumerable<T> entities) where T : class
        {
            Context.RemoveRange(entities);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await Context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            Context.Update(entity);
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            Context.UpdateRange(entities);
        }
    }
}