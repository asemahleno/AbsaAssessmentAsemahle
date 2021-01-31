using ABSA.Corporate.Investment.PhoneBook.Domain.Models.helpers;

namespace ABSA.Corporate.Investment.PhoneBook.Persistence.Repositories.Int64
{
    using Microsoft.EntityFrameworkCore;
    public class EntityRepository<TEntity> : EntityRepository<TEntity, long>, IEntityRepository<TEntity>
        where TEntity : class, IIdentifiable<long>
    {
        public EntityRepository(DbContext context)
            : base(context)
        {
        }
    }
}
