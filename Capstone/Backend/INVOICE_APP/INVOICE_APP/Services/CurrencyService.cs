using INVOICE_APP.Repository.Interfaces;
using INVOICE_APP.Services.Interfaces;
using System;

namespace INVOICE_APP.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepo _currencyRepository;

        public CurrencyService(ICurrencyRepo currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public decimal CurrConvCalc(decimal amount, string sourceCurrency, string targetCurrency)
        {
        
            return _currencyRepository.CurrConvCalc(amount, sourceCurrency);
        }
    }
}
