using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace School.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Range(1, 12)]
        public int GradeLevel { get; set; }

        [Range(1, 100)]
        public int Capacity { get; set; }

        [JsonIgnore]
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
