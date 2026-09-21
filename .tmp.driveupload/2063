using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTO.TeacherDTOs;
using SchoolProjcet.Mapping;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TeachersController()
        {
            _context = new AppDbContext();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<TeacherProfile>()).CreateMapper();

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var teachers = _context.Teachers.Include(e => e.Department).ToList();
            var teachermap = _mapper.Map<List<TeacherDTO>>(teachers);
            return Ok(teachermap);
        }

        [HttpGet("{id}")]
        [HttpGet("search/{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _context.Teachers.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            if (teacher == null)
            {
                return NotFound($"Teacher with id {id} not found.");
            }
            var teachermap = _mapper.Map<TeacherDTO>(teacher);
            return Ok(teachermap);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateTeacherDTO teacher)
        {
            if (teacher == null)
            {
                return BadRequest("Teacher data cannot be null.");
            }
            var d = _mapper.Map<Teacher>(teacher);
            _context.Teachers.Add(d);
            _context.SaveChanges();
            return Ok(teacher);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateTeacherDTO teacher)
        {
            if (teacher == null)
            {
                return BadRequest("Teacher data cannot be null.");
            }

            var existingTeacher = _context.Teachers.Find(id);
            if (existingTeacher == null)
            {
                return NotFound($"Teacher with id {id} not found.");
            }

            existingTeacher.FirstName = teacher.FirstName;
            existingTeacher.LastName = teacher.LastName;
            existingTeacher.Email = teacher.Email;
            existingTeacher.PhoneNumber = teacher.PhoneNumber;
            existingTeacher.Salary = teacher.Salary;
            existingTeacher.DepartmentId = teacher.DepartmentId;
            var teachermap = _mapper.Map<TeacherDTO>(existingTeacher);

            _context.SaveChanges();
            return Ok(teachermap);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingTeacher = _context.Teachers.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            if (existingTeacher == null)
            {
                return NotFound($"Teacher with id {id} not found.");
            }

            var dto = new TeacherDTO
            {
                Id = existingTeacher.Id,
                FirstName = existingTeacher.FirstName,
                LastName = existingTeacher.LastName,
                Email = existingTeacher.Email,
                PhoneNumber = existingTeacher.PhoneNumber,
                Salary = existingTeacher.Salary,
                DepartmentId = existingTeacher.DepartmentId,
                DepartmentName = existingTeacher.Department?.Name
            };

            _context.Teachers.Remove(existingTeacher);
            _context.SaveChanges();
            return Ok(dto);
        }
    }
}

