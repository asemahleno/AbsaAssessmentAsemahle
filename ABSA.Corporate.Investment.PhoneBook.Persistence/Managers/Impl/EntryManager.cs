using Microsoft.EntityFrameworkCore;

namespace ABSA.Corporate.Investment.PhoneBook.Persistence.Managers.Impl
{
    using System.Linq;
    using Domain.Models;
    using Repositories;
    public class EntryManager : IEntryManager
    {
        private readonly IEntryRepository _entryRepository;


        public EntryManager(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public void CreateOrUpdateEntry(Entry entry)
        {
            var existingEntry = GetEntryById(entry.Id);
            if (existingEntry == null)
            {
              _entryRepository.Add(entry);
            }
            else
            {
                _entryRepository.Detach(existingEntry);
                existingEntry.Name = entry.Name;
                existingEntry.PhoneNumber = entry.PhoneNumber;
                _entryRepository.Edit(existingEntry);
            }

            _entryRepository.Save();

        }

        public void DeleteEntry(long id)
        {
            var entry = GetEntry(id);
            _entryRepository.Delete(entry);
            _entryRepository.Save();
        }

        public Entry GetEntry(long id)
        {
            var entry = GetEntryById(id);

            return entry;
        }

        private Entry GetEntryById(long id)
        {
            return _entryRepository.FindBy(record => record.Id == id).FirstOrDefault();
        }
    }
}
