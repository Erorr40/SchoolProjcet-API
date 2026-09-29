using School.Models;

namespace SchoolProjcet.Repo
{
    public interface ITeacherRepo : IGenaricRepo<Teacher>
    {
        public IEnumerable<Teacher> GetTeachersByDepartmentId(int departmentId);
        public IEnumerable<Teacher> GetTeachersByDepartmentIdAndSalary(int departmentId, decimal minSalary);
    }
}
