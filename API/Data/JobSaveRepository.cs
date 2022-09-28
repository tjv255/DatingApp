using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class JobSaveRepository : IJobSaveRepository
  {
    private readonly DataContext _context;
    public JobSaveRepository(DataContext context){
        _context = context;

    }
    public async Task<JobSave> GetSavedJob(int savedUserId, int jbId)
    {
        return await _context.SavedJobs.FindAsync(savedUserId,jbId);
    }

    public Task<IEnumerable<JobSaveDto>> GetSavedJobs(string predicate, int userId)
    {
     // return await _context.SavedJobs
     // .Include(x=>x.)
        throw new NotImplementedException();
    }

    public Task<AppUser> GetUserWithSavedJobs(int id)
    {
      throw new NotImplementedException();
    }
  }
}