using AutoMapper;
using E_ShopAPI.Entity.DTO.Product;
using E_ShopAPI.Entity.Poco;

namespace E_ShopAPI.Apı.Mapping
{
    public class ProductResponseMapper : Profile
    {
        public ProductResponseMapper()
        {
            CreateMap<Product, ProductDTOResponse>()
               .ForMember(dest => dest.Name, opt =>
               {
                   opt.MapFrom(src => src.Name);
               })
               .ForMember(dest => dest.Guid, opt =>
               {
                   opt.MapFrom(src => src.GUID);
               }).ForMember(dest => dest.Description, opt =>
               {
                   opt.MapFrom(src => src.Description);
               }).ForMember(dest => dest.FeaturedImage, opt =>
               {
                   opt.MapFrom(src => src.FeaturedImage);
               }).ForMember(dest => dest.CategoryName, opt =>
               {
                   opt.MapFrom(src => src.Category.Name);
               }).ForMember(dest => dest.CategoryGuid, opt =>
               {
                   opt.MapFrom(src => src.Category.GUID);
               }).ForMember(dest => dest.UnitPrice, opt =>
               {
                   opt.MapFrom(src => src.UnitPrice);
               }).ReverseMap();

        }
    }
}
