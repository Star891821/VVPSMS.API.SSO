using AutoMapper;
using VVPSMSV1.API.SSO.Domain.Models;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMSV1.API.SSO.Service.DataManagers
{
    public class RolePermissionMappingService : IGenericService<RolePermissionsMappingDto>
    {
        private IMapper _mapper;
        public RolePermissionMappingService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public bool Delete(int id)
        {
            using (var dbContext = new Vvpsmsdbv1Context())
            {
                var entity = dbContext.RolePermissionsMappings.FirstOrDefault(e => e.MappingId == id);
                if (entity != null)
                {
                    dbContext.RolePermissionsMappings.Remove(entity);
                    dbContext.SaveChanges();
                }

                return true;
            }

        }

        public List<RolePermissionsMappingDto> GetAll()
        {
            using (var dbContext = new Vvpsmsdbv1Context())
            {
                var result = dbContext.RolePermissionsMappings.ToList();
                return _mapper.Map<List<RolePermissionsMappingDto>>(result);
            }
        }

        public RolePermissionsMappingDto? GetById(int id)
        {
            using (var dbContext = new Vvpsmsdbv1Context())
            {
                var result = dbContext.RolePermissionsMappings?.FirstOrDefault(e => e.MappingId.Equals(id));
                return _mapper.Map<RolePermissionsMappingDto>(result);
            }
        }

        public bool InsertOrUpdate(RolePermissionsMappingDto entity)
        {
            using (var dbContext = new Vvpsmsdbv1Context())
            {
                if (entity != null)
                {
                    if (entity.MappingId != 0)
                    {
                        var dbentity = dbContext.RolePermissionsMappings.FirstOrDefault(e => e.MappingId == entity.MappingId);

                        if (dbentity != null)
                        {
                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<RolePermissionsMapping>(entity));
                        }
                    }
                    else
                    {
                        dbContext.RolePermissionsMappings.Add(_mapper.Map<RolePermissionsMapping>(entity));
                    }
                    dbContext.SaveChanges();
                }
                return true;
            }
        }

    }
}
