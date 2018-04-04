using System;
using System.Collections.Generic;
using System.Text;
using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Infrastucture.Interfaces;

namespace TemplateDotNetCore.Data.IRepositories
{
    public interface IProductTagRepository : IRepository<ProductTag,int>
    {
    }
}
