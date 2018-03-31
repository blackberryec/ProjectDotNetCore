using System.Collections.Generic;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Data.Enums;
using TemplateDotNetCore.Utilities.Dtos;

namespace TemplateDotNetCore.Application.Interfaces
{
    public interface IBillService
    {
        void Create(BillViewModel billViewModel);

        void Update(BillViewModel billViewModel);

        PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageIndex, int pageSize);

        BillViewModel getDetail(int billId);

        BillDetailViewModel CreateDetail(BillDetailViewModel billDetailViewModel);

        void DeleteDetail(int productId, int billId, int colorId, int sizeId);

        void UpdateStatus(int orderId, BillStatus status);

        List<BillDetailViewModel> GetBillDetails(int billId);

        ColorViewModel GetColors(int id);

        void Save();
    }
}