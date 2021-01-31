namespace ABSA.Corporate.Investment.PhoneBook.Mappers
{
    using AutoMapper;
    public class EntryProfile : Profile
    {
        public EntryProfile()
        {
            CreateMap<Models.Entry, Domain.Models.Entry>().ReverseMap();
        }
    }
}
