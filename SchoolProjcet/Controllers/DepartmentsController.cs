using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTO.DepartmentDTOs;
using SchoolProjcet.Mapping;
using SchoolProjcet.Repo;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        readonly IGenaricRepo<Department> _departmentRepo;
        private readonly IMapper _mapper;
        public DepartmentsController(IGenaricRepo<Department> departmentRepo)
        {
            _departmentRepo = departmentRepo;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<DepartmentProfile>()).CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _departmentRepo.GetAll();
            var departmentDTOs = _mapper.Map<List<DepartmentDTO>>(departments);
            return Ok(departmentDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _departmentRepo.GetById(id);
            var departmentDTO = _mapper.Map<DepartmentDTO>(department);
            if (department == null)
            {
                return NotFound($"Department with id {id} not found.");
            }
            return Ok(departmentDTO);
        }

        [HttpPost("create")]
        public IActionResult Create(DepartmentCreateDTO depDTO)
        {
            if (depDTO == null)
            {
                return BadRequest("Department data cannot be null.");
            }

            var department = _mapper.Map<Department>(depDTO);
            _departmentRepo.Create(department);
            return Ok(department);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, DepartmentUpdateDTO depupdate)
        {
            if (depupdate == null)
            {
                return BadRequest("Department data cannot be null.");
            }

            var existingDepartment = _departmentRepo.GetById(id);
            if (existingDepartment == null)
            {
                return NotFound($"Department with id {id} not found.");
            }

            existingDepartment = _mapper.Map(depupdate, existingDepartment);

            _departmentRepo.Update(existingDepartment);
            return Ok(existingDepartment);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingDepartment = _departmentRepo.GetById(id);
            if (existingDepartment == null)
            {
                return NotFound($"Department with id {id} not found.");
            }

            _departmentRepo.Delete(id);
            return NoContent();
        }
    }
}
