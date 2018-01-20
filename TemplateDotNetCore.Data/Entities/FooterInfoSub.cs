using System.ComponentModel.DataAnnotations.Schema;
using TemplateDotNetCore.Data.Interfaces;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("FooterInfoSubs")]
    public class FooterInfoSub : DomainEntity<int>, IBasicInfo
    {
        public string Name { get; set; }

        public int FooterId { get; set; }

        public string Url { get; set; }

        public string Image { get; set; }

        [ForeignKey("FooterId")]
        public virtual FooterInfo FooterInfo { get; set; }
    }
}