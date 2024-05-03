using API_nasa.Models;

namespace API_nasa.Repositories
{
    public class SistemaRepo : IRepoEntSingole<Sistema>
    {
        #region context
        readonly NasaContext context;
        public SistemaRepo(NasaContext context)
        {
            this.context = context;
        }
        #endregion

        #region implemento CRUD da IRepoTabSingole per db
        public bool Insert(Sistema t)
        {
            try
            {
                context.Sistemi.Add(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public List<Sistema> GetAll()
        {
            try
            {
                return context.Sistemi.ToList();
            }
            catch { }

            return new List<Sistema>();
        }

        public Sistema? GetByID(int id)
        {
            try
            {
                return context.Sistemi.SingleOrDefault(c => c.SistemaID == id);
            }
            catch { }

            return null;
        }


        public bool Update(Sistema t)
        {
            try
            {
                context.Sistemi.Update(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public bool DeleteByID(int id)
        {
            try
            {
                context.Remove(context.Sistemi.Single(c => c.SistemaID == id));
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }
        #endregion

        #region metodi interni
        public Sistema GetSisByCodice(string codice)
        {
            try
            {
                return context.Sistemi.Single(c => c.Codice_sistema == codice);
            }
            catch { }

            return new Sistema();
        }
        #endregion 
    }
}
