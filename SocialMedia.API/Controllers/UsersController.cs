using BLL.Users.Abstract;
using DTO.Users;
using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region fields

        private readonly IUserService _userService;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes the new instance os <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">User service instance.</param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region operations

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<UserDTO> usersDto = await _userService.Get();
            if (usersDto is null)
            {
                return NotFound();
            }

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            UserDTO userDto = await _userService.Get(id);
            if (userDto is null)
            {
                return NotFound();
            }
            
            return Ok(userDto);
        }

        #endregion
    }
}
