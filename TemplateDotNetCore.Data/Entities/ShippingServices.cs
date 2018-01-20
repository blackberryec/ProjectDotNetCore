using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    public class ShippingServices : DomainEntity<int>
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public string Contents { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }
    }
}
