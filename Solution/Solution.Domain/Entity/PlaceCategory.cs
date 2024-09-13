using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Solution.Domain.Entity
{
    public class PlaceCategory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Place> Places { get; set; } = new List<Place>();
    }
}
