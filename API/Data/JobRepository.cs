using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class JobRepository : IJobRepository
  {
    private readonly DataContext _context;

    public JobRepository(DataContext context){
      _context = context;
        
    }
    // public async Task<bool> DeleteJob(int id)
    // {
    //   throw new NotImplementedException();
    // }
 
    public async Task<Job> GetJobByIdAsync(int id)
    {
      return await _context.Jobs.FindAsync(id);
    }

    // public async Task<IEnumerable<Job>> GetJobByTitleAsync(string title){
    //   var jobs = await_context.Jobs.Select(e=>e.Title == title).ToListAsync();
    //   return jobs;
    // }

    public async Task<IEnumerable<Job>> GetJobsAsync()
    {
      return await _context.Jobs.ToListAsync();
    }

    public Task<JobDto> GetMemberJobAsync()
    {
      //return await _context.Jobs.Where()
      throw new NotImplementedException();
    }

    public Task<IEnumerable<JobDto>> GetMemberJobsAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    // public void Update(Job job)
    // {
    //   _context.Entry(Jobs).State = EntityState.Modified;
    //   _context.SaveChangesAsync();
    // }
    
    // public async Task<List<Job>> GetJobsByPosterIdAsync(int id){
    //   return await _context.Jobs.Where(a=> a.JobPosterId==id).ToListAsync();
    // }
  }
}