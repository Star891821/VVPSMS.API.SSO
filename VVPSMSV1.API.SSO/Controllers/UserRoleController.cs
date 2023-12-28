using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserRoleController : ControllerBase 
    {
        IUserRoleService<MstUserRoleDto> GenericService;
        public UserRoleController(IUserRoleService<MstUserRoleDto> genericService)
        {
            GenericService = genericService;
        }

        [HttpGet]
        [AllowAnonymous]
        public List<MstUserRoleDto> GetAll()
        {
            try
            {
                return GenericService.GetAll();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public MstUserRoleDto GetById(int id)
        {
            try
            {
                return GenericService.GetById(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public string CheckRoleNameExists(string name)
        {
            string checkExits = string.Empty;
            try
            {
                var item = GenericService.GetByName(name);
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

        [HttpPost, ActionName("InsertOrUpdate")]
        [AllowAnonymous]
        public MstUserRoleDto Post([FromBody] MstUserRoleDto value)
        {
            try
            {
                return GenericService.InsertOrUpdateWithResponse(value);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(GenericService.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }
}
