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
            return _context.ClassRooms.Where(c => c.Capacity > capacity).Take(1);
        }

        public ClassRoom GetClassRoomWithName(string name)
        {
            return _context.ClassRooms.FirstOrDefault(c => c.Name == name);
        }

        public ClassRoom OrderAndReturnSpecifiedZeroIndex()
        {
            return _context.ClassRooms.OrderBy(c => c.Id).FirstOrDefault();
        }

        public bool CheckEveryClassRoomInSpecifiedGradeLevelatLestSpecifiedCapacity(int gradeLevel, int capacity)
        {
            return _context.ClassRooms
                .Where(c => c.GradeLevel == gradeLevel)
                .All(c => c.Capacity >= capacity);
        }

        public ClassRoom GetClassRoomByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
