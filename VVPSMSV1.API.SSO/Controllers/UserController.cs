using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.DataManagers;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private IConfiguration _configuration;
        IUserRoleService<MstUserRoleDto> userRolesService;
        IUserService<MstUserDto> userService;
        public UserController(IUserService<MstUserDto> genericService, IUserRoleService<MstUserRoleDto> userRoleService,  IConfiguration configuration)
        {
            userService = genericService;
            _configuration = configuration;
            userRolesService = userRoleService;
        }
        [HttpGet("{name}")]
        [AllowAnonymous]
        public string CheckUserNameExists(string name)
        {
            string checkExits = string.Empty;
            try
            {
                var item = userService.GetByName(name);
                if (item != null)
                {
                    checkExits = "taken";
                }
                else
                {
                    checkExits = "not_taken";
                }
            }
            catch (Exception ex)
            {
               
            }
            return checkExits;
        }
        [HttpGet("{name}")]
        [AllowAnonymous]
        public IActionResult? GetUserByName(string name)
        {
            var statusCode = StatusCodes.Status200OK;
            object? value = null;
            try
            {
               var item = userService.GetByName(name);
                if (item == null)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    value = "UserByName data is not found";
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


        [HttpPost]
        public IActionResult EncryptPassword(string clearText)
        {
            var encryptionKey = _configuration["PassPhrase:Key"];
            StringEncryptionService a = new StringEncryptionService();
            var result = a.EncryptAsync(clearText, encryptionKey);
            return Ok(result.Result);
        }

        [HttpPost]
        public IActionResult DecryptPassword(string cipherText)
        {
            var encryptionKey = _configuration["PassPhrase:Key"];
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            StringEncryptionService a = new StringEncryptionService();
            var result = a.DecryptAsync(cipherBytes, encryptionKey);
            return Ok(result.Result);
        }

        [HttpGet]
        public  List<MstUserDto> GetAll()
        {
            try
            {
                var results = userService.GetAll();
                foreach (var result in results)
                {
                    result.RoleName = userRolesService.GetById(result.RoleId).RoleName;
                }
           
             return results;
              
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public MstUserDto GetById(int id)
        {
            try
            {
                return userService.GetById(id);
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpPost, ActionName("InsertOrUpdate")]
        [AllowAnonymous]
        public MstUserDto Post([FromBody] MstUserDto values)
        {
            try
            {
                return userService.InsertOrUpdate(values);
               
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
                var item = userService.Delete(id);
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
