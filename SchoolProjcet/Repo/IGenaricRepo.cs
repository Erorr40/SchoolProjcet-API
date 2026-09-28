using School.AppContext;

namespace SchoolProjcet.Repo
{
    public interface IGenaricRepo<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Create(T obj);
        public void Update(T obj);
        public void Delete(int id);
    }
}
