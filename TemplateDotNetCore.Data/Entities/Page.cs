using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TemplateDotNetCore.Data.Enums;
using TemplateDotNetCore.Data.Interfaces;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("Pages")]
    public class Page : DomainEntity<int>,IHasStatus
    {
        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [MaxLength(256)]
        [Required]
        public string Alias { set; get; }

        public string Content { set; get; }
        public Status Status { set; get; }
    }
}
