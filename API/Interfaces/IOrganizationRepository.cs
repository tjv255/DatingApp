using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IOrganizationRepository
    {

    void Update(Organization organization);
    void Add(Organization organization);
    Task<bool> SaveAllAsync();

    Task<IEnumerable<Organization>> GetOrganizationsAsync();
    Task<IEnumerable<OrganizationDto>> GetCompactOrganizationsAsync();
    Task<Organization> GetOrganizationByOrgnameAsync(string orgname);
    Task<Organization> GetOrganizationByIdAsync(int id);
    Task<OrganizationDto> GetCompactOrganizationByIdAsync(int id);
    Task<PagedList<OrgMemberDto>> GetMembersByOrganizationIdAsync(UserParams userParams, int id);
    Task<PagedList<JobDto>> GetJobsByOrganizationIdAsync(JobParams jobParams, int id);
    }
}