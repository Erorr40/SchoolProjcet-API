using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTO.SubjectDTOs;
using SchoolProjcet.Mapping;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SubjectsController()
        {
            _context = new AppDbContext();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<SubjectProfile>()).CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var subjects = _context.Subjects.Include(e => e.Teacher).ToList();
            var dtos = _mapper.Map<List<SubjectDTO>>(subjects);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        [HttpGet("search/{id}")]
        public IActionResult GetById(int id)
        {
            var subject = _context.Subjects.Include(e => e.Teacher).FirstOrDefault(e => e.Id == id);
            if (subject == null)
            {
                return NotFound($"Subject with id {id} not found.");
            }
            var dto = _mapper.Map<SubjectDTO>(subject);
            return Ok(dto);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateSubjectDTO subject)
        {
            if (subject == null)
            {
                return BadRequest("Subject data cannot be null.");
            }

            var entity = _mapper.Map<Subject>(subject);

            _context.Subjects.Add(entity);
            _context.SaveChanges();
            return Ok(subject);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateSubjectDTO subject)
        {
            if (subject == null)
            {
                return BadRequest("Subject data cannot be null.");
            }

            var existingSubject = _context.Subjects.Find(id);
            if (existingSubject == null)
            {
                return NotFound($"Subject with id {id} not found.");
            }

            existingSubject = _mapper.Map(subject, existingSubject);

            _context.SaveChanges();
            return Ok(existingSubject);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingSubject = _context.Subjects.Include(e => e.Teacher).FirstOrDefault(e => e.Id == id);
            if (existingSubject == null)
            {
                return NotFound($"Subject with id {id} not found.");
            }

            var dto = _mapper.Map<SubjectDTO>(existingSubject);

            _context.Subjects.Remove(existingSubject);
            _context.SaveChanges();
            return Ok(dto);
        }
    }
}

