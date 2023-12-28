using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMSV1.API.SSO.Domain.Models;
using VVPSMSV1.API.SSO.Models.Enums;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMSV1.API.SSO.Service.DataManagers
{
    public class ApplicantService : IApplicantService<ApplicantDto>
    {
        private IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;
        public ApplicantService(IMapper mapper, IConfiguration configuration, IStorageService storageService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _storageService = storageService;
        }
        public bool Delete(int id)
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                var entity = dbContext.Applicants.FirstOrDefault(e => e.ApplicantId == id);
                if (entity != null)
                {
                    dbContext.Applicants.Remove(entity);
                    dbContext.SaveChanges();
                }
                return true;
            }
        }
        public ApplicantDto? GetByName(string applicantName)
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                var result = dbContext.Applicants?.FirstOrDefault(e => e.Applicantname.Equals(applicantName));
                return _mapper.Map<ApplicantDto>(result);
            }
        }
        public List<ApplicantDto> GetAll()
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                var result = dbContext.Applicants.ToList();
                return _mapper.Map<List<ApplicantDto>>(result);
            }
        }

        public ApplicantDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                var result = dbContext.Applicants?.FirstOrDefault(e => e.ApplicantId.Equals(id));
                return _mapper.Map<ApplicantDto>(result);
            }
        }

        

        public ApplicantDto InsertOrUpdate(ApplicantDto entity)
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                if (entity != null)
                {

                    if (entity.ApplicantId != 0)
                    {
                        var dbentity = dbContext.Applicants.FirstOrDefault(e => e.ApplicantId == entity.ApplicantId);
                        if (dbentity != null && dbentity.Applicantpassword == entity.Applicantpassword)
                        {

                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<Applicant>(entity));
                        }
                        else
                        {
                            throw new Exception(ErrorCode.MissingData.ToString());
                        }
                    }
                    else
                    {
                        var existingUser = dbContext.Applicants.FirstOrDefault(x => x.Applicantname.Equals(entity.Applicantname));
                        if (existingUser != null)
                        {
                            // throw new Exception(ErrorCode.AlreadyExist.ToString());
                            return _mapper.Map<ApplicantDto>(existingUser);
                        }
                        else
                        {
                            dbContext.Applicants.Add(_mapper.Map<Applicant>(entity));
                        }

                    }
                    dbContext.SaveChanges();

                }
                return _mapper.Map<ApplicantDto>(dbContext.Applicants.AsNoTracking().First(x => x.Applicantname == entity.Applicantname));
                
            }
        }

        bool IGenericService<ApplicantDto>.InsertOrUpdate(ApplicantDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
