namespace VVPSMSV1.API.SSO.Service.Interfaces
{
    public interface IGenericService<T>
    {
        List<T>? GetAll();
        T? GetById(int id);  
        bool InsertOrUpdate(T entity);
        bool Delete(int id);

    }
}
