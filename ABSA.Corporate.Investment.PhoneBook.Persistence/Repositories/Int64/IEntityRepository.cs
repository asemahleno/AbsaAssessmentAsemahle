namespace ABSA.Corporate.Investment.PhoneBook.Persistence.Repositories.Int64
{
    using ABSA.Corporate.Investment.PhoneBook.Domain.Models.helpers;
    public interface IEntityRepository<TEntity> : IEntityRepository<TEntity, long>
        where TEntity : class, IIdentifiable<long>
    {
    }
}
