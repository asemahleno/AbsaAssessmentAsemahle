namespace ABSA.Corporate.Investment.PhoneBook.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ABSA.Corporate.Investment.PhoneBook.Domain.Models.helpers;

    public class PhoneBook
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        public IEnumerable<Entry> Entries { get; set; }
    }
}
