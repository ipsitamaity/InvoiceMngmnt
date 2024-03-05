using INVOICE_APP.Models;
using INVOICE_APP.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
namespace INVOICE_APP.Repository
{
    public class InvoicesRepo : IInvoices
    {
        private readonly string _connectionString;
        private readonly Random _random;
        public InvoicesRepo()
        {
         _connectionString = "Data Source=APINP-ELPTIC7ZC\\SQLEXPRESS;Initial Catalog=INVOICE;User ID=tap2023;Password=tap2023;Encrypt=False";

        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Invoices";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Invoice invoice = new Invoice
                        {
                            InvoiceID = Convert.ToInt32(reader["InvoiceId"]),
                            InvoiceNumber = Convert.ToString(reader["InvoiceNumber"]),
                            InvoiceDate = Convert.ToString(reader["InvoiceDate"]),
                            //InvoiceDate= DateOnly.FromDateTime((DateTime)reader["InvoiceDate"]),
                            VendorID = Convert.ToInt32(reader["VendorId"]),
                            CustomerID = Convert.ToInt32(reader["CustomerId"]),
                            TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                            CurrencyID = Convert.ToInt32(reader["CurrencyId"])
                        };
                        invoices.Add(invoice);
                    }
                }
            }
            return invoices;
        }
        public void AddInvoice(Invoices_view invoice)
        {
           
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Invoices_view (InvoiceID, InvoiceNumber, InvoiceDate, VendorID, CustomerID, TotalAmount, CurrencyID) " +
                               "VALUES (@InvoiceID, @InvoiceNumber, @InvoiceDate, @VendorID, @CustomerID, @TotalAmount, @CurrencyID)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InvoiceID", invoice.InvoiceID);
                    //command.Parameters.AddWithValue("@InvoiceID", 1000);
                    command.Parameters.AddWithValue("@InvoiceNumber", invoice.InvoiceNumber);
                    command.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate);
                    command.Parameters.AddWithValue("@VendorId", invoice.VendorID);
                    command.Parameters.AddWithValue("@CustomerId", invoice.CustomerID);
                    command.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                    command.Parameters.AddWithValue("@CurrencyId", invoice.CurrencyID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateInvoice(Invoices_view invoice)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Invoices SET InvoiceNumber = @InvoiceNumber, TotalAmount = @TotalAmount, InvoiceDate = @InvoiceDate, VendorId = @VendorID, CustomerId = @CustomerID, CurrencyId = @CurrencyID WHERE InvoiceID = @InvoiceID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InvoiceID", invoice.InvoiceID);
                    command.Parameters.AddWithValue("@InvoiceNumber", invoice.InvoiceNumber);
                    command.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate);
                    command.Parameters.AddWithValue("@VendorId", invoice.VendorID);
                    command.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                    command.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                    command.Parameters.AddWithValue("@CurrencyID", invoice.CurrencyID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    
                }
            }
        }
    }
}
