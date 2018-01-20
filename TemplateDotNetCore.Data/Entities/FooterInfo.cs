using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TemplateDotNetCore.Data.Enums;
using TemplateDotNetCore.Data.Interfaces;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("Footers")]
    public class FooterInfo : DomainEntity<int>, IBasicInfo, IHasStatus
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public Status Status { get; set; }

        public virtual ICollection<FooterInfoSub> FooterInfoSubs { get; set; }
    }
}