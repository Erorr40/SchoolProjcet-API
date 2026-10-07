using School.AppContext;
using School.Models;

namespace SchoolProjcet.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db, IGenaricRepo<Department> department, IGenaricRepo<Student> student, IEnrollmentRepo enrollment, ITeacherRepo teacher, ISubject subject, IClassRoomRepo classRoom, IUserRepo users)
        {
            _db = db;
            Department = department;
            Student = student;
            Enrollment = enrollment;
            Teacher = teacher;
            Subject = subject;
            ClassRoom = classRoom;
            Users = users;
        }

        public IGenaricRepo<Department> Department { get; }

        public IGenaricRepo<Student> Student { get; }
        public IEnrollmentRepo Enrollment { get; }
        public ITeacherRepo Teacher { get; }

        public ISubject Subject { get; }

        public IClassRoomRepo ClassRoom { get; }
        
        public IUserRepo Users { get; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
