using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TemplateDotNetCore.Data.Enums;
using TemplateDotNetCore.Data.Interfaces;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("Brands")]
    public class Brand : DomainEntity<int> , IBasicInfo, IHasStatus
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public string Image { get; set; }

        public Status Status { get; set; }
    }
}