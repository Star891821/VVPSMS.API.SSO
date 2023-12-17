﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMS.API.Controllers.MasterControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserPermissionsController : Controller
    {
        IGenericService<MstPermissionDto> GenericService;
     //   private ILog _logger;

        public UserPermissionsController(IGenericService<MstPermissionDto> genericService)
        {
            GenericService = genericService;
          //  _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public IActionResult? GetAll()
        {
            try
            {
       //         _logger.Information($"GetAll API Started");

                return Ok(GenericService.GetAll());
            }
            catch (Exception ex)
            {
         //       _logger.Error($"Something went wrong inside GetAll API for" + typeof(UserPermissionsController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
           //     _logger.Information($"GetAll API Completed");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult? GetById(int id)
        {
            try
            {
             //   _logger.Information($"GetById API Started");
                return Ok(GenericService.GetById(id));
            }
            catch (Exception ex)
            {
               // _logger.Error($"Something went wrong inside GetById API for" + typeof(UserPermissionsController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                //_logger.Information($"GetById API Completed");
            }
        }


        [HttpPost, ActionName("InsertOrUpdate")]
        [Authorize]
        public IActionResult Post([FromBody] MstPermissionDto value)
        {
            try
            {
                //_logger.Information($"InsertOrUpdate API Started");
                return Ok(GenericService.InsertOrUpdate(value));
            }
            catch (Exception ex)
            {
                //_logger.Error($"Something went wrong inside InsertOrUpdate API for" + typeof(UserPermissionsController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                //_logger.Information($"InsertOrUpdate API Completed");
            }
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                //_logger.Information($"Delete API Started");
                return Ok(GenericService.Delete(id));
            }
            catch (Exception ex)
            {
                //_logger.Error($"Something went wrong inside Delete API for" + typeof(UserPermissionsController).FullName + "entity with exception" + ex.Message);
                return StatusCode(500);
            }
            finally
            {
                //_logger.Information($"Delete API Completed");
            }
        }

    }
}
