using API_nasa.Repositories;
using API_nasa.DTO;
using API_nasa.Models;

namespace API_nasa.Services
{
    public class CorpoService
    {
        #region repository
        readonly CorpoCelesteRepo repository;

        public CorpoService(CorpoCelesteRepo repository)
        {
            this.repository = repository;
        }
        #endregion

        #region CRUD Service 
        public bool Insert(CorpoDTO corpo)
        {
            return repository.Insert(new CorpoCeleste() 
            {
                Codice_corpo        = corpo.Code,
                Nome_corpo          = corpo.Name,
                Tipo_corpo          = corpo.Type,
                Scopritore          = corpo.Disc,
                Data_scoperta       = corpo.DDis,
                Distanza_da_terra   = corpo.Dist,
                CoordinataRadiale   = corpo.Radi,
                CoordinataAngolare  = corpo.Angu
            });
        }

        public List<CorpoDTO> GetAll()
        {
            return repository.GetAll().Select(c => new CorpoDTO()
            {
                Code = c.Codice_corpo,
                Name = c.Nome_corpo,
                Type = c.Tipo_corpo,
                Disc = c.Scopritore,
                DDis = c.Data_scoperta,
                Dist = c.Distanza_da_terra,
                Radi = c.CoordinataRadiale,
                Angu = c.CoordinataAngolare
            }).ToList();
        }

        CorpoCeleste GetCorpoByCodice(CorpoDTO corpo)
        {
            if (corpo.Code is not null)
            {
                return repository.GetCorByCodice(corpo.Code);
            }

            return new CorpoCeleste();
        }
        public CorpoDTO ToDTO(CorpoCeleste corpo)
        {
            return new CorpoDTO
            {
                Code = corpo.Codice_corpo,
                Name = corpo.Nome_corpo,
                Type = corpo.Tipo_corpo,
                Disc = corpo.Scopritore,
                DDis = corpo.Data_scoperta,
                Dist = corpo.Distanza_da_terra,
                Radi = corpo.CoordinataRadiale,
                Angu = corpo.CoordinataAngolare
            };
        }

        public CorpoCeleste FromDTO(CorpoDTO dto)
        {
            return new CorpoCeleste
            {
                Codice_corpo        = dto.Code,
                Nome_corpo          = dto.Name,
                Tipo_corpo          = dto.Type,
                Scopritore          = dto.Disc,
                Data_scoperta       = dto.DDis,
                Distanza_da_terra   = dto.Dist,
                CoordinataRadiale   = dto.Radi,
                CoordinataAngolare  = dto.Angu
            };
        }

        public CorpoDTO GetByCodice(CorpoDTO corpoDTO)
        {
            if (corpoDTO.Code is not null)
            {
                CorpoCeleste corpo = GetCorpoByCodice(corpoDTO);
                return new CorpoDTO()
                {
                    Code = corpo.Codice_corpo,
                    Name = corpo.Nome_corpo,
                    Type = corpo.Tipo_corpo,
                    Disc = corpo.Scopritore,
                    DDis = corpo.Data_scoperta,
                    Dist = corpo.Distanza_da_terra,
                    Radi = corpo.CoordinataRadiale,
                    Angu = corpo.CoordinataAngolare
                };
            }

            return new CorpoDTO();
        }

        public bool DeleteByCodice(CorpoDTO corpo)
        {
            if (corpo.Code is not null)
            {
                return repository.DeleteByID(GetCorpoByCodice(corpo).CorpoID);
            }

            return false;
        }

        public bool Update(CorpoDTO corpoDTO)
        {
            CorpoCeleste corpo = GetCorpoByCodice(corpoDTO);

            corpo.Nome_corpo            = corpoDTO.Name;
            corpo.Tipo_corpo            = corpoDTO.Type;
            corpo.Scopritore            = corpoDTO.Disc;
            corpo.Data_scoperta         = corpoDTO.DDis;
            corpo.Distanza_da_terra     = corpoDTO.Dist;
            corpo.CoordinataRadiale     = corpoDTO.Radi;
            corpo.CoordinataAngolare    = corpoDTO.Angu;

            return repository.Update(corpo);
        }
        #endregion

    }
}
