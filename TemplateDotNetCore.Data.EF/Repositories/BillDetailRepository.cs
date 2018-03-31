using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Data.IRepositories;

namespace TemplateDotNetCore.Data.EF.Repositories
{
    public class BillDetailRepository : EFRepository<BillDetail, int>, IBillDetailRepository
    {
        public BillDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
}