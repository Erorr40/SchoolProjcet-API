using School.Models;

namespace SchoolProjcet.Repo
{
    public interface IUnitOfWork 
    {
        public IGenaricRepo<Department> Department { get; }
        public IGenaricRepo<Student> Student { get; }
        public IEnrollmentRepo Enrollment { get; }
        public ITeacherRepo Teacher { get; }
        public ISubject Subject { get; }
        public IClassRoomRepo ClassRoom { get; }
        public IUserRepo Users { get;  }

        public void Save();
    }
}
