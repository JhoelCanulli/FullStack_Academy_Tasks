using API_torneo_Mario.DTO;
using API_torneo_Mario.Models;
using API_torneo_Mario.Repos;

namespace API_torneo_Mario.Services
{
    public class PersonaggioService
    {
        #region repo injection
        private readonly PersonaggioRepo _repository;

        public PersonaggioService(PersonaggioRepo repository)
        {
            _repository = repository;
        }
        #endregion

        #region converters 
        List<PersonaggioDTO> ConvertToPersonaggiDTO(List<Personaggio> personaggi)
        {
            return personaggi.Select(p => new PersonaggioDTO()
            {
                Code = p.CodiceP,
                Name = p.NomeP,
                Cate = p.Categoria,
                Cred = p.Crediti,
                Squa = ConvertToSquadraDTO(p.Squadra)
            }).ToList();
        }

        PersonaggioDTO ConvertToPersonaggioDTO(Personaggio personaggio)
        {
            return new PersonaggioDTO()
            {
                Code = personaggio.CodiceP,
                Name = personaggio.NomeP,
                Cate = personaggio.Categoria,
                Cred = personaggio.Crediti,
                Squa = ConvertToSquadraDTO(personaggio.Squadra)
            };
        }

        SquadraDTO? ConvertToSquadraDTO(Squadra? squadra)
        {
            if (squadra is not null)
                return new SquadraDTO()
                {
                    Code = squadra.CodiceS,
                    Name = squadra.NomeS,
                    Budg = squadra.Budget
                };

            return null;
        }
        #endregion

        public List<PersonaggioDTO> GetAllPer()
        {
            return ConvertToPersonaggiDTO(_repository.GetAll());
        }

        public bool InsPersonaggio(PersonaggioDTO per)
        {
            if (_repository.GetAll().SingleOrDefault(p => p.NomeP.ToLower() == per.Name.ToLower()) != null) return false;
            
            return _repository.Create(new Personaggio()
            {
                CodiceP = per.Code,
                NomeP = per.Name,
                Categoria = per.Cate,
                Crediti = per.Cred
            });
        }
        public bool ModPersonaggio(PersonaggioDTO p)
        {
            if (p.Code != null)
            {
                Personaggio per = _repository.GetByName(p.Name);
                if (per != null)
                {
                    per.CodiceP = p.Code;
                    per.NomeP = p.Name;
                    per.Categoria = p.Cate;
                    per.Crediti = p.Cred;
                    return _repository.Update(per);
                }
            }
            return false;
        }

        public PersonaggioDTO GetByName(PersonaggioDTO personaggio)
        {
            return ConvertToPersonaggioDTO(_repository.GetByName(personaggio.Name));
        }
    }
}
