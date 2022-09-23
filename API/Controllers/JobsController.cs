using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class JobsController : BaseApiController
    {
    private readonly DataContext _context;
        
    private readonly IJobRepository _jobRepository;
//     private readonly IMapper _mapper;

    public JobsController(IJobRepository jobRepository)
    {
      _jobRepository = jobRepository;
    //   _mapper = mapper;
    }

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Job>>> GetJobs(){
    //     return Ok(await _jobRepository.GetJobsAsync());
    // }

    [HttpGet("{id}")]
    public async Task<ActionResult<Job>> GetJobById(int id){
        return await _jobRepository.GetJobByIdAsync(id);
    }

    }
}