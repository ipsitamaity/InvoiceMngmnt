using INVOICE_APP.Models;

namespace INVOICE_APP.Repository.Interfaces
{
    public interface IInvoiceItems
    {
        IEnumerable<InvoiceItem> GetAllInvoiceItems(int invoiceID);
    }
}
