namespace ASP_ferramenta.Repositories
{
    public interface IRepo
    {
        public interface IRepo<T>
        {
            T? GetById(int id);
            T? GetByCode(string? codice);
            List<T> GetAll();
            bool Insert(T t);
            bool Update(T t);
            bool Delete(int id);

        }
    }
}
