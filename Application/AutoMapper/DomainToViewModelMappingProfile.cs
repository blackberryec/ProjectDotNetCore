using AutoMapper;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Data.Entities;

namespace TemplateDotNetCore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Function, FunctionViewModel>();
        }
    }
}