using API_nasa.Models;

namespace API_nasa.Repositories
{
    public interface IRepoTabAppoggio <T>
    {
        /// <summary>
        /// Crea una relazione nella tabella di appoggio tra Corpo Celeste e Sistema 
        /// </summary>
        /// <param name="codiceCorpo"></param>
        /// <param name="codiceSistema"></param>
        /// <returns></returns>
        public bool InsertRelazione(string codiceCorpo, string codiceSistema);

        public List<Corpo_Sistema> GetCorSis();

        /// <summary>
        /// Visualizza tutti i Sistemi di appartenenza di un Corpo Celeste 
        /// </summary>
        /// <param name="codiceCorpo"></param>
        /// <returns></returns>
        /// 
        public List<Sistema> GetSistemiForCorpo(string codiceCorpo);

        /// <summary>
        /// Visualizza tutti i Corpi Celesti in un Sistema
        /// </summary>
        /// <param name="codiceSistema"></param>
        /// <returns></returns>
        /// 
        public List<CorpoCeleste> GetCorpiInSistema(string codiceSistema);

        /// <summary>
        /// Cambia il sistema di un corpo celeste 
        /// </summary>
        /// <param name="codiceCorpo"></param>
        /// <param name="codiceSistemaPrec"></param>
        /// <param name="codiceSistemaNuovo"></param>
        /// <returns></returns>
        public bool UpdateSistemaForCorpo(string codiceCorpo, string codiceSistemaPrec, string codiceSistemaNuovo);

        /// <summary>
        /// Cambia un corpo celeste in un sistema
        /// </summary>
        /// <param name="codiceSistema"></param>
        /// <param name="codiceCorpoPrec"></param>
        /// <param name="codiceCorpoNuovo"></param>
        /// <returns></returns>
        public bool UpdateCorpoInSistema(string codiceSistema, string codiceCorpoPrec, string codiceCorpoNuovo);

        /// <summary>
        /// Cancella una relazione nella tabella di appoggio tra Corpo Celeste e Sistema 
        /// </summary>
        /// <param name="codiceCorpo"></param>
        /// <param name="codiceSistema"></param>
        /// <returns></returns>
        public bool DeleteCorFromSis(string codiceCorpo, string codiceSistema);
    }
}
