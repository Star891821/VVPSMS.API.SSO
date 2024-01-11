using Microsoft.EntityFrameworkCore;
using VVPSMS.Service.Repository;
using VVPSMSV1.API.SSO.Domain.Models;
using VVPSMSV1.API.SSO.Models.ModelsDto;

namespace VVPSMS.Service.DataManagers
{
    public class LoginService : ILoginService
    {
        readonly VvpsmsSsoContext _vvpsmsdbContext;
        public LoginService()
        {
            _vvpsmsdbContext = new VvpsmsSsoContext();
        }

        public async Task<LoginResponseSSO> LoginDetails(LoginRequestSSO loginRequest)
        {
            LoginResponseSSO loginResponseDto = null;
            try
            {
                var userrole = await _vvpsmsdbContext.MstUserRoles.FirstOrDefaultAsync(x => x.RoleName == loginRequest.UserType);
                switch (loginRequest.UserType.ToUpper())
                {
                    case "APPLICANT":
                        var applicant = await _vvpsmsdbContext.Applicants.FirstOrDefaultAsync(x => x.Applicantname == loginRequest.UserName && x.Applicantpassword == loginRequest.Password);
                        if (applicant != null)
                        {
                            loginResponseDto = new LoginResponseSSO()
                            {
                                UserName = applicant.Applicantname,
                                Email = applicant.Applicantemail,
                                Id = applicant.ApplicantId,
                                LoginStatus = "Success"
                            };
                        }
                        else
                        {
                            loginResponseDto = new LoginResponseSSO()
                            {
                                LoginStatus = "Failure"
                            };
                        }
                        break;
                    default:
                        var user = await _vvpsmsdbContext.MstUsers.FirstOrDefaultAsync(x => x.Username == loginRequest.UserName
                        && x.Userpassword == loginRequest.Password && x.RoleId == userrole.RoleId);
                        if (user != null)
                        {
                            loginResponseDto = new LoginResponseSSO()
                            {
                                UserName = user.Username,
                                Email = user.Useremail,
                                Id = user.UserId,
                                LoginStatus = "Success"
                            };
                        }
                        else
                        {
                            loginResponseDto = new LoginResponseSSO()
                            {
                                LoginStatus = "Failure"
                            };
                        }
                        break;
                }
            }
            catch (Exception ex)
            {

            }
            return loginResponseDto;
        }

    }
}
