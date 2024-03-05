using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using INVOICE_APP.Repository.Interfaces;
using INVOICE_APP.Repository;
using INVOICE_APP.Services.Interfaces;
using INVOICE_APP.Services;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IInvoices, InvoicesRepo>();
builder.Services.AddScoped<IInvoiceItems, InvoiceItemsRepo>();
builder.Services.AddScoped<ITaxRepo, TaxRepo>();
builder.Services.AddScoped<ICurrencyRepo, CurrencyRepo>();


builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInvoiceItemService, InvoiceItemService>();
builder.Services.AddScoped<ITaxService, TaxService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var app = builder.Build();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
