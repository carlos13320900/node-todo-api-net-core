using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using node_todo_api_net_core.Models;
using node_todo_api_net_core.Repositories;

namespace node_todo_api_net_core.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) => _userRepository = userRepository;

        /// <summary>
        /// GET
        /// </summary>

        #region snippet_GetAll
        [HttpGet]
        public async Task<IEnumerable<User>> GetAll() => await _userRepository.GetAll();

        #endregion

        #region snippet_GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            User user = await _userRepository.GetById(id);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }
        #endregion
    }
}