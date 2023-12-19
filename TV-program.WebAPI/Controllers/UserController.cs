using TV_program.BL.Users;
using TV_program.WebAPI.Controllers.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TV_program.BL.Users.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;

namespace TV_program.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUsersProvider _usersProvider;
        private readonly IUsersManager _usersManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserController(IUsersProvider usersProvider, IUsersManager usersManager, IMapper mapper, ILogger logger)
        {
            _usersManager = usersManager;
            _usersProvider = usersProvider;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet] //users/
        public IActionResult GetAllUsers()
        {
            var users = _usersProvider.GetUsers();
            return Ok(new UsersListResponce()
            {
                Users = users.ToList()
            });
        }

        [HttpGet]
        [Route("filter")] //users/filter?filter.Surname = "Тагаев"&filter.PhoneNumber = "89205463432"
        public IActionResult GetFilteredUsers([FromQuery] UsersFilter filter)
        {
            var users = _usersProvider.GetUsers(_mapper.Map<UserModelFilter>(filter));
            return Ok(new UsersListResponce()
            {
                Users = users.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")] //users/{id}
        public IActionResult GetUserInfo([FromRoute] Guid id)
        {
            try
            {
                var users = _usersProvider.GetUserInfo(id);
                return Ok(users);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            try
            {
                var users = _usersManager.CreateUser(_mapper.Map<CreateUserModel>(request));
                return Ok(users);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUserInfo([FromRoute] Guid id, UpdateUserRequest request)
        {
            try
            {
                var users = _usersManager.UpdateUser(id, _mapper.Map<UpdateUserModel>(request));
                return Ok(users);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            try
            {
                _usersManager.DeleteUser(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);

            }
        }
    }
}
