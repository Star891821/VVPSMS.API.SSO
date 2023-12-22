
namespace VVPSMSV1.API.SSO.Service.Interfaces
{
    public interface IAzureSSOService<T>
    {
        T? GetByDomain(string domainName);
    }
}
