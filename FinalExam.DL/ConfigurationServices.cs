using FinalExam.Core.Models;
using FinalExam.DL.Repository.Abstractions;
using FinalExam.DL.Repository.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace FinalExam.DL;

public static class ConfigurationServices
{
    public static void AddDLServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Profession>, Repository<Profession>>();
        services.AddScoped<IRepository<Customer>, Repository<Customer>>();
    }
}
