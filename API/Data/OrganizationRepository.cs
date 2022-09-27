using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public OrganizationRepository(DataContext context , IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<OrganizationDto>> GetOrganizationsAsync()
        {
            return await  _context.Organizations
                .ProjectTo<OrganizationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<Organization> GetOrganizationByIdAsync(int id)
        {
            return await _context.Organizations.FindAsync(id);

        }

        public async Task<Organization> GetOrganizationByOrgnameAsync(string orgname)
        {
            return await _context.Organizations
            .Include(p => p.Photos).
                SingleOrDefaultAsync(x => x.Name == orgname);  
                
        // var organization = await _context.Organizations.Where(o=>o.Name.ToLower().Contains(orgname.ToLower())).ToListAsync();
        // return  organization;
        }
        

        public async Task<bool> SaveAllAsync()
        {
        return await _context.SaveChangesAsync() > 0;

        }

        public void Update(Organization organization)
        {
            _context.Entry(organization).State = EntityState.Modified;
        }

    }
}