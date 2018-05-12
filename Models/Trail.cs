using System.ComponentModel.DataAnnotations;

namespace woods.Models
{
    public abstract class BaseEntity {}
    public class Trail : BaseEntity
    {
        public int Id {get; set;}
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Required]
        public long Length { get; set; }
        public int Elevation { get; set; }

        [Required]
        [Range(-180, 180)]
        public long Longitude { get; set; }

        [Required]
        [Range(-90, 90)]
        public long Latitude { get; set; }
    }
}