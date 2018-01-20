using AutoMapper;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Data.Entities;

namespace TemplateDotNetCore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel,ProductCategory>()
                .ConstructUsing(c => new ProductCategory(c.Name, c.Discription, c.ParentId, c.HomeOrder, c.Image, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription,
                c.Status, c.LanguageId, c.Tags, c.DateCreated, c.DateModified, c.SortOrder, c.HomeFlag, c.HotFlag, c.NewFlag));
        }
    }
}