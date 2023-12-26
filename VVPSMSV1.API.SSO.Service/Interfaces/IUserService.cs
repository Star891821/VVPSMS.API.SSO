namespace VVPSMSV1.API.SSO.Service.Interfaces
{
    public interface IUserService<T>:IGenericService<T>
    {
        T InsertOrUpdate(T entity);
        T? GetByName(string name);
    }
}
