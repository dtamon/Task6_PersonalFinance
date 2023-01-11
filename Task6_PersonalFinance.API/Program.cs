using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task6_PersonalFinance.Core.Middleware;
using Task6_PersonalFinance.Core.Seeder;
using Task6_PersonalFinance.Core.Services.Interfaces;
using Task6_PersonalFinance.Core.Services.Services;
using Task6_PersonalFinance.Core.Validators;
using Task6_PersonalFinance.DataAccess.Context;
using Task6_PersonalFinance.DataAccess.Entities;
using Task6_PersonalFinance.DataAccess.Repositories.Interfaces;
using Task6_PersonalFinance.DataAccess.Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context
builder.Services.AddDbContext<FinancesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

//Repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IIncomeCategoryRepository, IncomeCategoryRepository>();
builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
builder.Services.AddScoped<IExpenseCategoryRepository, ExpenseCategoryRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();

//Services 
builder.Services.AddScoped<IAccountService, AccountService>();

//Middleware
builder.Services.AddScoped<ErrorHandlingMiddleware>();

//Password Hasher
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

//Validators
builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();

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
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();
app.UseHttpsRedirection();

//enable CORS
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
