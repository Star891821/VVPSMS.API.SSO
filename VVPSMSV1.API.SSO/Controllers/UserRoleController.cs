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
        IGenericService<MstUserRoleDto> GenericService;
        public UserRoleController(IGenericService<MstUserRoleDto> genericService)
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
        public IActionResult? GetById(int id)
        {
            try
            {
                return Ok(GenericService.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }


        [HttpPost, ActionName("InsertOrUpdate")]
        [AllowAnonymous]
        public IActionResult Post([FromBody] MstUserRoleDto value)
        {
            try
            {
                return Ok(GenericService.InsertOrUpdate(value));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
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
