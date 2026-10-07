using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;

namespace SchoolProjcet.Repo
{
    public class TeacherRepo : GenericRepo<Teacher>, ITeacherRepo
    {
        public TeacherRepo(AppDbContext context) : base(context)
        {
        }

        public override IEnumerable<Teacher> GetAll()
        {
            return _db.Include(e => e.Department).Include(e => e.Subjects).ToList();
        }

        public IEnumerable<Teacher> GetTeachersByDepartmentId(int departmentId)
        {
            return _db.Include(e => e.Department).Include(e => e.Subjects).Where(e => e.DepartmentId == departmentId).ToList();
        }


        // 1
        public IEnumerable<Teacher> GetTeachersByDepartmentIdAndSalary(int departmentId, decimal minSalary)
        {
            return _db.Include(e => e.Department).Include(e => e.Subjects).Where(e => e.DepartmentId == departmentId && e.Salary >= minSalary).ToList();
        }

        //4
        public Teacher GetTeacherByEmail(string email)
        {
            return _db.Include(e => e.Department).Include(e => e.Subjects).FirstOrDefault(e => e.Email == email);
        }

        //9
        public bool CheckAtLeastOneSubjectTaughtByTeacher(int teacherId)
        {
            var teacher = _db.Include(e => e.Subjects).FirstOrDefault(e => e.Id == teacherId);
            return teacher != null && teacher.Subjects != null && teacher.Subjects.Any();
        }

        public IEnumerable<Teacher> AllTeachersFromDepartmentandReturnID(int departmentId)
        {
            return _db.Include(e => e.Department).Include(e => e.Subjects).Where(e => e.DepartmentId == departmentId).Select(e => new Teacher { Id = e.Id});
        }

        public IEnumerable<Teacher> GetAllSubjectsBySpecifiedTeacher(int teacherId)
        {
            throw new NotImplementedException();
        }
    }
}
