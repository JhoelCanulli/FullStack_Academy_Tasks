using API_nasa.DTO;
using API_nasa.Repositories;

namespace API_nasa.Services
{
    public class CorSisService
    {
        #region repository
        private readonly Corpo_SistemaRepo _corpoSistemaRepo;
        public CorSisService(Corpo_SistemaRepo corpoSistemaRepo)
        {
            _corpoSistemaRepo = corpoSistemaRepo;
        }
        #endregion

        #region CRUD service
        public bool AddRelazione(CorSisDTO dto)
        {
            if (dto.co.Codice_corpo == null || dto.si.Codice_sistema == null)
            {
                return false;
            }

            return _corpoSistemaRepo.InsertRelazione(dto.co.Codice_corpo, dto.si.Codice_sistema);
        }

        public List<CorSisDTO> GetAllRelazioni()
        {
            var relazioni = _corpoSistemaRepo.GetCorSis();
            return relazioni.Select(relazione => new CorSisDTO
            {
                co    = relazione.cor, 
                si    = relazione.sis, 
                CoRIF = relazione.CorpoRIF,
                SiRIF = relazione.SistemaRIF
            }).ToList();
        }

        public bool UpdateRelazione(string codiceCorpo, string codiceSistemaPrec, string codiceSistemaNuovo)
        {
            return _corpoSistemaRepo.UpdateSistemaForCorpo(codiceCorpo, codiceSistemaPrec, codiceSistemaNuovo);
        }

        public bool RemoveRelazione(string codiceCorpo, string codiceSistema)
        {
            return _corpoSistemaRepo.DeleteCorFromSis(codiceCorpo, codiceSistema);
        }
        #endregion
    }
}
