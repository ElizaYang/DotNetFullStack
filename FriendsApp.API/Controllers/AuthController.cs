using System.Threading.Tasks;
using FriendsApp.API.Data;
using FriendsApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FriendsApp.API.Controllers
{
    [Route("api/[controller]")]//api/Auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            this._repo = repo;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            // validation request
            
            // get username to lowercase
            username = username.ToLower();
            if (await _repo.UserExists(username))
                return BadRequest("Username already exist");
            var userToCreate = new User
            {
                Username = username
            };

            var createdUser = await _repo.Register(userToCreate, password);
            
            return StatusCode(201); // http 201: created
        }
    }
}