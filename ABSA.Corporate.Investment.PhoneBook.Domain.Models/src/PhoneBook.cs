using System.Collections.Generic;
using ABSA.Corporate.Investment.PhoneBook.Domain.Models.helpers;

namespace ABSA.Corporate.Investment.PhoneBook.Domain.Models
{
    public class PhoneBook : IIdentifiable<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        #region Navigable properties

        public ICollection<Entry> Entries { get; set; }
        #endregion
    }
}
