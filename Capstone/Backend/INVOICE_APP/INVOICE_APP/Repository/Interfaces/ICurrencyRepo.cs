namespace INVOICE_APP.Repository.Interfaces
{
    public interface ICurrencyRepo
    {
        decimal CurrConvCalc(decimal amount, string currencyName);
    }
}
