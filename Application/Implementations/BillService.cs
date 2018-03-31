using System;
using AutoMapper;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper.QueryableExtensions;
using TemplateDotNetCore.Application.Interfaces;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Data.Enums;
using TemplateDotNetCore.Data.IRepositories;
using TemplateDotNetCore.Infrastucture.Interfaces;
using TemplateDotNetCore.Utilities.Dtos;

namespace TemplateDotNetCore.Application.Implementations
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IBillDetailRepository _billDetailRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BillService(IBillRepository billRepository, IBillDetailRepository billDetailRepository, IColorRepository colorRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _billRepository = billRepository;
            _billDetailRepository = billDetailRepository;
            _colorRepository = colorRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public void Create(BillViewModel billViewModel)
        {
            var order = Mapper.Map<BillViewModel, Bill>(billViewModel);
            var orderDetail = Mapper.Map<List<BillDetailViewModel>, List<BillDetail>>(billViewModel.BillDetails);
            foreach (var detail in orderDetail)
            {
                var product = _productRepository.FindById(detail.ProductId);
                detail.Price = product.Price;
            }
            order.BillDetails = orderDetail;
            _billRepository.Add(order);
        }

        public void Update(BillViewModel billViewModel)
        {
            //Mapping to order domain
            var order = Mapper.Map<BillViewModel, Bill>(billViewModel);

            //Get order detail
            var newDetails = order.BillDetails;

            //New details added
            var addedDetails = newDetails.Where(x => x.Id == 0).ToList();

            //Get updated details
            var updatedDetails = newDetails.Where(x => x.Id != 0).ToList();

            //Existed details
            var existedDetails = _billDetailRepository.FindAll(x => x.BillId == billViewModel.Id);

            //Clear db
            order.BillDetails.Clear();

            foreach (var detail in updatedDetails)
            {
                var product = _productRepository.FindById(detail.ProductId);
                detail.Price = product.Price;
                _billDetailRepository.Add(detail);
            }

            _billDetailRepository.RemoveMultiple(existedDetails.Except(updatedDetails).ToList());

            _billRepository.Update(order);
        }

        public void UpdateStatus(int orderId, BillStatus status)
        {
            var order = _billRepository.FindById(orderId);
            order.BillStatus = status;
            _billRepository.Update(order);
        }

        public PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageIndex, int pageSize)
        {
            var query = _billRepository.FindAll();
            if (!string.IsNullOrEmpty(startDate))
            {
                DateTime start = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                query = query.Where(x => x.DateCreated >= start);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                DateTime end = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                query = query.Where(x => x.DateCreated <= end);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.CustomerName.Contains(keyword) || x.CustomerMobile.Contains(keyword));
            }
            var totalRow = query.Count();
            var data = query.OrderByDescending(x => x.DateCreated)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BillViewModel>()
                .ToList();
            return new PagedResult<BillViewModel>()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                Results = data, 
                RowCount = totalRow
            };

        }

        public BillViewModel getDetail(int billId)
        {
            var bill = _billRepository.FindSingle(x => x.Id == billId);
            var billVm = Mapper.Map<Bill,BillViewModel>(bill);
            var billDetailVm = _billDetailRepository.FindAll(x => x.BillId == billId).ProjectTo<BillDetailViewModel>().ToList();
            billVm.BillDetails = billDetailVm;
            return billVm;
        }

        public BillDetailViewModel CreateDetail(BillDetailViewModel billDetailViewModel)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteDetail(int productId, int billId, int colorId, int sizeId)
        {
            throw new System.NotImplementedException();
        }


        public List<BillDetailViewModel> GetBillDetails(int billId)
        {
            return _billDetailRepository
                .FindAll(x => x.BillId == billId, c => c.Bill, c => c.Color, c => c.Product)
                .ProjectTo<BillDetailViewModel>().ToList();
        }

        public ColorViewModel GetColors(int id)
        {
            return Mapper.Map<Color, ColorViewModel>(_colorRepository.FindById(id));
        }


        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}