using ASP_ferramenta.Models;
using ASP_ferramenta.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_ferramenta.Controllers
{
    [ApiController]
    [Route("api/prodotti")]
    public class ProdottoController : Controller
    {
        [HttpGet]
        public IActionResult ElencoProdotti()          //http://localhost:5229/api/prodotti
        {
            return Ok(ProdottoRepo.GetInstance().GetAll());
        }

        [HttpGet("{valCodice}")]
        public IActionResult DettaglioProdotto(string valCodice)
        {
            Prodotto? prod = ProdottoRepo.GetInstance().GetByCode(valCodice);
            if (prod is not null)
                return Ok(prod);

            return NotFound();
        }

        [HttpPost]
        public IActionResult InserisciProdotto(Prodotto objProd)
        {
            if (ProdottoRepo.GetInstance().Insert(objProd))
                return Ok();

            return BadRequest();
        }

            
        private IActionResult EliminaProdotto(int varId)
        {
            if (ProdottoRepo.GetInstance().Delete(varId))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("codice/{varCodice}"), HttpPost("codice/{varCodice}")]
        public IActionResult EliminaPerCodiceProdotto(string varCodice)
        {
            Prodotto? prod = ProdottoRepo.GetInstance().GetByCode(varCodice);
            if (prod is null)
                return BadRequest();

            return EliminaProdotto(prod.ProdottoId);
        }

        [HttpPut]
        public IActionResult ModificaProdotto(Prodotto objProd)
        {
            if (ProdottoRepo.GetInstance().Update(objProd))
                return Ok();

            return BadRequest();
        }

    }

    
}
