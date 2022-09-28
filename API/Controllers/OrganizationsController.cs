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
        public readonly IPhotoService _photoService;

        public OrganizationsController(IUserRepository userRepository, IOrganizationRepository organizationRepository,
                                        IMapper mapper, IPhotoService photoService)

        {
            _photoService = photoService;
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

    //     [HttpPost("add-photo")]
    //     public async Task<ActionResult<OrgPhotoDto>>AddPhoto(IFormFile file, int id)
    //     {
    //     var organization = await _organizationRepository.GetOrganizationByIdAsync(id); 
    //     var result = await _photoService.AddPhotoAsync(file);

    //     if (result.Error != null) return BadRequest(result.Error.Message);
    //     var photo = new OrgPhoto
    //     {
    //     Url = result.SecureUrl.AbsoluteUri,
    //     PublicId = result.PublicId
    //     };

    //     if (organization.Photos.Count == 0)
    //     {
    //     photo.IsMain = true;
    //     }

    //     organization.Photos.Add(photo);
    //     if (await _organizationRepository.SaveAllAsync())
    //     {
    //   //  return CreatedAtRoute("GetOrganization", new { orgname = organization.Name },          
    //         return   _mapper.Map<OrgPhotoDto>(photo);
    //     }
    //     return BadRequest("Problem addding photo");
    // }


        [HttpPost("add")]
        public async Task<ActionResult<OrganizationDto>> AddNewOrganization(OrganizationDto organizationDto)       
        {

        var organization = _mapper.Map<Organization>(organizationDto);

        _organizationRepository.Add(organization);

        if (await _organizationRepository.SaveAllAsync()) 
            return NoContent();
        return BadRequest("Failed to add user");
        
    }
        [Authorize]
        [HttpPost("add-member/{id}")]
        public async Task<ActionResult<OrganizationDto>> AddMember(MemberDto memberDto, int id)
        {

            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
            AppUser returnUser = _mapper.Map<AppUser>(memberDto);
            Organization org = await _organizationRepository.GetOrganizationByIdAsync(id);

            org.Members.Add(returnUser);

            if (await _organizationRepository.SaveAllAsync())
                return NoContent();

            return BadRequest("Failed to add member");

        }



    }
}
