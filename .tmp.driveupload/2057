using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTO.StudentDTOs;
using SchoolProjcet.Mapping;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public StudentsController()
        {
            _context = new AppDbContext();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<StudentProfile>()).CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _context.Students.Include(e => e.ClassRoom).ToList();
            var studentDTOs = _mapper.Map<List<StudentDTO>>(students);
            return Ok(studentDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.Include(e => e.ClassRoom).FirstOrDefault(e => e.Id == id);
            if (student == null)
            {
                return NotFound($"Student with id {id} not found.");
            }
            var studentDTO = _mapper.Map<StudentDTO>(student);

            return Ok(studentDTO);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateStudentDTO s)
        {
            if (s == null)
            {
                return BadRequest("Student data cannot be null.");
            }
            var student = _mapper.Map<Student>(s);

            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok(s);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateStudentDTO student)
        {
            if (student == null)
            {
                return BadRequest("Student data cannot be null.");
            }

            var existingStudent = _context.Students.Find(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with id {id} not found.");
            }

            existingStudent = _mapper.Map(student, existingStudent);

            _context.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingStudent = _context.Students.Find(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with id {id} not found.");
            }
            var s = _mapper.Map<StudentDTO>(existingStudent);

            _context.Students.Remove(existingStudent);
            _context.SaveChanges();
            return Ok(s);
        }
    }
}

