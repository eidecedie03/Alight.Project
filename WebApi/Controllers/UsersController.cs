using Application.Interfaces;
using Application.Models.Request;
using Application.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUnitOfWork unitOfWork, IUserService userService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var response = await _userService.AddUser(request);

            return CreatedAtAction("Get", new { response.Id }, response);
        }

        /// <summary>
        /// The requirements says, create only 3 endpoints so I assumed that upsert and delete operation of employment will happen in this route. 
        /// Passing a user request without employment would simply delete all the employments for that specific user
        /// Employment will be created if the data doesn't have ID and update will happen if it has an ID.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            var response = await _userService.UpdateUser(request);

            return CreatedAtAction("Get", new { response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _userService.GetUser(id);

            return Ok(response);
        }
    }
}