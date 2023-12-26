
using AutoMapper;
using Microsoft.Extensions.Configuration;
using VVPSMSV1.API.SSO.Domain.Models;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMSV1.API.SSO.Service.DataManagers
{
    public class AzureSSOService : IAzureSSOService<AzureBlobConfigurationDto>
    {
        private IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;
        public AzureSSOService(IMapper mapper, IConfiguration configuration, IStorageService storageService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _storageService = storageService;
        }

        public AzureBlobConfigurationDto? GetByDomain(string domainName)
        {
            using (var dbContext = new VvpsmsSsoContext())
            {
                var result = dbContext.AzureBlobConfigurations?.FirstOrDefault(e => e.DomainName.Equals(domainName));
                return _mapper.Map<AzureBlobConfigurationDto>(result);
            }
        }
    }
}
