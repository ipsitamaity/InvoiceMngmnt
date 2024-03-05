using INVOICE_APP.Models;
using INVOICE_APP.Repository.Interfaces;
using INVOICE_APP.Services.Interfaces;

namespace INVOICE_APP.Services
{
    public class InvoiceItemService : IInvoiceItemService
    {
        private readonly IInvoiceItems _invoiceItemsRepository;

        public InvoiceItemService(IInvoiceItems invoiceItemsRepository)
        {
            _invoiceItemsRepository = invoiceItemsRepository;
        }
        public IEnumerable<InvoiceItem> GetAllInvoiceItems()
        {
            // Add your implementation here if needed
            throw new System.NotImplementedException();
        }


        public IEnumerable<InvoiceItem> GetAllInvoiceItems(int invoiceID)
        {
            return _invoiceItemsRepository.GetAllInvoiceItems(invoiceID);
        }

    }
}
