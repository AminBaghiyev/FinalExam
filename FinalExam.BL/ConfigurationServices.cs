using FinalExam.BL.Services.Abstractions;
using FinalExam.BL.Services.Concretes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FinalExam.BL;

public static class ConfigurationServices
{
    public static void AddBLServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();

        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IProfessionService, ProfessionService>();
        services.AddScoped<ICustomerService, CustomerService>();
    }
}
