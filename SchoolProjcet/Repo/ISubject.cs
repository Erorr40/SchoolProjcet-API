using School.Models;

namespace SchoolProjcet.Repo
{
    public interface ISubject : IGenaricRepo<Subject>
    {
        public IEnumerable<Subject> FristSubjectbySpecifiedTeacherOrderedbySubjectName(int teacherId);
        public Subject LastSubjectBySpecifiedTeacherOrderedbySubjectID(int teacherId);
        public bool CheckSpecifiedSubjectIDExistInaListOfSubjects(int subjectId);
        public List<Subject> GetAllSubjectsBySpecifiedTeacher(int teacherId);
    }
}
