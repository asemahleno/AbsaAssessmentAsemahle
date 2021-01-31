namespace ABSA.Corporate.Investment.PhoneBook.Domain.Models.helpers
{
    public interface IIdentifiable<TId>
    {
        TId Id { get; set; }
    }
}
