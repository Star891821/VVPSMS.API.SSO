using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.DataManagers;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMSV1.API.SSO.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicantController : Controller
    {
        private IConfiguration _configuration;
        IApplicantService<ApplicantDto> applicantService;
        public ApplicantController(IApplicantService<ApplicantDto> genericService, IConfiguration configuration)
        {
            applicantService = genericService;
            _configuration = configuration;
        }
        [HttpGet]
        public List<ApplicantDto> GetAll()
        {
            try
            {
                return applicantService.GetAll();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ApplicantDto GetById(int id)
        {
            try
            {
                return applicantService.GetById(id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost, ActionName("InsertOrUpdate1")]
        [AllowAnonymous]
        public LoginResponseDto InsertOrUpdateWithResponse([FromBody] LoginRequestDto request)
        {
            try
            {
                var applicantdata = new ApplicantDto()
                {
                    ApplicantId = request.Id,
                    Applicantname = request.name,
                    RoleId =request.RoleId,
                    Applicantemail = request.email,
                    ApplicantLoginType = request.UserType,
                    ApplicantGivenName = "",
                    Applicantpassword = request.Password,
                    ApplicantPhone = request.Phone,
                    ApplicantSurname = "",
                    Enforce2Fa = request.Enforce2Fa
                };

                var data = applicantService.InsertOrUpdate(applicantdata);
                if(data != null)
                {
                    return new LoginResponseDto()
                    {
                        Id = data.ApplicantId,
                        email = data.Applicantemail,
                        UserName = data.Applicantname,
                        Role = "Admin",
                        Status = true
                    };

                }
                else
                {
                    return new LoginResponseDto()
                    {
                        Id = 0,
                        email = "",
                        UserName = "",
                        Role = "",
                        Status = false
                    };
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public bool CheckIfExists(int id)
        {
            try
            {
                if (applicantService.GetById(id) != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        [HttpPost, ActionName("InsertOrUpdate")]
        [AllowAnonymous]
        public ApplicantDto Post([FromBody] ApplicantDto values)
        {
            try
            {
                return applicantService.InsertOrUpdate(values);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
                var item = applicantService.Delete(id);
                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "Delete data is not found";
                }
                else
                {
                    value = item;
                }
            }
            catch (Exception ex)
            {
                statusCode = StatusCodes.Status500InternalServerError;
                value = ex.Message;
            }
            return StatusCode(statusCode, value);
        }

    }
}
