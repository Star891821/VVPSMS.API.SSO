using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.DataManagers;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserPermissionsController : Controller
    {
        IUserPermissionService<MstPermissionDto> GenericService;
        public UserPermissionsController(IUserPermissionService<MstPermissionDto> genericService)
        {
            GenericService = genericService;
        }

        [HttpGet]
        public List<MstPermissionDto> GetAll()
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
        public MstPermissionDto GetById(int id)
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
        public string CheckPermissionNameExists(string name)
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
        public MstPermissionDto Post([FromBody] MstPermissionDto value)
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
        public bool Delete(int id)
        {
            try
            {
                return GenericService.Delete(id);
            }
            catch (Exception ex)
            {

            }
            return false;
        }

    }
}
