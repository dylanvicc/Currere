using Currere.Service.Posts.Model;
using Currere.Service.Posts.Services;
using Currere.Shared.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Currere.Service.Posts.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PostsController(IPostsService service) : ControllerBase
    {
        private readonly IPostsService _service = service;

        [HttpPost, Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreatePostDTO post)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var identity = User.FindFirst(ClaimTypes.PrimarySid)?.Value;

            if (int.TryParse(identity, out int _identity))
            {
                var result = await _service.CreateAsync(new Post
                {
                    UserID = _identity,
                    Title = post.Title,
                    TextContent = post.TextContent,
                    CreationDateUTC = DateTime.UtcNow,
                    TimesFlagged = 0,
                    DisplayPriority = 0,
                });

                return result is null ? StatusCode(StatusCodes.Status500InternalServerError) : Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet, Route("find")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> FindAsync()
        {
            return Ok(await _service.FindAsync());
        }

        [HttpGet, Route("find/identity/{identity}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindAsync(
            [FromRoute] int identity)
        {
            var result = await _service.FindAsync(identity);

            return result is null ? StatusCode(StatusCodes.Status500InternalServerError) : Ok(result);
        }
    }
}
