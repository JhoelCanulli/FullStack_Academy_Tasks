using ASP_WEB_impiegati.Models;

namespace ASP_WEB_impiegati.Repositories
{
    public class ImpiegatoRepository
    {
        #region context, logger
        private readonly ILogger _logger;
        private readonly Context _dbContext;

        public ImpiegatoRepository(Context dbContext, ILogger<ImpiegatoRepository> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        #endregion

        public List<Impiegato> GetListOfEmployees()
        {
            try
            {
                return _dbContext.Impiegati.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return new List<Impiegato>();
        }

    }
}
