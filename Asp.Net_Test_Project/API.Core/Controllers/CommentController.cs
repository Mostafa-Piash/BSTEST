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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;
        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllComments();
            if (result.Any())
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status204NoContent);

        }
        [HttpGet("{commentId}")]
        public async Task<IActionResult> Get(int commentId)
        {
            var result = await _service.GetComment(commentId);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status204NoContent);

        }
        [HttpPost]
        public async Task<IActionResult> Comment(Comments comment)
        {
            var result = await _service.AddComment(comment);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status204NoContent);

        }
        [HttpPut]
        public async Task<IActionResult> Put(Comments comment)
        {
            var result = await _service.UpdateComment(comment);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status204NoContent);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Comments comment)
        {
            var result = await _service.RemoveComment(comment);
            if (result)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status204NoContent);

        }
    }
}
