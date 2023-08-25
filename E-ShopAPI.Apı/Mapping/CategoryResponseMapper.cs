using AutoMapper;
using E_ShopAPI.Entity.DTO.Category;
using E_ShopAPI.Entity.Poco;

namespace E_ShopAPI.Apı.Mapping
{
    public class CategoryResponseMapper : Profile
    {
        public CategoryResponseMapper()
        {
            CreateMap<Category, CategoryDTOResponse>()
               .ForMember(dest => dest.Name, opt =>
               {
                   opt.MapFrom(src => src.Name);
               })
               .ForMember(dest => dest.Guid, opt =>
               {
                   opt.MapFrom(src => src.GUID);
               }).ReverseMap();

        }
    }
}
