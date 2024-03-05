using System;
using System.Data;
using System.Data.SqlClient;
using INVOICE_APP.Models;
using INVOICE_APP.Repository.Interfaces;

namespace INVOICE_APP.Repository
{
    public class TaxRepo : ITaxRepo
    {
        private readonly string _connectionString;

        public TaxRepo()
        {
            _connectionString = "Data Source=APINP-ELPTIC7ZC\\SQLEXPRESS;Initial Catalog=INVOICE;User ID=tap2023;Password=tap2023;Encrypt=False"; 
        }

        public decimal CalculateTax(decimal amount, string taxType)
        {
            decimal rate = 0;
            Console.WriteLine(amount);
            Console.WriteLine(taxType);


            using (SqlConnection connection = new SqlConnection(_connectionString))
                

            {
                string query = "SELECT Rate FROM Taxes WHERE TaxName = @TaxType";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaxType", taxType);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("end");

                    if (reader.Read())
                    {
                        rate = Convert.ToDecimal(reader["Rate"]);
                    }
                }
            }

            decimal taxAmount = amount * (rate / 100);
            decimal AmounttoPay = amount + taxAmount;
            Console.WriteLine(rate);
            return AmounttoPay;
        }

       // public decimal CalculateAmountToPay(decimal amount, decimal taxAmount)
       // {
            //decimal amountToPay = amount + taxAmount;
            //return amountToPay;
       // }
    }
}
