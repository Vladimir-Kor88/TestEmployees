using TestEmployees.Models;

namespace TestEmployees.Interfaces
{
    public interface ICreateEmployee
    {
        Task<IResult> CreateEmployee(Employee employee, ApplicationContext db);
    }
}
