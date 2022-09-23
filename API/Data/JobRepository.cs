using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;

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

    // public async Task<List<Job>> GetJobsAsync()
    // {
    //   return await _context.Jobs.ToListAsync();
    // }

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