using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class OrgLikesRepository : IOrgLikesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public OrgLikesRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<OrgLike> GetOrganizationLike(int OrgId, int likedUserId)
        {
            return await _context.OrgLikes.FindAsync(OrgId, likedUserId);
        }

        public async Task<Organization> GetOrganizationWithLikes(int orgId)
        {
            return await _context.Organizations
                .Include(x => x.LikedByUser)
                .FirstOrDefaultAsync(x => x.Id ==orgId);
        }

        public async Task<IEnumerable<OrgLikeDto>> GetOrganizationLikes(int orgId)
        {
            // var organizations = _context.Organizations.OrderBy(u => u.Name).AsQueryable();
            //var orgLikes = _context.OrgLikes.AsQueryable();


            // orgLikes = orgLikes.Where(like => like.OrgId == orgId);
            // organizations = orgLikes.Select(like => like.Org);

            // return await organizations.Select(organization => new OrgLikeDto
            // {

            //     OrgId = organization.Id,
            //     Name = organization.Name,
            //     Introduction = organization.Introduction,
            //     PhotoUrl = organization.Photos.FirstOrDefault(p => p.IsMain).Url,
            //     Established = organization.Established,
            //     Created = organization.Created,
            //     LastUpdated = organization.LastUpdated,
            //     City = organization.City,
            //     ProvinceOrState = organization.ProvinceOrState,
            //     Country = organization.Country

            // }).ToListAsync();

            return await _context.OrgLikes
                            .Include(o => o.Org)
                            .Include(o => o.LikedUser)
                            .ProjectTo<OrgLikeDto>(_mapper.ConfigurationProvider)
                            .ToListAsync();

        }

    }
}