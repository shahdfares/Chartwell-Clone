using Chartwell.Core.Entity;
using Chartwell.Core.RepositoryContract;
using Chartwell.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ChartwellDbContext _dbContext;

        public GenericRepository(ChartwellDbContext dbContext)
        {
           _dbContext = dbContext;
        }

      
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();  
        }

        public async Task<T?> GetEntityAsync(int id)
        {
          return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
                       => await _dbContext.Set<T>().AddAsync(entity);

        public void Update(T entity)
                      => _dbContext.Set<T>().Update(entity);

        public void Delete(T entity)
                    => _dbContext.Set<T>().Remove(entity);

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).AsNoTracking().ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
        }

        public Task<T?> GetEntityWithSpecs(ISpecification<T> spec)
        {
            return ApplySpecification(spec).FirstOrDefaultAsync();
        }
    }
}
