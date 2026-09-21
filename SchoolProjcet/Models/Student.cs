using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace School.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        [Phone]
        public string?PhoneNumber { get; set; }

        
        public DateOnly DateOfBirth { get; set; }
        [ForeignKey(nameof(ClassRoom))]
        public int ClassRoomId { get; set; }
       
        [JsonIgnore]
        public ClassRoom? ClassRoom { get; set; }

        [JsonIgnore]
        public ICollection<Enrollment>? Enrollments { get; set; } = new List<Enrollment>();
    }
}
