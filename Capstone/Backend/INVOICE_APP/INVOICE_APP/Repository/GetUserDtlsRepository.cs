using INVOICE_APP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using INVOICE_APP.Repository.Interfaces;
namespace INVOICE_APP.Repository
{
    public class GetUserDtlsRepository : IGetUserDtlsRepository
    {
        private readonly string _connectionString;
        public GetUserDtlsRepository(string connectionString)
        {
            _connectionString = "Data Source=APINP-ELPTIC7ZC\\SQLEXPRESS;Initial Catalog=INVOICE;User ID=tap2023;Password=tap2023;Encrypt=False";
        }
        public Users GetUserDtls(string username)
        {
            Users user =new Users();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Users WHERE UserName = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user.UserID = Convert.ToInt32(reader["UserID"]);
                        user.UserName = Convert.ToString(reader["UserName"]);
                        user.Password = Convert.ToString(reader["Password"]);
                        user.Role = Convert.ToString(reader["Role"]);
                    };
                }
            }
            return user;
        }
    }
}
