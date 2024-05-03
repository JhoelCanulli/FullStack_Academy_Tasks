using API_torneo_Mario.Models;

namespace API_torneo_Mario.Repos
{
    public class SquadraRepo : IRepo<Squadra>
    {
        #region context injection
        private readonly Context _context;

        public SquadraRepo(Context context)
        {
            _context = context;
        }
        #endregion

        public bool Create(Squadra entity)
        {
            try
            {
                _context.Squadre.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool DeleteByCode(string code)
        {

            try
            {
                Squadra? temp = GetByCode(code);
                if (temp != null)
                {
                    _context.Squadre.Remove(temp);
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

        public List<Squadra> GetAll()
        {
            try
            {
                return _context.Squadre.ToList();
            }
            catch
            { }
            return new List<Squadra>();
        }

        public bool Update(Squadra entity)
        {
            try
            {
                _context.Squadre.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Squadra? GetByCode(string codice)
        {
            try
            {
                return _context.Squadre.FirstOrDefault(p => p.CodiceS == codice);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
