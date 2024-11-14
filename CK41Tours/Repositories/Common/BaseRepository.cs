using CK41Tours.DAO;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CK41Tours.Repositories.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly CK41ToursDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(CK41ToursDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = dbContext.Set<T>();
        }
        public void Create(T entiyy)
        {
            _dbContext.Add<T>(entiyy);
        }

        public void Delete(T entiyy)
        {
            _dbContext.Update<T>(entiyy);
        }

        public IEnumerable<T> GetAll()
        {
           return _dbSet.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> expression)
        {
           return _dbSet.AsNoTracking().Where(expression).AsEnumerable();
        }

        public void Update(T entiyy)
        {
            _dbContext.Update<T>(entiyy);
        }
    }
}
