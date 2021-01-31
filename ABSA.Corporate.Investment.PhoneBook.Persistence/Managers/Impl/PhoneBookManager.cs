using Microsoft.EntityFrameworkCore;

namespace ABSA.Corporate.Investment.PhoneBook.Persistence.Managers.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Repositories;

    public class PhoneBookManager : IPhoneBookManager
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public PhoneBookManager(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }

        public void CreateOrUpdatePhoneBook(Domain.Models.PhoneBook phoneBook)
        {
            var existingPhoneBook = GetPhoneBookById(phoneBook.Id);
            if (existingPhoneBook == null)
            {
                _phoneBookRepository.Add(phoneBook);
            }
            else
            {
                _phoneBookRepository.Detach(existingPhoneBook);
                existingPhoneBook.Name = phoneBook.Name;
                existingPhoneBook.Entries = phoneBook.Entries;
                _phoneBookRepository.Edit(existingPhoneBook);
            }

            _phoneBookRepository.Save();
        }

        public void DeletePhoneBook(long id)
        {
            var entry = GetPhoneBookById(id);
            _phoneBookRepository.Delete(entry);
            _phoneBookRepository.Save();
        }

        public IEnumerable<Domain.Models.PhoneBook> GetAll()
        {
            return _phoneBookRepository.GetAll().Include(record => record.Entries);
        }

        public Domain.Models.PhoneBook GetPhoneBook(long id)
        {
            return GetPhoneBookById(id);
        }
        private Domain.Models.PhoneBook GetPhoneBookById(long id)
        {
            return _phoneBookRepository.FindBy(record => record.Id == id).Include(record => record.Entries).FirstOrDefault();
        }
    }
}
