﻿using AutoMapper;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Data.Entities;

namespace TemplateDotNetCore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Function, FunctionViewModel>();
            CreateMap<Slide, SlideViewModel>();
            CreateMap<ProductImage, ProductImageViewModel>();
            CreateMap<Color, ColorViewModel>();
            CreateMap<Bill, BillViewModel>();
            CreateMap<Size,SizeViewModel>();
        }
    }
}