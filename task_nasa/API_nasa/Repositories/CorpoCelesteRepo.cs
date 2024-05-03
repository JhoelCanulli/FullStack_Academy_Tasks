using API_nasa.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace API_nasa.Repositories
{
    public class CorpoCelesteRepo : IRepoEntSingole<CorpoCeleste>
    {

        #region context
        readonly NasaContext context;
        public CorpoCelesteRepo(NasaContext context)
        {
            this.context = context;
        }
        #endregion

        #region implemento CRUD da IRepoTabSingole per db
        public bool Insert(CorpoCeleste t)
        {
            try
            {
                context.Corpi.Add(t);
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public List<CorpoCeleste> GetAll()
        {
            try
            {
                return context.Corpi.ToList();
            }
            catch { }

            return new List<CorpoCeleste>();
        }

        public CorpoCeleste? GetByID(int id)
        {
            try
            {
                return context.Corpi.SingleOrDefault(c => c.CorpoID == id);
            }
            catch { }

            return null;
        }


        public bool Update(CorpoCeleste t)
        {
            try
            {
                context.Corpi.Update(t);
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
                context.Remove(context.Corpi.Single(c => c.CorpoID == id));
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }
        #endregion

        #region metodi interni
        public CorpoCeleste GetCorByCodice(string codice)
        {
            try
            {
                return context.Corpi.Single(c => c.Codice_corpo == codice);
            }
            catch { }

            return new CorpoCeleste();
        }
        #endregion 
    }
}
