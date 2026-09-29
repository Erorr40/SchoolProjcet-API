using School.Models;

namespace SchoolProjcet.Repo
{
    public interface IClassRoomRepo : IGenaricRepo<ClassRoom>
    {
        public IEnumerable<ClassRoom> GetFristClassRoomWithCapasicyMorethanVal(int capacity);
    }
}
