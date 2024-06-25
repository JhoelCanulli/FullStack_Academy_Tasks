using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_WEB_impiegati.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpiegatoController : ControllerBase
    {
        [HttpGet("ListOfUsers")]
        public IActionResult GetListOfUsers()
        {
            return Ok(new Response()
            {
                Status = "SUCCESS",
                Data = _service.GetListOfUsers()
            });
        }
    }
}
