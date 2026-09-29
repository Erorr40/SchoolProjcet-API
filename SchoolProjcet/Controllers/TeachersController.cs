using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTO.TeacherDTOs;
using SchoolProjcet.Mapping;
using SchoolProjcet.Repo;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepo _context;
        private readonly IMapper _mapper;
        public TeachersController(ITeacherRepo context)
        {
            _context = context;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<TeacherProfile>()).CreateMapper();

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var teachers = _context.GetAll();
            var teachermap = _mapper.Map<List<TeacherDTO>>(teachers);
            return Ok(teachermap);
        }

        [HttpGet("getbydepartment/{departmentId}")]
        public IActionResult GetByDepartment(int departmentId)
        {
            var teachers = _context.GetTeachersByDepartmentId(departmentId);
            var teachermap = _mapper.Map<List<TeacherDTO>>(teachers);
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
            _context.Create(d);
            return Ok(teacher);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateTeacherDTO teacher)
        {
            if (teacher == null)
            {
                return BadRequest("Teacher data cannot be null.");
            }

            var existingTeacher = _context.GetById(id);
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

            _context.Update(existingTeacher);
            return Ok(teachermap);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingTeacher = _context.GetById(id);
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

            _context.Delete(id);
            return Ok(dto);
        }
    }
}

