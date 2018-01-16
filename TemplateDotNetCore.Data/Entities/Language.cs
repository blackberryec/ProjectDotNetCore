using TemplateDotNetCore.Data.Interfaces;
using TemplateDotNetCore.Infrastucture.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TemplateDotNetCore.Data.Enums;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("Languages")]
    public class Language : DomainEntity<string>, IHasStatus
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public string Resources { get; set; }

        public Status Status { get; set; }
    }
}
