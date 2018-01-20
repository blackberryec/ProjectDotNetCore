using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("Services")]
    public class Service : DomainEntity<int>
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public string Contents { get; set; }

        [MaxLength(255)]
        public string Image { set; get; }
    }
}
