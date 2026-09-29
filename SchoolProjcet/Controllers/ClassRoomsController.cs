using AutoMapper;
using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
    using School.Models;
using SchoolProjcet.DTO.ClassRoomsDTOs;
using SchoolProjcet.Mapping;
using SchoolProjcet.Repo;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomsController : ControllerBase
    {
        readonly UnitOfWork _classRoomRepo;
        private readonly IMapper _mapper;
        public ClassRoomsController(UnitOfWork classRoomRepo)
        {
            _classRoomRepo = classRoomRepo;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClassRoomProfile>()).CreateMapper();
        }

        [HttpGet]
        public IActionResult GetClassRooms()
        {
            var classRooms = _classRoomRepo.ClassRoom.GetAll();
            var CRDTO = _mapper.Map<List<ClassRoomDTO>>(classRooms);
            return Ok(CRDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetClassRoomById(int id)
        {
            var classRoom = _classRoomRepo.ClassRoom.GetById(id);
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

            var newClassRoom = _mapper.Map<ClassRoom>(classRoom);

            _classRoomRepo.ClassRoom.Create(newClassRoom);
            return CreatedAtAction(nameof(GetClassRoomById), new { id = newClassRoom.Id }, classRoom);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateClassRoom(int id, UpdateClassRoomDTO classRoom)
        {
            if (classRoom == null)
            {
                return BadRequest("ClassRoom data cannot be null.");
            }

            var existingClassRoom = _classRoomRepo.GetById(id);
            if (existingClassRoom == null)
            {
                return NotFound($"ClassRoom with id {id} not found.");
            }
            existingClassRoom = _mapper.Map(classRoom, existingClassRoom);
            _classRoomRepo.Update(existingClassRoom);
            return Ok(existingClassRoom);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteClassRoom(int id)
        {
            var existingClassRoom = _classRoomRepo.GetById(id);
            if (existingClassRoom == null)
            {
                return NotFound($"ClassRoom with id {id} not found.");
            }

            _classRoomRepo.Delete(id);
            return Ok(existingClassRoom);
        }
    }
}
