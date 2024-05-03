namespace API_nasa.Repositories
{
    public interface IRepoEntSingole<T>
    {
        #region CRUD per db
        public bool Insert(T t);
        List<T> GetAll();
        public T? GetByID(int id);
        public bool Update(T t);
        bool DeleteByID(int id);
        #endregion
    }
}
