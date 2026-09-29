using School.Models;

namespace SchoolProjcet.Repo
{
    public interface IUnitOfWork 
    {
        public IGenaricRepo<Department> Department { get; }
        public IGenaricRepo<Student> Student { get; }
        public IGenaricRepo<Enrollment> Enrollment { get; }
        public ITeacherRepo Teacher { get; }
        public ISubject Subject { get; }
        public IClassRoomRepo ClassRoom { get; }

        public void Save();
    }
}
