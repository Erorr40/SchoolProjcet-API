using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTO.EnrollmentDTOs;
using SchoolProjcet.Mapping;
using SchoolProjcet.Repo;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IGenaricRepo<Enrollment> _enrollmentRepo;
        private readonly IMapper _mapper;
        public EnrollmentsController(IGenaricRepo<Enrollment> enrollmentRepo)
        {
            _enrollmentRepo = enrollmentRepo;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<EnrollmentProfile>()).CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var enrollments = _enrollmentRepo.GetAll();
            var enrollmentDTOs = _mapper.Map<List<EnrollmentDTO>>(enrollments);
            return Ok(enrollmentDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var enrollment = _enrollmentRepo.GetById(id);
            if (enrollment == null)
            {
                return NotFound($"Enrollment with id {id} not found.");
            }
            var enrollmentDTO = _mapper.Map<EnrollmentDTO>(enrollment);
            return Ok(enrollmentDTO);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateEnrollmentDTO enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest("Enrollment data cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newEnrollment = _mapper.Map<Enrollment>(enrollment);
            _enrollmentRepo.Create(newEnrollment);
            return Ok(enrollment);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateEnrollmentDTO enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest("Enrollment data cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingEnrollment = _enrollmentRepo.GetById(id);
            if (existingEnrollment == null)
            {
                return NotFound($"Enrollment with id {id} not found.");
            }
            existingEnrollment = _mapper.Map(enrollment, existingEnrollment);
            _enrollmentRepo.Update(existingEnrollment);
            return Ok(enrollment);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingEnrollment = _enrollmentRepo.GetById(id);
            if (existingEnrollment == null)
            {
                return NotFound($"Enrollment with id {id} not found.");
            }

            _enrollmentRepo.Delete(id);
            return Ok(existingEnrollment);
        }
    }
}

