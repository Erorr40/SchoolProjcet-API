using Microsoft.EntityFrameworkCore;
using School.AppContext;

namespace SchoolProjcet.Repo
{
    public class GenericRepo<T> : IGenaricRepo<T> where T : class
    {
        readonly AppDbContext _context;
        readonly DbSet<T> _db;

        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public void Create(T obj)
        {
            _db.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _db.ToList();
        }

        public T GetById(int id)
        {
            return _db.Find(id);
        }

        public void Update(T obj)
        {
            _db.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = _db.Find(id);
            if (obj != null)
            {
                _db.Remove(obj);
                _context.SaveChanges();
            }
        }
    }
}
