using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IOrganizationRepository
    {

  //  void Update(AppUser organization);
    Task<bool> SaveAllAsync();

    Task<IEnumerable<OrganizationDto>> GetOrganizationsAsync();
    Task<Organization> GetOrganizationByOrganizationameAsync(string organizationname);
    Task<Organization> GetOrganizationByIdAsync(int id);
    }
}