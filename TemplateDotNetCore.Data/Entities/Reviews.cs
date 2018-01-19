using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("Reviews")]
    public class Reviews : DomainEntity<int>
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public string Contents { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        public string Value { get; set; }

        public double Quantity { get; set; }    

        public int Start { get; set; }

        public bool ShowIndex { get; set; }

    }
}
