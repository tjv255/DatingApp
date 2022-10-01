using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class JobRepository : IJobRepository
  {
    private readonly DataContext _context;
        private readonly IMapper _mapper;

        public JobRepository(DataContext context, IMapper mapper){
      _context = context;
            _mapper = mapper;
        } 
    public async Task<Job> GetJobByIdAsync(int id)
    {
      return await _context.Jobs
      .Include(j => j.JobPoster)
      .SingleOrDefaultAsync(x => x.Id == id);
    }

     public async Task<PagedList<JobDto>> GetJobsByTitleAsync(JobParams jobParams, string title)
        {
      var jobs = _context.Jobs.Where(t=>t.Title.ToLower().Contains(title.ToLower())).AsQueryable();
      var query = jobs.Where(j => j.Title != jobParams.CurrentName);

            query = jobParams.OrderBy switch
            {
                "alphabetical" => query.OrderBy(o => o.Title),
                "deadline" => query.OrderByDescending(o => o.Deadline),
                _ => query.OrderByDescending(o => o.LastUpdated)
            };

            return await PagedList<JobDto>.CreateAsync(
                query.ProjectTo<JobDto>(_mapper.ConfigurationProvider).AsNoTracking(),
                jobParams.PageNumber,
                jobParams.PageSize
            );
    }

    public async Task<PagedList<JobDto>> GetJobsAsync(JobParams jobParams)
    {
            var jobs = _context.Jobs.AsQueryable();
            var query = jobs.Where(j => j.Title != jobParams.CurrentName);

            query = jobParams.OrderBy switch
            {
                "alphabetical" => query.OrderBy(o => o.Title),
                "deadline" => query.OrderByDescending(o => o.Deadline),
                _ => query.OrderByDescending(o => o.LastUpdated)
            };

            return await PagedList<JobDto>.CreateAsync(
                query.ProjectTo<JobDto>(_mapper.ConfigurationProvider).AsNoTracking(),
                jobParams.PageNumber,
                jobParams.PageSize
            );
    }

    public Task<JobDto> GetMemberJobAsync()
    {
      //return await _context.Jobs.Where()
      throw new NotImplementedException();
    }

    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public void Update(Job job)
    {
      _context.Entry(job).State = EntityState.Modified;
    }

    public void Add(Job job)
        {
            _context.Jobs.Add(job);
        }

    public async Task<AppUser> GetUserByUsernameAsync(string username)
    {
      return await _context.Users
      .Include(p=>p.Photos).SingleOrDefaultAsync(x=>x.UserName == username);
    }
    
    public async Task<PagedList<JobDto>> GetJobsByPosterIdAsync(JobParams jobParams, int id)
        {
            var jobs = _context.Jobs.Where(j => j.JobPoster.Id == id).AsQueryable();
            var query = jobs.Where(j => j.Title != jobParams.CurrentName);

            query = jobParams.OrderBy switch
            {
                "alphabetical" => query.OrderBy(o => o.Title),
                "deadline" => query.OrderByDescending(o => o.Deadline),
                _ => query.OrderByDescending(o => o.LastUpdated)
            };

            return await PagedList<JobDto>.CreateAsync(
                query.ProjectTo<JobDto>(_mapper.ConfigurationProvider).AsNoTracking(),
                jobParams.PageNumber,
                jobParams.PageSize
            );
    }

        public Task<PagedList<JobDto>> GetMemberJobsAsync(JobParams jobParams)
        {
            throw new NotImplementedException();
        }
    }
}
