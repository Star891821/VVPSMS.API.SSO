using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRolePermissionMappingController : Controller
    {
        IGenericService<RolePermissionsMappingDto> GenericService;

        public UserRolePermissionMappingController(IGenericService<RolePermissionsMappingDto> genericService)
        {
            GenericService = genericService;
        }

        [HttpGet]
        public IActionResult? GetAll()
        {
            try
            {

                return Ok(GenericService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("{id}")]
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
        public IActionResult Post([FromBody] RolePermissionsMappingDto value)
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
