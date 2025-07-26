using Chartwell.Core.Entity;
using Chartwell.Core.RepositoryContract;
using Chartwell.Infrastructure.Data.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repository;
        private readonly ChartwellDbContext _dbContext;

        public UnitOfWork(ChartwellDbContext dbContext)
        {
            _dbContext = dbContext;
            _repository = new Hashtable();
        }
        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            var key = typeof(T).Name;

            if (!_repository.ContainsKey(key))
            {

                var repository = new GenericRepository<T>(_dbContext);
                _repository.Add(key, repository);
            }
            return _repository[key] as IGenericRepository<T>;
        }

        public async Task<int> CompleteAsync()
                          => await _dbContext.SaveChangesAsync();

        public  ValueTask DisposeAsync()
                         => _dbContext.DisposeAsync();

    }
}
