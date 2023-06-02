using TestEmployees.Interfaces;
using TestEmployees.Models;

namespace TestEmployees.Services
{
    public class TestCreateEmployee : ICreateEmployee
    {
        public async Task<IResult> CreateEmployee(Employee employee, ApplicationContext db)
        {
            try
            {
                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unique"))
                    return Results.BadRequest(new { message = "Такой сотрудник уже есть" });
            }

            return Results.Json(employee);
        }
    }
}
