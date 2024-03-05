using INVOICE_APP.Models;
using INVOICE_APP.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace INVOICE_APP.Repository
{
    public class InvoiceItemsRepo : IInvoiceItems
    {
        private readonly string _connectionString;
        public InvoiceItemsRepo()
        {
            _connectionString = "Data Source=APINP-ELPTIC7ZC\\SQLEXPRESS;Initial Catalog=INVOICE;User ID=tap2023;Password=tap2023;Encrypt=False";
        }

        public IEnumerable<InvoiceItem> GetAllInvoiceItems(int invoiceID)
        {
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM InvoiceItems WHERE InvoiceId=@InvoiceID";
                using (SqlCommand command = new SqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@InvoiceID",invoiceID);
                
                
                
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        InvoiceItem invoiceItem = new InvoiceItem
                        {
                            ItemID = Convert.ToInt32(reader["ItemId"]),
                            InvoiceID = Convert.ToInt32(reader["InvoiceId"]),
                            ProductID = Convert.ToInt32(reader["ProductId"]),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                            TaxID = Convert.ToInt32(reader["TaxId"]),
                            Discount = Convert.ToDecimal(reader["Discount"]),
                            LineTotal = Convert.ToDecimal(reader["LineTotal"])
                        };
                        invoiceItems.Add(invoiceItem);
                    }
                }
            }
            return invoiceItems;
        }

    }
}
