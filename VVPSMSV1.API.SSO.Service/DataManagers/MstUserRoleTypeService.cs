using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class MstUserRoleTypeService : IUserRoleType<MstRoleTypeDto>
    {
        private IMapper _mapper;
        public MstUserRoleTypeService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public MstRoleTypeDto InsertOrUpdateWithResponse(MstRoleTypeDto entity)
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                if (entity != null)
                {

                    if (entity.RoletypeId != 0)
                    {
                        var dbentity = dbContext.MstRoleTypes.FirstOrDefault(e => e.RoletypeId == entity.RoletypeId);
                        if (dbentity != null)
                        {

                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<MstRoleType>(entity));
                        }
                        else
                        {
                            throw new Exception(ErrorCode.MissingData.ToString());
                        }
                    }
                    else
                    {
                        var existingPermission = dbContext.MstRoleTypes.FirstOrDefault(x => x.RoletypeName.Equals(entity.RoletypeName));
                        if (existingPermission != null)
                        {
                            return _mapper.Map<MstRoleTypeDto>(existingPermission);
                        }
                        else
                        {
                            dbContext.MstRoleTypes.Add(_mapper.Map<MstRoleType>(entity));
                        }

                    }
                    dbContext.SaveChanges();
                }
                return _mapper.Map<MstRoleTypeDto>(dbContext.MstRoleTypes.AsNoTracking().First(x => x.RoletypeName == entity.RoletypeName));


            }
        }
        public MstRoleTypeDto? GetByName(string roleName)
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                var result = dbContext.MstRoleTypes?.FirstOrDefault(e => e.RoletypeName.Equals(roleName));
                return _mapper.Map<MstRoleTypeDto>(result);
            }
        }

        public bool Delete(int id)
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                var entity = dbContext.MstRoleTypes.FirstOrDefault(e => e.RoletypeId == id);

                if (entity != null)
                {
                    dbContext.MstRoleTypes.Remove(entity);
                    dbContext.SaveChanges();

                }
                return true;
            }

        }

        public List<MstRoleTypeDto> GetAll()
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                var result = dbContext.MstRoleTypes.ToList();
                return _mapper.Map<List<MstRoleTypeDto>>(result);
            }
        }

        public MstRoleTypeDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                var result = dbContext.MstRoleTypes?.FirstOrDefault(e => e.RoletypeId.Equals(id));
                return _mapper.Map<MstRoleTypeDto>(result);
            }
        }

        public bool InsertOrUpdate(MstRoleTypeDto entity)
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                if (entity != null)
                {
                    if (entity.RoletypeId != 0)
                    {
                        var dbentity = dbContext.MstRoleTypes.FirstOrDefault(e => e.RoletypeId == entity.RoletypeId);

                        if (dbentity != null)
                        {
                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<MstRoleType>(entity));
                        }
                    }
                    else
                    {
                        dbContext.MstRoleTypes.Add(_mapper.Map<MstRoleType>(entity));
                    }
                    dbContext.SaveChanges();
                }
                return true;
            }
        }

    }
}
