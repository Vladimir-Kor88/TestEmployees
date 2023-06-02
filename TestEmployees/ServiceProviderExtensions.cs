using TestEmployees.Interfaces;
using TestEmployees.Services;

namespace TestEmployees
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddTestCreateEmployeeService(this IServiceCollection services)
        {
            return services.AddTransient<ICreateEmployee, TestCreateEmployee>();
        }

        public static IServiceCollection AddTestGetEmployeesService(this IServiceCollection services)
        {
            return services.AddTransient<IGetEmployees, TestGetEmployees>();
        }

        public static IServiceCollection AddTestRemoveEmployeeService(this IServiceCollection services)
        {
            return services.AddTransient<IRemoveEmployee, TestRemoveEmployee>();
        }

        public static IServiceCollection AddTestUpdateEmployeeService(this IServiceCollection services)
        {
            return services.AddTransient<IUpdateEmployee, TestUpdateEmployee>();
        }
    }
}
