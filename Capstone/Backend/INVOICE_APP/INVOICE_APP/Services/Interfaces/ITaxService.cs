namespace INVOICE_APP.Services.Interfaces
{
    public interface ITaxService
    {
        decimal CalculateTax(decimal amount, string TaxName);
        //decimal CalculateAmountToPay(decimal amount, decimal taxAmount);
    }
}
