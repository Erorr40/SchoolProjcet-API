using School.Models;

namespace SchoolProjcet.Repo
{
    public interface IEnrollmentRepo : IGenaricRepo<Enrollment>
    {
        public Enrollment GetOldestEnrollmentBySubjectEnrollmentDate(int subjectId);
    }
}
