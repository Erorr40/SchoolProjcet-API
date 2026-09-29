using School.AppContext;
using School.Models;

namespace SchoolProjcet.Repo
{
    public class ClassRoomRepo : GenericRepo<ClassRoom>, IClassRoomRepo
    {
        public ClassRoomRepo(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<ClassRoom> GetFristClassRoomWithCapasicyMorethanVal(int capacity)
        {
            throw new NotImplementedException();
        }
    }
}
