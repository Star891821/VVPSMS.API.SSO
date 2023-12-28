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
        IUserRoleType<MstRoleTypeDto> UserRoleTypeService;
        public UserRoleController(IUserRoleService<MstUserRoleDto> genericService, IUserRoleType<MstRoleTypeDto> userRoleType)
        {
            GenericService = genericService;
            UserRoleTypeService = userRoleType;
        }

        [HttpGet]
        [AllowAnonymous]
        public List<MstUserRoleDto> GetAll()
        {
            try
            {
                var results =  GenericService.GetAll();
                foreach(var result in results)
                {
                    result.RoletypeName = UserRoleTypeService.GetById(result.RoletypeId).RoletypeName;
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
