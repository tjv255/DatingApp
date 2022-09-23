using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    public class OrganizationsController : BaseApiController
    {

        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        public OrganizationsController(  IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;

        }
        [AllowAnonymous]
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<OrganizationDto>>>GetOrganizations()
        {
            var organizations =  await _organizationRepository.GetOrganizationsAsync();
            var organizationsToReturn = _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
    
            return Ok(organizationsToReturn);


        }

    
}
}
