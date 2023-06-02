using TestEmployees.Models;

namespace TestEmployees.Interfaces
{
    public interface IGetEmployees
    {
        Task<IResult> GetEmployees(DataEmployee data, ApplicationContext db);

        Task<IResult> GetOneEmployee(int id, ApplicationContext db);
    }
}
