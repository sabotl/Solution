using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Solution.Domain.Entity
{
    public class Place
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public PlaceCategory Category { get; set; } = null!;

        [Required, StringLength(255)]
        public string Address { get; set; } = string.Empty;
        public string? Description {  get; set; }

        [JsonIgnore]
        public ICollection<Tag> Tags { get; set; }
    }
}
