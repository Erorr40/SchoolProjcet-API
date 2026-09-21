using AutoMapper;
using School.Models;
using SchoolProjcet.DTO.ClassRoomsDTOs;

namespace SchoolProjcet.Mapping
{
    public class ClassRoomProfile : Profile
    {
        public ClassRoomProfile()
        {
            CreateMap<ClassRoom, ClassRoomDTO>().ReverseMap();
            CreateMap<ClassRoom, CreateClassRoomDTO>().ReverseMap();
            CreateMap<ClassRoom, UpdateClassRoomDTO>().ReverseMap();
        }
    }
}
