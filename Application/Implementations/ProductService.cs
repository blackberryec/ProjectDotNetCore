using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemplateDotNetCore.Application.Interfaces;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Application.ViewModels.Common;
using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Data.Enums;
using TemplateDotNetCore.Data.IRepositories;
using TemplateDotNetCore.Infrastucture.Interfaces;
using TemplateDotNetCore.Utilities.Dtos;

namespace TemplateDotNetCore.Application.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IProductTagRepository _productTagRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IProductImageRepository productImageRepository,ITagRepository tagRepository, IProductTagRepository productTagRepository)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _productImageRepository = productImageRepository;
            _productTagRepository = productTagRepository;
            _tagRepository = tagRepository;
        }

        public ProductViewModel Add(ProductViewModel productViewModel)
        {
            List<ProductTag> productTags = new List<ProductTag>();
            return new ProductViewModel();
        }

        //public void Update(ProductViewModel productCategoryVm)
        //{
        //    var product = Mapper.Map<ProductViewModel, Product>(productCategoryVm);
        //    _productRepository.Update(product);
        //}

        public List<ProductImageViewModel> GetImages(int productId)
        {
            return _productImageRepository.FindAll(x => x.ProductId == productId)
                .ProjectTo<ProductImageViewModel>().ToList();
        }

        public List<ProductViewModel> GetHotProducts(int top)
        {
            return _productRepository.FindAll(x => x.Status == Status.Active && x.HomeFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .Take(top)
                .ProjectTo<ProductViewModel>()
                .ToList();
        }

        public void Delete(int id)
        {
            _productRepository.Remove(id);
        }

        
        public IQueryable<ProductViewModel> GetAll()
        {
            return _productRepository.FindAll(x => x.ProductCategory).ProjectTo<ProductViewModel>();
        }

        public ProductViewModel GetById(int id)
        {
            return Mapper.Map<Product, ProductViewModel>(_productRepository.FindById(id));
        }

        public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var query = _productRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));
            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId.Value);

            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ProjectTo<ProductViewModel>().ToList();

            var paginationSet = new PagedResult<ProductViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;

        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ProductViewModel> GetRelatedProducts(int id, int top)
        {
            var product = _productRepository.FindById(id);
            return _productRepository.FindAll(x => x.Status == Status.Active && x.Id != id && x.CategoryId == product.CategoryId)
                .OrderByDescending(x => x.DateCreated)
                .Take(top)
                .ProjectTo<ProductViewModel>()
                .ToList();
        }

        public List<TagViewModel> GetProductTags(int productId)
        {
            var tags = _tagRepository.FindAll();
            var productTags = _productTagRepository.FindAll();

            var query = from t in tags
                        join pt in productTags
                        on t.Id equals pt.TagId
                        where pt.ProductId == productId
                        select new TagViewModel()
                        {
                            Id = t.Id,
                            Name = t.Name
                        };
            return query.ToList();
        }
    }
}
