namespace ABSA.Corporate.Investment.PhoneBook.Persistence.Managers
{
    using Domain.Models;

    public interface IEntryManager
    {
        void CreateOrUpdateEntry(Entry entry);

        void DeleteEntry(long id);

        Entry GetEntry(long id);

    }
}
