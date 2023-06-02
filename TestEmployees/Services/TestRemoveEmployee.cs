using Microsoft.EntityFrameworkCore;
using TestEmployees.Interfaces;
using TestEmployees.Models;

namespace TestEmployees.Services
{
    public class TestRemoveEmployee : IRemoveEmployee
    {
        public async Task<IResult> RemoveEmployee(int id, ApplicationContext db)
        {
            Employee? employee = await db.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null) return Results.NotFound(new { message = "Работник не найден" });

            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return Results.Json(new { message = "Работник удалён" });
        }
    }
}
