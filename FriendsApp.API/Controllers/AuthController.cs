using System.Threading.Tasks;
using FriendsApp.API.Data;
using FriendsApp.API.Dtos;
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
        [HttpGet]
        public string Get()
        {
            return "hello from auth";
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            // validation request
            
            // get username to lowercase
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if (await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exist");
            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
            
            return StatusCode(201); // http 201: created
        }
    }
}