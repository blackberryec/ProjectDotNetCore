using System;
using System.ComponentModel.DataAnnotations;
using TemplateDotNetCore.Data.Interfaces;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    public class Comment : DomainEntity<Guid>, IHasOwner<int>, IBasicInfo
    {
        public int OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Time { get; set; }

        [Required]
        public string Content { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        public string Avatar { set; get; }
    }
}