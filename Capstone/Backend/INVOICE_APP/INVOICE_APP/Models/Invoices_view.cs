using INVOICE_APP.Repository.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
namespace INVOICE_APP.Models
{
    public class Invoices_view
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public int VendorID { get; set; }
        public int CustomerID { get; set; }
        public decimal TotalAmount { get; set; }
        public int CurrencyID { get; set; }
        //public Vendors Vendor { get; set; }
        //public Customers Customer { get; set; }
        //public Currencies Currency { get; set; }
    }
}
