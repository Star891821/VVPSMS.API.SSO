
namespace VVPSMSV1.API.SSO.Service.Interfaces
{
    public interface IGoogleSSOService<T>
    {
        T? GetByDomain(string domainName);
    }
}
