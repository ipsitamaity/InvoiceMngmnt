using Microsoft.AspNetCore.Mvc;
using INVOICE_APP.Repository.Interfaces;

namespace INVOICE_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CCController : ControllerBase
    {
        private readonly ICurrencyRepo _currencyRepository;

        public CCController(ICurrencyRepo currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        [HttpGet]
        public IActionResult get(decimal amount, string currType) //<decimal> ConvertCurrency(decimal amount, string currency, string newCurrency)
        {
            //decimal exchangeRate = _currencyRepository.GetExchangeRate(newCurrency);
            decimal newAmount = _currencyRepository.CurrConvCalc(amount, currType);

            return Ok(newAmount);
        }
    }
}