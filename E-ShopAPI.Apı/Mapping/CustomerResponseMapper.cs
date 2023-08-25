using AutoMapper;
using E_ShopAPI.Entity.DTO.Customer;
using E_ShopAPI.Entity.Poco;

namespace E_ShopAPI.Apı.Mapping
{
    public class CustomerResponseMapper : Profile
    {
        public CustomerResponseMapper()
        {
            CreateMap<Customer, CustomerDTOResponse>()
         .ForMember(dest => dest.FirstName, opt =>
         {
             opt.MapFrom(src => src.FirstName);
         })
         .ForMember(dest => dest.LastName, opt =>
         {
             opt.MapFrom(src => src.LastName);
         })
         .ForMember(dest => dest.Customername, opt =>
         {
             opt.MapFrom(src => src.Customername);
         })
         .ForMember(dest => dest.Password, opt =>
         {
             opt.MapFrom(src => src.Password);
         })
         .ForMember(dest => dest.PhoneNumber, opt =>
         {
             opt.MapFrom(src => src.PhoneNumber);
         })
         .ForMember(dest => dest.Email, opt =>
         {
             opt.MapFrom(src => src.Email);
         })
         .ForMember(dest => dest.Adress, opt =>
         {
             opt.MapFrom(src => src.Adress);
         })
          .ForMember(dest => dest.Guid, opt =>
          {
              opt.MapFrom(src => src.GUID);
          }).ReverseMap();
        }
    }
}
