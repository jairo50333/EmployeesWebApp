using EmployesWebApp.Repository;
using EmployesWebApp.Repository.Implements;
using EmployesWebApp.Services;
using EmployesWebApp.Services.Implements;

namespace EmployesWebApp.Midleware
{
    public static class IoC
    {
        public static IServiceCollection addDependency(this IServiceCollection services)
        {
            //services
            services.AddScoped<IEmployeeService, EmployeeService>();

            //Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();



            return services;
        }
    }
}
