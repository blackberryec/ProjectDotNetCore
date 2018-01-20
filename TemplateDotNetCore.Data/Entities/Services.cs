using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    public class Services : DomainEntity<int>
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public string Contents { get; set; }

        [MaxLength(255)]
        public string Image { set; get; }
    }
}
