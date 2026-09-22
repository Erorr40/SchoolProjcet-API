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

        [HttpGet("filter {id} and min gradeLevel {int}")]
        public IActionResult Filter(int id, int minGradeLevel)
        {
            var students = _context.Students
                .Include(e => e.ClassRoom)
                .Where(s => s.ClassRoomId == id && s.ClassRoom.GradeLevel >= minGradeLevel)
                .ToList();
            if (students.Count == 0)
            {
                return NotFound($"No students found for ClassRoomId {id} with GradeLevel >= {minGradeLevel}.");
            }
            var studentDTOs = _mapper.Map<List<StudentDTO>>(students);
            return Ok(studentDTOs);
        }

        [HttpGet("first/{id}")]
        public IActionResult GetFirstByClassRoomId(int id)
        {
            var student = _context.Students.Include(e => e.ClassRoom).FirstOrDefault(s => s.ClassRoomId == id);
            if (student == null)
            {
                return NotFound($"No students found for ClassRoomId {id}.");
            }
            var studentDTO = _mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
        }

        [HttpGet("FristOrDefault/{id}")]
        public IActionResult GetFirstOrDefaultByClassRoomId(int id)
        {
            var student = _context.Students.Include(e => e.ClassRoom).FirstOrDefault(s => s.ClassRoomId == id);
            if (student == null)
            {
                return NotFound($"No students found for ClassRoomId {id}.");
            }
            var studentDTO = _mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
        }
        [HttpGet("Single/{id}")]
        public IActionResult GetSingleClassRoomById(int id)
        {
            var student = _context.Students.Include(e => e.ClassRoom).Single(e => e.ClassRoomId == id);
            if (student == null)
                return NotFound($"No student found for ClassRoomId {id}");
            var studentDTO = _mapper.Map<StudentDTO>
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

