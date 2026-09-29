using School.Models;

namespace SchoolProjcet.Repo
{
    public interface IClassRoomRepo : IGenaricRepo<ClassRoom>
    {
        public IEnumerable<ClassRoom> GetFristClassRoomWithCapasicyMorethanVal(int capacity);
        public ClassRoom GetClassRoomByName(string name);
        public ClassRoom OrderAndReturnSpecifiedZeroIndex();
        public bool CheckEveryClassRoomInSpecifiedGradeLevelatLestSpecifiedCapacity(int gradeLevel, int capacity);
    }
}
