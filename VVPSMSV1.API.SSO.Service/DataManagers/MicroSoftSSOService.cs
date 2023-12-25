using AutoMapper;
using Microsoft.Extensions.Configuration;
using VVPSMSV1.API.SSO.Domain.Models;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMSV1.API.SSO.Service.DataManagers
{
    public class MicroSoftSSOService : IMicroSoftSSOService<MicroSoftConfigurationDto>
    {
        private IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;
        public MicroSoftSSOService(IMapper mapper, IConfiguration configuration, IStorageService storageService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _storageService = storageService;
        }

        public MicroSoftConfigurationDto? GetByDomain(string domainName)
        {
            using (var dbContext = new Vvpsmsdbv1Context())
            {
                var result = dbContext.GoogleConfigurations?.FirstOrDefault(e => e.DomainName.Equals(domainName));
                return _mapper.Map<MicroSoftConfigurationDto>(result);
            }
        }
    }
}
