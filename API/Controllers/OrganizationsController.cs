using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    public class OrganizationsController : BaseApiController
    {
        private readonly IUserRepository _userRepository;

        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        public OrganizationsController(IUserRepository userRepository, IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
            _mapper = mapper;

        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationDto>>> GetOrganizations()
        {
            var organizations = await _organizationRepository.GetOrganizationsAsync();

            return Ok(organizations);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganizationsById(int id)

        {
            return await _organizationRepository.GetOrganizationByIdAsync(id);
        }

        // [HttpGet("{orgname}")]
        // public async Task<ActionResult<Organization>> GetOrganizationByName(string orgName)
        // {

        //     return  await _organizationRepository.GetOrganizationByOrgnameAsync(orgName);

        // }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateOrganization( OrganizationUpdateDto organizationUpdateDto , int id)
        {

            var organization = await _organizationRepository.GetOrganizationByIdAsync(id); 

            _mapper.Map(organizationUpdateDto , organization);

            _organizationRepository.Update(organization);


            if (await _organizationRepository.SaveAllAsync()) 
            
            return NoContent();

            return BadRequest("Failed to update user");
        }


        [HttpPost("add")]

        public async Task<ActionResult<OrganizationDto>> AddNewOrganizationById(OrganizationDto organizationDto)
        
        {

        var organization = _mapper.Map<Organization>(organizationDto);

        _organizationRepository.Add(organization);

        if (await _organizationRepository.SaveAllAsync()) 
            return NoContent();

        return BadRequest("Failed to add user");
    }



    }
}
