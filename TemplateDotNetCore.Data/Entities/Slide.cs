using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TemplateDotNetCore.Data.Enums;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("Slides")]
    public class Slide : DomainEntity<int>
    {
        public Slide()
        {

        }

        public Slide(string name, string description, string image, string contentUrl, string url, int displayOrder, Status status, string content, string groupAlias)
        {
            Name = name;
            Description = description;
            Image = image;
            ContentUrl = contentUrl;
            Url = url;
            DisplayOrder = displayOrder;
            Status = status;
            Content = content;
            GroupAlias = groupAlias;
        }

        [StringLength(250)]
        [Required]
        public string Name { set; get; }

        [StringLength(250)]
        public string Description { set; get; }

        [StringLength(250)]
        [Required]
        public string Image { set; get; }

        [StringLength(125)]
        public string ContentUrl { set; get; }

        [StringLength(250)]
        public string Url { set; get; }

        public int? DisplayOrder { set; get; }

        public Status Status { set; get; }

        [StringLength(250)]
        public string Content { set; get; }

        [StringLength(125)]
        public string GroupAlias { get; set; }
    }
}
