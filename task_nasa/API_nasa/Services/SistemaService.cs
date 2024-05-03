using API_nasa.DTO;
using API_nasa.Models;
using API_nasa.Repositories;

namespace API_nasa.Services
{
    public class SistemaService
    {
        #region repository
        readonly SistemaRepo repository;

        public SistemaService(SistemaRepo repository)
        {
            this.repository = repository;
        }
        #endregion

        #region Metodi privati
        Sistema GetSistemaByCodice(SistemaDTO sistema)
        {
            if (sistema.Code is not null)
            {
                return repository.GetSisByCodice(sistema.Code);
            }

            return new Sistema();
        }
        #endregion



        public List<SistemaDTO> GetAll() 
        {
            return repository.GetAll().Select(s => new SistemaDTO()
            {
                Code = s.Codice_sistema,
                Name = s.Nome_sistema,
                Type = s.Tipo_sistema
            }).ToList();
        }

        public SistemaDTO GetByCodice(SistemaDTO sistema)
        {
            if (sistema.Code is not null) {
                Sistema temp = GetSistemaByCodice(sistema);
                return new SistemaDTO()
                {
                    Code = temp.Codice_sistema,
                    Name = temp.Nome_sistema,
                    Type = temp.Tipo_sistema
                };
            }

            return new SistemaDTO();
        }

        public bool DeleteByCodice(SistemaDTO sistema)
        {
            if (sistema.Code is not null)
            {
                return repository.DeleteByID(GetSistemaByCodice(sistema).SistemaID);
            }

            return false;
        }

        public bool Insert(SistemaDTO sistema)
        {
            return repository.Insert(new Sistema() { Codice_sistema = sistema.Code , Nome_sistema = sistema.Name , Tipo_sistema = sistema.Type });
        }

        public bool Update(SistemaDTO sistemaDTO)
        {
            Sistema sistema = GetSistemaByCodice(sistemaDTO);

            sistema.Nome_sistema = sistemaDTO.Name;
            sistema.Tipo_sistema = sistemaDTO.Type;

            return repository.Update(sistema);
        }
    }
}
