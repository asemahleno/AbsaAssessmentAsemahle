namespace ABSA.Corporate.Investment.PhoneBook.Persistence.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain.Models.helpers;
    public interface IRepository<TEntity, TId>
        where TEntity : class, IIdentifiable<TId> where TId : IComparable
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
    }
}
