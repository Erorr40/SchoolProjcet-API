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
    }
}
