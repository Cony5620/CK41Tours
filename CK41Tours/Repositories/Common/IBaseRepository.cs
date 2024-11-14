using System.Linq.Expressions;

namespace CK41Tours.Repositories.Common
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T entiyy);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetBy(Expression<Func<T,bool>>expression);
        void Update(T entiyy);
        void Delete(T entiyy);
    }
}
