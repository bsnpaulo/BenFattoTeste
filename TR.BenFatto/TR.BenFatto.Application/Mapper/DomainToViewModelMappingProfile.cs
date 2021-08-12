using AutoMapper;
using TR.BenFatto.Application.ViewModels;
using TR.BenFatto.Domain.Entities;

namespace TR.BenFatto.Application.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<UserLog, UserLogViewModel>();
        }
    }
}
