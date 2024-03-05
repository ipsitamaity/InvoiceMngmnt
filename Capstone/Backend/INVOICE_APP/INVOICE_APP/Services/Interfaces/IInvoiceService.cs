using INVOICE_APP.Models;
using System.Collections.Generic;

namespace INVOICE_APP.Services.Interfaces
{
    public interface IInvoiceService
    {
        IEnumerable<Invoice> GetAllInvoices();
        void AddInvoice(Invoices_view invoice);
        void UpdateInvoice(Invoices_view invoice);

    }
}
