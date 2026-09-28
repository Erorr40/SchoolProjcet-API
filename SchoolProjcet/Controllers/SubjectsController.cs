using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTO.SubjectDTOs;
using SchoolProjcet.Mapping;
using SchoolProjcet.Repo;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IGenaricRepo<Subject> _context;
        private readonly IMapper _mapper;
        public SubjectsController(IGenaricRepo<Subject> context)
        {
            _context = context;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<SubjectProfile>()).CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var subjects = _context.GetAll();
            var dtos = _mapper.Map<List<SubjectDTO>>(subjects);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        [HttpGet("search/{id}")]
        public IActionResult GetById(int id)
        {
            var subject = _context.GetById(id);
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

            _context.Create(entity);
            return Ok(subject);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateSubjectDTO subject)
        {
            if (subject == null)
            {
                return BadRequest("Subject data cannot be null.");
            }

            var existingSubject = _context.GetById(id);
            if (existingSubject == null)
            {
                return NotFound($"Subject with id {id} not found.");
            }

            existingSubject = _mapper.Map(subject, existingSubject);

            _context.Update(existingSubject);
            return Ok(existingSubject);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingSubject = _context.GetById(id); 
            if (existingSubject == null)
            {
                return NotFound($"Subject with id {id} not found.");
            }

            var dto = _mapper.Map<SubjectDTO>(existingSubject);

            _context.Delete(id); 
            return Ok(dto);
        }
    }
}

