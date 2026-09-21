namespace SchoolProjcet.DTO.SubjectDTOs
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int MaxGrade { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
    }
}
