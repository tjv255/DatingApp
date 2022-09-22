using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
    public class JobsController : BaseApiController
    {
    private readonly DataContext _context;
        
//     private readonly IJobRepository _jobRepository;
//     private readonly IMapper _mapper;
// IJobRepository jobRepository, IMapper mapper
    public JobsController(DataContext context)
    {
      _context = context;
    //   _jobRepository = jobRepository;
    //   _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<JobRepository>> GetJobs(){
        var jobs = _context.Jobs.ToList();
    }

    }
}