using API_torneo_Mario.Models;

namespace API_torneo_Mario.Repos
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        T? GetByCode(string codice);
        bool Create(T entity);
        bool Update(T entity);
        public bool DeleteByCode(string cod);
    }
}
