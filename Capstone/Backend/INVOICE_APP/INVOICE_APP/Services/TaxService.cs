using INVOICE_APP.Repository.Interfaces;
using INVOICE_APP.Services.Interfaces;

namespace INVOICE_APP.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepo _taxRepo;

        public TaxService(ITaxRepo taxRepo)
        {
            _taxRepo = taxRepo;
        }

        public decimal CalculateTax(decimal amount, string taxType)
        {
            
            decimal AmounttoPay = _taxRepo.CalculateTax(amount, taxType);
          
            return AmounttoPay;
        }

       
    }
}
