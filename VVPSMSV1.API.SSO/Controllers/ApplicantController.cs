﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using VVPSMSV1.API.SSO.Common;
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
        IUserRoleService<MstUserRoleDto> userRolesService;
        public ApplicantController(IApplicantService<ApplicantDto> genericService, IUserRoleService<MstUserRoleDto> userRoleService, IConfiguration configuration)
        {
            applicantService = genericService;
            _configuration = configuration;
            userRolesService = userRoleService;
        }
        [HttpGet]
        public List<ApplicantDto> GetAll()
        {
            try
            {
                var results =  applicantService.GetAll();
                foreach(var result in results)
                {
                    result.Applicantpassword = CommonMethods.DecryptPassword(_configuration["PassPhrase:Key"], result.Applicantpassword);
                    result.Applicantname = CommonMethods.DecryptPassword(_configuration["PassPhrase:Key"], result.Applicantname);
                    result.Applicantemail = CommonMethods.DecryptPassword(_configuration["PassPhrase:Key"], result.Applicantemail);
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
        public ApplicantDto GetById(int id)
        {
            try
            {
                var result =  applicantService.GetById(id);
                result.Applicantpassword = CommonMethods.DecryptPassword(_configuration["PassPhrase:Key"], result.Applicantpassword);
                result.Applicantname = CommonMethods.DecryptPassword(_configuration["PassPhrase:Key"], result.Applicantname);
                result.Applicantemail = CommonMethods.DecryptPassword(_configuration["PassPhrase:Key"], result.Applicantemail);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("{name}")]
        [AllowAnonymous]
        public string CheckApplicantNameExists(string name)
        {
            string checkExits = string.Empty;
            try
            {
                name = CommonMethods.EncryptPassword(_configuration["PassPhrase:Key"],name);
                var item = applicantService.GetByName(name);
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
        [HttpGet("{emailid}")]
        [AllowAnonymous]
        public string CheckApplicantEmailExists(string emailid)
        {
            string checkExits = string.Empty;
            try
            {
                emailid = CommonMethods.EncryptPassword(_configuration["PassPhrase:Key"], emailid);
                var item = applicantService.GetByEmail(emailid);
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
        [HttpPost, ActionName("InsertOrUpdateWithResponse")]
        [AllowAnonymous]
        public ApplicantDto InsertOrUpdateWithResponse([FromBody] LoginRequestDto request)
        {
            try
            {
                var applicantdata = new ApplicantDto()
                {
                    ApplicantId = request.Id,
                    Applicantname = CommonMethods.EncryptPassword(_configuration["PassPhrase:Key"], request.name),
                    RoleId =request.RoleId,
                    Applicantemail = CommonMethods.EncryptPassword(_configuration["PassPhrase:Key"], request.email),
                    ApplicantGivenName = "",
                    Applicantpassword = CommonMethods.EncryptPassword(_configuration["PassPhrase:Key"], request.Password),
                    ApplicantPhone = request.Phone,
                    ApplicantSurname = "",
                    Enforce2Fa = request.Enforce2Fa
                };

                var result = applicantService.InsertOrUpdate(applicantdata);
                result.Applicantpassword = CommonMethods.DecryptPassword(_configuration["PassPhrase:Key"], result.Applicantpassword);
                result.Applicantname = CommonMethods.DecryptPassword(_configuration["PassPhrase:Key"], result.Applicantname);
                result.Applicantemail = CommonMethods.DecryptPassword(_configuration["PassPhrase:Key"], result.Applicantemail);

                return result;
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
                values.Applicantpassword = CommonMethods.EncryptPassword(_configuration["PassPhrase:Key"], values.Applicantpassword);
                values.Applicantname = CommonMethods.EncryptPassword(_configuration["PassPhrase:Key"], values.Applicantname);
                values.Applicantemail = CommonMethods.EncryptPassword(_configuration["PassPhrase:Key"], values.Applicantemail);

                return applicantService.InsertOrUpdate(values);

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
                return applicantService.Delete(id);
            }
            catch (Exception ex)
            {
              
            }
            return false;
        }

    }
}
