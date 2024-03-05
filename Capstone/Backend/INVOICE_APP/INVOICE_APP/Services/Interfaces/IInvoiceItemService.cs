using INVOICE_APP.Models;

namespace INVOICE_APP.Services.Interfaces
{
    public interface IInvoiceItemService
    {
        IEnumerable<InvoiceItem> GetAllInvoiceItems();
    }
}
