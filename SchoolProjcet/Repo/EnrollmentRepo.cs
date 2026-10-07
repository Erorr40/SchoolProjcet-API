using School.AppContext;
using School.Models;

namespace SchoolProjcet.Repo
{
    public class EnrollmentRepo : GenericRepo<Enrollment>, IEnrollmentRepo
    {
        public EnrollmentRepo(AppDbContext context) : base(context)
        {
        }

        public Enrollment GetOldestEnrollmentBySubjectEnrollmentDate(int subjectId)
        {
            return _context.Enrollments
                .Where(e => e.SubjectId == subjectId)
                .OrderBy(e => e.EnrollmentDate)
                .Last();
        }
    }
}
