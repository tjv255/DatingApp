using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IJobRepository
    {
        void Update(Job job);
		Task<bool> SaveAllAsync();
		Task<IEnumerable<Job>> GetJobsAsync();
		Task<Job> GetJobByIdAsync(int id);
		Task<bool> DeleteJob(int id);
        
    }
}