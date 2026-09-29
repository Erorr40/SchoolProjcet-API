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
        private readonly IUnitOfWork _IOW;

        public LinqController(ITeacherRepo teacherRepo, ISubject subjectRepo, IUnitOfWork IOW)
        {
            _teacherRepo = teacherRepo ;
            _subjectRepo = subjectRepo ;
            _IOW = IOW ;
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

        //3
        [HttpGet("GetFristClassRoomWithCapasicyMorethanVal/{capacity}")]
        public IActionResult GetFristClassRoomWithCapasicyMorethanVal(int capacity)
        {
            return Ok(_IOW.ClassRoom.GetFristClassRoomWithCapasicyMorethanVal(capacity));
        }

        //4
        [HttpGet("GetTeacherWithEmail/{email}")]
        public IActionResult GetTeacherWithEmail(string email)
        {
            return Ok(_IOW.Teacher.GetTeacherByEmail(email));
        }

        //5
        [HttpGet("GetClassRoomByName/{name}")]
        public IActionResult GetClassRoomByName(string name)
        {
            return Ok(_IOW.ClassRoom.GetClassRoomByName(name));
        }

        //6
        [HttpGet("GetOldestEnrollmentBySubjectEnrollmentDate/{subjectId}")]
        public IActionResult GetOldestEnrollmentBySubjectEnrollmentDate(int subjectId)
        {
            return Ok(_IOW.Enrollment.GetOldestEnrollmentBySubjectEnrollmentDate(subjectId));
        }

        //7
        [HttpGet("LastSubjectBySpecifiedTeacherOrderedbySubjectID/{teacherId}")]
        public IActionResult LastSubjectBySpecifiedTeacherOrderedbySubjectID(int teacherId)
        {
            return Ok(_subjectRepo.LastSubjectBySpecifiedTeacherOrderedbySubjectID(teacherId));
        }

        //8
        [HttpGet("OrderAndReturnSpecifiedZeroIndex")]
        public IActionResult OrderAndReturnSpecifiedZeroIndex(int teacherId)
        {
            return Ok(_IOW.ClassRoom.OrderAndReturnSpecifiedZeroIndex(teacherId));
        }

        //9
        [HttpGet("CheckAtLeastOneSubjectTaughtByTeacher/{teacherId}")]
        public IActionResult CheckAtLeastOneSubjectTaughtByTeacher(int teacherId)
        {
            return Ok(_IOW.Teacher.CheckAtLeastOneSubjectTaughtByTeacher(teacherId));
        }

        //10
        [HttpGet("CheckEveryClassRoomInSpecifiedGradeLevelatLestSpecifiedCapacity/{gradeLevel}/{capacity}")]
        public IActionResult CheckEveryClassRoomInSpecifiedGradeLevelatLestSpecifiedCapacity(int gradeLevel, int capacity)
        {
            return Ok(_IOW.ClassRoom.CheckEveryClassRoomInSpecifiedGradeLevelatLestSpecifiedCapacity(gradeLevel, capacity));
        }

        //11
        [HttpGet("CheckSpecifiedSubjectIDExistInaListOfSubjects/{subjectId}")]
        public IActionResult CheckSpecifiedSubjectIDExistInaListOfSubjects(int subjectId)
        {
            return Ok(_IOW.Subject.CheckSpecifiedSubjectIDExistInaListOfSubjects(subjectId));
        }

        //12
        [HttpGet("AllTeachersFromDepartmentandReturnIDs/{departmentId}")]
        public IActionResult AllTeachersFromDepartmentandReturnIDs(int departmentId)
        {
            return Ok(_IOW.Teacher.AllTeachersFromDepartmentandReturnID(departmentId));
        }

        
    }
}
