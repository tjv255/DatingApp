using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class JobsController : BaseApiController
    {        
    private readonly IJobRepository _jobRepository;
     private readonly IMapper _mapper;

    public JobsController(IJobRepository jobRepository, IMapper mapper)
    {
      _jobRepository = jobRepository;
       _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobDto>>> GetJobs(){
        var jobs = await _jobRepository.GetJobsAsync();
        var jobstoreturn = _mapper.Map<IEnumerable<JobDto>>(jobs);
        return Ok(jobstoreturn);
       // return Ok(await _context.Jobs.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<JobDto>> GetJobById(int id){
        var job = await _jobRepository.GetJobByIdAsync(id);
        return _mapper.Map<JobDto>(job);
    }

    }
}