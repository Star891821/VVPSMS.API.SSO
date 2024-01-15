using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VVPSMSV1.API.SSO.Domain.Models;
using VVPSMSV1.API.SSO.Models.Enums;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMSV1.API.SSO.Service.DataManagers
{
    public class MstUserRoleService : IUserRoleService<MstUserRoleDto>
    {
        private IMapper _mapper;
        public MstUserRoleService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public MstUserRoleDto InsertOrUpdateWithResponse(MstUserRoleDto entity)
        {
            using (var dbContext = new VvpsmsdbSsoContext())
            {
                if (entity != null)
                {

                    if (entity.RoleId != 0)
                    {
                        var dbentity = dbContext.MstUserRoles.FirstOrDefault(e => e.RoleId == entity.RoleId);
                        if (dbentity != null)
                        {

                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<MstUserRole>(entity));
                        }
                        else
                        {
                            throw new Exception(ErrorCode.MissingData.ToString());
                        }
                    }
                    else
                    {
                        var existingPermission = dbContext.MstUserRoles.FirstOrDefault(x => x.RoleName.Equals(entity.RoleName));
                        if (existingPermission != null)
                        {
                            return _mapper.Map<MstUserRoleDto>(existingPermission);
                        }
                        else
                        {
                            dbContext.MstUserRoles.Add(_mapper.Map<MstUserRole>(entity));
                        }

                    }
                    dbContext.SaveChanges();
                }
                return _mapper.Map<MstUserRoleDto>(dbContext.MstUserRoles.AsNoTracking().First(x => x.RoleName == entity.RoleName));


            }
        }
        public MstUserRoleDto? GetByName(string roleName)
        {
            using (var dbContext = new VvpsmsdbSsoContext())
            {
                var result = dbContext.MstUserRoles?.FirstOrDefault(e => e.RoleName.Equals(roleName));
                return _mapper.Map<MstUserRoleDto>(result);
            }
        }

        public bool Delete(int id)
        {
            using (var dbContext = new VvpsmsdbSsoContext())
            {
                var entity = dbContext.MstUserRoles.FirstOrDefault(e => e.RoleId == id);

                if (entity != null)
                {
                    var roleTypeEntity = dbContext.MstRoleTypes.FirstOrDefault(e => e.RoletypeId == entity.RoletypeId);
                    if (roleTypeEntity != null)
                    {
                        if (roleTypeEntity.RoletypeName != "Seeded")
                        {
                            dbContext.MstUserRoles.Remove(entity);
                            dbContext.SaveChanges();
                            
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

        }

        public List<MstUserRoleDto> GetAll()
        {
            using (var dbContext = new VvpsmsdbSsoContext())
            {
                var result = dbContext.MstUserRoles.ToList();
                return _mapper.Map<List<MstUserRoleDto>>(result);
            }
        }

        public MstUserRoleDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsdbSsoContext())
            {
                var result = dbContext.MstUserRoles?.FirstOrDefault(e => e.RoleId.Equals(id));
                return _mapper.Map<MstUserRoleDto>(result);
            }
        }

        public bool InsertOrUpdate(MstUserRoleDto entity)
        {
            using (var dbContext = new VvpsmsdbSsoContext())
            {
                if (entity != null)
                {
                    if (entity.RoleId != 0)
                    {
                        var dbentity = dbContext.MstUserRoles.FirstOrDefault(e => e.RoleId == entity.RoleId);

                        if (dbentity != null)
                        {
                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<MstUserRole>(entity));
                        }
                    }
                    else
                    {
                        dbContext.MstUserRoles.Add(_mapper.Map<MstUserRole>(entity));
                    }
                    dbContext.SaveChanges();
                }
                return true;
            }
        }
    }
}
