using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IJobSaveRepository
    {
        Task<JobSave> GetSavedJob(int sourceUserId, int savedJobId);
        Task<AppUser> GetUserWithSavedJobs(int id);

        Task<IEnumerable<JobSaveDto>>  GetSavedJobs(string predicate, int userId);

        
    }
}