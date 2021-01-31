namespace ABSA.Corporate.Investment.PhoneBook.Persistence.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Domain.Models.helpers;

    public class EntityRepository<TEntity, TId> : IEntityRepository<TEntity, TId>
        where TEntity : class, IIdentifiable<TId> where TId : IComparable
    {
        private readonly DbContext _context;

        public EntityRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            var queryable = GetAll().Where(predicate);
            return queryable;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entityEntryResult = await _context.Set<TEntity>().AddAsync(entity);
            return await Task.FromResult(entityEntryResult.Entity);
        }

        public DatabaseFacade GetUnitOfWork()
        {
            return _context.Database;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Detach(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public void Edit(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            var intResult = await _context.SaveChangesAsync();
            return await Task.FromResult(intResult);
        }
    }
}
