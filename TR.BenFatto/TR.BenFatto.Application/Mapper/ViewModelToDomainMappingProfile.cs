using AutoMapper;
using TR.BenFatto.Application.ViewModels;
using TR.BenFatto.Domain.Entities;

namespace TR.BenFatto.Application.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<UserLogViewModel, UserLog>();
        }
    }
}
