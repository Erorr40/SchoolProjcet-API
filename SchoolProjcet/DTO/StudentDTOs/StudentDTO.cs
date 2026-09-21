namespace SchoolProjcet.DTO.StudentDTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int ClassRoomId { get; set; }
        public string ClassRoomName { get; set; }
    }
}
