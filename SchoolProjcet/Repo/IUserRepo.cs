using SchoolProjcet.DTO;
using SchoolProjcet.Models;

namespace SchoolProjcet.Repo
{
    public interface IUserRepo : IGenaricRepo<User>
    {
        public User GetUserByUserName(string name);
    }
}
