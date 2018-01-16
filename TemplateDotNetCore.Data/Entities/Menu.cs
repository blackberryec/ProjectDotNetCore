using TemplateDotNetCore.Data.Enums;
using TemplateDotNetCore.Data.Interfaces;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    public class Menu : DomainEntity<int>, IBasicInfo, IHasStatus, ISortable
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string Css { get; set; }

        public int? ParentId { get; set; }

        public Status Status { get; set; }

        public int SortOrder { get; set; }
    }
}