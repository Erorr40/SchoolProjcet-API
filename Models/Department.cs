using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace School.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
