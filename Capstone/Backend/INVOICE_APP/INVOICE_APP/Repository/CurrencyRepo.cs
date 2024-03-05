using System.Data;
using System.Data.SqlClient;
using INVOICE_APP.Models;
using INVOICE_APP.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class CurrencyRepo : ICurrencyRepo
{
    private readonly string _connectionString;

    public CurrencyRepo(IConfiguration configuration)
    {
        _connectionString = "Data Source=APINP-ELPTIC7ZC\\SQLEXPRESS;Initial Catalog=INVOICE;User ID=tap2023;Password=tap2023;Encrypt=False"; 
    }

    public decimal CurrConvCalc(decimal amount,string currencyName)
    {
        decimal convAmount;
        string query = "SELECT ExchangeRate FROM Currencies WHERE CurrencyName = @CurrencyName";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CurrencyName", currencyName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        convAmount = amount * reader.GetDecimal(0);
                        return (convAmount);
                    }

                    // Handle invalid currency code
                    throw new ArgumentException("Invalid currency code.");
                }
            }
        }
    }
}
