using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IJobRepository
    {
       // void Update(Job job);
		Task<bool> SaveAllAsync();
		//Task<List<Job>> GetJobsAsync();
		Task<Job> GetJobByIdAsync(int id);
		//Task<bool> DeleteJobAsync(int id);
        //Task<List<Job>> GetJobsByPosterIdAsync(int id);
    }
}