using TemplateDotNetCore.Data.Enums;

namespace TemplateDotNetCore.Data.Interfaces
{
    public interface IHasStatus
    {
        Status Status { get; set; }
    }
}