using AutoMapper;
using VVPSMSV1.API.SSO.Domain.Models;
using VVPSMSV1.API.SSO.Models.ModelsDto;

namespace VVPSMSV1.API.SSO.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<AdmissionForm, AdmissionFormDto>().ReverseMap();
            //CreateMap<StudentInfoDetail, StudentInfoDetailDto>().ReverseMap();
            //CreateMap<FamilyOrGuardianInfoDetail, FamilyOrGuardianInfoDetailDto>().ReverseMap();
            //CreateMap<SiblingInfo, SiblingInfoDto>().ReverseMap();
            //CreateMap<EmergencyContactDetail, EmergencyContactDetailDto>().ReverseMap();
            //CreateMap<PreviousSchoolDetail, PreviousSchoolDetailDto>().ReverseMap();
            //CreateMap<StudentHealthInfoDetail, StudentHealthInfoDetailDto>().ReverseMap();
            //CreateMap<StudentIllnessDetail, StudentIllnessDetailDto>().ReverseMap();
            //CreateMap<AdmissionEnquiryDetail, AdmissionEnquiryDetailDto>().ReverseMap();
            //CreateMap<AdmissionDocument, AdmissionDocumentDto>().ReverseMap();
            //CreateMap<TransportDetail, TransportDetailDto>().ReverseMap();
            ////Archival Mapping
            //CreateMap<ArAdmissionForm, ArAdmissionFormDto>().ReverseMap();
            //CreateMap<ArStudentInfoDetail, ArStudentInfoDetailDto>().ReverseMap();
            //CreateMap<ArFamilyOrGuardianInfoDetail, ArFamilyOrGuardianInfoDetailDto>().ReverseMap();
            //CreateMap<ArSiblingInfo, ArSiblingInfoDto>().ReverseMap();
            //CreateMap<ArEmergencyContactDetail, ArEmergencyContactDetailDto>().ReverseMap();
            //CreateMap<ArPreviousSchoolDetail, ArPreviousSchoolDetailDto>().ReverseMap();
            //CreateMap<ArStudentHealthInfoDetail, ArStudentHealthInfoDetailDto>().ReverseMap();
            //CreateMap<ArStudentIllnessDetail, ArStudentIllnessDetailDto>().ReverseMap();
            //CreateMap<ArAdmissionEnquiryDetail, ArAdmissionEnquiryDetailDto>().ReverseMap();
            //CreateMap<ArAdmissionDocument, ArAdmissionDocumentDto>().ReverseMap();
            //CreateMap<ArTransportDetail, ArTransportDetailDto>().ReverseMap();

            //CreateMap<MstSchool, MstSchoolDto>().ReverseMap();
            //CreateMap<MstSchoolGrade, MstSchoolGradeDto>().ReverseMap();
            //CreateMap<MstClass, MstClassDto>().ReverseMap();
            //CreateMap<MstAcademicYear, MstAcademicYearDto>().ReverseMap();
            //CreateMap<MstSchoolStream, MstSchoolStreamDto>().ReverseMap();
            //CreateMap<MstUserRole, MstUserRoleDto>().ReverseMap();
            CreateMap<MstUser, MstUserDto>().ReverseMap();
            CreateMap<AzureBlobConfiguration, AzureBlobConfigurationDto>().ReverseMap();
            CreateMap<GoogleConfiguration, GoogleConfigurationDto>().ReverseMap();
            CreateMap<MicroSoftConfiguration, MicroSoftConfigurationDto>().ReverseMap();
            CreateMap<MstPermission, MstPermissionDto>().ReverseMap();
            CreateMap<MstRoleType, MstRoleTypeDto>().ReverseMap();
            CreateMap<MstUserRole, MstUserRoleDto>().ReverseMap();
            CreateMap<RolePermissionsMapping, RolePermissionsMappingDto>().ReverseMap();
            //CreateMap<MstDocumentType, MstDocumentTypesDto>().ReverseMap();
            //CreateMap<MstEnquiryQuestionDetail, MstEnquiryQuestionDetailDto>().ReverseMap();
            //CreateMap<Log, LogsDto>().ReverseMap();
            //CreateMap<GoogleConfiguration, GoogleConfigurationDto>().ReverseMap();
            //CreateMap<MicroSoftConfiguration, MicroSoftConfigurationDto>().ReverseMap();
            //CreateMap<AzureBlobConfiguration, AzureBlobConfigurationDto>().ReverseMap();

        }
    }
}
