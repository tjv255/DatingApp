using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{

   // [Authorize]
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
            var organizations = await _organizationRepository.GetCompactOrganizationsAsync();
            return Ok(organizations);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationDto>> GetOrganizationsById(int id)
        {
            return await _organizationRepository.GetOrganizationByIdAsyncDto(id);
        }

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

        [HttpPost("add-photo")]
        public async Task<ActionResult<OrgPhotoDto>>AddPhoto(IFormFile file, int id)
    {
        var organization = await _organizationRepository.GetOrganizationByIdAsync(id); 
        var result = await _photoService.AddPhotoAsync(file);

        if (result.Error != null) return BadRequest(result.Error.Message);
        var photo = new OrgPhoto
        {
        Url = result.SecureUrl.AbsoluteUri,
        PublicId = result.PublicId
        };

        if (organization.Photos.Count == 0)
        {
        photo.IsMain = true;
        }

        organization.Photos.Add(photo);
        if (await _organizationRepository.SaveAllAsync())
        {
            return   _mapper.Map<OrgPhotoDto>(photo);
        }
        return BadRequest("Problem addding photo");
    }

        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int photoId, int id)
    {
        var organization = await _organizationRepository.GetOrganizationByIdAsync(id); 

        var photo = organization.Photos.FirstOrDefault(x => x.Id == photoId);

        if (photo.IsMain) return BadRequest("This is already your main photo");

        var currentMain = organization.Photos.FirstOrDefault(x => x.IsMain);
        if (currentMain != null) currentMain.IsMain = false;
        photo.IsMain = true;

        if (await _organizationRepository.SaveAllAsync()) return NoContent();

        return BadRequest("Failed to set main photo");
    }


        [HttpPost("add")]
        public async Task<ActionResult<OrganizationDto>> AddNewOrganization(OrganizationDto organizationDto)       
        {

        var organization = _mapper.Map<Organization>(organizationDto);

        _organizationRepository.Add(organization);

        if (await _organizationRepository.SaveAllAsync()) 
            return NoContent();
        return BadRequest("Failed to add user");
        
    }
        

        [HttpPost("add-member/{id}")]
        public async Task<ActionResult<Organization>> AddMember(string username, int id)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            _mapper.Map<AppUser>(user);
            var org = await _organizationRepository.GetOrganizationByIdAsync(id);
            org.Members.Add(user);
            if (await _organizationRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to add member");

        }

        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId, int id)
        {
        var organization = await _organizationRepository.GetOrganizationByIdAsync(id);

        var photo = organization.Photos.FirstOrDefault(x => x.Id == photoId);

        if (photo == null) return NotFound();

        if (photo.IsMain) return BadRequest("You cannot delete your main photo");

        if (photo.PublicId != null)
        {
        var result = await _photoService.DeletePhotoAsync(photo.PublicId);
        if (result.Error != null) return BadRequest(result.Error.Message);
        }

        organization.Photos.Remove(photo);

        if (await _userRepository.SaveAllAsync()) return Ok();

        return BadRequest("Failed to delete the photo");
    }





    }
}
