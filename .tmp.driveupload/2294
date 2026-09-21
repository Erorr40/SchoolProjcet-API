using AutoMapper;
using School.Models;
using SchoolProjcet.DTO.EnrollmentDTOs;

namespace SchoolProjcet.Mapping
{
    public class EnrollmentProfile: Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentDTO>().ReverseMap();
            CreateMap<Enrollment, CreateEnrollmentDTO>().ReverseMap();
            CreateMap<Enrollment, UpdateEnrollmentDTO>().ReverseMap();
        }
    }
}
