namespace TestEmployees.Interfaces
{
    public interface IRemoveEmployee
    {
        Task<IResult> RemoveEmployee(int id, ApplicationContext db);
    }
}
