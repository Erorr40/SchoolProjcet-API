namespace SchoolProjcet.DTO.EnrollmentDTOs
{
    public class CreateEnrollmentDTO
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal Grade { get; set; }
    }
}
