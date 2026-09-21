using AutoMapper;
using School.Models;
using SchoolProjcet.DTO.TeacherDTOs;
namespace SchoolProjcet.Mapping
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<Teacher, CreateTeacherDTO>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDTO>().ReverseMap();
        }
    }
}
