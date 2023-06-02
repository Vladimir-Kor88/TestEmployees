using TestEmployees.Models;

namespace TestEmployees.Interfaces
{
    public interface IUpdateEmployee
    {
        Task<IResult> UpdateEmployee(DataEmployee data, ApplicationContext db);
    }
}
