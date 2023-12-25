using AutoMapper;
using VVPSMSV1.API.SSO.Domain.Models;
using VVPSMSV1.API.SSO.Models.ModelsDto;

namespace VVPSMSV1.API.SSO.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MstUser, MstUserDto>().ReverseMap();
            CreateMap<AzureBlobConfiguration, AzureBlobConfigurationDto>().ReverseMap();
            CreateMap<GoogleConfiguration, GoogleConfigurationDto>().ReverseMap();
            CreateMap<MicroSoftConfiguration, MicroSoftConfigurationDto>().ReverseMap();
            CreateMap<MstPermission, MstPermissionDto>().ReverseMap();
            CreateMap<MstRoleType, MstRoleTypeDto>().ReverseMap();
            CreateMap<MstUserRole, MstUserRoleDto>().ReverseMap();
            CreateMap<RolePermissionsMapping, RolePermissionsMappingDto>().ReverseMap();
            CreateMap<Applicant, ApplicantDto>().ReverseMap();
        }
    }
}
