using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using INVOICE_APP.Repository.Interfaces;

namespace INVOICE_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxRepo _taxRepo;

        public TaxController(ITaxRepo taxRepo)
        {
            _taxRepo = taxRepo;
        }

        [HttpGet]
        public IActionResult get(decimal amount, string taxType)
        {
            decimal AmounttoPay = _taxRepo.CalculateTax(amount, taxType);


            return Ok(AmounttoPay);
        }
    }
}
