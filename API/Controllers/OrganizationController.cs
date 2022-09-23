using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    public class OrganizationController : BaseApiController
    {

        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        public OrganizationController(  IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;

        }
        
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<OrganizationDto>>>GetOrganizations()
        {
            var organizations =  await _organizationRepository.GetOrganizationsAsync();
            var organizationsToReturn = _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
    
            return Ok(organizationsToReturn);


        }

    
}
}
