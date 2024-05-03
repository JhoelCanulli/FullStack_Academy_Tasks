using API_torneo_Mario.DTO;
using API_torneo_Mario.Services;
using API_torneo_Mario.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API_torneo_Mario.Controllers
{
    [Route("api/squadre")]
    [ApiController]
    public class SquadraController : ControllerBase
    {
        #region service injection
        private readonly SquadraService _service;

        public SquadraController(SquadraService service)
        {
            _service = service;
        }
        #endregion

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = _service.GetAll()
            });
        }

        [HttpGet("{codice}")]
        public IActionResult GetByCodice(string codice)
        {
            if (codice.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Il campo codice è vuoto"
                });

            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = _service.GetByCode(new SquadraDTO() { Code = codice })
            });
        }

        [HttpPost("inserisci")]
        public IActionResult InsSquadra(SquadraDTO objSqu)
        {
            if (objSqu.Name.Trim().Equals("") || objSqu.Code.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Campi vuoti"
                });

            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = _service.Insert(objSqu)
            });
        }

        [HttpDelete("{codice}")]
        public IActionResult Delete(string codice)
        {
            if (codice.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Il campo codice è vuoto"
                });

            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = _service.Delete(new SquadraDTO() { Code = codice})
            });
        }

        [HttpPut("modifica")]
        public IActionResult Update(SquadraDTO squadra)
        {
            if (squadra.Code.Trim().Equals(""))
                return BadRequest(new Status()
                {
                    Stato = "ERROR",
                    Data = "Il campo codice è vuoto"
                });

            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = _service.Update(squadra)
            });
        }
    }
}
