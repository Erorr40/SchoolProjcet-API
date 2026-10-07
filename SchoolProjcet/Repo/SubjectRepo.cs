using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;

namespace SchoolProjcet.Repo
{
    public class SubjectRepo : GenericRepo<Subject>, ISubject
    {
        public SubjectRepo(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Subject> FristSubjectbySpecifiedTeacherOrderedbySubjectName(int teacherId)
        {
            return 
                _db
                .Include(e => e.Enrollments)
                .Include(e => e.Teacher)
                .Where(s => s.TeacherId == teacherId)
                .OrderBy(s => s.Name)
                .Take(1)
                .ToList();
        }
        public Subject LastSubjectBySpecifiedTeacherOrderedbySubjectID(int teacherId)
        {
            return
                _db
                .Include(e => e.Enrollments)
                .Include(e => e.Teacher)
                .Where(s => s.TeacherId == teacherId)
                .OrderByDescending(s => s.Id)
                .FirstOrDefault();
        }

        public bool CheckSpecifiedSubjectIDExistInaListOfSubjects(int subjectId)
        {
            return _db.Where(e => e.Id == subjectId).Any();
        }

        public List<Subject> GetAllSubjectsBySpecifiedTeacher(int teacherId)
        {
            return _db
                .Include(e => e.Enrollments)
                .Include(e => e.Teacher)
                .Where(s => s.TeacherId == teacherId)
                .ToList();
        }

        
    }
}
