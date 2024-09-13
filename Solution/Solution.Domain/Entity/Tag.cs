
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Solution.Domain.Entity
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Place> Places { get; set; } = new List<Place>();
    }
}
