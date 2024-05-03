using gestore_prestiti_libri.Models;
using gestore_prestiti_libri.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestore_prestiti_libri.DAL
{
    internal class UtenteDAL: IDal<Utente>
    {
        private static UtenteDAL? istanza;

        public static UtenteDAL getIstanza()
        {
            if (istanza == null)
                istanza = new UtenteDAL();

            return istanza;
        }

        private UtenteDAL() { }


        public bool Delete(Utente t)
        {
            throw new NotImplementedException();
        }

        public List<Utente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Utente? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Utente t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Utente t)
        {
            throw new NotImplementedException();
        }
    }
}
