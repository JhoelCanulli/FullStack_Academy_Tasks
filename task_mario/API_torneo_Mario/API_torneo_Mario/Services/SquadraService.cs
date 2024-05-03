using API_torneo_Mario.DTO;
using API_torneo_Mario.Models;
using API_torneo_Mario.Repos;

namespace API_torneo_Mario.Services
{
    public class SquadraService
    {
        #region repo injection
        private readonly SquadraRepo _repository;

        public SquadraService(SquadraRepo repository)
        {
            _repository = repository;
        }
        #endregion

        #region converters
        List<SquadraDTO> ConvertToSquadreDTO(List<Squadra> squadre)
        {
            return squadre.Select(s => new SquadraDTO()
            {
                Code = s.CodiceS,
                Name = s.NomeS,
                Budg = s.Budget,
                ElPe = ConvertToPersonaggiDTO(s.Personaggi.ToList())
            }).ToList();
        }

        SquadraDTO ConvertToSquadraDTO(Squadra squadra)
        {
            return new SquadraDTO()
            {
                Code = squadra.CodiceS,
                Name = squadra.NomeS,
                Budg = squadra.Budget,
                ElPe = ConvertToPersonaggiDTO(squadra.Personaggi.ToList())
            };
        }

        List<PersonaggioDTO> ConvertToPersonaggiDTO(List<Personaggio> personaggi)
        {
            return personaggi.Select(p => new PersonaggioDTO()
            {
                Code = p.CodiceP,
                Name = p.NomeP,
                Cate = p.Categoria,
                Cred = p.Crediti,
            }).ToList();
        }
        #endregion

        public List<SquadraDTO> GetAll()
        {
            return ConvertToSquadreDTO(_repository.GetAll());
        }

        public bool Insert(SquadraDTO squadra)
        {
            if (_repository.GetAll().Count >= 3)
                return false;

            if (_repository.GetAll().SingleOrDefault(g => g.CodiceS.ToLower() == squadra.Code.ToLower()) is not null)
                return false;

            return _repository.Create(new Squadra()
            {
                CodiceS = squadra.Code,
                NomeS = squadra.Name,
            });
        }
        public bool Delete(SquadraDTO squadra)
        {
            try
            {
                return _repository.DeleteByCode(squadra.Code);
            }
            catch
            {}
            return false;
        }

        public bool Update(SquadraDTO squadraDTO)
        {
            Squadra squadra = _repository.GetByCode(squadraDTO.Code);

            squadra.NomeS = squadraDTO.Name;
            squadra.Budget = squadraDTO.Budg;

            return _repository.Update(squadra);
        }

        public SquadraDTO GetByCode(SquadraDTO squadra)
        {
            return ConvertToSquadraDTO(_repository.GetByCode(squadra.Code));
        }
    }
}
