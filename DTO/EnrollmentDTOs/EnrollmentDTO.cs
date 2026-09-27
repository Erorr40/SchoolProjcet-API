namespace SchoolProjcet.DTO.EnrollmentDTOs
{
    public class EnrollmentDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal Grade { get; set; }
    }
}
