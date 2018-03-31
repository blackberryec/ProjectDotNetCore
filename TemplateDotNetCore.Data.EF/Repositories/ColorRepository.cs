using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Data.IRepositories;

namespace TemplateDotNetCore.Data.EF.Repositories
{
    public class ColorRepository : EFRepository<Color,int>, IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context)
        {
        }
    }
}