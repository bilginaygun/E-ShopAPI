using AutoMapper;
using E_ShopAPI.Entity.DTO.Category;
using E_ShopAPI.Entity.Poco;

namespace E_ShopAPI.Apı.Mapping
{
    public class CategoryRequestMapper : Profile
    {
        public CategoryRequestMapper()
        {
            CreateMap<Category, CategoryDTORequest>()
                .ForMember(dest => dest.Name, opt =>
                {
                    opt.MapFrom(src => src.Name);
                }).ReverseMap();


        }
    }
}
