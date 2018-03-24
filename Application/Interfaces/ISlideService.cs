using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemplateDotNetCore.Application.ViewModels;

namespace TemplateDotNetCore.Application.Interfaces
{
    public interface ISlideService : IDisposable
    {
        List<SlideViewModel> GetAll();

        void Update(SlideViewModel slideVm);

        void Delete(int id);

        SlideViewModel Add(SlideViewModel slideViewModel);

        void Save();
    }
}
