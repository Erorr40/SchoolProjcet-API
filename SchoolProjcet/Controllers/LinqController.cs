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
        private readonly ISubject _subjectRepo;

        public LinqController(ITeacherRepo teacherRepo, ISubject subjectRepo)
        {
            _teacherRepo = teacherRepo ;
            _subjectRepo = subjectRepo ;
        }

        //1
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

        //2
        [HttpGet("FristSubjectbySpecifiedTeacherOrderedbySubjectName")]
        public IActionResult GetFristSubjectBySpecifiedTeacherOrderedBySubjectName (int teacherId)
        {
            return Ok(_subjectRepo.FristSubjectbySpecifiedTeacherOrderedbySubjectName(teacherId));

        }

    }
}
