using Currere.Service.Authentication.Models;
using Currere.Service.Authentication.Services;
using Currere.Shared.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Currere.Service.Authentication.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class AuthenticationController(IJWTAuthenticationService service, HttpClient client) : ControllerBase
    {
        private readonly IJWTAuthenticationService _service = service;
        private readonly HttpClient _client = client;

        [HttpPost, Route("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AuthenticateAsync(
            [FromBody] LoginCredentials credentials)
        {
            HttpResponseMessage request = await _client.PostAsync("http://currere-service-users:8080/Users/exists",
                new StringContent(JsonSerializer.Serialize(new User
                {
                    EmailAddress = credentials.EmailAddress,
                    Password = credentials.Password
                }), Encoding.UTF8, "application/json"));

            if (request.IsSuccessStatusCode == false)
                return Unauthorized();

            var user = await request.Content.ReadFromJsonAsync<User>();

            if (user is null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            var token = _service.GenerateToken(user);

            if (string.IsNullOrEmpty(token))
                return StatusCode(StatusCodes.Status500InternalServerError);

            var response = new AuthenticatedResponse()
            {
                Token = _service.GenerateToken(user),
            };

            return Ok(response);
        }
    }
}
