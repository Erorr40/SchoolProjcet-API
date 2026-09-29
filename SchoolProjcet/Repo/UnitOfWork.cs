using School.AppContext;
using School.Models;

namespace SchoolProjcet.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db, IGenaricRepo<Department> department, IGenaricRepo<Student> student, ITeacherRepo teacher, ISubject subject, IClassRoomRepo classRoom)
        {
            _db = db;
            Department = department;
            Student = student;
            Teacher = teacher;
            Subject = subject;
            ClassRoom = classRoom;
        }
        public IGenaricRepo<Department> Department { get; }

        public IGenaricRepo<Student> Student { get; }
        public IEnrollmentRepo Enrollment { get; }
        public ITeacherRepo Teacher { get; }

        public ISubject Subject { get; }

        public IClassRoomRepo ClassRoom { get; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
