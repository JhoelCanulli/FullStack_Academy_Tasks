using ASP_ferramenta.Models;
using static ASP_ferramenta.Repositories.IRepo;

namespace ASP_ferramenta.Repositories
{
    public class ProdottoRepo : IRepo<Prodotto>
    {
        private static ProdottoRepo? _instance;

        public static ProdottoRepo GetInstance()
        {
            if (_instance == null)
                _instance = new ProdottoRepo();
            return _instance;
        }

        private ProdottoRepo() { }

        public bool Delete(int id)
        {
            bool risultato = false;
            using (FerramentaContext ctx = new FerramentaContext())
            {
                try
                {
                    Prodotto prod = ctx.Prodottos.Single(c => c.ProdottoId == id);
                    ctx.Prodottos.Remove(prod);
                    ctx.SaveChanges();

                    risultato = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;

        }

        public List<Prodotto> GetAll()
        {
            List<Prodotto> elenco = new List<Prodotto>();

            using (FerramentaContext ctx = new FerramentaContext())
            {
                elenco = ctx.Prodottos.ToList();
            }

            return elenco;
        }

        public Prodotto? GetById(int id)
        {
            Prodotto? prod = null;
            
            using (FerramentaContext ctx = new FerramentaContext())
                prod = ctx.Prodottos.FirstOrDefault(p => p.ProdottoId == id);

            return prod;
        }

        public bool Insert(Prodotto t)
        {
            bool risultato = false;
            using (FerramentaContext ctx = new FerramentaContext())
            {
                try
                {
                    ctx.Prodottos.Add(t);
                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return risultato;
        }

        public bool Update(Prodotto t)
        {
            bool risultato = false;

            using (FerramentaContext ctx = new FerramentaContext())
            {
                try
                {
                    Prodotto temp = ctx.Prodottos.Single(p => p.Codice == t.Codice);

                    t.ProdottoId = temp.ProdottoId;
                    t.Nome = t.Nome is not null ? t.Nome : temp.Nome;
                    t.Descrizione = t.Descrizione is not null ? t.Descrizione : temp.Descrizione;
                    t.Prezzo = t.Prezzo == 0 ? temp.Prezzo : t.Prezzo;
                    t.Quantita = t.Quantita is null ? temp.Quantita : t.Quantita;
                    t.Categoria = t.Categoria is null ? temp.Categoria : t.Categoria;
                    t.DataCreaz = t.DataCreaz is null ? temp.DataCreaz : t.DataCreaz;

                    ctx.Entry(temp).CurrentValues.SetValues(t);

                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;
        }

        public Prodotto? GetByCode(string? codice)
        {
            Prodotto? prod = null;

            using (FerramentaContext ctx = new FerramentaContext())
            {
                try
                {
                    prod = ctx.Prodottos.FirstOrDefault(p => p.Codice == codice);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }
            return prod;
        }
    }
}
