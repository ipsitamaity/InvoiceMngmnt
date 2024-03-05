namespace INVOICE_APP.Services.Interfaces
{
    public interface ICurrencyService
    {
        decimal CurrConvCalc(decimal amount, string currency, string newCurrency);
    }
}
