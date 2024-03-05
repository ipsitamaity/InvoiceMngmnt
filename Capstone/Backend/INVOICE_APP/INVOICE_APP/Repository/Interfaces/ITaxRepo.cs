using INVOICE_APP.Models;
using Microsoft.AspNetCore.Mvc;

namespace INVOICE_APP.Repository.Interfaces
{
    public interface ITaxRepo
    {
        decimal CalculateTax(decimal amount, string taxType);
       // decimal CalculateAmountToPay(decimal amount, decimal taxAmount);
    }
}
