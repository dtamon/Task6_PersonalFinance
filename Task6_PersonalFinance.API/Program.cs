using Microsoft.EntityFrameworkCore;
using Task6_PersonalFinance.Core.Seeder;
using Task6_PersonalFinance.DataAccess.Context;
using Task6_PersonalFinance.DataAccess.Repositories.Interfaces;
using Task6_PersonalFinance.DataAccess.Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context
builder.Services.AddDbContext<FinancesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

//Repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IIncomeCategoryRepository, IncomeCategoryRepository>();
builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
builder.Services.AddScoped<IOutcomeCategoryRepository, OutcomeCategoryRepository>();
builder.Services.AddScoped<IOutcomeRepository, OutcomeRepository>();

//Data Seeder
builder.Services.AddScoped<DataSeeder>();

var app = builder.Build();

app.Services.CreateScope().ServiceProvider.GetRequiredService<DataSeeder>();/*.Seed();*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseHttpsRedirection();

//enable CORS
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
