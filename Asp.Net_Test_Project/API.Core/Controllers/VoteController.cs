using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Model;
using API.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _service;
        public VoteController(IVoteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Votes votes)
        {
            var result = await _service.GiveVote(votes);
            if (result)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status204NoContent);

        }
    }
}