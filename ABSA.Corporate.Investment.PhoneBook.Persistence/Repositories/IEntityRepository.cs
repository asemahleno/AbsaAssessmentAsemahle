namespace ABSA.Corporate.Investment.PhoneBook.Persistence.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using ABSA.Corporate.Investment.PhoneBook.Domain.Models.helpers;

    public interface IEntityRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class, IIdentifiable<TId> where TId : IComparable
    {
        DatabaseFacade GetUnitOfWork();

        void Add(TEntity entity);

        void Detach(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);

        void Edit(TEntity entity);

        void Delete(TEntity entity);

        int Save();

        Task<int> SaveAsync();
    }
}
