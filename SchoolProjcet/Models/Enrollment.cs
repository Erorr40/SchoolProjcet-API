using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace School.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        
        [JsonIgnore]
        public Student? Student { get; set; }

        public int SubjectId { get; set; }

        [JsonIgnore]
        public Subject? Subject { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }

         [Range(0, 100)]
        public decimal Grade { get; set; }
    }
}
