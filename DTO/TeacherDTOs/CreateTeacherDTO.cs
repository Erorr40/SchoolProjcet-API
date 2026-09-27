namespace SchoolProjcet.DTO.TeacherDTOs
{
    public class CreateTeacherDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
