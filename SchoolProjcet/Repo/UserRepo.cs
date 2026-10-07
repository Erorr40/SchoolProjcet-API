using School.AppContext;
using SchoolProjcet.Models;

namespace SchoolProjcet.Repo
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(AppDbContext context) : base(context)
        {
        }

        public User GetUserByUserName(string name)
        {
            return _db.Where(e => e.UserName == name).FirstOrDefault();
        }
    }
}
