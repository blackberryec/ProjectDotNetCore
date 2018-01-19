using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("ShippingInfo")]
    public class ShippingInfo : DomainEntity<int>
    {
        [ForeignKey("BillId")]
        public virtual Bill Bill { set; get; }

        public int BillId { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        [StringLength(50)]
        public string Phone { set; get; }
    }
}
