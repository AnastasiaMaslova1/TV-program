using System.Linq.Expressions;
using TV_program.DataAccess.Entities;

namespace TV_program.DataAccess
{
    public interface IRepository<T> where T : IBaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
        T? GetById(int id);
        T? GetById(Guid id);
        T Save(T entity);
        void Delete(T entity);
    }
}
