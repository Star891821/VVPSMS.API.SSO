using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VVPSMS.Service.Repository;
using VVPSMSV1.API.SSO.Common;
using VVPSMSV1.API.SSO.Models.ModelsDto;

namespace VVPSMSV1.API.SSO.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly ILoginService _dataRepository;
        private IConfiguration _configuration;
        public AuthenticationController(ILoginService dataRepository, IConfiguration configuration)
        {
            _dataRepository = dataRepository;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost, ActionName("AuthenticateUsers")]
        // [Microsoft.AspNetCore.Mvc.HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateUsers(LoginRequestSSO loginRequest)
        {
           // IActionResult response = Unauthorized();
            if (loginRequest != null)
            {
                if (loginRequest.UserType.ToUpper() == "APPLICANT")
                {
                    loginRequest.UserName = CommonMethods.EncryptPassword(_configuration["PassPhrase:Key"], loginRequest.UserName);
                    loginRequest.Password = CommonMethods.EncryptPassword(_configuration["PassPhrase:Key"], loginRequest.Password);
                }
                var loginResponse = await _dataRepository.LoginDetails(loginRequest);
                if (loginResponse != null && loginResponse.LoginStatus == "Success")
                {
                    if (loginRequest.UserType.ToUpper() == "APPLICANT")
                    {
                        loginResponse.UserName = CommonMethods.DecryptPassword(_configuration["PassPhrase:Key"], loginResponse.UserName);
                        loginResponse.Email = CommonMethods.DecryptPassword(_configuration["PassPhrase:Key"], loginResponse.Email);

                    }
                    return Ok(loginResponse);
                }
                else
                {
                    ErrorResponse error = new ErrorResponse()
                    {
                        StatusCode = Unauthorized().StatusCode.ToString(),
                        Message = "Failure"
                    };
                    return Ok(error);
                }
            }
            return BadRequest();
          //  return response;
        }
    }
}
