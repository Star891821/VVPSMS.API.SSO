using AutoMapper;
using Microsoft.Extensions.Configuration;
using VVPSMSV1.API.SSO.Domain.Models;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMSV1.API.SSO.Service.DataManagers
{
    public class GoogleSSOService : IGoogleSSOService<GoogleConfigurationDto>
    {
        private IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;
        public GoogleSSOService(IMapper mapper, IConfiguration configuration, IStorageService storageService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _storageService = storageService;
        }

        public GoogleConfigurationDto? GetByDomain(string domainName)
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                var result = dbContext.GoogleConfigurations?.FirstOrDefault(e => e.DomainName.Equals(domainName));
                return _mapper.Map<GoogleConfigurationDto>(result);
            }
        }
    }
}
