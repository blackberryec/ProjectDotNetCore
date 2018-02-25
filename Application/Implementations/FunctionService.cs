using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateDotNetCore.Application.Interfaces;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Data.IRepositories;

namespace TemplateDotNetCore.Application.Implementations
{
    public class FunctionService : IFunctionService
    {
        private IFunctionRepository _functionRepository;
        public FunctionService(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<List<FunctionViewModel>> GetAll()
        {
            return _functionRepository.FindAll().ProjectTo<FunctionViewModel>().ToListAsync();
        }

        public List<FunctionViewModel> GetAllByPermission(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
