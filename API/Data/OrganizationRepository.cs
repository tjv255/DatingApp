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

        public async Task<IEnumerable<Organization>> GetOrganizationsAsync()
        {
            return await  _context.Organizations
                .Include(p => p.Photos)
                .Include(m => m.Members)
                .Include(j => j.Jobs)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrganizationDto>> GetCompactOrganizationsAsync()
        {
            return await _context.Organizations
                .ProjectTo<OrganizationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<OrganizationDto> GetOrganizationByIdAsyncDto(int id)
        {
            return await _context.Organizations
                    .Include(p => p.Photos)
                    .Include(m => m.Members)
                    .Include(j => j.Jobs)
                    .SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<OrganizationDto> GetCompactOrganizationByIdAsync(int id)
        {
            return await _context.Organizations
                    .Include(p => p.Photos)
                    .Include(m => m.Members)
                    .Include(j => j.Jobs)
                    .ProjectTo<OrganizationDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Organization> GetOrganizationByOrgnameAsync(string orgname)
        {
            return await _context.Organizations
                    .Include(p => p.Photos)
                    .Include(m => m.Members)
                    .Include(j => j.Jobs)
                    .SingleOrDefaultAsync(x => x.Name == orgname);  
                
        // var organization = await _context.Organizations.Where(o=>o.Name.ToLower().Contains(orgname.ToLower())).ToListAsync();
        // return  organization;
        }        

        public async Task<bool> SaveAllAsync()
        {
        return await _context.SaveChangesAsync() > 0;
        }


        public void Add(Organization organization)
        {
            _context.Organizations.Add(organization);
        }

        public void Update(Organization organization)
        {
            _context.Entry(organization).State = EntityState.Modified;
        }

        public async Task<PagedList<OrgMemberDto>> GetMembersByOrganizationIdAsync(UserParams userParams, int id)
        {
            var org = _context.Organizations.SingleOrDefault(o => o.Id == id);
            var query = _context.Users.Where(u => u.Affiliation.Contains(org));
            query = query.Where(u => u.UserName != userParams.CurrentUsername);

            query = userParams.OrderBy switch
            {
                "created" => query.OrderByDescending(u => u.Created),
                _ => query.OrderByDescending(u => u.LastActive)
            };

            return await PagedList<OrgMemberDto>.CreateAsync(
                    query.ProjectTo<OrgMemberDto>(_mapper.ConfigurationProvider).AsNoTracking(),
                    userParams.PageNumber,
                    userParams.PageSize
                );
        }

        public async Task<PagedList<JobDto>> GetJobsByOrganizationIdAsync(JobParams jobParams, int id)
        {
            var org = _context.Organizations.SingleOrDefault(o => o.Id == id);
            var query = _context.Jobs.AsQueryable();

            query = jobParams.OrderBy switch
            {
                "deadline" => query.OrderByDescending(u => u.Deadline),
                _ => query.OrderByDescending(u => u.LastUpdated)
            };

            return await PagedList<JobDto>.CreateAsync(
                    query.ProjectTo<JobDto>(_mapper.ConfigurationProvider).AsNoTracking(),
                    jobParams.PageNumber,
                    jobParams.PageSize
                );
        }
    }
}