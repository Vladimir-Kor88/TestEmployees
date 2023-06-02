using Microsoft.EntityFrameworkCore;
using TestEmployees;
using TestEmployees.Interfaces;
using TestEmployees.Models;

var builder = WebApplication.CreateBuilder();
string connection = "Server=(localdb)\\mssqllocaldb;Database=applicationdb;Trusted_Connection=True;";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection))
                .AddTestCreateEmployeeService()
                .AddTestGetEmployeesService()
                .AddTestRemoveEmployeeService()
                .AddTestUpdateEmployeeService();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/employees", async (IGetEmployees getEmployees, DataEmployee data, ApplicationContext db) =>
{
    return await getEmployees.GetEmployees(data, db);
});

app.MapGet("api/employees/{id}", async (int id, IGetEmployees getEmployees, ApplicationContext db) =>
{
    return await getEmployees.GetOneEmployee(id, db);
});

app.MapPost("api/employee", async (ICreateEmployee createEmployee, Employee employee, ApplicationContext db) =>
{
    return await createEmployee.CreateEmployee(employee, db);
});

app.MapPut("api/update", async (IUpdateEmployee updateEmployee, DataEmployee data, ApplicationContext db) =>
{
    return await updateEmployee.UpdateEmployee(data, db);
});

app.MapDelete("api/employees/{id}", async (int id, IRemoveEmployee removeEmployee, ApplicationContext db) =>
{
    return await removeEmployee.RemoveEmployee(id, db);
});

app.Run();
