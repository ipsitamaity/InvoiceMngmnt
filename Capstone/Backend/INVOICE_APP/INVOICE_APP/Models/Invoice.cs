using INVOICE_APP.Repository.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace INVOICE_APP.Models
{
    public class Invoice
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
        public List<InvoiceItem> InvoiceItems {get; set;}
     }
    public class InvoiceItem
    {
        public int ItemID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int TaxID { get; set; }
        public decimal Discount { get; set; }
        public decimal LineTotal { get; set; }
        
        public Product Product { get; set; }
       public Tax Tax { get; set; }
    }
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
    public class Tax
    {
        public int TaxID { get; set; }
        public string TaxName { get; set; }
        public decimal Rate { get; set; }
    }
    public class Currencies 
    { 
        public int CurrencyID { get; set;}
        public string CurrencyName { get; set; }
        public decimal ExchangeRate { get; set; }
    }
    public class Customers
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
    }
    public class Vendors
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string Address { get; set; }
    }
}
