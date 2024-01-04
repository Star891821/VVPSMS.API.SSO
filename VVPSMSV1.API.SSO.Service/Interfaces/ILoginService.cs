using VVPSMSV1.API.SSO.Models.ModelsDto;

namespace VVPSMS.Service.Repository
{
    public interface ILoginService
    {
        Task<LoginResponseSSO> LoginDetails(LoginRequestSSO loginRequest);
      
    }
}
