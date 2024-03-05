using INVOICE_APP.Models;
using Microsoft.AspNetCore.Mvc;

namespace INVOICE_APP.Repository.Interfaces
{
    public interface IInvoices
    {
        IEnumerable<Invoice> GetAllInvoices();
        public void AddInvoice(Invoices_view invoice);
        void UpdateInvoice(Invoices_view invoice);
    }
}
