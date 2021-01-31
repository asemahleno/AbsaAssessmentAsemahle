namespace ABSA.Corporate.Investment.PhoneBook.Persistence.Managers
{
    using Domain.Models;
    using System.Collections.Generic;

    public interface IPhoneBookManager
    {
        void CreateOrUpdatePhoneBook(PhoneBook phoneBook);

        void DeletePhoneBook(long id);

        PhoneBook GetPhoneBook(long id);

        IEnumerable<PhoneBook> GetAll();
    }
}
