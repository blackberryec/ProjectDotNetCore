using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("AdvertistmentPages")]
    public class AdvertistmentPage : DomainEntity<string>
    {
        public string Name { get; set; }

        public virtual ICollection<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    }
}
