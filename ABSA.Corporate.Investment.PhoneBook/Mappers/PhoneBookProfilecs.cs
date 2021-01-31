namespace ABSA.Corporate.Investment.PhoneBook.Mappers
{
    using AutoMapper;
    public class PhoneBookProfile : Profile
    {
        public PhoneBookProfile()
        {
            CreateMap<Domain.Models.PhoneBook, Models.PhoneBook>().ReverseMap();
        }
    }
}
