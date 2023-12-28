using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMSV1.API.SSO.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRoleTypeController : Controller
    {
        IUserRoleType<MstRoleTypeDto> GenericService;
        public UserRoleTypeController(IUserRoleType<MstRoleTypeDto> genericService)
        {
            GenericService = genericService;
        }

        [HttpGet]
        [AllowAnonymous]
        public List<MstRoleTypeDto> GetAll()
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
        public MstRoleTypeDto GetById(int id)
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
        public MstRoleTypeDto Post([FromBody] MstRoleTypeDto value)
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
