using INVOICE_APP.Models;
using INVOICE_APP.Repository.Interfaces;
using INVOICE_APP.Services.Interfaces;
using System.Collections.Generic;
namespace INVOICE_APP.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoices _invoicesRepository;

        public InvoiceService(IInvoices invoicesRepository)
        {
            _invoicesRepository = invoicesRepository;
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return _invoicesRepository.GetAllInvoices();
        }
        public void AddInvoice(Invoices_view invoice)
        {
            _invoicesRepository.AddInvoice(invoice);
        }
        public void UpdateInvoice(Invoices_view invoice)
        {
            _invoicesRepository.UpdateInvoice(invoice);
        }
    }
}

