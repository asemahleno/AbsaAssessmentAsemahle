namespace ABSA.Corporate.Investment.PhoneBook.Models
{
    using System.ComponentModel.DataAnnotations;

    public  class Entry
    {
        public long Id { get; set; }

        public long PhoneBookId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
