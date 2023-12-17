namespace VVPSMSV1.API.SSO.Service.Interfaces
{
    public interface IUserService<T>:IGenericService<T>
    {
        T? GetByName(string name);
    }
}
