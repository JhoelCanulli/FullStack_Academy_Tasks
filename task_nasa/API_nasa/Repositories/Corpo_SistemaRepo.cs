using API_nasa.Models;
using Microsoft.EntityFrameworkCore;

namespace API_nasa.Repositories
{
    public class Corpo_SistemaRepo : IRepoTabAppoggio <Corpo_Sistema>
    {
        #region context
        readonly NasaContext context;
        public Corpo_SistemaRepo(NasaContext context)
        {
            this.context = context;
        }
        #endregion

        #region implemento CRUD da IRepoTabAppoggio per db
        public bool InsertRelazione(string codiceCorpo, string codiceSistema)
        {
            try
            {
                CorpoCeleste? corpo = context.Corpi.SingleOrDefault(c => c.Codice_corpo == codiceCorpo);
                Sistema? sistema = context.Sistemi.SingleOrDefault(s => s.Codice_sistema == codiceSistema);

                if (corpo != null && sistema != null)
                {
                    Corpo_Sistema relazione = new Corpo_Sistema
                    {
                        CorpoRIF = corpo.CorpoID,
                        SistemaRIF = sistema.SistemaID
                    };
                    context.Corpi_Sistemi.Add(relazione);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            { }

            return false;
        }

        public List<Corpo_Sistema> GetCorSis()
        {
            try
            {
                return context.Corpi_Sistemi.ToList();
            }
            catch { }

            return new List<Corpo_Sistema>();
        }

        public List<Sistema> GetSistemiForCorpo(string codiceCorpo)
        {
            CorpoCeleste? corpo = context.Corpi.FirstOrDefault(c => c.Codice_corpo == codiceCorpo);

            if (corpo == null) return new List<Sistema>();

            return context.Corpi_Sistemi
                .Where(cs => cs.CorpoRIF == corpo.CorpoID)
                .Include(cs => cs.sis)
                .Select(cs => cs.sis)
                .ToList();
        }

        public List<CorpoCeleste> GetCorpiInSistema(string codiceSistema)
        {
            Sistema? sistema = context.Sistemi.FirstOrDefault(c => c.Codice_sistema == codiceSistema);

            if (sistema == null) return new List<CorpoCeleste>();

            return context.Corpi_Sistemi
                .Where(cs => cs.SistemaRIF == sistema.SistemaID)
                .Include(cs => cs.cor)
                .Select(cs => cs.cor)
                .ToList();
        }

        public bool UpdateSistemaForCorpo(string codiceCorpo, string codiceSistemaPrec, string codiceSistemaNuovo)
        {
            try
            {
                CorpoCeleste? corpo = context.Corpi.SingleOrDefault(c => c.Codice_corpo == codiceCorpo);
                Sistema? sisPrec = context.Sistemi.SingleOrDefault(s => s.Codice_sistema == codiceSistemaPrec);
                Sistema? sisNuovo = context.Sistemi.SingleOrDefault(s => s.Codice_sistema == codiceSistemaNuovo);

                if (corpo != null && sisPrec != null && sisNuovo != null)
                {
                    Corpo_Sistema? relazionePrec = context.Corpi_Sistemi.FirstOrDefault(cs => cs.CorpoRIF == corpo.CorpoID && 
                                                                                              cs.SistemaRIF == sisPrec.SistemaID);
                    if (relazionePrec != null)
                    {
                        context.Corpi_Sistemi.Remove(relazionePrec);
                    }

                    Corpo_Sistema relazioneNuova = new Corpo_Sistema
                    {
                        CorpoRIF = corpo.CorpoID,
                        SistemaRIF = sisNuovo.SistemaID
                    };
                    context.Corpi_Sistemi.Add(relazioneNuova);
                    context.SaveChanges();
                    return true;
                }
                
            }
            catch
            { }
            return false;
        }

        public bool UpdateCorpoInSistema(string codiceSistema, string codiceCorpoPrec, string codiceCorpoNuovo)
        {
            try
            {
                Sistema? sistema = context.Sistemi.SingleOrDefault(s => s.Codice_sistema == codiceSistema);
                CorpoCeleste? corPrec = context.Corpi.SingleOrDefault(c => c.Codice_corpo == codiceCorpoPrec);
                CorpoCeleste? corNuovo = context.Corpi.SingleOrDefault(c => c.Codice_corpo == codiceCorpoNuovo);

                if (sistema != null && corPrec != null && corNuovo != null)
                {
                    Corpo_Sistema? relazionePrec = context.Corpi_Sistemi.FirstOrDefault(cs => cs.SistemaRIF == sistema.SistemaID &&
                                                                                              cs.CorpoRIF == corPrec.CorpoID);
                    if (relazionePrec != null)
                    {
                        context.Corpi_Sistemi.Remove(relazionePrec);
                    }

                    Corpo_Sistema relazioneNuova = new Corpo_Sistema
                    {
                        CorpoRIF = corNuovo.CorpoID,
                        SistemaRIF = sistema.SistemaID
                    };
                    context.Corpi_Sistemi.Add(relazioneNuova);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            { }
            return false;
        }

        public bool DeleteCorFromSis(string codiceCorpo, string codiceSistema)
        {
            try
            {
                CorpoCeleste? corpo = context.Corpi.SingleOrDefault(c => c.Codice_corpo == codiceCorpo);
                Sistema? sistema = context.Sistemi.SingleOrDefault(s => s.Codice_sistema == codiceSistema);

                if (corpo != null && sistema != null)
                {
                    Corpo_Sistema? relazione = context.Corpi_Sistemi.FirstOrDefault(cs => cs.CorpoRIF == corpo.CorpoID && 
                                                                                          cs.SistemaRIF == sistema.SistemaID);
                    if (relazione != null)
                    {
                        context.Corpi_Sistemi.Remove(relazione);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            catch
            {}

            return false;
        }
        #endregion
    }
}