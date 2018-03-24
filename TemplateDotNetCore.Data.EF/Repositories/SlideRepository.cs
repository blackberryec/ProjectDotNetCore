using System;
using System.Collections.Generic;
using System.Text;
using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Data.IRepositories;

namespace TemplateDotNetCore.Data.EF.Repositories
{
    public class SlideRepository : EFRepository<Slide, int>, ISlideRepository
    {
        public SlideRepository(AppDbContext context) : base(context)
        {
        }
    }
}
