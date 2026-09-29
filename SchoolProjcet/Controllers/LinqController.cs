using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProjcet.Repo;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqController : ControllerBase
    {
        private readonly ITeacherRepo _teacherRepo;

        public LinqController(ITeacherRepo teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }
        [HttpGet("getteacherswithdepartmentandminsalary/{departmentId}/{minSalary}")]
        public IActionResult GetTeacherWithDepartmentAndMinSalary(int departmentId, decimal minSalary)
        {
            var teachers = _teacherRepo?.GetTeachersByDepartmentIdAndSalary(departmentId, minSalary);
            if (teachers == null )
            {
                return NotFound($"No teachers found in department {departmentId} with salary greater than {minSalary}.");
            }
            return Ok(teachers);
        }
    }
}
