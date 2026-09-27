namespace SchoolProjcet.DTO.EnrollmentDTOs
{
    public class UpdateEnrollmentDTO
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal Grade { get; set; }
    }
}
