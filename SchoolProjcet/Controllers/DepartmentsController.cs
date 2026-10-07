using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTO.DepartmentDTOs;
using SchoolProjcet.Mapping;
using SchoolProjcet.Repo;

namespace SchoolProjcet.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        readonly IUnitOfWork _UOW;
        private readonly IMapper _mapper;
        public DepartmentsController(IUnitOfWork uow)
        {
            _UOW = uow;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<DepartmentProfile>()).CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _UOW.Department.GetAll();
            var departmentDTOs = _mapper.Map<List<DepartmentDTO>>(departments);
            return Ok(departmentDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _UOW.Department.GetById(id);
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
            _UOW.Department.Create(department);
            return Ok(department);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, DepartmentUpdateDTO depupdate)
        {
            if (depupdate == null)
            {
                return BadRequest("Department data cannot be null.");
            }

            var existingDepartment = _UOW.Department.GetById(id);
            if (existingDepartment == null)
            {
                return NotFound($"Department with id {id} not found.");
            }

            existingDepartment = _mapper.Map(depupdate, existingDepartment);

            _UOW.Department.Update(existingDepartment);
            return Ok(existingDepartment);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingDepartment = _UOW.Department.GetById(id);
            if (existingDepartment == null)
            {
                return NotFound($"Department with id {id} not found.");
            }

            _UOW.Department.Delete(id);
            return NoContent();
        }
    }
}
