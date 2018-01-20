using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("PaymentInfos")]
    public class PaymentInfo : DomainEntity<int>
    {
        [ForeignKey("PaymentId")]
        public virtual Payment Payment { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string Money { get; set; }

        [StringLength(255)]
        public string CreditCard { get; set; }
    }
}
