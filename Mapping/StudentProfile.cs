using AutoMapper;
using School.Models;

using SchoolProjcet.DTO.StudentDTOs;

namespace SchoolProjcet.Mapping
{
    public class StudentProfile: Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, CreateStudentDTO>().ReverseMap();
            CreateMap<Student, UpdateStudentDTO>().ReverseMap();
        }
    }
}
