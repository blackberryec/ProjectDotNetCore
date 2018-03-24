using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemplateDotNetCore.Application.Interfaces;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Data.IRepositories;
using TemplateDotNetCore.Infrastucture.Interfaces;

namespace TemplateDotNetCore.Application.Implementations
{
    public class SlideService : ISlideService
    {
        private ISlideRepository _slideRepository;
        IUnitOfWork _unitOfWork;

        public SlideService(ISlideRepository slideRepository, IUnitOfWork unitOfWork)
        {
            _slideRepository = slideRepository;
            _unitOfWork = unitOfWork;
        }
        public SlideViewModel Add(SlideViewModel slideViewModel)
        {
            List<Slide> slides = new List<Slide>();
            return new SlideViewModel();
        }

        public void Delete(int id)
        {
            _slideRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<SlideViewModel> GetAll()
        {
            return _slideRepository.FindAll().OrderBy(x=>x.DisplayOrder)
                .ProjectTo<SlideViewModel>().ToList();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(SlideViewModel slideVm)
        {
            var slide = Mapper.Map<SlideViewModel, Slide>(slideVm);
            _slideRepository.Update(slide);
        }
    }
}
