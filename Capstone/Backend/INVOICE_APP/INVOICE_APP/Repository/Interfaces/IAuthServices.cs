using INVOICE_APP.Models;

namespace INVOICE_APP.Repository.Interfaces
{
    public interface IAuthServices
    {
        public  Users Authenticate(string username, string password);
        public string GenerateToken(Users user);
    }
}
