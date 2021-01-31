namespace ABSA.Corporate.Investment.PhoneBook.Persistence.Repositories.Impl
{
    using Domain.Models;
    using Int64;
    using Microsoft.EntityFrameworkCore;

    public class PhoneBookRepository: EntityRepository<PhoneBook>, IPhoneBookRepository
    {
        public PhoneBookRepository(DbContext context) : base(context)
        {
        }
    }
}
