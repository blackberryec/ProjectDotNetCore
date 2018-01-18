using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TemplateDotNetCore.Data.Enums;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("ContactDetails")]
    public class ContactDetail : DomainEntity<string>
    {

        [StringLength(250)]
        [Required]
        public string Name { set; get; }

        [StringLength(50)]
        public string Phone { set; get; }

        [StringLength(250)]
        public string Email { set; get; }

        [StringLength(250)]
        public string Website { set; get; }

        [StringLength(250)]
        public string Address { set; get; }

        public string Other { set; get; }

        public double? Lat { set; get; }

        public double? Lng { set; get; }

        public Status Status { set; get; }
    }
}
