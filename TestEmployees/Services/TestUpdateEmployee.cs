using Microsoft.EntityFrameworkCore;
using TestEmployees.Interfaces;
using TestEmployees.Models;

namespace TestEmployees.Services
{
    public class TestUpdateEmployee : IUpdateEmployee
    {
        public async Task<IResult> UpdateEmployee(DataEmployee data, ApplicationContext db)
        {
            if (data.Id == null || data.Name == null ) 
                return Results.BadRequest(new { message = "Некорректный запрос" });

            Employee? employee = await db.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == data.Id);

            if (employee == null) return Results.NotFound(new { message = "Работник не найден" });

            employee.Name = data.Name;
            employee.Position = data.Position;

            try
            {
                db.Employees.Update(employee);
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
