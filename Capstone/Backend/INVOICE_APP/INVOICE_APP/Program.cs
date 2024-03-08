using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using INVOICE_APP.Repository.Interfaces;
using INVOICE_APP.Repository;
using INVOICE_APP.Services.Interfaces;
using INVOICE_APP.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt: Issuer"],
            ValidAudience = builder.Configuration["Jwt: Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };


    });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IInvoices, InvoicesRepo>();
builder.Services.AddScoped<IInvoiceItems, InvoiceItemsRepo>();
builder.Services.AddScoped<ITaxRepo, TaxRepo>();
builder.Services.AddScoped<ICurrencyRepo, CurrencyRepo>();

//builder.Services.AddScoped<IAuthServices, AuthServicesRepo>();
//builder.Services.AddScoped<IGetUserDtlsRepository, GetUserDtlsRepository>();

builder.Services.AddScoped<IAuthServices>(provider => new AuthServicesRepo("secretKey", "issuer", "audience", 10)); 

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
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
