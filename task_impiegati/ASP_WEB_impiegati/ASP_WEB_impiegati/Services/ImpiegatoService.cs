using ASP_WEB_impiegati.Models;
using ASP_WEB_impiegati.Repositories;

namespace ASP_WEB_impiegati.Services
{
    public class ImpiegatoService
    {
        #region repository
        private readonly ImpiegatoRepository _imRepository;
        private readonly RepartoRepository _repRepository;
        private readonly ResidenzaRepository _resRepository;

        public ImpiegatoService(ImpiegatoRepository imRepository, RepartoRepository repRepository, ResidenzaRepository resRepository)
        {
            _imRepository = imRepository;
            _repRepository = repRepository;
            _resRepository = resRepository;
        }
        #endregion

        public List<Impiegato> GetListOfEmployees()
        {
            return _imRepository.GetListOfEmployees();
        }


    }
}
