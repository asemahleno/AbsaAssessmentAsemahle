using ABSA.Corporate.Investment.PhoneBook.Domain.Models;
using ABSA.Corporate.Investment.PhoneBook.Persistence.Repositories.Int64;
using Microsoft.EntityFrameworkCore;

namespace ABSA.Corporate.Investment.PhoneBook.Persistence.Repositories.Impl
{
    public class EntryRepository: EntityRepository<Entry>, IEntryRepository
    {
        public EntryRepository(DbContext context) : base(context)
        {
        }
    }
}
