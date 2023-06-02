using Microsoft.EntityFrameworkCore;
using System;
using TestEmployees.Interfaces;
using TestEmployees.Models;

namespace TestEmployees.Services
{
    public class TestGetEmployees : IGetEmployees
    {
        public async Task<IResult> GetEmployees(DataEmployee data, ApplicationContext db)
        {
            IQueryable<Employee> IQueryEmployees = db.Employees.AsNoTracking();

            if (data.Name != null) IQueryEmployees = IQueryEmployees.Where(e => e.Name == data.Name);
            
            if (data.Position != null) IQueryEmployees = IQueryEmployees.Where(e => e.Position == data.Position);

            var employees = await IQueryEmployees.ToListAsync();
            return Results.Json(employees);
        }

        public async Task<IResult> GetOneEmployee(int id, ApplicationContext db)
        {
            Employee? employee = await db.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null) return Results.NotFound(new { message = "Работник не найден" });

            return Results.Json(employee);
        }
    }
}
