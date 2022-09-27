using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IOrganizationRepository
    {

    void Update(Organization organization);
    Task<bool> SaveAllAsync();

    Task<IEnumerable<OrganizationDto>> GetOrganizationsAsync();
    Task<Organization> GetOrganizationByOrgnameAsync(string orgname);
    Task<Organization> GetOrganizationByIdAsync(int id);
    }
}