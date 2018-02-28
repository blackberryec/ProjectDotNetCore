using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TemplateDotNetCore.Application.Interfaces;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Data.IRepositories;
using TemplateDotNetCore.Infrastucture.Interfaces;

namespace TemplateDotNetCore.Application.Implementations
{
    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(ProductCategoryViewModel productCategoryVm)
        {
            var productCategory = Mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            _productCategoryRepository.Add(productCategory);
        }

        public void Update(ProductCategoryViewModel productCategoryVm)
        {
            var productCategory = Mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            _productCategoryRepository.Update(productCategory);
        }

        public void Remove(ProductCategoryViewModel productCategoryVm)
        {
            var productCategory = Mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            _productCategoryRepository.Remove(productCategory);
        }

        public void Remove(int id)
        {
            _productCategoryRepository.Remove(id);
        }

        public void RemoveMultiple(List<ProductCategoryViewModel> entities)
        {
            throw new NotImplementedException();
        }

        public ProductCategoryViewModel FindById(int id, params Expression<Func<ProductCategoryViewModel, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public ProductCategoryViewModel FindSingle(Expression<Func<ProductCategoryViewModel, bool>> predicate, params Expression<Func<ProductCategoryViewModel, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductCategoryViewModel> FindAll(params Expression<Func<ProductCategoryViewModel, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductCategoryViewModel> FindAll(Expression<Func<ProductCategoryViewModel, bool>> predicate, params Expression<Func<ProductCategoryViewModel, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductCategoryViewModel> FindMultiPaging(Expression<Func<ProductCategoryViewModel, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryRepository.FindAll().OrderBy(x => x.ParentId)
                 .ProjectTo<ProductCategoryViewModel>().ToList();
        }
    }
}