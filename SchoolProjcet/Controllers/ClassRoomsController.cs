using AutoMapper;
using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
    using School.Models;
using SchoolProjcet.DTO.ClassRoomsDTOs;
using SchoolProjcet.Mapping;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ClassRoomsController()
        {
            _context = new AppDbContext();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClassRoomProfile>()).CreateMapper();
        }

        [HttpGet]
        public IActionResult GetClassRooms()
        {
            var classRooms = _context.ClassRooms.Include(e => e.Students).ToList();
            var CRDTO = _mapper.Map<List<ClassRoomDTO>>(classRooms);
            return Ok(CRDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetClassRoomById(int id)
        {
            var classRoom = _context.ClassRooms.Include(e => e.Students).FirstOrDefault(e => e.Id == id);
            if (classRoom == null)
            {
                return NotFound($"ClassRoom with id {id} not found.");
            }
            var CRDTO = _mapper.Map<ClassRoomDTO>(classRoom);
            return Ok(CRDTO);
        }


        [HttpGet("filter {id} and min gradeLevel {int}")]
        public IActionResult FilterAndMinGradeLevel(int id, int gradelevel)
        {
            var classRoom = _context.ClassRooms.Where(e => e.Id == id && e.GradeLevel == gradelevel).ToList();
            if (classRoom == null || !classRoom.Any())
            {
                return NotFound();
            }
            var CRDTO = _mapper.Map<List<ClassRoomDTO>>(classRoom);
            return Ok(CRDTO);
        }

        [HttpGet("Frist/{id}")]
        public IActionResult GetFristClassRoom(int id)
        {
            var classRoom = _context.ClassRooms.FirstOrDefault(e => e.Id == id);
            if (classRoom == null)
            {
                return NotFound($"ClassRoom with id {id} not found.");
            }
            var CRDTO = _mapper.Map<ClassRoomDTO>(classRoom);
            return Ok(CRDTO);
        }



        [HttpPost("create")]
        public IActionResult CreateClassRoom(CreateClassRoomDTO classRoom)
        {
            if (classRoom == null)
            {
                return BadRequest("ClassRoom data cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newClassRoom = _mapper.Map<ClassRoom>(classRoom);

            _context.ClassRooms.Add(newClassRoom);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetClassRoomById), new { id = newClassRoom.Id }, classRoom);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateClassRoom(int id, UpdateClassRoomDTO classRoom)
        {
            if (classRoom == null)
            {
                return BadRequest("ClassRoom data cannot be null.");
            }

            var existingClassRoom = _context.ClassRooms.Find(id);
            if (existingClassRoom == null)
            {
                return NotFound($"ClassRoom with id {id} not found.");
            }
            existingClassRoom = _mapper.Map(classRoom, existingClassRoom);
            _context.SaveChanges();
            return Ok(existingClassRoom);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteClassRoom(int id)
        {
            var existingClassRoom = _context.ClassRooms.Find(id);
            if (existingClassRoom == null)
            {
                return NotFound($"ClassRoom with id {id} not found.");
            }

            _context.ClassRooms.Remove(existingClassRoom);
            _context.SaveChanges();
            return Ok(existingClassRoom);
        }
    }
}
