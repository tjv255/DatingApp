using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class JobSaveController : BaseApiController
    {
    private readonly IUserRepository _userRepository;
    private readonly IJobRepository _jobRepository;
    private readonly IJobSaveRepository _jobSaveRepository;
        public JobSaveController(IUserRepository userRepository,IJobRepository jobRepository, IJobSaveRepository jobSaveRepository)
        {
            _jobSaveRepository = jobSaveRepository;
            _jobRepository = jobRepository;
            _userRepository = userRepository;

        }

        //user to save job by id - api/JobSave/id
        [HttpPost("{id}")]
        public async Task<ActionResult> SaveJob(int id){
            var sourceUserId = User.GetUserId();
            var savedJob = await _jobRepository.GetJobByIdAsync(id);
            var savedJobUsername = await _jobRepository.GetUserByUsernameAsync(savedJob.JobPoster.UserName);
            var sourceUser = await _jobSaveRepository.GetUserWithSavedJobs(sourceUserId);

            if(savedJob==null) return NotFound();

            // implement check - job poster cannot save their own posted job
            if(sourceUserId==id) return BadRequest("You cannot save your posted Job");

            var jobSaved = await _jobSaveRepository.GetSavedJob(sourceUserId, savedJob.Id);

            if(jobSaved != null) BadRequest("You have already saved this job.");

            jobSaved = new JobSave
            {
                SavedUserId = sourceUserId,
                JobId = savedJob.Id
                
            };

            sourceUser.SavedJobs.Add(jobSaved);
            if(await _userRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to save Job.");

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobSaveDto>>> GetSavedJobs(string predicate)
        {
            var jobs = await _jobSaveRepository.GetSavedJobs(predicate, User.GetUserId());
            return Ok(jobs);
        }

        
    }
}