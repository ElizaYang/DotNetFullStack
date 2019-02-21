using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FriendsApp.API.Data;
using FriendsApp.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriendsApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")] //api/users
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserOpRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserOpRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();

            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }
    }
}