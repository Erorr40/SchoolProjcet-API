using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace School.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [Range(1, 100)]
        public int MaxGrade { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }

        [JsonIgnore]
        public Teacher? Teacher { get; set; }

        [JsonIgnore]
        public ICollection<Enrollment>? Enrollments { get; set; } = new List<Enrollment>();


    }
}
