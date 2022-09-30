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
    }
}