
namespace VVPSMSV1.API.SSO.Service.Interfaces
{
    public interface IMicroSoftSSOService<T>
    {
        T? GetByDomain(string domainName);
    }
}
