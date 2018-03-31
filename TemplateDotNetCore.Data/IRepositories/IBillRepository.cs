using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Infrastucture.Interfaces;

namespace TemplateDotNetCore.Data.IRepositories
{
    public interface IBillRepository : IRepository<Bill, int>
    {
    }
}