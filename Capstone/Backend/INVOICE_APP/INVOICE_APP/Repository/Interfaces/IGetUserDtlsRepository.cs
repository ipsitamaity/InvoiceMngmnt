using INVOICE_APP.Models;

namespace INVOICE_APP.Repository.Interfaces
{
    public interface IGetUserDtlsRepository
    {
        public Users GetUserDtls(string username);
    }
}
