using API_nasa.DTO;
using API_nasa.Services;
using API_nasa.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API_nasa.Controllers
{
    [ApiController]
    [Route("api/corpo")]
    public class CorpoController : Controller
    {
        #region service
        readonly CorpoService service;

        public CorpoController(CorpoService service)
        {
            this.service = service;
        }
        #endregion

        #region Requests
        [HttpPost]
        public IActionResult Insert(CorpoDTO corpo)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Insert(corpo)
            });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetAll()
            });
        }

        [HttpGet("{codice}")]
        public IActionResult GetByCodice(string codice)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.GetByCodice(new CorpoDTO() { Code = codice })
            });
        }

        [HttpDelete("{codice}")]
        public IActionResult DeleteByCodice(string codice)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.DeleteByCodice(new CorpoDTO() { Code = codice })
            });
        }


        [HttpPost("update")]
        public IActionResult Update(CorpoDTO corpo)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Update(corpo)
            });
        }
        #endregion
    }
}
