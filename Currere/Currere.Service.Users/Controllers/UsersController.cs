using Currere.Service.Users.Model;
using Currere.Service.Users.Services;
using Currere.Shared.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Currere.Service.Users.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(IUsersService service) : ControllerBase
    {
        private readonly IUsersService _service = service;

        [AllowAnonymous]
        [HttpPost, Route("exists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ExistsAsync(
            [FromBody] User user)
        {
            var result = await _service.FindAsync(user.EmailAddress, user.Password);

            return result is null ? NotFound() : Ok(result);
        }

        [Authorize]
        [HttpGet, Route("find/identity/{identity}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> FindAsync(
            [FromRoute] int identity)
        {
            var result = await _service.FindAsync(identity);

            return result is null ? NotFound() : Ok(result);
        }

        [AllowAnonymous]
        [HttpPost, Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateUserDTO user)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            if (await _service.FindAsync(user.EmailAddress) is not null)
                return BadRequest("This email address is already registered.");

            var result = await _service.CreateAsync(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                Password = user.Password,
                RoleID = 1,
                Locked = false,
                LastLoginDateUTC = DateTime.UtcNow,
                RegistrationDateUTC = DateTime.UtcNow
            });

            return result is null ? StatusCode(StatusCodes.Status500InternalServerError) : Ok(result);
        }
    }
}
