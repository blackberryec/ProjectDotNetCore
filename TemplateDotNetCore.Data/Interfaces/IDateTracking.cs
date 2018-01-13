using System;

namespace TemplateDotNetCore.Data.Interfaces
{
    public interface IDateTracking
    {
        DateTime DateCreated { get; set; }

        DateTime DateModified { get; set; }
    }
}