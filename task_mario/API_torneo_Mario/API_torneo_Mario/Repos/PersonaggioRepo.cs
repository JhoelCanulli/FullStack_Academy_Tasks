using API_torneo_Mario.Models;
using Microsoft.EntityFrameworkCore;

namespace API_torneo_Mario.Repos
{
    public class PersonaggioRepo : IRepo<Personaggio>
    {
        #region context injection
        private readonly Context _context;

        public PersonaggioRepo(Context context)
        {
            _context = context;
        }
        #endregion

        public bool Create(Personaggio entity)
        {
            try
            {
                _context.Personaggi.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
            return false;
        }

        public bool DeleteByCode(string cod)
        {
            try
            {
                Personaggio? temp = GetByCode(cod);
                if (temp != null)
                {
                    _context.Personaggi.Remove(temp);
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            return false;
        }

        public List<Personaggio> GetAll()
        {
            try
            {
                return _context.Personaggi.ToList();
            }
            catch { }

            return new List<Personaggio>();
        }

        public bool Update(Personaggio entity)
        {
            try
            {
                _context.Personaggi.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public Personaggio? GetByCode(string codice)
        {
            try
            {
                return _context.Personaggi.FirstOrDefault(p => p.CodiceP == codice);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
        public Personaggio GetByName(string nome)
        {
            try
            {
                return _context.Personaggi.Include(s => s.Squadra).Single(p => p.NomeP == nome);
            }
            catch { }

            return new Personaggio();
        }
    }
}
