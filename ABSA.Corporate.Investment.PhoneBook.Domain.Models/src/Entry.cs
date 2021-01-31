using System.ComponentModel.DataAnnotations.Schema;
using ABSA.Corporate.Investment.PhoneBook.Domain.Models.helpers;

namespace ABSA.Corporate.Investment.PhoneBook.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public  class Entry: IIdentifiable<long>
    {
        public long Id { get; set; }

        [ForeignKey("PhoneBookId")]
        public long PhoneBookId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        #region Navigable Properties
        public PhoneBook PhoneBook { get; set; }
        #endregion

    }
}
