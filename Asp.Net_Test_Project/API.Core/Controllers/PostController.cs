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
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;
        public PostController(IPostService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllPosts();
            if (result.Any())
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status204NoContent);

        }
        [HttpGet("{postId}")]
        public async Task<IActionResult> Get(int postId)
        {
            var result = await _service.GetPost(postId);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status204NoContent);

        }

        [HttpGet("GetPostWithCommentsAndVotes/{postPage=1}/{commentPage=1}")]
        public async Task<IActionResult> GetPostWithCommentsAndVotes(int postPage,int commentPage)
        {
            var result = await _service.GetPostWithCommentsAndVotes(postPage, commentPage);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status204NoContent);

        }
        [HttpPost]
        public async Task<IActionResult> Post(Posts post)
        {
            var result = await _service.AddPost(post);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status204NoContent);

        }
        [HttpPut]
        public async Task<IActionResult> Put(Posts post)
        {
            var result = await _service.UpdatePost(post);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status204NoContent);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Posts post)
        {
            var result = await _service.RemovePost(post);
            if (result)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status204NoContent);

        }
    }
}
