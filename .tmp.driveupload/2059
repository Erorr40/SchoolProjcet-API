using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTO.EnrollmentDTOs;
using SchoolProjcet.Mapping;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EnrollmentsController()
        {
            _context = new AppDbContext();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<EnrollmentProfile>()).CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var enrollments = _context.Enrollments.ToList();
            var enrollmentDTOs = _mapper.Map<List<Enrollment>>(enrollments);
            return Ok(enrollmentDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var enrollment = _context.Enrollments.Find(id);
            if (enrollment == null)
            {
                return NotFound($"Enrollment with id {id} not found.");
            }
            var enrollmentDTO = _mapper.Map<Enrollment>(enrollment);
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
            _context.Enrollments.Add(newEnrollment);
            _context.SaveChanges();
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

            var existingEnrollment = _context.Enrollments.Find(id);
            if (existingEnrollment == null)
            {
                return NotFound($"Enrollment with id {id} not found.");
            }
            existingEnrollment = _mapper.Map(enrollment, existingEnrollment);
            _context.SaveChanges();
            return Ok(enrollment);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingEnrollment = _context.Enrollments.Find(id);
            if (existingEnrollment == null)
            {
                return NotFound($"Enrollment with id {id} not found.");
            }

            _context.Enrollments.Remove(existingEnrollment);
            _context.SaveChanges();
            return Ok(existingEnrollment);
        }
    }
}

